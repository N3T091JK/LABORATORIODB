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
    public partial class FrmTypeOfExam : Form
    {
        private List<TypeOfExam> _listado;
        public FrmTypeOfExam()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            _listado = TypeOfExamBL.Instance.SellecALL();
            var query = from x in _listado
                        select new
                        {
                            id = x.TipoDeExamenId,
                            Nombres = x.NombreExamen,
                            Estado = x.States.NomEsado
                        };
            dataGridView1.DataSource = query.ToList();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NomEsado";
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = StateBL.Instance.SellecALL();
        }



        private void FrmTypeOfExam_Load(object sender, EventArgs e)
        {
            UpdateCombo();
            UpdateGrid();
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TypeOfExam entity = new TypeOfExam()
            {
                NombreExamen = textBox1.Text.Trim(),
                EstadoId = (int)comboBox1.SelectedValue
            };

            if (TypeOfExamBL.Instance.Insert(entity))
            {
                MessageBox.Show("Se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateGrid();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            _listado = TypeOfExamBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.TipoDeExamenId,
                               Nombres = x.NombreExamen,
                               Estado = x.States.NomEsado

                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(textBox2.Text.ToLower())).ToList();
            dataGridView1.DataSource = query.ToList();

        }
    }
}
