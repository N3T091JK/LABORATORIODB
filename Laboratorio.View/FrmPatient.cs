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
    public partial class FrmPatient : Form
    {
        private List<Patient> _listado;
        public FrmPatient()
        {
            InitializeComponent();
        }

        private void FrmPatient_Load(object sender, EventArgs e)
        {
            UpdateComboEstado();
            UpdateComboGenero();
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            _listado = PatientBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.PacienteId,
                            Nombres = x.Nombre,
                            Apellido = x.Apellidos,
                            edades = x.Edad,
                            Dui = x.DUI,
                            Celula = x.NumCelular,
                            direcciones = x.Direccion,
                            Estado = x.States.NomEsado,
                            Genero = x.Genders.NomGenero
                        };
            dataGridView1.DataSource = query.ToList();

        }
        private void UpdateComboEstado()
        {
            comboBox1.DisplayMember = "NomEsado";
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = StateBL.Instance.SellecALL();

        }
        private void UpdateComboGenero()
        {
            comboBox2.DisplayMember = "NomGenero";
            comboBox2.ValueMember = "GeneroId";
            comboBox2.DataSource = GenderBL.Instance.SellecALL();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Patient entity = new Patient()
            {
                Nombre = textBox1.Text.Trim(),
                Apellidos = textBox2.Text.Trim(),
                Edad = Convert.ToInt32(textBox6.Text.Trim()),
                DUI = textBox3.Text.Trim(),
                NumCelular = textBox4.Text.Trim(),
                Direccion = textBox5.Text.Trim(),
                EstadoId = (int)comboBox1.SelectedValue,
                GeneroId = (int)comboBox2.SelectedValue,
            };

            if (PatientBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            _listado = PatientBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.PacienteId,
                               Nombres = x.Nombre,
                               Apellido = x.Apellidos,
                               edades = x.Edad,
                               Dui = x.DUI,
                               Celula = x.NumCelular,
                               direcciones = x.Direccion,
                               Estado = x.States.NomEsado,
                               Genero = x.Genders.NomGenero
                           };
            var query = busqueda.Where(x => x.Apellido.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
