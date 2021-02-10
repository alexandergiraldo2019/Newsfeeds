using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.DataNewsfeeds.Interfaces
{
    public interface IFeedRepository
    {
        IList<Feed> GetFeeds();
        Feed GetFeed(int idFeed);
        Feed CreateFeed(Feed feed);
        List<Feed> GetFeedsByUser(string Login);

    }
}
