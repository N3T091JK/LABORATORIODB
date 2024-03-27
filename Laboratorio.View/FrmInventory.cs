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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Laboratorio.View
{
    public partial class FrmInventory : Form
    {
        private List<Inventory> _listado;
        public FrmInventory()
        {
            InitializeComponent();
        }
        private void UpdateGrid()
        {
            _listado = InventoryBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.InventoryId,
                            ProductoId = x.Products.NomProducto,
                            Cantidades = x.Cantidad,
                            CompraDetalle = x.PurchaseDetails.Cantidad,
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NomProducto";
            comboBox1.ValueMember = "ProductId";
            comboBox1.DataSource = ProductBL.Instance.SellecALL();
        }
        private void UpdateCombo2()
        {
            comboBox2.DisplayMember = "Cantidad";
            comboBox2.ValueMember = "CompraDetalleId";
            comboBox2.DataSource = PurchaseDetailBL.Instance.SellecALL();
        }

        private void FrmInventory_Load(object sender, EventArgs e)
        {
            UpdateCombo();
            UpdateCombo2();
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Inventory entity = new Inventory()
            {

                Cantidad = Convert.ToInt32(textBox1.Text),
                ProductoId = (int)comboBox1.SelectedValue,
            };

            if (InventoryBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = InventoryBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.InventoryId,
                               ProductoId = x.Products.NomProducto,
                               Cantidades = x.Cantidad,
                               CompraDetalle = x.PurchaseDetails.Cantidad,
                           };

            var query = busqueda.Where(x => x.Cantidades.ToString().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();





        }
    }
}
