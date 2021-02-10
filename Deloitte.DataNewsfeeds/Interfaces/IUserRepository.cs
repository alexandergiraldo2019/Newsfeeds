using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deloitte.DataNewsfeeds.Interfaces
{
    public interface IUserRepository
    {
        IList<User> GetUsers();
        User CreateUser(User user);
        User LoginUser(string id, string password);
        User GetUserByUsernameOrEmail(string username, string email);
    }
}
