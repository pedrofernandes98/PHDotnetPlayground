using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PHDotnetPlaygroundAPI.Models;
using PHDotnetPlaygroundAPI.Services;
using PHDotnetPlaygroundAPI.Services.Auth;

namespace PHDotnetPlaygroundAPI.Controllers
{
    public class UserAuth
    {
        public string User { get; set; }

        public string Password { get; set; }
    }

    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> _logger;

        private readonly IJwtToken _JwtToken;
        public AuthController(ILogger<AuthController> logger, IJwtToken jwtToken)
        {
            _logger = logger;
            _JwtToken = jwtToken;
        }


        [HttpPost]
        [Route("/auth")]
        [AllowAnonymous]
        public ActionResult<Cliente> Post([FromBody] UserAuth userAuth)
        {
            if(userAuth == null || (string.IsNullOrEmpty(userAuth.User)) || (string.IsNullOrEmpty(userAuth.Password)) )
                return BadRequest("Por favor, preencha o usuário e senha");

            var authencatedCliente = new ClienteAuth(_JwtToken).Auth(userAuth.User, userAuth.Password);

            if(authencatedCliente == null)
                return BadRequest("Usuário ou senha inválidos");

            authencatedCliente.Token = _JwtToken.GenerateToken(authencatedCliente);

            return authencatedCliente;
        }

        
    }
}