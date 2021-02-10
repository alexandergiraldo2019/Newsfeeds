using Deloitte.DataNewsfeeds;
using Deloitte.DataNewsfeeds.Repositories;
using Deloitte.Domain;
using Deloitte.ServiceNewsfeeds.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Services
{
    public class FeedService : IFeedService
    {
        private IConnectionFactory connectionFactory;
        private IConfiguration _DataConfiguration;

        public FeedService(IConfiguration dataConfiguration)
        {
            _DataConfiguration = dataConfiguration;
        }

        public bool CreateFeed(Feed feed)
        {
            connectionFactory = ConnectionHelper.GetConnection(_DataConfiguration);

            var context = new DbContext(connectionFactory);

            var Rep = new FeedRepository(context);

            var result =  Rep.CreateFeed(feed);

            return !(result != null && result.FeedId > 0);

        }

        public Feed GetFeed(int id)
        {
            connectionFactory = ConnectionHelper.GetConnection(_DataConfiguration);

            var context = new DbContext(connectionFactory);

            var Rep = new FeedRepository(context);

            return Rep.GetFeed(id);
        }

        public IList<Feed> GetFeeds()
        {
            connectionFactory = ConnectionHelper.GetConnection(_DataConfiguration);

            var context = new DbContext(connectionFactory);

            var Rep = new FeedRepository(context);

            return Rep.GetFeeds();
        }

        public List<Feed> GetFeedsByUser(string Login)
        {
            connectionFactory = ConnectionHelper.GetConnection(_DataConfiguration);

            var context = new DbContext(connectionFactory);

            var Rep = new FeedRepository(context);

            return Rep.GetFeedsByUser(Login);
        }
    }
}
