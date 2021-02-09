using Deloitte.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.UINewsfeeds.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedNewsController : ControllerBase
    {
        private IConfiguration _dataConfiguration;
        private Deloitte.ServiceNewsfeeds.ExternalServices.NewsFeedService _newsFeedService;
 

        public FeedNewsController(IConfiguration dataConfiguration)
        {
            _dataConfiguration = dataConfiguration;
            _newsFeedService = new ServiceNewsfeeds.ExternalServices.NewsFeedService(dataConfiguration);
        }

        [HttpGet]
        public IEnumerable<NewsFeed> GetFeedNews()
        {
            List<NewsFeed> NewsFeedsList = (List<NewsFeed>) _newsFeedService.GetNewsFeeds();
            return (NewsFeedsList);
        }
    }
}
