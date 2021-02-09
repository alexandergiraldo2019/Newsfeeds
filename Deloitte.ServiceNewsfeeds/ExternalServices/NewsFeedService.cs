using Deloitte.Domain;
using Deloitte.ServiceNewsfeeds.Interfaces;
using Deloitte.ServiceNewsfeeds.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.ExternalServices
{
    public class NewsFeedService : INewsFeedService
    {
        private IConfiguration _DataConfiguration;

        public NewsFeedService(IConfiguration dataConfiguration)
        {
            _DataConfiguration = dataConfiguration;
        }

        public IList<NewsFeed> GetNewsFeeds()
        {
            FeedService serviceFeed = new FeedService(_DataConfiguration);
            ServiceAction ServicioAPI = new ServiceAction();
            List<Feed> FeedList = new List<Feed>();
            List<News> NewsList;
            List<NewsFeed> NewsFeedList = new List<NewsFeed>();
            NewsFeed NewReg ;

            FeedList = (List<Feed>)serviceFeed.GetFeeds();

            foreach (var item in FeedList)
            {
                NewReg = new NewsFeed();

                NewsList = new List<News>();

                // Obtain news from API
                var Result = ServicioAPI.Get<List<News>>(item.ApiUrl, "", "", "", "");

                //NewsList = (List<News>)Result.Result;

                NewReg.FeedData = item;
                NewReg.NewsTop = NewsList;
                NewsFeedList.Add(NewReg);
            }

            FeedList.Add(new Feed { FeedId = 1, FeedName = "Google", ApiUrl = "https://news.google.com" });
            FeedList.Add(new Feed { FeedId = 2, FeedName = "Yahoo", ApiUrl = "https://news.yahoo.com" });
            FeedList.Add(new Feed { FeedId = 3, FeedName = "ApiNews", ApiUrl = "https://www.apinews.com" });
            FeedList.Add(new Feed { FeedId = 4, FeedName = "Facebook", ApiUrl = "https://news.facebook.com" });

            int Secuence = 0;

            foreach (var item in FeedList)
            {
                NewReg = new NewsFeed();

                NewsList = new List<News>();

                // Obtain news from API
                NewsList.Add(new News { IdNews = Secuence, Title  = "Title " + Secuence.ToString() , URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString() });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString() });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString() });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString() });
                Secuence++;

                NewReg.FeedData = item;
                NewReg.NewsTop = NewsList;
                NewsFeedList.Add(NewReg);
            }

            return NewsFeedList;
        }
    }
}
