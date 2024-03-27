using Laboratorio.Entities;
using Laboratorio.BussinesLogic;
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
    public partial class FrmExam : Form
    {
        private List<Exam> _listado;
        public FrmExam()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            _listado = ExamBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.ExamenId,
                            N = x.Nombre,
                            P = x.Precio,
                            TypeOfExam = x.TypeOfExams.NombreExamen,
                            Estado = x.States.NomEsado

                        };
            dataGridView1.DataSource = query.ToList();

        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NombreExamen";
            comboBox1.ValueMember = "TipoDeExamenId";
            comboBox1.DataSource = TypeOfExamBL.Instance.SellecALL();
        }

        private void UpdComboBox2()
        {
            comboBox2.DisplayMember = "NomEsado";
            comboBox2.ValueMember = "EstadoId";
            comboBox2.DataSource = StateBL.Instance.SellecALL();
        }

        private void FrmExam_Load(object sender, EventArgs e)
        {
            UpdateCombo();
            UpdComboBox2();
            UpdateGrid();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Exam entity = new Exam()
            {
                Nombre = textBox1.Text.Trim(),
                Precio = decimal.Parse(textBox2.Text),
            };

            if (ExamBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            _listado = ExamBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.ExamenId,
                               N = x.Nombre,
                               P = x.Precio,
                               TypeOfExam = x.TypeOfExams.NombreExamen,
                               Estado = x.States.NomEsado

                           };


            var query = busqueda.Where(x => x.N.ToLower().Contains(textBox1.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();
        }
    }
}
