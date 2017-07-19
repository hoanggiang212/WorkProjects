USE LTSS
GO


--CREATE TABLE MASTER DATA CUSTOMERS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Customers')
BEGIN
  DROP TABLE [dbo].[Customers]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE Customers(
	[Id]			[varchar](15)	NOT NULL,
	[ShortName]		[nvarchar](50)	NOT NULL,
	[FullName]		[nvarchar](200)	NOT NULL,
	[MaSoThue]		[varchar](15)	NOT NULL,
	[PhoneNumber]	[varchar](50)	NULL,
	[FaxNumber]		[varchar](50)	NULL,
	[Address]		[nvarchar](150)	NULL,
	[Province]		[nvarchar](50)	NULL,
	[ContactName]	[nvarchar](50)	NULL,
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



--CREATE TABLE MASTER DATA MATERIALS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Materials')
BEGIN
  DROP TABLE [dbo].[Materials]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE Materials(
	[Id]			bigint			NOT NULL,
	[CustomerID]		[nvarchar](50)	NULL,
	[ShortName]		[nvarchar](50)	NOT NULL,
	[FullName]		[nvarchar](200)	NOT NULL,
	[GroupMat]		[nvarchar](15)	NOT NULL,
	[Unit]			[nvarchar](10)	NOT NULL,
	[volumne]		[numeric](18,2) Null,
	[Weight]		[numeric](18,2) Null,
	[Square]		[numeric](18,2) Null,
	[LeadTime]		[numeric](18,2) Null,
	[SafetyStock]	[numeric](18,2) Null,	
	CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE MASTER DATA MATERIALS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'GroupMaterials')
BEGIN
  DROP TABLE [dbo].[GroupMaterials]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE GroupMaterials(
	[GroupMat]		[nvarchar](15)	NOT NULL,
	[GroupName]		[nvarchar](50)	NOT NULL,	
	CONSTRAINT [PK_GroupMaterials] PRIMARY KEY CLUSTERED (
	[GroupMat] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO




--CREATE TABLE MASTER DATA MATERIALS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'SaleOrders')
BEGIN
  DROP TABLE [dbo].[SaleOrders]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE SaleOrders(
	[Id]			[bigint]		NOT NULL,
	[MaterialId]	[bigint]		NOT NULL,
	[CustomerId]	[bigint]		NOT NULL,
	[Quantity]		[numeric](18,2)	NOT NULL,
	[Unit]			[nvarchar](10)	NOT NULL,
	[SaleDate]		[smalldatetime] not null,
	[InDate]		[smalldatetime] null,
	[Status]		[varchar](15)	not null,	
	CONSTRAINT [PK_SaleOrders] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CREATE TABLE MASTER DATA MATERIALS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Warehouses')
BEGIN
  DROP TABLE [dbo].[Warehouses]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE Warehouses(
	[Id]			[varchar](5)	NOT NULL,
	[Name]			[nvarchar](50)	NOT NULL,
	[Description]	[nvarchar](150)	NOT NULL,
	[CapVoulume]	[numeric](18,2)	NOT NULL,
	[CapSquare]		[numeric](18,2)	NOT NULL,
	[CapWeight]		[numeric](18,2)	NOT NULL,		
	[StoreKeeper]	[nvarchar](50),
	CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



--CREATE TABLE MASTER DATA MATERIALS
--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'StoreLocation')
BEGIN
  DROP TABLE [dbo].[StoreLocation]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE StoreLocation(
	[Id]			[varchar](10)	NOT NULL,
	[WarehouseId]	[varchar](5)		NOT NULL,
	[Name]			[nvarchar](50)	NOT NULL,
	[Description]	[nvarchar](150)	NOT NULL,
	[CapVoulume]	[numeric](18,2)	NOT NULL,
	[CapSquare]		[numeric](18,2)	NOT NULL,
	[CapWeight]		[numeric](18,2)	NOT NULL,		
	[StoreKeeper]	[nvarchar](50),
	CONSTRAINT [PK_StoreLocation] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'InPlans')
BEGIN
  DROP TABLE [dbo].[InPlans]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE InPlans(
	[Id]			[bigint]		NOT NULL,
	[SaleOrderId]	[bigint]		NOT NULL,	
	[InDatePlan]	[smalldatetime] not null,	
	[DateCreated]	[smalldatetime] not null,	
	[UserCreated]	[varchar](10)	not null,	
	CONSTRAINT [PK_InPlans] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'InPlanDetail')
BEGIN
  DROP TABLE [dbo].[InPlanDetail]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE InPlanDetail(
	[Id]			[bigint]		NOT NULL,
	[SaleOrderId]	[bigint]		NOT NULL,
	[MaterialId]	[bigint]		NOT NULL,
	[PalletId]		[varchar](15)	NOT NULL,
	[DateCreated]	[smalldatetime] not null,
	CONSTRAINT [PK_InPlanDetail] PRIMARY KEY CLUSTERED (
	[Id] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO


--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Pallets')
BEGIN
  DROP TABLE [dbo].[Pallets]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE Pallets(
	[Id]			[varchar](15)	NOT NULL,
	[MaterialId]	[bigint]		NOT NULL,
	[Quantity]		[numeric](18,2)	NOT NULL,
	[Voulume]		[numeric](18,2)	NULL,
	[Square]		[numeric](18,2)	NULL,
	[Weight]		[numeric](18,2)	NULL,
	CONSTRAINT [PK_Pallets] PRIMARY KEY CLUSTERED (
	[Id] ASC,
	[MaterialId] ASC )
WITH (	PAD_INDEX = OFF, 
		STATISTICS_NORECOMPUTE = OFF, 
		IGNORE_DUP_KEY = OFF, 
		ALLOW_ROW_LOCKS = ON, 
		ALLOW_PAGE_LOCKS = ON ) ON [PRIMARY]
) ON [PRIMARY]
GO



--CHECK EXIST TABLE
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = N'Inventory')
BEGIN
  DROP TABLE [dbo].[Inventory]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE 
CREATE TABLE Inventory(
	[DocumentNo]	[varchar](10)	NOT NULL,
	[MaterialId]	[bigint]		NOT NULL,
	[PalletId]		[varchar](15)	NOT NULL,
	[MvtType]		[varchar](10)	NOT NULL,
	[StoreLocId]	[varchar](10)	NOT NULL,
	[DiscardFlg]	[char](1)		NOT NULL,
	[Quantity]		[numeric](18,2)	NOT NULL,
	[Voulume]		[numeric](18,2)	NULL,
	[Square]		[numeric](18,2)	NULL,
	[Weight]		[numeric](18,2)	NULL,
	[CreatedDate]	[smalldatetime]	NOT NULL,
	[UserCreate]	[smalldatetime]	NOT NULL,
	CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED (
	[DocumentNo]	ASC,
	[MaterialId]	ASC,
	[PalletId]		ASC
	)
WITH (	PAD_INDEX				= OFF, 
		STATISTICS_NORECOMPUTE	= OFF, 
		IGNORE_DUP_KEY			= OFF, 
		ALLOW_ROW_LOCKS			= ON, 
		ALLOW_PAGE_LOCKS		= ON ) ON [PRIMARY]
) ON [PRIMARY]
GO

