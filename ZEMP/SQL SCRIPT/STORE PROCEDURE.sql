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
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetSanLuongOnline
	@mode VARCHAR(20),
	@capdo VARCHAR(20),
	@giatricapdo VARCHAR(20),
	@congdoan VARCHAR(20),
	@ngay varchar(10)
AS
BEGIN
DECLARE @where NVARCHAR(MAX);
DECLARE @command NVARCHAR(MAX);

SET NOCOUNT ON;

-- Define table source
IF @mode = 'CHUYEN'
	SET @command = 'SELECT tb1.*, tb3.TenCongDoan FROM dbo.ZEMP_SL_CH AS tb1 
					INNER JOIN ZEMP_CH AS tb2 ON tb1.IdChuyen = tb2.IdChuyen AND tb1.SystemId = tb2.SystemId
					INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId'		
ELSE IF @mode = 'WRKCT'
	SET @command = 'SELECT tb1.*, tb3.TenCongDoan FROM dbo.ZEMP_SL_WC AS tb1 
					INNER JOIN dbo.ZEMP_WC AS tb2 ON tb1.Wrkct = tb2.Wrkct AND tb1.SystemId = tb2.SystemId
					INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId'

ELSE IF @mode = 'KHVUC'
	SET @command = 'SELECT tb1.*, tb3.TenCongDoan FROM dbo.ZEMP_SL_KV AS tb1 
					INNER JOIN dbo.ZEMP_KV AS tb2 ON tb1.KhuVuc = tb2.KhuVuc AND tb1.SystemId = tb2.SystemId
					INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '
ELSE IF @mode = 'NGANH'
	SET @command = 'SELECT tb1.*, tb3.TenCongDoan FROM dbo.ZEMP_SL_NG AS tb1 
					INNER JOIN dbo.ZEMP_KV AS tb2 ON tb1.Nganh = tb2.Nganh AND tb1.SystemId = tb2.SystemId
					INNER JOIN dbo.ZEMP_CONGDOAN AS tb3 ON tb1.CongDoan = tb3.CongDoan AND tb1.SystemId = tb3.SystemId '

--define condition
IF @capdo = 'WRKCT'
	SET @where = 'tb2.Wrkct = ';

ELSE IF @capdo = 'KHVUC'
	SET @where = 'tb2.KhuVuc ';

ELSE IF @capdo = 'NGANH'
	SET @where = 'tb2.Nganh = ';



	SET @command = @command + ' WHERE ' + @where  + '''' + CAST(@giatricapdo AS VARCHAR) + '''' +  ' AND tb1.CongDoan = ' + '''' + CAST( @congdoan AS VARCHAR) + '''' + ' AND tb1.Ngay = ' + '''' + CAST( @ngay  AS VARCHAR) + '''';

	EXECUTE sys.sp_executesql @command
END
GO


EXEC dbo.GetSanLuongOnline @mode = 'WRKCT', -- varchar(20)
    @capdo = 'WRKCT', -- varchar(20)
    @giatricapdo = 'WC02', -- varchar(20)
    @congdoan = 'SMAy', -- varchar(20)
    @ngay = '2017-06-15' -- varchar(10)
