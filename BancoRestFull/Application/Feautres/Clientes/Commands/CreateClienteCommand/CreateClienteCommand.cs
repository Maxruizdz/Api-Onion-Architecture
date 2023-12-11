using Application.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;



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

    
}
