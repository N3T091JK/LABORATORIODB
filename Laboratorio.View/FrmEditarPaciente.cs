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
    public partial class FrmEditarPaciente : Form
    {
        int PacienteId = 0;


        public FrmEditarPaciente()
        {
            InitializeComponent();
        }
        public FrmEditarPaciente(Patient entity)
        {
            InitializeComponent();
            PacienteId = entity.PacienteId;
            textBox1.Text = entity.Nombre;
            textBox2.Text = entity.Apellidos;
       entity.Edad=Convert.ToInt32(textBox3.Text);
        



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

        private void FrmEditarPaciente_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Patient entity = new Patient()
            {
                PacienteId = PacienteId,
                Nombre = textBox1.Text.Trim(),
                Apellidos = textBox2.Text.Trim(),
                Edad=Convert.ToInt32(textBox3.Text.Trim()),
                DUI=textBox4.Text.Trim(),
                NumCelular=textBox5.Text.Trim(),
                Direccion=textBox6.Text.Trim(),
                EstadoId=(int)comboBox1.SelectedValue,
                GeneroId=(int)comboBox2.SelectedValue
            };
            if (PacienteId == 0 )
            {
                if(PatientBL.Instance.Insert(entity)){
                    MessageBox.Show(this, "REGISTRO SE AGREGO CON EXITO","confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                if (PatientBL.Instance.Update(entity)) {
                    MessageBox.Show(this, "REGISTRO SE AGREGO CON EXITO","confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            this.Close();
        }
    }
}
