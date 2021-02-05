using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.ServiceNewsfeeds.Interfaces
{
    public interface IUserService
    {
        //[OperationContract]
        IList<User> GetUsers();

        //[OperationContract]
        User RegisterUser(User user);

        //[OperationContract]
        User Login(string id, string password);

        //[OperationContract]
        bool UserNameExists(string username, string email);
    }
}
