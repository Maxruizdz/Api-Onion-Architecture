using Application.DTOs;
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

namespace Application.Feautres.Clientes.Queries.GetClienteByid
{
    public class GetClienteByidQueries : IRequest<Response<ClienteDto>>
    {
        public int id { get; set; }



    }
    public class GetClientByidQueriesHandler : IRequestHandler<GetClienteByidQueries, Response<ClienteDto>>
    {

        private readonly IRepositoryAsync<Cliente> repositoryAsync;

        private readonly IMapper _mapper;

        public GetClientByidQueriesHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async  Task<Response<ClienteDto>> Handle(GetClienteByidQueries request, CancellationToken cancellationToken)
        {  var cliente_buscado= await repositoryAsync.GetByIdAsync(request.id);


            var clienteDto= _mapper.Map<ClienteDto>(cliente_buscado);

            return new Response<ClienteDto>(clienteDto);
        }
    }
}
