USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[User.Authenticate]    Script Date: 4/4/2024 10:51:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[User.Authenticate]

	@Email NVARCHAR(100),
	@Password NVARCHAR(100),
	@MsgType varchar(10) out
AS
BEGIN
if exists (select 1 from dbo.[User] where UserEmail=@Email and [PassWord]=@Password)
begin
select * from dbo.[User] where UserEmail=@Email and [PassWord]=@Password
set @MsgType ='ok'
end
else
begin
set @MsgType='user not found'
end
select @MsgType as MsgType
END
