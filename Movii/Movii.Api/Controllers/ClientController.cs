using System;
using System.Threading.Tasks;
using Movii.Api.BindingModels;
using Movii.Api.Validation;
using Movii.Api.ViewModels;
using Movii.Data.Sql;
using Movii.Data.Sql.DAO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movii.Api.Mappers;
using Movii.IServices.Client;

namespace Movii.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]

    public class ClientController : Controller
    {
        private readonly MoviiDbContext _context;
        private readonly IClientService _clientService;

        public ClientController(MoviiDbContext context,IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Client.ToListAsync();
        }

        [HttpGet("{clientId:min(1)}", Name = "GetClientById")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            var client = await _clientService.GetClientByClientId(clientId);
            
            if (client != null)
            {
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }

            return NotFound();
        }

        [HttpGet("name/{clientName}", Name = "GetClientByClientName")]
        public async Task<IActionResult> GetClientByClientName(string clientName)
        {
            var client = await _clientService.GetClientByClientName(clientName);
            if (client != null)
            {
                return Ok(ClientToClientViewModelMapper.ClientToClientViewModel(client));
            }
            return NotFound();
        }

        [ValidateModel]
        public async Task<IActionResult> Post([FromBody] IServices.Requests.CreateClient createClient)
        {
            var client = await _clientService.CreateClient(createClient);
            return Created(client.ClientId.ToString(),ClientToClientViewModelMapper.ClientToClientViewModel(client)) ;
        }
        
        [ValidateModel]
        [HttpPut("{clientId:min(1)}", Name = "EditClient")]
        public async Task<IActionResult> EditClient([FromBody] IServices.Requests.EditClient editClient, int clientId)
        {
            await _clientService.EditClient(editClient, clientId);
            
            return NoContent();
        }
        
        [HttpPatch("{clientId:min(1)}/address", Name = "UpdateClientAddress")]
        public async Task<IActionResult> UpdateClientAddress(int clientId, [FromBody] IServices.Requests
            .UpdateClientAddress client)
        {
            await _clientService.UpdateClientAddress(client, clientId);
            return NoContent();
        }

        [HttpDelete("{clientId:min(1)}", Name = "RemoveClient")]
        public async Task<IActionResult> RemoveClient(int clientId)
        {
            await _clientService.RemoveClient(clientId);
            return NoContent();
        }
    }
}
