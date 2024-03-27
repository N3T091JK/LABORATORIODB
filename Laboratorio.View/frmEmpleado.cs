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
    public partial class frmEmpleado : Form
    {
        private List<Employee> _listado;
        Validaciones val = new Validaciones();
        public frmEmpleado()
        {
            InitializeComponent();
        }

        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            button1.Enabled = false;
            UpdateGrid();
            UpdateComboEstado();
            UpdateComboGenero();
        }
        private void UpdateGrid()
        {
            _listado = EmployeeBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.EmpleadoId,
                            Nombres = x.Nombre,
                            Apellido = x.Apellidos,
                            edades = x.Edad,
                            Dui = x.DUI,
                            correo = x.Correo,
                            Celula = x.NumCelular,
                            Direcciones = x.Direccion,
                            Estado = x.States.NomEstado,
                            Genero = x.Genders.NomGenero
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void UpdateComboEstado()
        {
            cboEstado.DisplayMember = "NomEstado";
            cboEstado.ValueMember = "EstadoId";
            cboEstado.DataSource = StateBL.Instance.SellecALL();
        }
        private void UpdateComboGenero()
        {
            cboGenero.DisplayMember = "NomGenero";
            cboGenero.ValueMember = "GeneroId";
            cboGenero.DataSource = GenderBL.Instance.SellecALL();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Employee entity = new Employee()
            {
                Nombre = txtNombre.Text.Trim(),
                Apellidos = txtApellido.Text.Trim(),
                Edad = Convert.ToInt32(txtEdad.Text),
                DUI = txtDui.Text.Trim(),
                NumCelular = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                EstadoId = (int)cboEstado.SelectedValue,
                GeneroId = (int)cboGenero.SelectedValue,

            };

            if (EmployeeBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                Limpiar();
            }
        }

        public void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtEdad.Clear();
            txtDui.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
        }
        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtApellido.Text) &&
                !string.IsNullOrEmpty(txtEdad.Text) &&
                !string.IsNullOrEmpty(txtDui.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(cboEstado.Text) &&
                !string.IsNullOrEmpty(cboGenero.Text);
            btnGuardar.Enabled = vr;
        }
        private void ValidarBuscar()
        {
           var vr = !string.IsNullOrEmpty(textBox1.Text);
            button1.Enabled = vr;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.Nombre.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtDui_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtDui_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void cboEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void cboGenero_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {

        }

        private void cboEstado_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
