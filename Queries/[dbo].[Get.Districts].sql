USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[Get.Districts]    Script Date: 4/4/2024 10:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Get.Districts]
	
AS
BEGIN
	Select DistrictID as [Value],DistrictName as [Text] from dbo.[District]
END
