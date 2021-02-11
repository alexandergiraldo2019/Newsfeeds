using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Interfaces
{
    public interface IFeedExternalServices
    {
        List<Feed> GetFeedsProviderNews(int IdProvider);
        List<Feed> GetFeedsProviderNews(string UrlProvider);
    }
}
