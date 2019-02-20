use stockr

;
WITH Dates as
(
	SELECT cast('2019-01-01' as date) as CalendarDate
	UNION ALL 
	SELECT dateadd(day , 1, CalendarDate) AS CalendarDate
	FROM Dates
	WHERE dateadd (day, 1, CalendarDate) < '2050-01-01'
)
SELECT dt.CalendarDate
	, DATEPART(yy, q.SystemTime) yy
	, DATEPART(mm, q.SystemTime) mm
	, DATEPART(dd, q.SystemTime) dd
	, DATEPART(hh, q.SystemTime) hh
	, COUNT(q.SystemTime)
FROM Dates dt
	LEFT JOIN dbo.Quote q
		ON CAST(dt.CalendarDate AS DATE) = CAST(q.SystemTime AS DATE)
WHERE dt.CalendarDate BETWEEN '2019-01-27' AND DATEADD(dd, 1, GETDATE())
GROUP BY dt.CalendarDate
	, DATEPART(yy, q.SystemTime)
	, DATEPART(mm, q.SystemTime)
	, DATEPART(dd, q.SystemTime)
	, DATEPART(hh, q.SystemTime)
ORDER BY 1 desc, 2 desc, 3 desc, 4 desc, 5 desc
OPTION (MAXRECURSION 32767);