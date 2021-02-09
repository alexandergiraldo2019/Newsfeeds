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
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        private IConfiguration _dataConfiguration;
        private Deloitte.ServiceNewsfeeds.ExternalServices.FeedExteranlService _feedExternalService;
        private Deloitte.ServiceNewsfeeds.Services.FeedService _feedService;

        public NewsController(IConfiguration dataConfiguration)
        {
            _dataConfiguration = dataConfiguration;
            _feedExternalService = new ServiceNewsfeeds.ExternalServices.FeedExteranlService();
            _feedService = new ServiceNewsfeeds.Services.FeedService(dataConfiguration);
        }

        [HttpGet]
        public IEnumerable<Feed> GetFeeds(string idProvider)
        {
            List<Feed> FeedsList = _feedExternalService.GetFeedsProviderNews(idProvider);
            return (FeedsList);
        }

        [HttpGet]
        [Route("/ObtainFeed/")]
        public Feed GetFeed(string idProvider, int idFeed)
        {
            List<Feed> FeedsList = _feedExternalService.GetFeedsProviderNews(idProvider);
            return (FeedsList.Where(f => f.FeedId == idFeed).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult PostFeed(Feed feed)
        {
            if (_feedService.CreateFeed(feed))
                return CreatedAtAction("GetFeed", new { idFeed = feed.FeedId });

            return BadRequest();
        }


    }
}
