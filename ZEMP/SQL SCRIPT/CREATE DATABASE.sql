--CREATE DATABASE FOR ZEMP.VN
USE TKTDSX
GO

--CREATE TABLE MASTER DATA FOR CHUYEN
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_CH')
BEGIN
  DROP TABLE [dbo].[ZEMP_CH]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_CH(
	[SystemId]	[varchar](15)	NOT NULL,
	[IdChuyen]	[varchar](10)	NOT NULL,
	[Xuong]		[nvarchar](20)	NULL,
	[Wrkct]		[varchar](20)	NULL,
	[KhuVuc]	[varchar](20)	NULL,
	[Nganh]		[varchar](20)	NULL,
	[MaChuyen]	[varchar](20)	NULL,
	[TenChuyen]	[nvarchar](50)	NULL,
	[QlChuyen]	[nvarchar](50)	NULL,
	[CongDoan]	[varchar](20)	NULL,
	[ZIACT]		[nvarchar](1)	NULL,
	[IsNoColor]	[varchar](1)	NULL,  --X: Khong to; blank: To mau
	CONSTRAINT [PK_ZEMP_CH] PRIMARY KEY CLUSTERED (
	[SystemId] ASC,
	[IdChuyen] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE WORKCENTER
--CHECK EXIST
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_WC')
BEGIN
  DROP TABLE [dbo].[ZEMP_WC]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_WC(
	[SystemId]	[varchar](15)	NOT NULL,
	[Wrkct]		[varchar](20)	NOT NULL,
	[TenWrkct]	[nvarchar](50)	NOT NULL,	
	[KhuVuc]	[varchar](20)	NOT NULL,
	[Nganh]		[varchar](20)	NOT NULL,
	[QlWrkct]	[nvarchar](50)	NULL,	
	CONSTRAINT [PK_ZEMP_WC] PRIMARY KEY CLUSTERED (
	[SystemId] ASC,
	[Wrkct] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

--CREATE TABLE KHU VUC
--CHECK EXIST
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_KV')
BEGIN
  DROP TABLE [dbo].[ZEMP_KV]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_KV(
	[SystemId]	[varchar](15)	NOT NULL,
	[KhuVuc]	[varchar](20)	NOT NULL,
	[TenKhuVuc]	[nvarchar](50)	NOT NULL,	
	[Nganh]		[varchar](20)	NOT NULL,
	[QlKhuVuc]	[nvarchar](50)	NULL,	
	CONSTRAINT [PK_ZEMP_KV] PRIMARY KEY CLUSTERED (
	[SystemId]	ASC,
	[KhuVuc]	ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO
--CREATE TABLE NGANH
--CHECK EXIST
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_NG')
BEGIN
  DROP TABLE [dbo].[ZEMP_NG]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_NG(
	[SystemId]	[varchar](15)	NOT NULL,
	[Nganh]		[varchar](20)	NOT NULL,
	[TenNganh]	[nvarchar](50)	NULL,	
	[QlNganh]	[nvarchar](50)	NULL,	
	CONSTRAINT [PK_ZEMP_NG] PRIMARY KEY CLUSTERED (
	[SystemId]		ASC,
	[Nganh]			ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

---CREATE TABLE CONG DOAN
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_CONGDOAN')
BEGIN
	DROP TABLE ZEMP_CONGDOAN
END 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE ZEMP_CONGDOAN
(
	[SystemId]		[varchar](15)	NOT NULL,
	[CongDoan]		[varchar](20)	NOT NULL,
	[TenCongDoan]	[nvarchar](50)	NOT NULL,
	[Stt]			[numeric](18,0) NOT NULL,
	CONSTRAINT [PK_ZEMP_CONGDOAN] PRIMARY KEY CLUSTERED (
		[SystemId] ASC,
		[CongDoan] ASC )
	WITH (PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


---CREATE TABLE DAU RA CONG DOAN
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_DAURA_WC')
BEGIN
	DROP TABLE ZEMP_DAURA_WC
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_DAURA_WC
(
	[SystemId]		[varchar](15)	NOT NULL,
	[Wrkct]			[varchar](20)	NOT NULL,
	[KhuVuc]		[varchar](20)	NOT NULL,
	[Nganh]			[varchar](20)	NOT NULL,
	[CongDoan]		[varchar](20)	NOT NULL,
	CONSTRAINT [PK_ZEMP_DAURA_WC] PRIMARY KEY CLUSTERED (
		[SystemId]	ASC,
		[Wrkct]		ASC, 
		[KhuVuc]	ASC,
		[Nganh]		ASC,
		[CongDoan]	ASC)
	WITH (PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE	= OFF, 
		IGNORE_DUP_KEY			= OFF, 
		ALLOW_ROW_LOCKS			= ON, 
		ALLOW_PAGE_LOCKS		= ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

---CREATE TABLE DAU RA CONG DOAN
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_DAURA_KV')
BEGIN
	DROP TABLE ZEMP_DAURA_KV
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_DAURA_KV
(
	[SystemId]		[varchar](15)	NOT NULL,
	[KhuVuc]		[varchar](20)	NOT NULL,
	[Nganh]			[varchar](20)	NOT NULL,
	[CongDoan]		[varchar](20)	NOT NULL,
	CONSTRAINT [PK_ZEMP_DAURA_KV] PRIMARY KEY CLUSTERED (
		[SystemId]	ASC,
		[KhuVuc]	ASC, 
		[Nganh]		ASC,
		[CongDoan]	ASC)
	WITH (PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



---CREATE TABLE DAU RA CONG DOAN
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_DAURA_NG')
BEGIN
	DROP TABLE ZEMP_DAURA_NG
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_DAURA_NG
(
	[SystemId]		[varchar](15)	NOT NULL,
	[Nganh]			[varchar](20)	NOT NULL,
	[CongDoan]		[varchar](20)	NOT NULL,
	CONSTRAINT [PK_ZEMP_DAURA_NG] PRIMARY KEY CLUSTERED (
		[SystemId] ASC,
		[Nganh] ASC, 
		[CongDoan] ASC)
	WITH (PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


---CREATE TABLE SAN LUONG CHUYEN ONLINE
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_SL_CH')
BEGIN
  DROP TABLE [dbo].[ZEMP_SL_CH]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE ZEMP_SL_CH (
	[SystemId]		[varchar](15)		NOT NULL,
	[IdChuyen]		[varchar](10)		NOT NULL,
	[Ngay]			[smalldatetime]		NOT NULL,
	[CongDoan]		[varchar](20)		NOT NULL,
	[SoLuongLD]		[numeric](18, 0) NULL,
	[NangSuat]		[numeric](18, 2) NULL, -- 2 so le
	[GioLamViec]	[numeric](18, 2) NULL, -- 2 so le
	[KeHoachGio]	[numeric](18, 0) NULL,
	[KeHoachNgay]	[numeric](18, 0) NULL,
	[ThucHienNgay]	[numeric](18, 0) NULL,
	[ChenhLech]		[numeric](18, 0) NULL,
	[DatKeHoach]	[numeric](18, 2) NULL, -- 2 so le (%)
	[Gio01]			[numeric](18, 0) NULL,
	[Gio02]			[numeric](18, 0) NULL,
	[Gio03]			[numeric](18, 0) NULL,
	[Gio04]			[numeric](18, 0) NULL,
	[Gio05]			[numeric](18, 0) NULL,
	[Gio06]			[numeric](18, 0) NULL,
	[Gio07]			[numeric](18, 0) NULL,
	[Gio08]			[numeric](18, 0) NULL,
	[Gio09]			[numeric](18, 0) NULL,
	[Gio10]			[numeric](18, 0) NULL,
	[Gio11]			[numeric](18, 0) NULL,
	[Gio12]			[numeric](18, 0) NULL,
	[Gio13]			[numeric](18, 0) NULL,
	[Gio14]			[numeric](18, 0) NULL,
	[Gio15]			[numeric](18, 0) NULL,
	[Gio16]			[numeric](18, 0) NULL,
	[Gio17]			[numeric](18, 0) NULL,
	[Gio18]			[numeric](18, 0) NULL,
	[Gio19]			[numeric](18, 0) NULL,
	[Gio20]			[numeric](18, 0) NULL,
	[Gio21]			[numeric](18, 0) NULL,
	[Gio22]			[numeric](18, 0) NULL,
	[Gio23]			[numeric](18, 0) NULL,
	[Gio24]			[numeric](18, 0) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_SL_CH] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[IdChuyen]	ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


---CREATE TABLE SAN LUONG WORK CENTER ONLINE
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_SL_WC')
BEGIN
  DROP TABLE [dbo].[ZEMP_SL_WC]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE ZEMP_SL_WC (
	[SystemId]	[varchar](15)	NOT NULL,
	[Wrkct]		[varchar](20)	NOT NULL,
	[Ngay]		[smalldatetime] NOT NULL,
	[CongDoan]	[varchar](20)	NOT NULL,
	[SoLuongLD]	[numeric](18, 0)	 NULL,
	[NangSuat]		[numeric](18, 2) NULL,  -- 2 so le
	[GioLamViec]	[numeric](18, 2) NULL, -- 2 so le
	[KeHoachGio]	[numeric](18, 0) NULL,
	[KeHoachNgay]	[numeric](18, 0) NULL,
	[ThucHienNgay]	[numeric](18, 0) NULL,
	[ChenhLech]		[numeric](18, 0) NULL,
	[DatKeHoach]	[numeric](18, 2) NULL, -- 2 so le (%)
	[Gio01]			[numeric](18, 0) NULL,
	[Gio02]			[numeric](18, 0) NULL,
	[Gio03]			[numeric](18, 0) NULL,
	[Gio04]			[numeric](18, 0) NULL,
	[Gio05]			[numeric](18, 0) NULL,
	[Gio06]			[numeric](18, 0) NULL,
	[Gio07]			[numeric](18, 0) NULL,
	[Gio08]			[numeric](18, 0) NULL,
	[Gio09]			[numeric](18, 0) NULL,
	[Gio10]			[numeric](18, 0) NULL,
	[Gio11]			[numeric](18, 0) NULL,
	[Gio12]			[numeric](18, 0) NULL,
	[Gio13]			[numeric](18, 0) NULL,
	[Gio14]			[numeric](18, 0) NULL,
	[Gio15]			[numeric](18, 0) NULL,
	[Gio16]			[numeric](18, 0) NULL,
	[Gio17]			[numeric](18, 0) NULL,
	[Gio18]			[numeric](18, 0) NULL,
	[Gio19]			[numeric](18, 0) NULL,
	[Gio20]			[numeric](18, 0) NULL,
	[Gio21]			[numeric](18, 0) NULL,
	[Gio22]			[numeric](18, 0) NULL,
	[Gio23]			[numeric](18, 0) NULL,
	[Gio24]			[numeric](18, 0) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_SL_WC] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[Wrkct]		ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

---CREATE TABLE SAN LUONG WORKCENTER ONLINE
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_SL_KV')
BEGIN
  DROP TABLE [dbo].[ZEMP_SL_KV]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE ZEMP_SL_KV (
	[SystemId]	[varchar](15)	NOT NULL,
	[KhuVuc]	[varchar](20)	NOT NULL,
	[Ngay]		[smalldatetime] NOT NULL,
	[CongDoan]	[varchar](20)	NOT NULL,
	[SoLuongLD]	[numeric](18, 0)	 NULL,
	[NangSuat]		[numeric](18, 2) NULL, -- 2 so le
	[GioLamViec]	[numeric](18, 2) NULL, -- 2 so le
	[KeHoachGio]	[numeric](18, 0) NULL,
	[KeHoachNgay]	[numeric](18, 0) NULL,
	[ThucHienNgay]	[numeric](18, 0) NULL,
	[ChenhLech]		[numeric](18, 0) NULL,
	[DatKeHoach]	[numeric](18, 2) NULL, -- 2 so le (%)
	[Gio01]			[numeric](18, 0) NULL,
	[Gio02]			[numeric](18, 0) NULL,
	[Gio03]			[numeric](18, 0) NULL,
	[Gio04]			[numeric](18, 0) NULL,
	[Gio05]			[numeric](18, 0) NULL,
	[Gio06]			[numeric](18, 0) NULL,
	[Gio07]			[numeric](18, 0) NULL,
	[Gio08]			[numeric](18, 0) NULL,
	[Gio09]			[numeric](18, 0) NULL,
	[Gio10]			[numeric](18, 0) NULL,
	[Gio11]			[numeric](18, 0) NULL,
	[Gio12]			[numeric](18, 0) NULL,
	[Gio13]			[numeric](18, 0) NULL,
	[Gio14]			[numeric](18, 0) NULL,
	[Gio15]			[numeric](18, 0) NULL,
	[Gio16]			[numeric](18, 0) NULL,
	[Gio17]			[numeric](18, 0) NULL,
	[Gio18]			[numeric](18, 0) NULL,
	[Gio19]			[numeric](18, 0) NULL,
	[Gio20]			[numeric](18, 0) NULL,
	[Gio21]			[numeric](18, 0) NULL,
	[Gio22]			[numeric](18, 0) NULL,
	[Gio23]			[numeric](18, 0) NULL,
	[Gio24]			[numeric](18, 0) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_SL_KV] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[KhuVuc]	ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


---CREATE TABLE SAN LUONG NGANH ONLINE
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_SL_NG')
BEGIN
  DROP TABLE [dbo].[ZEMP_SL_NG]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE ZEMP_SL_NG (
	[SystemId]	[varchar](15)	NOT NULL,
	[Nganh]		[varchar](20)	NOT NULL,
	[Ngay]		[smalldatetime] NOT NULL,
	[CongDoan]	[varchar](20)	NOT NULL,
	[SoLuongLD]	[numeric](18, 0)	 NULL,
	[NangSuat]		[numeric](18, 2) NULL,  -- 2 so le
	[GioLamViec]	[numeric](18, 2) NULL, -- 2 so le
	[KeHoachGio]	[numeric](18, 0) NULL,
	[KeHoachNgay]	[numeric](18, 0) NULL,
	[ThucHienNgay]	[numeric](18, 0) NULL,
	[ChenhLech]		[numeric](18, 0) NULL,
	[DatKeHoach]	[numeric](18, 2) NULL, -- 2 so le (%)
	[Gio01]			[numeric](18, 0) NULL,
	[Gio02]			[numeric](18, 0) NULL,
	[Gio03]			[numeric](18, 0) NULL,
	[Gio04]			[numeric](18, 0) NULL,
	[Gio05]			[numeric](18, 0) NULL,
	[Gio06]			[numeric](18, 0) NULL,
	[Gio07]			[numeric](18, 0) NULL,
	[Gio08]			[numeric](18, 0) NULL,
	[Gio09]			[numeric](18, 0) NULL,
	[Gio10]			[numeric](18, 0) NULL,
	[Gio11]			[numeric](18, 0) NULL,
	[Gio12]			[numeric](18, 0) NULL,
	[Gio13]			[numeric](18, 0) NULL,
	[Gio14]			[numeric](18, 0) NULL,
	[Gio15]			[numeric](18, 0) NULL,
	[Gio16]			[numeric](18, 0) NULL,
	[Gio17]			[numeric](18, 0) NULL,
	[Gio18]			[numeric](18, 0) NULL,
	[Gio19]			[numeric](18, 0) NULL,
	[Gio20]			[numeric](18, 0) NULL,
	[Gio21]			[numeric](18, 0) NULL,
	[Gio22]			[numeric](18, 0) NULL,
	[Gio23]			[numeric](18, 0) NULL,
	[Gio24]			[numeric](18, 0) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_SL_NG] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[Nganh]		ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE THONG KE WORK CENTER
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_TK_WC')
BEGIN
  DROP TABLE [dbo].[ZEMP_TK_WC]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_TK_WC (
	[SystemId]	[varchar](15)	NOT NULL,
	[Ngay]		[smalldatetime] NOT NULL,
	[Wrkct]		[varchar](20)	NOT NULL,
	[CongDoan]	[varchar](20)	NOT NULL,
	[TongLaoDong]	[numeric](18, 0) NULL,
	[ChuyenXanh]	[numeric](18, 0) NULL,
	[ChuyenVang]	[numeric](18, 0) NULL,
	[ChuyenDo]		[numeric](18, 0) NULL,
	[VatTuKeHoach]	[numeric](18, 2) NULL,
	[VatTuThucHien]	[numeric](18, 2) NULL,
	[TaiSanKeHoach]	[numeric](18, 2) NULL,
	[TaiSanThucHien]	[numeric](18, 2) NULL,
	[NhanCongKeHoach]	[numeric](18, 2) NULL,
	[NhanCongThucHien]	[numeric](18, 2) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_TK_WC] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[Wrkct]		ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE THONG KE KHU VUC
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_TK_KV')
BEGIN
  DROP TABLE [dbo].[ZEMP_TK_KV]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_TK_KV (
	[SystemId]	[varchar](15)	NOT NULL,
	[Ngay]		[smalldatetime] NOT NULL,
	[KhuVuc]		[varchar](20)	NOT NULL,
	[CongDoan]	[varchar](20)	NOT NULL,
	[TongLaoDong]	[numeric](18, 0) NULL,
	[ChuyenXanh]	[numeric](18, 0) NULL,
	[ChuyenVang]	[numeric](18, 0) NULL,
	[ChuyenDo]		[numeric](18, 0) NULL,
	[VatTuKeHoach]	[numeric](18, 2) NULL,
	[VatTuThucHien]	[numeric](18, 2) NULL,
	[TaiSanKeHoach]	[numeric](18, 2) NULL,
	[TaiSanThucHien]	[numeric](18, 2) NULL,
	[NhanCongKeHoach]	[numeric](18, 2) NULL,
	[NhanCongThucHien]	[numeric](18, 2) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_TK_KV] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[KhuVuc]	ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

--CREATE TABLE THONG KE KHU VUC
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_TK_NG')
BEGIN
  DROP TABLE [dbo].[ZEMP_TK_NG]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE ZEMP_TK_NG (
	[SystemId]			[varchar](15)	NOT NULL,
	[Ngay]				[smalldatetime] NOT NULL,
	[Nganh]				[varchar](20)	NOT NULL,
	[CongDoan]			[varchar](20)	NOT NULL,
	[TongLaoDong]		[numeric](18, 0) NULL,
	[ChuyenXanh]		[numeric](18, 0) NULL,
	[ChuyenVang]		[numeric](18, 0) NULL,
	[ChuyenDo]			[numeric](18, 0) NULL,
	[VatTuKeHoach]		[numeric](18, 2) NULL,
	[VatTuThucHien]		[numeric](18, 2) NULL,
	[TaiSanKeHoach]		[numeric](18, 2) NULL,
	[TaiSanThucHien]	[numeric](18, 2) NULL,
	[NhanCongKeHoach]	[numeric](18, 2) NULL,
	[NhanCongThucHien]	[numeric](18, 2) NULL,
	[Tuan]			[numeric](18, 0) NULL,
	[Thang]			[numeric](18, 0) NULL,
	[Quy]			[numeric](18, 0) NULL,
	[Nam]			[numeric](18, 0) NULL,
	CONSTRAINT [PK_ZEMP_TK_NG] PRIMARY KEY CLUSTERED 
	(
		[SystemId]	ASC,
		[Ngay]		ASC,
		[Nganh]	ASC,
		[CongDoan]	ASC
	)	WITH (	PAD_INDEX = OFF, 
			STATISTICS_NORECOMPUTE = OFF, 
			IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, 
			ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE USER
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_USER')
BEGIN
  DROP TABLE [dbo].[ZEMP_USER]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_USER(
	[SystemId]			[varchar](15)	NOT NULL,
	[Username]			[varchar](20)	NOT NULL,
	[Password]			[varchar](50)	NOT NULL,
	[HoTen]				[nvarchar](50)	NULL,
	[ChucVu]			[varchar](20)	NULL,
	[LastMode]			[varchar](20)	NULL,
	[LastCapDo]			[varchar](20)	NULL,
	[LastGiaTriCapDo]	[varchar](20)	NULL,
	[LastCongDoan]		[varchar](20)	NULL,
	[InActive]			[char](1) NULL,
	CONSTRAINT [PK_ZEMP_USER] PRIMARY KEY CLUSTERED (
	[SystemId] ASC,
	[Username] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--PHAN QUYEN USER
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'ZEMP_PQ')
BEGIN
  DROP TABLE [dbo].[ZEMP_PQ]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE ZEMP_PQ(
	[SystemId]			[varchar](15)	NOT NULL,
	[Username]			[varchar](20)	NOT NULL,
	[CapDo]				[varchar](20)	NOT NULL,		--NGANH / KHUVUC / WORKCENTER
	[GiaTriCapDo]		[varchar](20)	NOT NULL,		-- GIAY / KV01 / WC01 OR ALL
	[LastMode]			[varchar](20)	NULL,		
	[LastCapDo]			[varchar](20)	NULL,
	[LastGiaTriCapDo]	[varchar](20)	NULL,
	[LastCongDoan]		[varchar](20)	NULL,
	CONSTRAINT [PK_ZEMP_PQ] PRIMARY KEY CLUSTERED (
	[SystemId]		ASC,
	[Username]		ASC,
	[CapDo]			ASC,
	[GiaTriCapDo]	ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO