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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
        }

        private void htmlToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void laboratorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaboratorio frm = new frmLaboratorio();
            frm.ShowDialog();
        }

        private void registroEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmpleado frm = new frmEmpleado();
            frm.ShowDialog();
        }

        private void registroLaboratoristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLaboratorista frm = new frmLaboratorista();
            frm.ShowDialog();
        }

        private void registroGeneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGenero frm = new frmGenero();
            frm.ShowDialog();
        }

        private void registroEstadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEstado frm = new frmEstado();
            frm.ShowDialog();
        }

        private void registroUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            frm.ShowDialog();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPaciente frm = new frmPaciente();
            frm.ShowDialog();
        }

        private void examenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExamen frm = new frmExamen();
            frm.ShowDialog();
        }

        private void tipoDeExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoExamen frm = new frmTipoExamen();
            frm.ShowDialog();
        }
    }
}
