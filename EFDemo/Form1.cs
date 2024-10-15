using AccesoDato;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CustomerRepository cr = new CustomerRepository();

        private void btnCargar_Click(object sender, EventArgs e)
        {
            var cliente = cr.ObtenerTodo();
            dgvCustomers.DataSource = cliente;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            var id = txtObtenerTodos.Text; // Suponiendo que este es el ID que quieres buscar
            var cliente = cr.ObtenerPorId(id);
            // Crear una lista para que el DataGridView acepte el DataSource
            var listaCliente = new List<Customers>();
            if (cliente != null)
            {
                listaCliente.Add(cliente);
                LoadForm(cliente);
            }
            dgvCustomers.DataSource = listaCliente;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            var resultado = cr.InsertarCliente(cliente);
            MessageBox.Show($"Se inserto  {resultado}");

        }

        private Customers CrearCliente()
        {
            var cliente = new Customers
            {
                CustomerID = txtCustomersID.Text,
                CompanyName = txtCompanyName.Text,
                ContactName = txtContactName.Text,
                ContactTitle = txtContactTittle.Text,
                Address = txtAddres.Text,


            };
            return cliente;
        }

        private void LoadForm(Customers customers)
        {

            txtCustomersID.Text = customers.CustomerID;
            txtCompanyName.Text = customers.CompanyName;
            txtContactName.Text = customers.ContactName;
            txtContactTittle.Text = customers.ContactTitle;
            txtAddres.Text = customers.Address; 
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            var cliente = CrearCliente();
            cr.UpdateCliente(cliente);
            var resultado = cr.ObtenerPorId(cliente.CustomerID);
            List<Customers> lista1 = new List<Customers> { resultado };
            dgvCustomers.DataSource = lista1;
        }
    }
}
