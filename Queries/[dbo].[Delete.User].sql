USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[Delete.User]    Script Date: 4/4/2024 10:49:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Delete.User]
	@UserId Nvarchar(10),
	@MsgType varchar (10) out
AS
BEGIN
begin try
begin tran
update dbo.[User] set IsActive=0 where UserID=@UserId
set  @MsgType='success'
commit
end try
begin catch 
rollback
set @MsgType='error deleting user'
end catch
END
