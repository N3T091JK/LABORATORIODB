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
    public partial class frmPaciente : Form
    {
        private List<Patient> _listado;
        Validaciones val = new Validaciones();
        public frmPaciente()
        {
            InitializeComponent();
        }

        private void frmPaciente_Load(object sender, EventArgs e)
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
                            edad = x.Edad,
                            Dui = x.DUI,
                            Celular = x.NumCelular,
                            direcciones = x.Direccion,
                            Estado = x.States.NomEstado,
                            Genero = x.Genders.NomGenero
                        };
            dataGridView1.DataSource = query.ToList();

        }
        private void UpdateComboEstado()
        {
            comboBox1.DisplayMember = "NomEstado";
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = StateBL.Instance.SellecALL();

        }
        private void UpdateComboGenero()
        {
            comboBox2.DisplayMember = "NomGenero";
            comboBox2.ValueMember = "GeneroId";
            comboBox2.DataSource = GenderBL.Instance.SellecALL();
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

 /*************BUSCAR VALIDAR***********************/
        private void ValidarBuscar()
        {
            var vr = !string.IsNullOrEmpty(textBox7.Text);
            pictureBox1.Enabled = vr;
        }
        /*************************/


        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }
        /*************************************/
        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.Nombre.ToLower().Contains(textBox7.Text.ToLower())).ToList();
            dataGridView2.DataSource = query;
        }
        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(textBox3.Text) &&
                !string.IsNullOrEmpty(textBox4.Text) &&
                !string.IsNullOrEmpty(textBox5.Text) &&
                !string.IsNullOrEmpty(textBox6.Text);

            pictureBox2.Enabled = vr;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Patient entity = new Patient()
            {
                Nombre = textBox1.Text.Trim(),
                Apellidos = textBox2.Text.Trim(),
                Edad = Convert.ToInt32(textBox3.Text.Trim()),
                DUI = textBox4.Text.Trim(),
                NumCelular = textBox5.Text.Trim(),
                Direccion = textBox6.Text.Trim(),
                EstadoId = (int)comboBox1.SelectedValue,
                GeneroId = (int)comboBox2.SelectedValue,
            };

            if (PatientBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
                Limpiar();
            }
            /*************************/
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string Nombres = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                string Apellido = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                int Edad = (int)dataGridView1.CurrentRow.Cells[5].Value;
                string Dui = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                string NumCelular = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                string Direccion = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                int EstadoId=_listado.FirstOrDefault(x => x.PacienteId.Equals(id)).EstadoId;
                int GeneroId = _listado.FirstOrDefault(x => x.PacienteId.Equals(id)).GeneroId;
                Patient entity =new Patient()
                {
                    PacienteId =id,
                        Nombre=Nombres,
                        Apellidos=Apellido,
                        Edad=Edad,
                        DUI=Dui,
                        NumCelular=NumCelular,
                        Direccion=Direccion,
                        EstadoId=EstadoId,
                        GeneroId=GeneroId

                };
                FrmEditarPaciente frm = new FrmEditarPaciente (entity);
                frm.ShowDialog();
                UpdateGrid();


                if (dataGridView1.Rows[e.RowIndex].Cells["Eliminar"].Selected)
                {
                    int PacienteId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
                    DialogResult dr = MessageBox.Show("Desea eliminar el registro actual?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (PatientBL.Instance.Delete(id))
                        {
                            MessageBox.Show("Se elimino con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                    UpdateGrid();

                }

            }
        }
    }
}
