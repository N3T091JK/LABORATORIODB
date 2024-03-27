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
    public partial class frmEstado : Form
    {
        private List<State> _listado;
        Validaciones val = new Validaciones();
        public frmEstado()
        {
            InitializeComponent();
        }

        private void FrmEstado_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            btnGuardar.Enabled = false;
        }
        private void UpdateGrid()
        {
            _listado = StateBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            Id = x.EstadoId,
                            Nombres = x.NomEstado

                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            State entity = new State()
            {
                NomEstado = txtEstado.Text.Trim(),
            };
            if (StateBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
            txtEstado.Clear();
        }

        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(txtEstado.Text);
            btnGuardar.Enabled = vr;
        }
        private void txtEstado_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtEstado_KeyPress(object sender, KeyPressEventArgs e)
        {

            val.SoloLetras(e);
        }

        private void txtEstado_Validated(object sender, EventArgs e)
        {
          
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
    }
}
