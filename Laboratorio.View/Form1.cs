using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Laboratorio.BussinesLogic;
using MetroFramework.Forms;

namespace Laboratorio.View
{
    public partial class Form1 : MetroForm
    {
        //private List<CategoriaBL> _Listado;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateGrid()
        {
            ////_Listado = CategoriaBL.Intance.SelectAll();
            //var query = from x in _Listado
            //            select new
            //            {
            //                //id = x.Categoria
            //                //nombre = x.Nombre
            //                //estado = x.estado.Nombre
            //            }
            //            MetroGrid.Datasource = query.ToList();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            frmCategoriaNuevo frm = new frmCategoriaNuevo();
            frm.ShowDialog();
            UpdateGrid();
        }
    }
}
