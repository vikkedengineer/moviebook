
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_UserMovieData] 
	-- Add the parameters for the stored procedure here
	@MovieId int,
	@MovieName nvarchar(255),
	@GenreId int,
	@LanguageId int,
	@Rating int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
UPDATE [dbo].[MovieBase] 
SET MovieName = @MovieName, GenreId = @GenreId, LanguageId = @LanguageId
WHERE Id = @MovieId
END
