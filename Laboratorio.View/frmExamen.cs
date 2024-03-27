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
    public partial class frmExamen : Form
    {
        private List<Exam> _listado;
        Validaciones val = new Validaciones();
        public frmExamen()
        {
            InitializeComponent();
        }
        private void ValidarBuscar()
        {
            var vr = !string.IsNullOrEmpty(textBox3.Text);
            pictureBox2.Enabled = vr;
        }


        public void Limpiar()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void Validar()
        {
            var vr = !string.IsNullOrEmpty(textBox1.Text) &&
                !string.IsNullOrEmpty(textBox2.Text) &&
                !string.IsNullOrEmpty(comboBox1.Text) &&
                !string.IsNullOrEmpty(comboBox2.Text);
            pictureBox1.Enabled = vr;
        }
        private void UpdateGrid()
        {
            _listado = ExamBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.ExamenId,
                            ExamenNombre = x.NombreExamen,
                            Costo = x.Precio,
                            TypeOfExam = x.TypeOfExams.NombreExamen,
                            Estado = x.States.NomEstado

                        };
            metroGrid1.DataSource = query.ToList();

        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NombreExamen";
            comboBox1.ValueMember = "TipoDeExamenId";
            comboBox1.DataSource = TypeOfExamBL.Instance.SellecALL();
        }
        private void UpdComboBox2()
        {
            comboBox2.DisplayMember = "NomEstado";
            comboBox2.ValueMember = "EstadoId";
            comboBox2.DataSource = StateBL.Instance.SellecALL();
        }


        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmExamen_Load(object sender, EventArgs e)
        {
            UpdateCombo();
            UpdComboBox2();
            UpdateGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Exam entity = new Exam()
            {
                NombreExamen = textBox1.Text.Trim(),
                Precio = decimal.Parse(textBox2.Text),
                TipoDeExamenId= (int)comboBox1.SelectedValue,
                EstadoId= (int)comboBox2.SelectedValue

            };

            if (ExamBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validar();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ValidarBuscar();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            var query = _listado.Where(x => x.NombreExamen.ToLower().Contains(textBox3.Text.ToLower())).ToList();
            metroGrid2.DataSource = query;
        }
    }
}
