using Ardalis.Specification;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Specification
{
    public class PageClientesSpecification: Specification<Cliente>
    {

        public PageClientesSpecification(int pagesize, int PageNumbre, string nombre, string apellido) {

            Query.Skip((pagesize-1)*PageNumbre).Take(pagesize);


            if (!String.IsNullOrEmpty(nombre)) {

                Query.Search(p=>p.nombre , "%" + nombre + "%");
            
            }
            if (!String.IsNullOrEmpty(apellido))
            {

                Query.Search(p => p.apellido, "%" + apellido + "%");

            }



        }




    }
}
