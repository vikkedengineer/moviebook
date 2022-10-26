
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_AuthenticateUser] 
	-- Add the parameters for the stored procedure here
	@UserName nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from [dbo].[UserBase]
           where UserName = @UserName and UserPassword = @Password

END
GO


