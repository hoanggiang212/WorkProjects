USE [TKTDSX]
GO
INSERT [dbo].[ZEMP_USER] ([SystemId], [Username], [Password], [HoTen], [ChucVu], [LastMode], [LastCapDo], [LastGiaTriCapDo], [LastCongDoan], [InActive]) VALUES (N'900P01', N'giangnh', N'123456', N'Nguyễn Hoàng Giang', N'ABAP Developer', N'CHUYEN', N'WRKCT', N'WC01', N'SMAY', NULL)
GO
INSERT [dbo].[ZEMP_USER] ([SystemId], [Username], [Password], [HoTen], [ChucVu], [LastMode], [LastCapDo], [LastGiaTriCapDo], [LastCongDoan], [InActive]) VALUES (N'900P01', N'haivv', N'123456', N'Vũ Văn Hải', N'Giám Ð?c', N'KHUVUC', N'KHUVUC', N'KV01', N'SGO', NULL)
GO

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



INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1001', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 1', N'Nguyễn Văn A', N'SMAY', NULL, NULL)
GO
INSERT [dbo].[ZEMP_CH] ([SystemId], [IdChuyen], [Xuong], [Wrkct], [KhuVuc], [Nganh], [MaChuyen], [TenChuyen], [QlChuyen], [CongDoan], [ZIACT], [IsNoColor]) 
	VALUES (N'900P01', N'1002', N'PX01', N'WC01', N'KV01', N'GIAY', N'MC01KV01', N'Chuyền May 2', N'Nguyễn Văn B', N'SMAY', NULL, NULL)
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

