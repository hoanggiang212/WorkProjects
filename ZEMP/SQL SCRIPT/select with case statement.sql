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
--print @command
EXECUTE sys.sp_executesql @command
END

--TEST
exec CountTrangThaiChuyen '900P01','KHUVUC','KV01', 'SDBCHAT','2017-06-22','2017-06-22'
