using Deloitte.Domain;
using Deloitte.ServiceNewsfeeds.Interfaces;
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
        private readonly IConfiguration _dataConfiguration;
        private readonly IFeedService _FeedService;
        private readonly INewsFeedService _NewsFeedService;


        public FeedNewsController(IConfiguration dataConfiguration, IFeedService FeedService, INewsFeedService NewsFeedService)
        {
            _dataConfiguration = dataConfiguration;
            _FeedService = FeedService;
            _NewsFeedService = NewsFeedService;
        }

        [HttpGet]
        public IEnumerable<NewsFeed> GetFeedNews()
        {
            List<NewsFeed> NewsFeedsList = (List<NewsFeed>)_NewsFeedService.GetNewsFeeds();
            return (NewsFeedsList);
        }

        [Route("GetNews")]
        [HttpGet]
        //public IEnumerable<NewsFeed> GetFeedNews()
        public IEnumerable<News> GetNews()
        {
            List<News> news = _NewsFeedService.GetNews();
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
