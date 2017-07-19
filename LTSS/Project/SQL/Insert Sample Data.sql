USE LTSS
GO

INSERT INTO [dbo].[Customers]
           ([Id]
			,[ShortName]
           ,[FullName]
           ,[MaSoThue]
           ,[PhoneNumber]
           ,[FaxNumber]
           ,[Address]
           ,[Province]
           ,[ContactName]
		   )
     VALUES
           (
		   '3'
           ,N'ĐẠM CÀ MAU'
		   ,N'Công Ty CP PBDK Cà Mau'
           ,N'012345678'
           ,N'0345678'
           ,N'43234545'
           ,N'Phường 1 - Tp Cà Mau'
           ,N'Cà Mau'
           ,N'Nguyễn Văn A'
		   )
GO
