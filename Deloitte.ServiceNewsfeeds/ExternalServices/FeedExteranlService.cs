using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.ExternalServices
{
    public class FeedExteranlService
    {

        public List<Feed> GetFeedsProviderNews( int IdProvider)
        {
            List<Feed> FeedList = new List<Feed>();

            FeedList.Add(new Feed { FeedId = 1, FeedName = "Noticia 1", ApiUrl = "https://www.google.com/noticia1.html" });
            FeedList.Add(new Feed { FeedId = 2, FeedName = "Noticia 2", ApiUrl = "https://www.google.com/noticia2.html" });
            FeedList.Add(new Feed { FeedId = 3, FeedName = "Noticia 3", ApiUrl = "https://www.google.com/noticia3.html" });
            FeedList.Add(new Feed { FeedId = 4, FeedName = "Noticia 4", ApiUrl = "https://www.google.com/noticia4.html" });

            return FeedList;
        }

        public List<Feed> GetFeedsProviderNews(string UrlProvider)
        {
            ServiceAction ServicioAPI = new ServiceAction();
            List<Feed> FeedList = new List<Feed>();


            FeedList.Add(new Feed { FeedId = 1, FeedName = "Noticia 1", ApiUrl = "https://www.google.com/noticia1.html" });
            FeedList.Add(new Feed { FeedId = 2, FeedName = "Noticia 2", ApiUrl = "https://www.google.com/noticia2.html" });
            FeedList.Add(new Feed { FeedId = 3, FeedName = "Noticia 3", ApiUrl = "https://www.google.com/noticia3.html" });
            FeedList.Add(new Feed { FeedId = 4, FeedName = "Noticia 4", ApiUrl = "https://www.google.com/noticia4.html" });


            var Response = ServicioAPI.Get<Response>(UrlProvider,"","","","");

            //FeedList = Response.Result;


            return FeedList;
        }



    }
}
