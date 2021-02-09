using System;
using Deloitte.Domain;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Interfaces
{
    public interface INewsFeedService
    {
        IList<NewsFeed> GetNewsFeeds();
        List<News> GetNews();
    }
}
