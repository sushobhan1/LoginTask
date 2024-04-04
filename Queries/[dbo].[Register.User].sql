USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[Register.User]    Script Date: 4/4/2024 10:51:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Register.User]
	@UserName NVARCHAR(100),
	@DistrictId INT,
	@UserEmail NVARCHAR(100),
	@Password NVARCHAR(100),
	@MsgType NVARCHAR(10) out
AS
BEGIN
Declare @MsgInfo NVARCHAR(10)
begin try
begin tran
insert into dbo.[User](UserName,DistrictID,UserEmail,[PassWord],IsActive)
values (@UserName,@DistrictId,@UserEmail,@Password,1)

set @MsgType='success'
commit
end try

begin catch
rollback
set @MsgType='error'
end catch
Select @MsgType as MsgType
END
