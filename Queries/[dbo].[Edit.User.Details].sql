USE [DemoInfo]
GO
/****** Object:  StoredProcedure [dbo].[Edit.User.Details]    Script Date: 4/4/2024 10:50:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Edit.User.Details]
@UserName NVARCHAR(100),
	@DistrictId INT,
	@UserEmail NVARCHAR(100),
	@Password NVARCHAR(100),
	@UserID NVARCHAR(10),
	@MsgType NVARCHAR(10) out
AS
BEGIN
	begin try
	begin tran
	update dbo.[User]
	set UserName=@UserName,
	UserEmail=@UserEmail,
	DistrictID=@DistrictId,
	[PassWord]=@Password
	where UserID=@UserID
	set @MsgType='Updated'
	commit
	end try
	begin catch
	rollback
	set @MsgType='Update Failed'
	end catch
	Select @MsgType as MsgType
END
