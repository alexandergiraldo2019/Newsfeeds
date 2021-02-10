using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Interfaces
{
    public interface IFeedService
    {
        //[OperationContract]
        IList<Feed> GetFeeds();

        //[OperationContract]
        Feed GetFeed(int id);

        //[OperationContract]
        bool CreateFeed(Feed feed);

        // Develve los feed por usuario
        List<Feed> GetFeedsByUser(string Login);

    }
}
