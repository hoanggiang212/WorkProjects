use LTSS
GO

IF Exists ( select * from sysobjects sysobjects WHERE  id = object_id(N'[dbo].[GetMaterialList]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )  )
begin
 DROP PROCEDURE [dbo].[GetMaterialList]
end

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE GetMaterialList
@NAME		NVARCHAR(50),
@ADDRESS	NVARCHAR(100),
@MST		NVARCHAR(20),
@SODT		NVARCHAR(20)
as
begin
	DECLARE @command NVARCHAR(MAX);

	SET @command = 'SELECT * FROM CUSTOMERS '	+
					' WHERE ShortName LIKE N'	+ '''' +  '%' + @NAME		+ '%' +
					' OR FullName LIKE N'		+ '''' +  '%' + @NAME		+ '%' +
					' OR MaSoThue LIKE N'		+ '''' +  '%' + @MST		+ '%' +
					' OR Address LIKE N'		+ '''' +  '%' + @ADDRESS	+ '%' +
					' OR PhoneNumber LIKE N'	+ '''' +  '%' + @ADDRESS	+ '%';
	EXECUTE sys.sp_executesql @command;
end