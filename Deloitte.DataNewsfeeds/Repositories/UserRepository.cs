using Deloitte.DataNewsfeeds.Extensions;
using Deloitte.DataNewsfeeds.Interfaces;
using Deloitte.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Deloitte.DataNewsfeeds.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext _context;
        public UserRepository(DbContext context)
        {
            _context = context;
        }


        public IList<User> GetUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[GetUsers]";

                return this.ToList(command).ToList();
            }
        }

        public User CreateUser(User user)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SignUp";

                //command.Parameters.Add(command.CreateParameter("@pFirstName", user.FirstName));
                //command.Parameters.Add(command.CreateParameter("@pLastName", user.LastName));
                command.Parameters.Add(command.CreateParameter("@pUserName", user.UserName));
                command.Parameters.Add(command.CreateParameter("@pPassword", user.Password));
                //command.Parameters.Add(command.CreateParameter("@pEmail", user.Email));

                return this.ToList(command).FirstOrDefault();


            }

        }

        public User LoginUser(string id, string password)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "stpUsersValidation";

                command.Parameters.Add(command.CreateParameter("@Login", id));
                command.Parameters.Add(command.CreateParameter("@Password", password));

                return this.ToList(command).FirstOrDefault();
            }
        }


        public User GetUserByUsernameOrEmail(string username, string email)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetUserByUsernameOrEmail";

                command.Parameters.Add(command.CreateParameter("@pUsername", username));
                command.Parameters.Add(command.CreateParameter("@pEmail", email));

                return this.ToList(command).FirstOrDefault();
            }
        }
        protected IEnumerable<User> ToList(IDbCommand command)
        {
            using (var record = command.ExecuteReader())
            {
                List<User> items = new List<User>();
                while (record.Read())
                {
                    items.Add(Map<User>(record));
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
