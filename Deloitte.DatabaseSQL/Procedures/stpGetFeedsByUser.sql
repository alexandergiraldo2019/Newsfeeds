
CREATE PROCEDURE [dbo].[stpGetFeedsByUser]
(
 @Login				VARCHAR(20) = NULL
)
AS
BEGIN
	select f.FeedId, f.FeedName, f.ApiUrl from Users u join FeebByUser fu on u.UserId = fu.UserId
	join Feeds f on f.FeedId = fu.FeedId where u.Login = @Login
END
