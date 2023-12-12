using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Clientes.Commands.DeleteClienteCommand
{
    public class DeleteClienteCommand :  IRequest<Response<int>>
    {


        public int id { get; set; }
    }


    public class DeleteClientCommandHandler : IRequestHandler<DeleteClienteCommand, Response<int>>

        
    {
       private readonly IRepositoryAsync<Cliente> _repositoryAsync;

        public DeleteClientCommandHandler(IRepositoryAsync<Cliente> repository) {
        
        
        this._repositoryAsync = repository;
        
        }
        public async  Task<Response<int>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryAsync.GetByIdAsync(request.id);

            if (cliente == null)
            {

                throw new KeyNotFoundException($"El id={request.id}   no pertenece a ningun cliente");


            }
            else
            {


                await _repositoryAsync.DeleteAsync(cliente);

                return new Response<int>(cliente.id);



            }
        }
    }
}
