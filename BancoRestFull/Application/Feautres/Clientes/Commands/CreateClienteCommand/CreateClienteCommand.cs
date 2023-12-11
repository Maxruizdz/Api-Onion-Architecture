using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Clientes.Commands.CreateClienteCommand
{
   public class CreateClienteCommand: IRequest<Response<int>>
    {

        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public string telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }



    } 
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repositoryAsync;

        private readonly IMapper _mapper;


        public CreateClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {

            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;



        }
        public async Task<Response<int>> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {

            var nuevo_registro = _mapper.Map<Cliente>(request);
            var data = await _repositoryAsync.AddAsync(nuevo_registro);
            return new Response<int>(data.id);
        }
    }
}
    

