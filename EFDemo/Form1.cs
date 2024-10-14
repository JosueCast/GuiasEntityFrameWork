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
            }
            dgvCustomers.DataSource = listaCliente;
        }
    }
}
