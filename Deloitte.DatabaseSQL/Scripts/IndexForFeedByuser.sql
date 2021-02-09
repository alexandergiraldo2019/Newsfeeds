ALTER TABLE [dbo].[FeebByUser]  WITH CHECK ADD  CONSTRAINT [FK_FeebByUser_Feeds] FOREIGN KEY([FeedId])
REFERENCES [dbo].[Feeds] ([FeedId])
GO

ALTER TABLE [dbo].[FeebByUser] CHECK CONSTRAINT [FK_FeebByUser_Feeds]
GO

ALTER TABLE [dbo].[FeebByUser]  WITH CHECK ADD  CONSTRAINT [FK_FeebByUser_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([UserId])
GO