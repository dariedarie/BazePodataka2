alter procedure online_igra
as
declare prenos_cursor cursor
for 
Select KompanijaZaIgreNaSrecus.NazKmp
from KompanijaZaIgreNaSrecus inner join OnlineSajts on KompanijaZaIgreNaSrecus.IdKmp = OnlineSajts.KompanijaZaIgreNaSrecuIdKmp 
inner join OnlineIgraNaSrecus on OnlineSajts.IdSajta=OnlineIgraNaSrecus .OnlineSajtIdSajta


declare @temp varchar(30)

begin
	open prenos_cursor
	while @@FETCH_STATUS = 0
		begin
			fetch next from prenos_cursor
			into @temp;
			print @temp;
		
	end
		close prenos_cursor
		deallocate prenos_cursor
end

exec online_igra