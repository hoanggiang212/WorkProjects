USE TKTDSX
GO

-- ================================================
-- PROC GET SAN LUONG ONLINE THEO TUNG CAP DO / MODE
-- ================================================
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[GetSanLuongOnline]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetSanLuongOnline]
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Hoang Giang>
-- Create date: <16 / 06 / 2017>
-- Description:	<Get San Luong>
-- =============================================
CREATE PROCEDURE GetSanLuongOnline
	@SystemId		VARCHAR(20),
	@mode			VARCHAR(20),
	@capdo			VARCHAR(20),
	@giatricapdo	VARCHAR(20),
	@congdoan		VARCHAR(20),
	@ngay			VARCHAR(10)
AS
BEGIN
DECLARE @where NVARCHAR(MAX)
DECLARE @command NVARCHAR(MAX)

SET NOCOUNT ON;

-- Define table source
IF @mode = 'CHUYEN'
	SET @command = N'SELECT tb2.TenChuyen as BoPhan,tb3.TenCongDoan, tb1.SoLuongLD, tb1.NangSuat, tb1.GioLamViec, tb1.KeHoachGio, '
				+ ' tb1.KeHoachNgay, tb1.ThucHienNgay, tb1.ChenhLech, tb1.DatKeHoach, '
				+ ' (tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ) As Truoc8h, ' +
				+ ' tb1.Gio08, tb1.Gio09, tb1.Gio10,tb1.Gio11,tb1.Gio12,tb1.Gio13,tb1.Gio14,tb1.Gio15,tb1.Gio16,tb1.Gio17,tb1.Gio18,'
				+ ' (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23) As Sau18h, tb2.isNoColor ' +
				+ ' FROM dbo.ZEMP_SL_CH AS tb1 INNER JOIN ZEMP_CH AS '
				+ ' tb2 ON tb1.IdChuyen = tb2.IdChuyen AND tb1.SystemId = tb2.SystemId INNER JOIN dbo.ZEMP_CONGDOAN '
				+ ' AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '		
ELSE IF @mode = 'WRKCT'
	SET @command = N'SELECT tb2.TenWrkct as BoPhan,tb3.TenCongDoan, tb1.SoLuongLD, tb1.NangSuat, tb1.GioLamViec, tb1.KeHoachGio, '
					+ ' tb1.KeHoachNgay, tb1.ThucHienNgay, tb1.ChenhLech, tb1.DatKeHoach, '
					+ ' (tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ) As Truoc8h, ' +
					+ ' tb1.Gio08, tb1.Gio09, tb1.Gio10,tb1.Gio11,tb1.Gio12,tb1.Gio13,tb1.Gio14,tb1.Gio15,tb1.Gio16,tb1.Gio17,tb1.Gio18,'
					+ ' (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23) As Sau18h, ' + '''' + ' '  + '''' + ' as isNoColor '
					+ 'FROM dbo.ZEMP_SL_WC AS tb1 '
					+ ' INNER JOIN dbo.ZEMP_WC AS tb2 ON tb1.Wrkct = tb2.Wrkct AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '

ELSE IF @mode = 'KHVUC'
	SET @command = N'SELECT tb2.TenKhuVuc as BoPhan,tb3.TenCongDoan, tb1.SoLuongLD, tb1.NangSuat, tb1.GioLamViec, tb1.KeHoachGio, '
					+ ' tb1.KeHoachNgay, tb1.ThucHienNgay, tb1.ChenhLech, tb1.DatKeHoach, '
					+ ' (tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ) As Truoc8h, ' +
					+ ' tb1.Gio08, tb1.Gio09, tb1.Gio10,tb1.Gio11,tb1.Gio12,tb1.Gio13,tb1.Gio14,tb1.Gio15,tb1.Gio16,tb1.Gio17,tb1.Gio18,'
					+ ' (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23) As Sau18h, ' + '''' + ' '  + '''' + ' as isNoColor '
					+ ' FROM dbo.ZEMP_SL_KV AS tb1 '
					+ ' INNER JOIN dbo.ZEMP_KV AS tb2 ON tb1.KhuVuc = tb2.KhuVuc AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '
ELSE IF @mode = 'NGANH'
	SET @command = N'SELECT tb2.Nganh as BoPhan,tb3.TenCongDoan, tb1.SoLuongLD, tb1.NangSuat, tb1.GioLamViec, tb1.KeHoachGio, '
					+ ' tb1.KeHoachNgay, tb1.ThucHienNgay, tb1.ChenhLech, tb1.DatKeHoach, '
					+ ' (tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ) As Truoc8h, ' +
					+ ' tb1.Gio08, tb1.Gio09, tb1.Gio10,tb1.Gio11,tb1.Gio12,tb1.Gio13,tb1.Gio14,tb1.Gio15,tb1.Gio16,tb1.Gio17,tb1.Gio18,'
					+ ' (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23) As Sau18h, ' + '''' + ' '  + '''' + ' as isNoColor '
					+ ' FROM dbo.ZEMP_SL_NG AS tb1 '
					+ 'INNER JOIN dbo.ZEMP_KV AS tb2 ON tb1.Nganh = tb2.Nganh AND tb1.SystemId = tb2.SystemId '
					+ 'INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '

--define condition
IF @capdo = 'WRKCT'
	SET @where = ' tb1.SystemId = ' + '''' + @SystemId + '''' + ' AND  tb2.Wrkct = ';

ELSE IF @capdo = 'KHVUC'
	SET @where = ' tb1.SystemId = ' + '''' + @SystemId + '''' + ' AND tb2.KhuVuc = ';

ELSE IF @capdo = 'NGANH'
	SET @where = ' tb1.SystemId = ' + '''' + @SystemId + '''' + ' AND tb2.Nganh = ';

IF @congdoan = 'ALL'
	SET @command = @command + ' WHERE ' + @where  + '''' + CAST(@giatricapdo AS VARCHAR) + '''' + ' AND tb1.Ngay = ' + '''' + CAST( @ngay  AS VARCHAR) + '''';
ELSE
	SET @command = @command + ' WHERE ' + @where  + '''' + CAST(@giatricapdo AS VARCHAR) + '''' +  ' AND tb1.CongDoan = ' + '''' + CAST( @congdoan AS VARCHAR) + '''' + ' AND tb1.Ngay = ' + '''' + CAST( @ngay  AS VARCHAR) + '''';

EXECUTE sys.sp_executesql @command
END
GO
--TEST
EXEC GetSanLuongOnline '900P01', 'WRKCT', 'KHVUC', 'KV01', 'ALL', '2017-06-15'

select * from zemp_sl_wc

-- ================================================
-- GET LIST CAP DO
-- ================================================
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[GetListCapDo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetListCapDo]
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Hoang Giang>
-- Create date: <16 / 06 / 2017>
-- Description:	<Get List Cap Do>
-- =============================================
CREATE PROCEDURE GetListCapDo
	@SystemId varchar(20),
	@username VARCHAR(20)	
AS
BEGIN
DECLARE @command NVARCHAR(MAX);
SET FMTONLY OFF
SET NOCOUNT ON;
SET @command = 'SELECT distinct(tb1.CapDo) as value, tb2.DienGiai as text from ZEMP_PQ as tb1 
				INNER JOIN zemp_cf_mode as tb2
				ON tb1.SystemId = tb2.SystemId AND tb1.CapDo = tb2.Mode WHERE tb1.SystemId = ' 
				+ '''' + @SystemId + '''' + ' AND tb1.username = ' + '''' + @username + '''';

	EXECUTE sys.sp_executesql @command
END
GO
--TEST
--exec GetListCapDo '900P01', 'giangnh'

-- ================================================
-- GET LIST GIA TRI CAP DO
-- ================================================
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[GetListGiaTriCapDo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetListGiaTriCapDo]
END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetListGiaTriCapDo
	@SystemId	VARCHAR(20),
	@username	VARCHAR(20),
	@capdo		VARCHAR(20)
AS
BEGIN
DECLARE @command NVARCHAR(MAX);
SET FMTONLY OFF
SET NOCOUNT ON;

if @capdo = 'WRKCT'
	SET @command = 'SELECT TB2.Wrkct as value, TB2.TenWrkct as text FROM ZEMP_PQ AS TB1 
					INNER JOIN ZEMP_WC AS TB2 ON TB1.GiaTriCapDo = TB2.Wrkct AND TB1.SystemId = TB2.SystemId
					WHERE TB1.SystemId = ' + '''' + @SystemId + '''' + 'AND TB1.Username =' + '''' + @username + '''';
else if @capdo = 'KHVUC'
	SET @command = 'SELECT TB2.KhuVuc as value, TB2.TenKhuVuc as text FROM ZEMP_PQ AS TB1 
					INNER JOIN ZEMP_KV AS TB2 ON TB1.GiaTriCapDo = TB2.KhuVuc AND TB1.SystemId = TB2.SystemId
					WHERE TB1.SystemId = ' + '''' + @SystemId + '''' + 'AND TB1.Username =' + '''' + @username + '''';
else if @capdo = 'NGANH'
	SET @command = 'SELECT TB2.Nganh as value, TB2.TenNganh as text FROM ZEMP_PQ AS TB1 
					INNER JOIN ZEMP_NG AS TB2 ON TB1.GiaTriCapDo = TB2.Nganh AND TB1.SystemId = TB2.SystemId
					WHERE TB1.SystemId = ' + '''' + @SystemId + '''' + 'AND TB1.Username =' + '''' + @username + '''';
	EXECUTE sys.sp_executesql @command
END
GO

--TEST
--exec GetListGiaTriCapDo '900P01', 'GIANGNH', 'WRKCT'
--exec GetListGiaTriCapDo '900P01', 'GIANGNH', 'KHVUC'
--exec GetListGiaTriCapDo '900P01', 'GIANGNH', 'NGANH'


-- ================================================
-- GET LIST CONG DOAN CHO LIVEBOARD
-- ================================================
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[GetCongDoanLiveboard]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetCongDoanLiveboard]
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetCongDoanLiveboard
	@SystemId VARCHAR(20)
AS
BEGIN
DECLARE @command NVARCHAR(MAX);
SET FMTONLY OFF
SET NOCOUNT ON;

	SET @command = 'SELECT CongDoan as value, TenCongDoan as text FROM ZEMP_CONGDOAN WHERE SystemId = '
					+ '''' + @SystemId + '''' +
					' ORDER BY Stt ASC';

	EXECUTE sys.sp_executesql @command
END
GO
--TEST
--EXEC GetCongDoanLiveboard '900P01'


-- ================================================
-- GET LIST MODE VIEW 
-- ================================================
IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[GetModeView]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetModeView]
END


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetModeView
	@SystemId VARCHAR(20)
AS
BEGIN
DECLARE @command NVARCHAR(MAX);
SET FMTONLY OFF
SET NOCOUNT ON;

	SET @command = 'select Mode as value, DienGiai as text from ZEMP_CF_MODE WHERE SystemId = '
					+ '''' + @SystemId + '''' +
					' ORDER BY STT ASC';

	EXECUTE sys.sp_executesql @command
END
GO
--TEST
--exec GetModeView '900P01'
