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

        public int InsertarCliente(Customers customers)
        {
            context.Customers.Add(customers);
            return context.SaveChanges();
        }

        public int UpdateCliente(Customers customers)
        {
            var registro = ObtenerPorId(customers.CustomerID);
            if (registro != null)
            {
                registro.CustomerID = customers.CustomerID;
                registro.CompanyName = customers.CompanyName;
                registro.ContactName = customers.ContactName;
                registro.ContactTitle = customers.ContactTitle;
                registro.Address = customers.Address;
            }
            return context.SaveChanges();
        }

    }
}
