using Deloitte.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.UINewsfeeds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private IConfiguration _dataConfiguration;
        private Deloitte.ServiceNewsfeeds.Services.UserService _userService;

        public LoginController(IConfiguration dataConfiguration)
        {
            _dataConfiguration = dataConfiguration;
            _userService = new ServiceNewsfeeds.Services.UserService(_dataConfiguration);
        }

        [HttpGet]
        public User Get(string id, string password)
        {
            User _user = _userService.Login(id, password);
            return (_user);
        }
    }
}
