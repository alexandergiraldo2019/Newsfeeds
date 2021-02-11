using Deloitte.DataNewsfeeds;
using Deloitte.DataNewsfeeds.Interfaces;
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
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public IList<User> GetUsers()
        {
            return _UserRepository.GetUsers();
        }

        public User RegisterUser(User user)
        {
            return _UserRepository.CreateUser(user);
        }


        public User Login(string id, string password)
        {
            return _UserRepository.LoginUser(id, password);
        }

        public bool UserNameExists(string username, string email)
        {
            var user = _UserRepository.GetUserByUsernameOrEmail(username, email);
            return !(user != null && user.UserID > 0);

        }
    }
}
