using Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feautres.Clientes.Queries.GetClient
{
    public class GetAllClienteQueriesParameter: RequestParameter
    {
        public string? nombre { get; set; }
        public string? apellido{ get; set; } 


    }
}
