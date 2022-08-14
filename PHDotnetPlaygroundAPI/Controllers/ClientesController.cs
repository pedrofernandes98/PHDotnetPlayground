using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PHDotnetPlaygroundAPI.Models;
using PHDotnetPlaygroundAPI.Services;

namespace PHDotnetPlaygroundAPI.Controllers
{
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private ILogger<ClientesController> _logger;
        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/clientes")]
        public IEnumerable<Cliente> Get()
        {
            return ClientesFactory.GetAll();
        }
    }
}