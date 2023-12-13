using Application.DTOs;
using Application.Feautres.Clientes.Commands.CreateClienteCommand;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class GeneralProfile:Profile
    {


        public GeneralProfile() {

            CreateMap< Cliente, ClienteDto>();

            CreateMap<CreateClienteCommand,Cliente>();
        
        }
    }
}
