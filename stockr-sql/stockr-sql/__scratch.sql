use stockr


;
with ss as (
	select
		q.symbol
		, min(q.latestPrice) [min]
		, max(q.latestPrice) [max]
		, AVG(q.latestPrice) [ave]
	from Quote q
		join Symbols s
			on q.symbol = s.symbol
	where CAST(q.SystemTime AS DATE) = CAST(GETDATE() AS DATE)
		and s.SymbolType = 'cs'
		and calculationPrice != 'previousclose'
	group by q.symbol
)
select *
	, [ave] / (([min] + [max]) / 2)
	, ([max] - [min]) / [max]
from ss
order by 5 desc


;
with ss as (
	select
		q.symbol
		, min(q.latestPrice) [min]
		, max(q.latestPrice) [max]
	from Quote q
		join Symbols s
			on q.symbol = s.symbol
	where CAST(q.SystemTime AS DATE) = CAST(GETDATE() AS DATE)
		and s.SymbolType = 'cs'
		and calculationPrice != 'previousclose'
	group by q.symbol
)
select *
	, ([max] - [min]) / [min]
from ss
order by 4 desc
