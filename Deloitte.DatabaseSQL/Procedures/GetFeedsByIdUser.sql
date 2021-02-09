CREATE PROCEDURE dbo.GetFeedsByIdUser	
	@UserId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
		f.* 
		from
			FeebByUser AS fu
			INNER JOIN Feeds AS f ON fu.FeedId = f.FeedId 
	WHERE
		fu.UserId = @UserId
END
GO

