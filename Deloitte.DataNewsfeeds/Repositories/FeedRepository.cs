using Deloitte.DataNewsfeeds.Extensions;
using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Deloitte.DataNewsfeeds.Repositories
{
    public class FeedRepository : Repository<Feed>
    {
        private DbContext _context;
        public FeedRepository(DbContext context)
            : base(context)
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


        public Feed GetFeed( int idFeed)
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



    }
}
