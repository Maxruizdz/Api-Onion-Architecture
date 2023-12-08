using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Cliente.Commands.CreateClienteCommand
{
    public class CreateClienteCommandValidator :AbstractValidator<CreateClienteCommand> 
    {

        


        public CreateClienteCommandValidator() { 
        
        RuleFor(p=>p.nombre).NotEmpty().WithMessage("{PropertyName} no puede estar vacio").MaximumLength(30).WithMessage("{PropertyName} no debe excede de {MaxLength} caracteres") ;
          
        RuleFor(p => p.apellido).NotEmpty().WithMessage("{PropertyName} no puede estar vacio").MaximumLength(30).WithMessage("{PropertyName} no debe excede de {MaxLength} caracteres");


        RuleFor(p => p.fecha_nacimiento).NotEmpty().WithMessage("Fecha de nacimiento no puede estar vacio");


        RuleFor(p => p.telefono).NotEmpty().WithMessage("{PropertyName} no puede estar vacio").Matches(@"^\d(4)-\d(4)$").WithMessage("{PropertyName} debe cumplir el formato 0000-0000 ").
                MaximumLength(9).WithMessage("{PropertyName} no debe excede de {MaxLength} caracteres");

            RuleFor(p => p.Email).NotEmpty().WithMessage("{PropertyName} no puede estar vacio").EmailAddress().WithMessage("{PropertyName} debe ser una direccion de email valida.").MaximumLength(100).WithMessage("{PropertyName} no debe excede de {MaxLength} caracteres");

            RuleFor(p => p.Direccion).NotEmpty().WithMessage("{PropertyName} no puede estar vacio").WithMessage("").MaximumLength(120).WithMessage("{PropertyName} no debe excede de {MaxLength} caracteres");


        }


    } 
}
