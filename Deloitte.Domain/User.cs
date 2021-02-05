using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.Domain
{
    public class User
    {
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        //public class UserResponse
        //{
        //    public string Code { get; set; }

        //    public string ValidationMessage { get; set; }

        //    public List<Deloitte.Domain.Feed> FeedsList { get; set; }
        //}
    }
}
