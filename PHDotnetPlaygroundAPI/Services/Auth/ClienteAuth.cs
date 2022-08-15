using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PHDotnetPlaygroundAPI.Models;

namespace PHDotnetPlaygroundAPI.Services.Auth
{
    public class ClienteAuth
    {
        
        public ClienteAuth(IJwtToken jwtToken)
        {
            _jwtToken = jwtToken;
        }

        private readonly IJwtToken _jwtToken;
        public Cliente Auth(string user, string password)
        {
            var authCliente = ClientesFactory.ValidateUserPassword(user, password);
            
            if(authCliente == null)
                return null;

            authCliente.Token = _jwtToken.GenerateToken(authCliente);

            return authCliente;
        }
    }
}