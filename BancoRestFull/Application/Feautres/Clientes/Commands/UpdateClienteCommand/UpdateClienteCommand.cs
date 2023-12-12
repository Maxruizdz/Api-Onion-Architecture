using Application.Exceptions;
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

namespace Application.Feautres.Clientes.Commands.UpdateClienteCommand
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public DateTime fecha_nacimiento { get; set; }

        public string telefono { get; set; }

        public string Email { get; set; }

        public string Direccion { get; set; }





    }


    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Cliente> _repositoryAsync;
        private readonly IMapper _mapper;




        public UpdateClienteCommandHandler(IRepositoryAsync<Cliente> repositoryAsync, IMapper mapper)
        {


            this._repositoryAsync = repositoryAsync;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        { var cliente= await _repositoryAsync.GetByIdAsync(request.id);


            if (cliente == null)
            {

                throw new KeyNotFoundException($"El id={request.id}   no pertenece a ningun cliente");


            }
            else { 
            
            cliente.telefono= request.telefono;
                cliente.nombre= request.nombre;
                cliente.apellido= request.apellido;
                cliente.Direccion= request.Direccion;
                cliente.Email= request.Email;
                cliente.fecha_nacimiento=request.fecha_nacimiento;

                await _repositoryAsync.UpdateAsync(cliente);

                return new Response<int>(cliente.id);
            
            
            
            }
            
        }
    }
}

   

