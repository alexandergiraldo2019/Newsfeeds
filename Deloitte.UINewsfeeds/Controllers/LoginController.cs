﻿using Deloitte.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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
        [AllowAnonymous]
        public async Task<IActionResult> Get(string id, string password)
        {
            password = EcriptarString(password);
            User _user = _userService.Login(id, password);
            if (_user != null)
            {
                return Ok(new { token = GenerarTokenJWT(_user) });
            }
            else
            {
                return Unauthorized();
            }
        }
        private string GenerarTokenJWT(User _user)
        {
            // CREAMOS EL HEADER //
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_dataConfiguration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);

            // CREAMOS LOS CLAIMS //
            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, _user.UserID.ToString()),
                new Claim("nombre", _user.UserName),
                new Claim("login", _user.Login)
                //new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.Email),
                //new Claim(ClaimTypes.Role, usuarioInfo.Rol)
            };

            // CREAMOS EL PAYLOAD //
            var _Payload = new JwtPayload(
                    issuer: _dataConfiguration["JWT:Issuer"],
                    audience: _dataConfiguration["JWT:Audience"],
                    claims: _Claims,
                    // definimos desde que fecha y hora es valido
                    notBefore: DateTime.UtcNow,
                    // Exipra a los 15 minutos
                    expires: DateTime.UtcNow.AddMinutes(15)
                );

            // GENERAMOS EL TOKEN //
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }

        private string EcriptarString(string Cadena)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(Cadena);
            result = Convert.ToBase64String(encryted);
            return result;

        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private string DesencriptarString(string Cadena)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(Cadena);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}
