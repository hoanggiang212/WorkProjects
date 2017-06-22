select * from ZEMP_SL_WC
where Ngay = '2017-06-22'
and Wrkct = 'WC01'

select tb1.STATUS, count(tb1.status) as 'SLCH' 
from (select IdChuyen, 'STATUS' =  CASE	WHEN DatKeHoach < 95 then 'RED'
	WHEN DatKeHoach >= 95 and DatKeHoach < 100 THEN 'YELLOW'
	ELSE 'GREEN'
	END
	from zemp_sl_ch
	where Ngay = '2017-06-22' 
	) as tb1
group by status