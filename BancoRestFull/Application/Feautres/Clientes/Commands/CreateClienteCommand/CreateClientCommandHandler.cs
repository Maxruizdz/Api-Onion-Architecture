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
    public class CreateClientCommandHandler : IRequestHandler<CreateClienteCommand, Response<int>>
    { private readonly IRepositoryAsync<Cliente> _repositoryAsync;

        private readonly IMapper _mapper;


        public CreateClientCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper) {
        
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
