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
        public ActionResult<IEnumerable<Cliente>> Get()
        {
            return ClientesFactory.GetAll();
        }

        [HttpGet]
        [Route("/clientes/{id}")]
        public ActionResult<Cliente> GetById(int id)
        {
            if(id <= 0)
                return BadRequest("Deve ser enviado o Id do cliente a ser pesquisado");

            return ClientesFactory.GetById(id) != null ? 
                    ClientesFactory.GetById(id) : BadRequest($"Não foi encontrado nenhum registro com o Id: {id}");
        }

        [HttpPost]
        [Route("/clientes")]
        public ActionResult<Cliente> Post([FromBody] Cliente cliente)
        {
            return ClientesFactory.Add(cliente);
        }

        [HttpPut]
        [Route("/clientes/{id}")]
        public ActionResult<Cliente> Put(int id, [FromBody] Cliente cliente)
        {
            if(id <= 0)
                return BadRequest("Deve ser enviado o Id do Cliente a ser atualizado");

            return ClientesFactory.Update(id, cliente);
        }

        [HttpDelete]
        [Route("/clientes/{id}")]
        public ActionResult Delete(int id)
        {
            if(id <= 0)
                return BadRequest("Deve ser enviado o Id do Cliente a ser atualizado");

            if(ClientesFactory.Remove(id))
                return Ok("Cliente removido com sucesso");

            return StatusCode(500);
        }
    }
}