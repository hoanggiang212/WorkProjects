USE [TKTDSX]
GO


--INSERT USER
INSERT [dbo].[ZEMP_USER] ([SystemId], [Username], [Password], [HoTen], [ChucVu], [LastMode], [LastCapDo], [LastGiaTriCapDo], [LastCongDoan], [InActive]) VALUES (N'900P01', N'giangnh', N'123456', N'Nguyễn Hoàng Giang', N'ABAP Developer', N'CHUYEN', N'WRKCT', N'WC01', N'SMAY', NULL)
GO
INSERT [dbo].[ZEMP_USER] ([SystemId], [Username], [Password], [HoTen], [ChucVu], [LastMode], [LastCapDo], [LastGiaTriCapDo], [LastCongDoan], [InActive]) VALUES (N'900P01', N'haivv', N'123456', N'Vũ Văn Hải', N'Giám Đốc', N'KHUVUC', N'KHUVUC', N'KV01', N'SGO', NULL)
GO


--MASTER DATA CONG DOAN
INSERT [dbo].[ZEMP_CONGDOAN] ([SystemId], [CongDoan], [TenCongDoan], [Stt]) VALUES (N'900P01', N'SCHAT', N'SH CHẶT', CAST(5 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_CONGDOAN] ([SystemId], [CongDoan], [TenCongDoan], [Stt]) VALUES (N'900P01', N'SDBCHAT', N'SH ĐỒNG BỘ CHẶT', CAST(4 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_CONGDOAN] ([SystemId], [CongDoan], [TenCongDoan], [Stt]) VALUES (N'900P01', N'SGO', N'SH GÒ', CAST(1 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_CONGDOAN] ([SystemId], [CongDoan], [TenCongDoan], [Stt]) VALUES (N'900P01', N'SLOTTAY', N'SH LÓT TẨY', CAST(3 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_CONGDOAN] ([SystemId], [CongDoan], [TenCongDoan], [Stt]) VALUES (N'900P01', N'SMAY', N'SH MAY', CAST(2 AS Numeric(18, 0)))
GO

---Insert data chuyen

--WC01

INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1001', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Chặt 1', N'Nguyễn Văn A', N'SDBCHAT', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1002', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Chặt 2', N'Nguyễn Văn B', N'SDBCHAT', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1003', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 3', N'Nguyễn Văn C', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1004', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 4', N'Nguyễn Văn D', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1005', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 5', N'Nguyễn Văn e', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1006', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 6', N'Nguyễn Văn f', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1007', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 7', N'Nguyễn Văn g', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1008', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 8', N'Nguyễn Văn h', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1009', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 9', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1010', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 10', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO

--WC02

INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1101', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 1', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1102', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 2', N'Nguyễn Văn B', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1103', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 3', N'Nguyễn Văn C', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1104', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 4', N'Nguyễn Văn D', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1105', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 5', N'Nguyễn Văn e', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1106', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 6', N'Nguyễn Văn f', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1107', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 7', N'Nguyễn Văn g', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1108', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 8', N'Nguyễn Văn h', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1109', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 9', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1110', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 10', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO

--WC03

INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1201', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Lót Tẩy 1', N'Nguyễn Văn A', N'SLOTTAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1202', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Lót 2', N'Nguyễn Văn B', N'SLOTTAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1203', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 3', N'Nguyễn Văn C', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1204', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 4', N'Nguyễn Văn D', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1205', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 5', N'Nguyễn Văn e', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1206', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 6', N'Nguyễn Văn f', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1207', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 7', N'Nguyễn Văn g', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1208', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 8', N'Nguyễn Văn h', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1209', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 9', N'Nguyễn Văn A', N'SGO', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1210', N'PX01', N'WC02', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền Gò 10', N'Nguyễn Văn A', N'SGO', NULL, NULL)
GO

--MASTER DATA KHU VỰC
INSERT [dbo].[ZEMP_KV] ([SystemId], [KhuVuc], [TenKhuVuc], [Nganh], [QlKhuVuc]) VALUES (N'900P01', N'KV01', N'Khu Vực 1', N'GIAY', N'Lê Duy Khương')
GO

--MASTER DATA NGÀNH
INSERT [dbo].[ZEMP_NG] ([SystemId], [Nganh], [TenNganh], [QlNganh]) VALUES (N'900P01', N'GIAY', N'GIÀY', N'Sketcher')
GO
INSERT [dbo].[ZEMP_NG] ([SystemId], [Nganh], [TenNganh], [QlNganh]) VALUES (N'900P01', N'TX', N'TÚI XÁCH', N'COACH')
GO

--MASTER DATA WORKCENTER
INSERT [dbo].[ZEMP_WC] ([SystemId], [Wrkct], [TenWrkct], [KhuVuc], [Nganh], [QlWrkct]) VALUES (N'900P01', N'WC01', N'Workcenter 01', N'KV01', N'GIAY', N'Nguyen Van A')
GO
INSERT [dbo].[ZEMP_WC] ([SystemId], [Wrkct], [TenWrkct], [KhuVuc], [Nganh], [QlWrkct]) VALUES (N'900P01', N'WC02', N'Workcenter 02', N'KV01', N'GIAY', N'Nguyen Van B')
GO
INSERT [dbo].[ZEMP_WC] ([SystemId], [Wrkct], [TenWrkct], [KhuVuc], [Nganh], [QlWrkct]) VALUES (N'900P01', N'WC03', N'Workcenter 03', N'KV01', N'GIAY', N'Nguyen Van C')
GO


-- SAN LUONG CHUYEN
-- CHUYEN '1001' - CONG DOAN : SDBCHAT
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA78F0000 AS SmallDateTime), N'SDBCHAT', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7900000 AS SmallDateTime), N'SDBCHAT', CAST(32 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7910000 AS SmallDateTime), N'SDBCHAT', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7920000 AS SmallDateTime), N'SDBCHAT', CAST(28 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7930000 AS SmallDateTime), N'SDBCHAT', CAST(35 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7940000 AS SmallDateTime), N'SDBCHAT', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1001', CAST(0xA7950000 AS SmallDateTime), N'SDBCHAT', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO

--CHUYEN '1002' - CONG DOAN : SDBCHAT

INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA78F0000 AS SmallDateTime), N'SMAY', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7900000 AS SmallDateTime), N'SMAY', CAST(32 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7910000 AS SmallDateTime), N'SMAY', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7920000 AS SmallDateTime), N'SMAY', CAST(28 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7930000 AS SmallDateTime), N'SMAY', CAST(35 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7940000 AS SmallDateTime), N'SMAY', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1003', CAST(0xA7950000 AS SmallDateTime), N'SMAY', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO

--CHUYỀN 1003 - CONG DOAN : SMAY
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA78F0000 AS SmallDateTime), N'SDBCHAT', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7900000 AS SmallDateTime), N'SDBCHAT', CAST(32 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7910000 AS SmallDateTime), N'SDBCHAT', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7920000 AS SmallDateTime), N'SDBCHAT', CAST(28 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7930000 AS SmallDateTime), N'SDBCHAT', CAST(35 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7940000 AS SmallDateTime), N'SDBCHAT', CAST(30 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO
INSERT [dbo].[ZEMP_SL_CH] ([SystemId], [IdChuyen], [Ngay], [CongDoan], [SoLuongLD], [NangSuat], [GioLamViec], [KeHoachGio], [KeHoachNgay], [ThucHienNgay], [ChenhLech], [DatKeHoach], [Gio01], [Gio02], [Gio03], [Gio04], [Gio05], [Gio06], [Gio07], [Gio08], [Gio09], [Gio10], [Gio11], [Gio12], [Gio13], [Gio14], [Gio15], [Gio16], [Gio17], [Gio18], [Gio19], [Gio20], [Gio21], [Gio22], [Gio23], [Gio24], [Tuan], [Thang], [Quy], [Nam]) VALUES (N'900P01', N'1002', CAST(0xA7950000 AS SmallDateTime), N'SDBCHAT', CAST(31 AS Numeric(18, 0)), CAST(8.60 AS Numeric(18, 2)), CAST(12.00 AS Numeric(18, 2)), CAST(50 AS Numeric(18, 0)), CAST(600 AS Numeric(18, 0)), CAST(1234 AS Numeric(18, 0)), CAST(-300 AS Numeric(18, 0)), CAST(68.12 AS Numeric(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(30 AS Numeric(18, 0)), CAST(40 AS Numeric(18, 0)), CAST(60 AS Numeric(18, 0)), CAST(55 AS Numeric(18, 0)), CAST(15 AS Numeric(18, 0)), NULL, CAST(45 AS Numeric(18, 0)), CAST(12 AS Numeric(18, 0)), CAST(69 AS Numeric(18, 0)), CAST(80 AS Numeric(18, 0)), CAST(100 AS Numeric(18, 0)), NULL, NULL, NULL, NULL, NULL, NULL, CAST(25 AS Numeric(18, 0)), NULL, CAST(2 AS Numeric(18, 0)), CAST(2017 AS Numeric(18, 0)))
GO

