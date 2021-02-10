using Deloitte.DataNewsfeeds;
using Deloitte.DataNewsfeeds.Repositories;
using Deloitte.Domain;
using Deloitte.ServiceNewsfeeds.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;


namespace Deloitte.ServiceNewsfeeds.Services
{
    public class UserService : IUserService
    {
        private IConnectionFactory connectionFactory;
        private string _connectionString;

        public UserService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IList<User> GetUsers()
        {
            connectionFactory = ConnectionHelper.GetConnection(_connectionString);

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.GetUsers();
        }

        public User RegisterUser(User user)
        {
            connectionFactory = ConnectionHelper.GetConnection(_connectionString);

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.CreateUser(user);
        }


        public User Login(string id, string password)
        {
            connectionFactory = ConnectionHelper.GetConnection(_connectionString);

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.LoginUser(id, password);
        }

        public bool UserNameExists(string username, string email)
        {
            connectionFactory = ConnectionHelper.GetConnection(_connectionString);

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            var user = userRep.GetUserByUsernameOrEmail(username, email);
            return !(user != null && user.UserID > 0);

        }
    }

}
