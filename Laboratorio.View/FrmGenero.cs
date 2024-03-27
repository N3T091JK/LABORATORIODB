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
    public partial class frmGenero : Form
    {
        private List<Gender> _listado;
        public frmGenero()
        {
            InitializeComponent();
        }

        private void FrmGender_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            btnGuardar.Enabled = false;
        }
        private void UpdateGrid()
        {
            _listado = GenderBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.GeneroId,
                            Generos = x.NomGenero

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Gender entity = new Gender()
            {
                NomGenero = txtGenero.Text.Trim(),
            };
            if (GenderBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
            txtGenero.Clear();
            
        }
        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(txtGenero.Text);
            btnGuardar.Enabled = vr;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtGenero_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }
    }
}
