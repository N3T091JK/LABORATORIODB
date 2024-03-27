using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio.Entities;
using Laboratorio.BussinesLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Remoting.Contexts;

namespace Laboratorio.View
{
    public partial class frmLaboratorio : Form
    {
        private List<Laboratory> _listado;
        Validaciones val = new Validaciones();
        public frmLaboratorio()
        {
            InitializeComponent();
        }

        private void frmLaboratorio_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            btnGuardar.Enabled = false;
            btnBuscar.Enabled = false;
        }

        private void UpdateGrid()
        {
            _listado = LaboratoryBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.NumRegistro,
                            nombres = x.Nombre,
                            direccion = x.Direccion,
                            telefono= x.Telefono,
                            Correo = x.correo,
                            administrador = x.Administrador
                        };
            dataGridView2.DataSource = query.ToList();
        }
        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                !string.IsNullOrEmpty(txtAdmin.Text);
            btnGuardar.Enabled = vr;
        }
        private void ValidarBuscar()
        {
            var vr = !string.IsNullOrEmpty(textBox5.Text);
            btnBuscar.Enabled = vr;
        }
        public void Limpiar()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtAdmin.Clear();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Laboratory entity = new Laboratory()
            {
                Nombre = txtNombre.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                correo = txtCorreo.Text.Trim(),
                Administrador = txtAdmin.Text.Trim(),
            };

            if (LaboratoryBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                Limpiar();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.Nombre.ToLower().Contains(textBox5.Text.ToLower())).ToList();
            dataGridView2.DataSource = query;
        }
    }
}
