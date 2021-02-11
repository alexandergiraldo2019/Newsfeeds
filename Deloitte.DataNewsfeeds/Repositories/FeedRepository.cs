using Deloitte.DataNewsfeeds.Extensions;
using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Deloitte.DataNewsfeeds.Interfaces;

namespace Deloitte.DataNewsfeeds.Repositories
{
    public class FeedRepository : IFeedRepository
    {
        private IDbContext _context;
        public FeedRepository(IDbContext context)
        {
            _context = context;
        }

        public IList<Feed> GetFeeds()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[GetFeeds]";

                return this.ToList(command).ToList();
            }
        }


        public Feed GetFeed(int idFeed)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "exec [dbo].[GetFeed]";

                command.Parameters.Add(command.CreateParameter("@pFeedId", idFeed));

                return this.ToList(command).FirstOrDefault();
            }
        }


        public Feed CreateFeed(Feed feed)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SignUp";

                command.Parameters.Add(command.CreateParameter("@pFeedName", feed.FeedName));
                command.Parameters.Add(command.CreateParameter("@pFeedUrl", feed.ApiUrl));

                return this.ToList(command).FirstOrDefault();
            }
        }

        public List<Feed> GetFeedsByUser(string Login)
        {
            using (var command = _context.CreateCommand())
            {
                List<Feed> LUserFeeds = new List<Feed>();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "stpGetFeedsByUser";

                command.Parameters.Add(command.CreateParameter("@Login", Login));
                var record = command.ExecuteReader();
                Feed oFeed = null;

                while (record.Read())
                {
                    oFeed = new Feed();
                    oFeed.FeedId= record.GetInt32(0);
                    oFeed.FeedName = record.GetString(1);
                    oFeed.ApiUrl = record.GetString(2);
                    LUserFeeds.Add(oFeed);
                }

                return LUserFeeds;
            }
        }

        protected IEnumerable<Feed> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<Feed> items = new List<Feed>();
                while (record.Read())
                {
                    items.Add(Map<Feed>(record));
                }
                return items;
            }
        }

        protected TEntity Map<TEntity>(IDataRecord record)
        {
            var objT = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (record.HasColumn(property.Name) && !record.IsDBNull(record.GetOrdinal(property.Name)))
                    property.SetValue(objT, record[property.Name]);


            }
            return objT;
        }

    }
}
