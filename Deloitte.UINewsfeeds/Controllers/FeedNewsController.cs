using Deloitte.Domain;
using Microsoft.AspNetCore.Authorization;
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
        private Deloitte.ServiceNewsfeeds.Services.FeedService _FeedService;


        public FeedNewsController(IConfiguration dataConfiguration)
        {
            _dataConfiguration = dataConfiguration;
            _newsFeedService = new ServiceNewsfeeds.ExternalServices.NewsFeedService(dataConfiguration);
            _FeedService = new ServiceNewsfeeds.Services.FeedService(dataConfiguration);
        }

        [HttpGet]
        public IEnumerable<NewsFeed> GetFeedNews()
        {
            List<NewsFeed> NewsFeedsList = (List<NewsFeed>) _newsFeedService.GetNewsFeeds();
            return (NewsFeedsList);
        }

        [Route("GetNews")]
        [HttpGet]
        //public IEnumerable<NewsFeed> GetFeedNews()
        public IEnumerable<News> GetNews()
        {
            List<News> news = _newsFeedService.GetNews();
            return (news);
        }

        // Metodo para obtener los feeds por usuario despues de haberse logueado - Edison Suarez
        [Route("GetFeedsByUser")]
        [HttpGet]
        [AllowAnonymous]
        //public IEnumerable<NewsFeed> GetFeedNews()
        public IEnumerable<Feed> GetFeedsByUser(string Login)
        {
            List<Feed> feed = _FeedService.GetFeedsByUser(Login);
            return (feed);
        }
    }
}
