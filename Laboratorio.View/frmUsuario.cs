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
    public partial class frmUsuario : Form
    {
        private List<Employee> _listado;
        private List<User> _listado2;
        Validaciones val = new Validaciones();
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
            UpdateGrid();
            UpdateGrid2();
            UpdateComboEstado();
            UpdateComboTipoUsuario();
        }
        private void UpdateGrid2()
        {
            _listado2 = UserBL.Instance.SellecALL();
            var query = from x in _listado2
                        select new
                        {
                            id = x.UsuarioId,
                            Nombres = x.NomUsuario,
                            Password = x.Password,
                            Empleado = x.Employees.Nombre,
                            Estado = x.States.NomEstado,
                            TipoUsuario = x.UserTypes.NomTipoUsuario
                        };
            dataGridView1.DataSource = query.ToList();
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
                        };
            dataGridView2.DataSource = query.ToList();
        }
        private void UpdateComboEstado()
        {
            cboEstado.DisplayMember = "NomEstado";
            cboEstado.ValueMember = "EstadoId";
            cboEstado.DataSource = StateBL.Instance.SellecALL();
        }
        private void UpdateComboTipoUsuario()
        {
            cboTipUsuario.DisplayMember = "NomTipoUsuario";
            cboTipUsuario.ValueMember = "TipoUsuarioId";
            cboTipUsuario.DataSource = UserTypeBL.Instance.SellecALL();
        }
        private void ValidarBuscar()
        {
            var vr = !string.IsNullOrEmpty(txtUsuario.Text)&&
                !string.IsNullOrEmpty(txtPassw.Text)&&
                !string.IsNullOrEmpty(cboEmpleado.Text)&&
                !string.IsNullOrEmpty(cboTipUsuario.Text)&&
                !string.IsNullOrEmpty(cboEstado.Text);
            btnGuardar.Enabled = vr;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            User entity = new User()
            {
                NomUsuario = txtUsuario.Text.Trim(),
                Password = txtPassw.Text.Trim(),
                EmpleadoId = (int)cboEmpleado.SelectedValue,
                TipoUsuarioId = (int)cboTipUsuario.SelectedValue,
                EstadoId = (int)cboEstado.SelectedValue,
            };

            if (UserBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.Nombre.ToLower().Contains(txtNombre.Text.ToLower())).ToList();
            dataGridView2.DataSource = query;
        }

        private void cboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
