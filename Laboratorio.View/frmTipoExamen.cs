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
    public partial class frmTipoExamen : Form
    {
        private List<TypeOfExam> _listado;
        public frmTipoExamen()
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
                            Estado = x.States.NomEstado
                        };
            metroGrid1.DataSource = query.ToList();
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "NomEstado";
            comboBox1.ValueMember = "EstadoId";
            comboBox1.DataSource = StateBL.Instance.SellecALL();
        }


        private void metroToggle1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmTipoExamen_Load(object sender, EventArgs e)
        {
            UpdateCombo();
            UpdateGrid();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void metroTextBox1_Click(object sender, EventArgs e)
        {
            _listado = TypeOfExamBL.Instance.SellecALL();
            var busqueda = from x in _listado
                           select new
                           {
                               id = x.TipoDeExamenId,
                               Nombres = x.NombreExamen,
                               Estado = x.States.NomEstado

                           };
            var query = busqueda.Where(x => x.Nombres.ToLower().Contains(metroTextBox1.Text.ToLower())).ToList();
           metroGrid2.DataSource = query.ToList();
        }

        private void metroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
