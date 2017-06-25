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
	SET @command = N'SELECT ISNULL(tb2.TenChuyen, SPACE(1)) as BoPhan,	ISNULL(tb3.TenCongDoan,SPACE(1)) as TenCongDoan, ISNULL(tb1.SoLuongLD, 0) as SoLuongLD, '
					+ ' ISNULL( tb1.NangSuat , 0 ) as NangSuat,			ISNULL( tb1.GioLamViec, 0 ) as GioLamViec,		ISNULL( tb1.KeHoachGio, 0 ) as KeHoachGio, '
					+ '	ISNULL( tb1.KeHoachNgay, 0 ) as KeHoachNgay,	ISNULL( tb1.ThucHienNgay, 0 ) as ThucHienNgay,	ISNULL( tb1.ChenhLech, 0 ) as ChenhLech, '
					+ '	ISNULL( tb1.DatKeHoach, 0 ) as DatKeHoach,		ISNULL((tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ),0) As Truoc8h, ' 
					+ ' ISNULL(tb1.Gio08, 0 ) as Gio08,					ISNULL( tb1.Gio09, 0 ) as Gio09,				ISNULL( tb1.Gio10, 0 ) as Gio10, '
					+ ' ISNULL(tb1.Gio11, 0 ) as Gio11,					ISNULL(tb1.Gio12, 0 ) as Gio12,					ISNULL(tb1.Gio13, 0 ) as Gio13, '
					+ ' ISNULL(tb1.Gio14, 0 ) as Gio14,					ISNULL(tb1.Gio15, 0 ) as Gio15,					ISNULL(tb1.Gio16, 0 ) as Gio16, ' 
					+ ' ISNULL(tb1.Gio17, 0 ) as Gio17,					ISNULL(tb1.Gio18, 0 ) as Gio18, '
					+ ' ISNULL( (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23),0) As Sau18h,				ISNULL(tb2.isNoColor, SPACE(1) ) as IsNoColor' +
					+ ' FROM dbo.ZEMP_SL_CH AS tb1 INNER JOIN ZEMP_CH AS tb2 ON tb1.IdChuyen = tb2.IdChuyen AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '		
ELSE IF @mode = 'WRKCT'
	SET @command = N'SELECT ISNULL(tb2.TenWrkct, SPACE(1)) as BoPhan,	ISNULL(tb3.TenCongDoan,SPACE(1)) as TenCongDoan, ISNULL(tb1.SoLuongLD, 0) as SoLuongLD, '
					+ ' ISNULL( tb1.NangSuat , 0 ) as NangSuat,			ISNULL( tb1.GioLamViec, 0 ) as GioLamViec,		ISNULL( tb1.KeHoachGio, 0 ) as KeHoachGio, '
					+ '	ISNULL( tb1.KeHoachNgay, 0 ) as KeHoachNgay,	ISNULL( tb1.ThucHienNgay, 0 ) as ThucHienNgay,	ISNULL( tb1.ChenhLech, 0 ) as ChenhLech, '
					+ '	ISNULL( tb1.DatKeHoach, 0 ) as DatKeHoach,		ISNULL((tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ),0) As Truoc8h, ' 
					+ ' ISNULL(tb1.Gio08, 0 ) as Gio08,					ISNULL( tb1.Gio09, 0 ) as Gio09,				ISNULL( tb1.Gio10, 0 ) as Gio10, '
					+ ' ISNULL(tb1.Gio11, 0 ) as Gio11,					ISNULL(tb1.Gio12, 0 ) as Gio12,					ISNULL(tb1.Gio13, 0 ) as Gio13, '
					+ ' ISNULL(tb1.Gio14, 0 ) as Gio14,					ISNULL(tb1.Gio15, 0 ) as Gio15,					ISNULL(tb1.Gio16, 0 ) as Gio16, ' 
					+ ' ISNULL(tb1.Gio17, 0 ) as Gio17,					ISNULL(tb1.Gio18, 0 ) as Gio18, '
					+ ' ISNULL( (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23),0) As Sau18h,				SPACE(1) as IsNoColor' +
					+ ' FROM dbo.ZEMP_SL_WC AS tb1 INNER JOIN dbo.ZEMP_WC AS tb2 ON tb1.Wrkct = tb2.Wrkct AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '

ELSE IF @mode = 'KHVUC'
	SET @command = N'SELECT ISNULL(tb2.TenKhuVuc, SPACE(1)) as BoPhan,	ISNULL(tb3.TenCongDoan,SPACE(1)) as TenCongDoan, ISNULL(tb1.SoLuongLD, 0) as SoLuongLD, '
					+ ' ISNULL( tb1.NangSuat , 0 ) as NangSuat,			ISNULL( tb1.GioLamViec, 0 ) as GioLamViec,		ISNULL( tb1.KeHoachGio, 0 ) as KeHoachGio, '
					+ '	ISNULL( tb1.KeHoachNgay, 0 ) as KeHoachNgay,	ISNULL( tb1.ThucHienNgay, 0 ) as ThucHienNgay,	ISNULL( tb1.ChenhLech, 0 ) as ChenhLech, '
					+ '	ISNULL( tb1.DatKeHoach, 0 ) as DatKeHoach,		ISNULL((tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ),0) As Truoc8h, ' 
					+ ' ISNULL(tb1.Gio08, 0 ) as Gio08,					ISNULL( tb1.Gio09, 0 ) as Gio09,				ISNULL( tb1.Gio10, 0 ) as Gio10, '
					+ ' ISNULL(tb1.Gio11, 0 ) as Gio11,					ISNULL(tb1.Gio12, 0 ) as Gio12,					ISNULL(tb1.Gio13, 0 ) as Gio13, '
					+ ' ISNULL(tb1.Gio14, 0 ) as Gio14,					ISNULL(tb1.Gio15, 0 ) as Gio15,					ISNULL(tb1.Gio16, 0 ) as Gio16, ' 
					+ ' ISNULL(tb1.Gio17, 0 ) as Gio17,					ISNULL(tb1.Gio18, 0 ) as Gio18, '
					+ ' ISNULL( (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23),0) As Sau18h,				SPACE(1) as IsNoColor' +
					+ ' FROM dbo.ZEMP_SL_KV AS tb1 INNER JOIN dbo.ZEMP_KV AS tb2 ON tb1.KhuVuc = tb2.KhuVuc AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '
ELSE IF @mode = 'NGANH'

	SET @command = N'SELECT ISNULL(tb2.TenNganh, SPACE(1)) as BoPhan,	ISNULL(tb3.TenCongDoan,SPACE(1)) as TenCongDoan, ISNULL(tb1.SoLuongLD, 0) as SoLuongLD, '
					+ ' ISNULL( tb1.NangSuat , 0 ) as NangSuat,			ISNULL( tb1.GioLamViec, 0 ) as GioLamViec,		ISNULL( tb1.KeHoachGio, 0 ) as KeHoachGio, '
					+ '	ISNULL( tb1.KeHoachNgay, 0 ) as KeHoachNgay,	ISNULL( tb1.ThucHienNgay, 0 ) as ThucHienNgay,	ISNULL( tb1.ChenhLech, 0 ) as ChenhLech, '
					+ '	ISNULL( tb1.DatKeHoach, 0 ) as DatKeHoach,		ISNULL((tb1.Gio01 + tb1.Gio02 + tb1.Gio03 + tb1.Gio04 + tb1.Gio05 + tb1.Gio06 + tb1.Gio07 ),0) As Truoc8h, ' 
					+ ' ISNULL(tb1.Gio08, 0 ) as Gio08,					ISNULL( tb1.Gio09, 0 ) as Gio09,				ISNULL( tb1.Gio10, 0 ) as Gio10, '
					+ ' ISNULL(tb1.Gio11, 0 ) as Gio11,					ISNULL(tb1.Gio12, 0 ) as Gio12,					ISNULL(tb1.Gio13, 0 ) as Gio13, '
					+ ' ISNULL(tb1.Gio14, 0 ) as Gio14,					ISNULL(tb1.Gio15, 0 ) as Gio15,					ISNULL(tb1.Gio16, 0 ) as Gio16, ' 
					+ ' ISNULL(tb1.Gio17, 0 ) as Gio17,					ISNULL(tb1.Gio18, 0 ) as Gio18, '
					+ ' ISNULL( (tb1.Gio19 + tb1.Gio20 + tb1.Gio21 + tb1.Gio22 + tb1.Gio23),0) As Sau18h,				SPACE(1) as IsNoColor' +
					+ ' FROM dbo.ZEMP_SL_NG AS tb1 INNER JOIN dbo.ZEMP_NG AS tb2 ON tb1.Nganh = tb2.Nganh AND tb1.SystemId = tb2.SystemId '
					+ ' INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '	
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
--EXEC GetSanLuongOnline '900P01', 'WRKCT', 'KHVUC', 'KV01', 'ALL', '2017-06-15'

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


IF EXISTS ( SELECT * FROM   sysobjects WHERE  id = object_id(N'[dbo].[CountTrangThaiChuyen]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[CountTrangThaiChuyen]
END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Nguyen Hoang Giang>
-- Create date: <16 / 06 / 2017>
-- Description:	<Dem So luong chuyen theo trang thai>
-- =============================================
CREATE PROCEDURE CountTrangThaiChuyen
	@systemId		VARCHAR(20),
	@capDo			VARCHAR(20),
	@giaTriCapDo	VARCHAR(20),
	@congDoan		VARCHAR(20),
	@fromDate		VARCHAR(10),
	@toDate		VARCHAR(10)
AS
BEGIN
DECLARE @command nvarchar(max);
DECLARE @whereCongDoan nvarchar(max);
DECLARE @whereCapDo nvarchar(max);


IF @congDoan = 'ALL'
	SET @whereCongDoan = ''
ELSE
	SET @whereCongDoan =  ' AND tb_sl.CongDoan = '	+ ''''	+ @congDoan		+ ''''



IF @capDo = 'WRKCT'
	SET  @whereCapDo = ' WHERE tb1.Wrkct = '		+ ''''	+ @giaTriCapDo		+ ''''
ELSE IF @capDo = 'KHUVUC'
	SET  @whereCapDo = ' WHERE tb1.KhuVuc = '		+ ''''	 + @giaTriCapDo		+ ''''
ELSE
	SET  @whereCapDo = ' WHERE tb1.Nganh = '		+ ''''	+ @giaTriCapDo		+ ''''



SET @command =	' SELECT COUNT(tb1.status) [SLCH] , tb1.STATUS '
			+	' FROM ( '
			+	' SELECT tb_master.IdChuyen, tb_master.Wrkct, tb_master.KhuVuc, tb_master.Nganh, ' + '''' + 'STATUS' + '''' + ' =  CASE	WHEN tb_sl.DatKeHoach < 95 then ' + '''' + 'RED' + '''' +
			+	' WHEN tb_sl.DatKeHoach >= 95 and tb_sl.DatKeHoach < 100 THEN ' + '''' + 'YELLOW' + '''' +
			+	' ELSE' + '''' + 'GREEN' + '''' + ' END FROM zemp_sl_ch AS tb_sl INNER JOIN ZEMP_CH AS tb_master ON tb_sl.SystemId = tb_master.SystemId  '
			+	' AND tb_sl.IdChuyen = tb_master.IdChuyen  WHERE Ngay between ' + '''' + @fromDate + '''' + '  AND ' + '''' +  @toDate + '''' +
			+	@whereCongDoan + ' AND (tb_master.IsNoColor IS NULL OR tb_master.IsNoColor = ' + '''' + '''' + ' ) ) AS tb1 ' + @whereCapDo + ' GROUP BY STATUS '
print @command
EXECUTE sys.sp_executesql @command
END

--TEST
exec CountTrangThaiChuyen '900P01','KHUVUC','KV01', 'SDBCHAT','2017-06-22','2017-06-22'


-- ================================================
-- GET KE HOACH THUC HIEN THEO CAP DO / CONG DOAN
-- ================================================
IF EXISTS ( SELECT * FROM SYSOBJECTS WHERE id = OBJECT_ID(N'GetKeHoachThucHien') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
BEGIN
	DROP PROCEDURE GetKeHoachThucHien
END
GO
--When SET ANSI_NULLS is ON, 
-- a SELECT statement that uses WHERE column_name = NULL returns zero rows 
-- even if there are null values in column_name
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE GetKeHoachThucHien
	@systemId		VARCHAR(20),
	@capDo			VARCHAR(20),
	@giaTriCapDo	VARCHAR(20),
	@congDoan		VARCHAR(20),
	@fromDate		VARCHAR(10),
	@toDate			VARCHAR(10)
AS
BEGIN
	DECLARE @command		nvarchar(max);
	DECLARE @whereCongDoan	varchar(100);
	DECLARE @whereCapDo		varchar(100);
	DECLARE @tableSource	varchar(100);

	SET FMTONLY OFF

	IF @congDoan = 'ALL'
		SET @whereCongDoan = ' ';
	ELSE
		SET @whereCongDoan = ' AND CongDoan = ' + '''' + @congDoan  + ''''  ;

	
	

	if @capDo = 'WRKCT'
		BEGIN
			SET @tableSource	= 'ZEMP_SL_WC'
			SET @whereCapDo		= ' AND  Wrkct = ' + '''' + @giaTriCapDo + '''';
		END
	else if @capDo = 'KHUVUC'
		BEGIN
			SET @tableSource	= 'ZEMP_SL_KV'
			SET @whereCapDo		= ' AND  KhuVuc = ' + '''' + @giaTriCapDo + '''';
		END
	else if  @capDo = 'NGANH'
		BEGIN
			SET @tableSource	= 'ZEMP_SL_NG'
			SET @whereCapDo		= ' AND  Nganh = ' + '''' + @giaTriCapDo + '''';
		END

		SET @command  =		' SELECT Ngay as' + '''' + 'Ngay' + '''' + ', CongDoan as ' + '''' + 'CongDoan' + '''' + ', KeHoachNgay as '	+ '''' + 'KeHoach'		+ '''' +
						+	' , ThucHienNgay  AS ' + ''''	+	'ThucHien'	+ '''' + 'FROM '	+ @tableSource
						+	' WHERE Ngay BETWEEN '	+ ''''	+	@fromDate	+ '''' + ' AND '	+ '''' + @toDate + ''''
						+	@whereCapDo
						+	@whereCongDoan 
						+	' Order by Ngay ASC'
	--print @command
EXEC sys.sp_executesql @command
END
GO
--TEST
GetKeHoachThucHien '900P01', 'WRKCT', 'WC01', 'ALL', '2017-06-16', '2017-06-23'