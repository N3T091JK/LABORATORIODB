using Laboratorio.BussinesLogic;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio.View
{
    public partial class FrmProduct : Form
    {
        private List<Product> _listado;
        public FrmProduct()
        {
            InitializeComponent();
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            UpdateComboEstado();
            UpdateGrid();

        }
        private void UpdateGrid()
        {
            _listado = ProductBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.ProductoId,
                            NomProduct = x.NomProducto,
                            Estado = x.States.NomEstado,
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void UpdateComboEstado()
        {
            comboBox1.DisplayMember = "NomEstado";
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = StateBL.Instance.SellecALL();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product entity = new Product()
            {
                NomProducto = textBox1.Text.Trim(),
                EstadoId = (int)comboBox1.SelectedValue,

            };
            if (ProductBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = ProductBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.ProductoId,
                               NomProduct = x.NomProducto,
                               Estado = x.States.NomEstado,
                           };
            var query = busqueda.Where(x => x.NomProduct.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();
        }
    }
}