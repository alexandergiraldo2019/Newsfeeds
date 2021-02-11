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
        /// <summary>
        /// Get top 10 News for the user suscribe feeds
        /// </summary>
        /// <param name="login">username</param>
        /// <returns>Top 10 news for each feed suscribed</returns>
        List<NewsFeed> GetNewsFeedsByUser(string login);
    }
}
