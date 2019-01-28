use stockr

--select * from Symbols where SymbolType = 'cs' and isEnabled = 1

with durr as (
	select top 100 Symbol 
	from Symbols 
	where SymbolType = 'cs' and isEnabled = 1
)
select STRING_AGG(Symbol, ',') from durr

select * from dbo.vSymbols