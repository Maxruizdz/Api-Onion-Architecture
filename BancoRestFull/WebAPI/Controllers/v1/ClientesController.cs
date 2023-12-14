using Application.Feautres.Clientes.Commands.CreateClienteCommand;
using Application.Feautres.Clientes.Commands.DeleteClienteCommand;
using Application.Feautres.Clientes.Commands.UpdateClienteCommand;
using Application.Feautres.Clientes.Queries.GetClient;
using Application.Feautres.Clientes.Queries.GetClienteByid;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
   
    public class ClientesController : BaseApiController
    {
        private readonly IMediator _mediator;


        public ClientesController(IMediator mediator) {
        
        
        _mediator= mediator ?? throw new ArgumentNullException(nameof(mediator));


        }
        
        [HttpGet]

        public async Task<ActionResult> GetCliente([FromQuery]GetAllClienteQueriesParameter queries) {
            


            return Ok(await _mediator.Send(new GetAllClienteQueries { PageNumber= queries.PageNumber,
                PageSize= queries.PageSize,
                Nombre= queries.nombre ,
                Apellido= queries.apellido}));






        }


        [HttpGet("id")]

        public async Task<ActionResult> GetClienteId(int id) {


            return Ok(await _mediator.Send(new GetClienteByidQueries { id= id}));



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
