USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[GetUser.Details]    Script Date: 4/4/2024 10:50:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetUser.Details]
@UserId Nvarchar(10)
AS
BEGIN
select * from dbo.[User] as u
inner join dbo.[District] d
on d.DistrictID=u.DistrictID
where u.UserID=@UserId and u.IsActive=1
END
