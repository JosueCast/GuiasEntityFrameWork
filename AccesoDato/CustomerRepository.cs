using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDato
{
    public class CustomerRepository
    {
        NorthwindEntities context = new NorthwindEntities();

        public List<Customers> ObtenerTodo()
        {
            var cliente = from custM in context.Customers select custM;
            return cliente.ToList();

        }
        public Customers ObtenerPorId(string id)
        {
            return context.Customers.Find(id);
        }


    }
}
