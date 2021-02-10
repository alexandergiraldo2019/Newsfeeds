using Deloitte.Domain;
using Deloitte.ServiceNewsfeeds.Interfaces;
using Deloitte.ServiceNewsfeeds.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace Deloitte.ServiceNewsfeeds.ExternalServices
{
    public class NewsFeedService : INewsFeedService
    {
        private IConfiguration _DataConfiguration;
        private IFeedService _FeedService;

        public NewsFeedService(IConfiguration dataConfiguration, IFeedService feedService)
        {
            _DataConfiguration = dataConfiguration;
            _FeedService = feedService;
        }

        public IList<NewsFeed> GetNewsFeeds()
        {
            
            ServiceAction ServicioAPI = new ServiceAction();
            List<Feed> FeedList = new List<Feed>();
            List<News> NewsList;
            List<NewsFeed> NewsFeedList = new List<NewsFeed>();
            NewsFeed NewReg ;

            FeedList = (List<Feed>)_FeedService.GetFeeds();

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

            FeedList = new List<Feed>();
            NewsFeedList = new List<NewsFeed>();

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
                NewsList.Add(new News { IdNews = Secuence, Title  = "Title " + Secuence.ToString() , URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString(), DateNews = "2020-02-09" });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString(), DateNews = "2020-02-09" });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString(), DateNews = "2020-02-09" });
                Secuence++;
                NewsList.Add(new News { IdNews = Secuence, Title = "Title " + Secuence.ToString(), URLImage = "https://www.google.com/imagen.jpg", URLNews = "https://www.google.com/noticia1.html", Author = "Author " + Secuence.ToString(), Content = "Lorem ipsum " + Secuence.ToString(), Description = "Lorem Ipsum Ipsum " + Secuence.ToString(), DateNews = "2020-02-09" });
                Secuence++;

                NewReg.FeedData = item;
                NewReg.NewsTop = NewsList;
                NewsFeedList.Add(NewReg);
            }

            return NewsFeedList;
        }

        public List<News> GetNews()
        {
            List<News> news = new List<News>();
            //Devuelva los feeds del usuario
            string url = "https://rss.nytimes.com/services/xml/rss/nyt/MostViewed.xml";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                News source = new News()
                {
                    IdNews = item.Id.FirstOrDefault(),
                    Title = item.Title.Text,
                    DateNews = item.PublishDate.DateTime.ToShortDateString(),
                    URLNews = item.Links.FirstOrDefault().Uri.OriginalString,
                    Description = item.Summary.Text
                };
                news.Add(source);
            }
            return news;
        }

        public List<NewsFeed> GetNewsFeedsByUser(string login)
        {
            List<NewsFeed> newsFeeds = new List<NewsFeed>();
            List<Feed> feeds = _FeedService.GetFeedsByUser(login);
            foreach (var feed in feeds)
            {
                NewsFeed newsFeed = new NewsFeed();
                List<News> news = new List<News>();
                XmlReader reader = XmlReader.Create(feed.ApiUrl);
                SyndicationFeed feedXml = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feedXml.Items)
                {
                    News source = new News()
                    {
                        IdNews = item.Id.FirstOrDefault(),
                        Title = item.Title.Text,
                        DateNews = item.PublishDate.DateTime.ToShortDateString(),
                        URLNews = item.Links.FirstOrDefault().Uri.OriginalString,
                        Description = item.Summary.Text
                    };
                    news.Add(source);
                }
                newsFeed.FeedData = feed;
                newsFeed.NewsTop = news.Take(10).ToList();
            }
            return newsFeeds;
        }
    }
}
