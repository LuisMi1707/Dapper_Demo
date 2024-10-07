using AccesoDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DapperDemo
{
    public partial class Form1 : Form
    {
        CustomerRepository customerR = new CustomerRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnObtenerTodo_Click(object sender, EventArgs e)
        {
            var cliente = customerR.ObtenerTodo();
            dgvCustomers.DataSource = cliente; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnObtenerID_Click(object sender, EventArgs e)
        {
            var Cliente = customerR.ObtenerPorID(tboxObtenerID.Text);
            dgvCustomers.DataSource = new List<Customers> { Cliente };
        }

        private Customers CrearCliente()
        {
            var nuevo = new Customers
            {
                CustomerID = txbCustomerID.Text,
                CompanyName = txbCompanyName.Text,
                ContactName = txbContactName.Text,
                ContactTitle = txbContactTitle.Text,
                Address = txbAddress.Text
            };
            return nuevo;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = CrearCliente();
            var insertado = customerR.insertarCliente(nuevoCliente);
            MessageBox.Show($"{insertado} registros insertados");
        }
    }
    
}
