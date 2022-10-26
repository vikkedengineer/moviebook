
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AddUserBase] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(255),
	@Password nvarchar(255),
	@NickName nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO [dbo].[UserBase]
           ([UserName]
           ,[UserPassword]
           ,[NickName])
     VALUES
           (@UserName
           ,@Password
           ,@NickName)

END
GO


