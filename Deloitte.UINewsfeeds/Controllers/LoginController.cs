using Deloitte.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.UINewsfeeds.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private Deloitte.ServiceNewsfeeds.Services.UserService _userService = new ServiceNewsfeeds.Services.UserService();

        [HttpGet]
        public User Get(string id, string password)
        {
            User _user = _userService.Login(id, password);
            return (_user);
        }
    }
}
