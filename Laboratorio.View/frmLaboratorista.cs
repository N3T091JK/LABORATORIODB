using Laboratorio.BussinesLogic;
using Laboratorio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio.View
{
    public partial class frmLaboratorista : Form
    {
        private List<Employee> _listado;
        private List<LaboratoryWorker> _listado2;
        Validaciones val = new Validaciones();
        public frmLaboratorista()
        {
            InitializeComponent();
        }

        private void frmLaboratorista_Load(object sender, EventArgs e)
        {
            btnBuscar.Enabled = false;
            UpdateGrid();
            UpdateGrid2();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            LaboratoryWorker entity = new LaboratoryWorker()
            {
                EmpleadoId = int.Parse(txtId.Text.Trim()),
                PVPM = txtPvpm.Text.Trim(),

            };

            if (LaboratoryWorkerBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid2();
            }
            txtPvpm.Clear();
        }
        private void UpdateGrid2()
        {
            _listado2 = LaboratoryWorkerBL.Instance.SellecALL();
            var query = from x in _listado2
                        select new
                        {
                            id = x.LaboratoristaId,
                            pvpm = x.PVPM,
                            Nombre_Empleado = x.Employees.Nombre,
                             Apellido_Empleado = x.Employees.Apellidos
                        };
            dataGridView2.DataSource = query.ToList();
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.Nombre.ToLower().Contains(txtCorreo.Text.ToLower())).ToList();
            dataGridView1.DataSource = query;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
        private void ValidarBuscar()
        {
            var vr = !string.IsNullOrEmpty(txtCorreo.Text);
            btnBuscar.Enabled = vr;
        }
        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNom.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDui.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txtCorreo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                txtEdad.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                txtTelefono.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                txtEstado.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                txtGenero.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
