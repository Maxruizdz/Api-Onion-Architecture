using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Clientes.Queries.GetClient
{
    public class GetAllClienteQueries : IRequest<PagedResponse<List<ClienteDto>>> {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }
    }

    public class GetAllClienteQueriesHandler : IRequestHandler<GetAllClienteQueries, PagedResponse<List<ClienteDto>> >{

        private readonly IRepositoryAsync<Cliente> repositoryAsync;

        private readonly IMapper _mapper;

        public GetAllClienteQueriesHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }


        public async Task<PagedResponse<List<ClienteDto>>> Handle(GetAllClienteQueries request, CancellationToken cancellationToken)
        {
            var clientes = await repositoryAsync.ListAsync(new PageClientesSpecification(request.PageSize, request.PageNumber, request.Nombre, request.Apellido));

            var clienteDtos = _mapper.Map<List<ClienteDto>>(clientes);


            return new PagedResponse<List<ClienteDto>>(clienteDtos, request.PageNumber, request.PageSize);






        }
    }
}
