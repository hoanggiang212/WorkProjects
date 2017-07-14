--LAY THONG TIN CHI PHI SAN XUAT
--exec GetChiPhiSanXuat '900P01', 'WRKCT', 'WC01', 'ALL', '2017-06-01', '2017-06-30'
--exec GetChiPhiSanXuat '900P01', 'KHUVUV', 'KV01', 'ALL', '2017-06-01', '2017-06-30'
--exec GetChiPhiSanXuat '900P01', 'NGANH', 'GIAY', 'SMAY', '2017-06-01', '2017-06-30'


-- GET KE HOACH THUC HIEN THEO CAP DO / CONG DOAN
GetKeHoachThucHien '900P01', 'WRKCT', 'WC01', 'ALL', '2017-06-30', '2017-07-14'
go


--EXEC GetThongKeLaoDong '900P01', 'wrkct', 'WC01', 'smay', '2017-07-07', '2017-07-14'

use TKTDSX
go

Update zemp_sl_wc 
set ngay = '2017-07-14'
where ngay = '2017-07-13'

Update zemp_TK_wc 
set ngay = '2017-07-14'
where ngay = '2017-07-13'

