using Application.DTOs;
using Application.Interfaces;
using Application.Specification;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        private readonly IDistributedCache _distributedCache;
        private readonly IMapper _mapper;

        public GetAllClienteQueriesHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper, IDistributedCache distributedCache)
        {
            this.repositoryAsync = repositoryAsync;
            this._mapper = mapper;
            _distributedCache = distributedCache;
        }


        public async Task<PagedResponse<List<ClienteDto>>> Handle(GetAllClienteQueries request, CancellationToken cancellationToken)
        {
            var cacheKey = $"ListadoClientes_{request.PageSize}_{request.PageNumber}_{request.Nombre}_{request.Apellido}";
            string SerializedListadoClientes;
            var listadoClientes = new List<Cliente>();
            var redisListadoClientes = await _distributedCache.GetAsync(cacheKey);
            if (redisListadoClientes != null)
            {

                SerializedListadoClientes = Encoding.UTF8.GetString(redisListadoClientes);
                listadoClientes = JsonConvert.DeserializeObject<List<Cliente>>(SerializedListadoClientes);

            }
            else {
                listadoClientes = await repositoryAsync.ListAsync(new PageClientesSpecification(request.PageSize, request.PageNumber, request.Nombre, request.Apellido));
                SerializedListadoClientes= JsonConvert.SerializeObject(listadoClientes);
                redisListadoClientes = Encoding.UTF8.GetBytes(SerializedListadoClientes);

                var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(DateTime.Now.AddMinutes(10)).SetSlidingExpiration(TimeSpan.FromMinutes(2));


                await _distributedCache.SetAsync(cacheKey,redisListadoClientes, options);


            }
          

            var clienteDtos = _mapper.Map<List<ClienteDto>>(listadoClientes);


            return new PagedResponse<List<ClienteDto>>(clienteDtos, request.PageNumber, request.PageSize);






        }
    }
}
