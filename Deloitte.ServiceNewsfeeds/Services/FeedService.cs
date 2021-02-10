using Deloitte.DataNewsfeeds;
using Deloitte.DataNewsfeeds.Interfaces;
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
        private IConnectionFactory _ConnectionFactory;
        private IConfiguration _DataConfiguration;
        private IFeedRepository _FeedRepository;


        public FeedService(IConfiguration dataConfiguration, IConnectionFactory connectionFactory, IFeedRepository feedRepository)
        {
            _DataConfiguration = dataConfiguration;
            _ConnectionFactory = connectionFactory;
            _FeedRepository = feedRepository;
        }

        public bool CreateFeed(Feed feed)
        {
            var result = _FeedRepository.CreateFeed(feed);
            return !(result != null && result.FeedId > 0);

        }

        public Feed GetFeed(int id)
        {
            return _FeedRepository.GetFeed(id);
        }

        public IList<Feed> GetFeeds()
        {
            return _FeedRepository.GetFeeds();
        }

        public List<Feed> GetFeedsByUser(string Login)
        {
            
            return _FeedRepository.GetFeedsByUser(Login);
        }
    }
}
