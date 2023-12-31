﻿using Application.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceExtensions
    {
        
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => {

                config.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReference>();
              
            
            });
         
            
            services.AddTransient(typeof(IPipelineBehavior<,>),  typeof(ValidatorBehaviour<,>));
         
        }

    }
}
