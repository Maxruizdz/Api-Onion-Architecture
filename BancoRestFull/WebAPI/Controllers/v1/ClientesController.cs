using Application.Feautres.Clientes.Commands.CreateClienteCommand;
using Application.Feautres.Clientes.Commands.DeleteClienteCommand;
using Application.Feautres.Clientes.Commands.UpdateClienteCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
   
    public class ClientesController : BaseApiController
    {
        private readonly IMediator _mediator;


        public ClientesController(IMediator mediator) {
        
        
        _mediator= mediator ?? throw new ArgumentNullException(nameof(mediator));


        }
        [HttpPost]

        public async Task<ActionResult> Post(CreateClienteCommand command) {

          

            return Ok(await _mediator.Send(command));
        
        }
        [HttpPut("id")]
        public async Task<ActionResult> Put(int id, UpdateClienteCommand command)
        {
            if (id != command.id) {

                return BadRequest();
            
            }

            return Ok(await _mediator.Send(command));

        }
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id) { 
        
        
        return Ok(await _mediator.Send(new DeleteClienteCommand {id=id }));
        
        }




    }
    
}
