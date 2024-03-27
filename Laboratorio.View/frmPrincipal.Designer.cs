namespace Laboratorio.View
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.laboratorioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEmpleadosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroLaboratoristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroGeneroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEstadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.principalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeExamenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionToolStripMenuItem,
            this.principalesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(165, 353);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.laboratorioToolStripMenuItem,
            this.registroEmpleadosToolStripMenuItem,
            this.registroLaboratoristaToolStripMenuItem,
            this.registroGeneroToolStripMenuItem,
            this.registroEstadoToolStripMenuItem,
            this.registroUsuarioToolStripMenuItem});
            this.configuracionToolStripMenuItem.Image = global::Laboratorio.View.Properties.Resources.users64x;
            this.configuracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(152, 68);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // laboratorioToolStripMenuItem
            // 
            this.laboratorioToolStripMenuItem.Name = "laboratorioToolStripMenuItem";
            this.laboratorioToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.laboratorioToolStripMenuItem.Text = "Laboratorio";
            this.laboratorioToolStripMenuItem.Click += new System.EventHandler(this.laboratorioToolStripMenuItem_Click);
            // 
            // registroEmpleadosToolStripMenuItem
            // 
            this.registroEmpleadosToolStripMenuItem.Name = "registroEmpleadosToolStripMenuItem";
            this.registroEmpleadosToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.registroEmpleadosToolStripMenuItem.Text = "Registro Empleados";
            this.registroEmpleadosToolStripMenuItem.Click += new System.EventHandler(this.registroEmpleadosToolStripMenuItem_Click);
            // 
            // registroLaboratoristaToolStripMenuItem
            // 
            this.registroLaboratoristaToolStripMenuItem.Name = "registroLaboratoristaToolStripMenuItem";
            this.registroLaboratoristaToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.registroLaboratoristaToolStripMenuItem.Text = "Registro Laboratorista";
            this.registroLaboratoristaToolStripMenuItem.Click += new System.EventHandler(this.registroLaboratoristaToolStripMenuItem_Click);
            // 
            // registroGeneroToolStripMenuItem
            // 
            this.registroGeneroToolStripMenuItem.Name = "registroGeneroToolStripMenuItem";
            this.registroGeneroToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.registroGeneroToolStripMenuItem.Text = "Registro Genero";
            this.registroGeneroToolStripMenuItem.Click += new System.EventHandler(this.registroGeneroToolStripMenuItem_Click);
            // 
            // registroEstadoToolStripMenuItem
            // 
            this.registroEstadoToolStripMenuItem.Name = "registroEstadoToolStripMenuItem";
            this.registroEstadoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.registroEstadoToolStripMenuItem.Text = "Registro Estado";
            this.registroEstadoToolStripMenuItem.Click += new System.EventHandler(this.registroEstadoToolStripMenuItem_Click);
            // 
            // registroUsuarioToolStripMenuItem
            // 
            this.registroUsuarioToolStripMenuItem.Name = "registroUsuarioToolStripMenuItem";
            this.registroUsuarioToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.registroUsuarioToolStripMenuItem.Text = "Registro Usuario";
            this.registroUsuarioToolStripMenuItem.Click += new System.EventHandler(this.registroUsuarioToolStripMenuItem_Click);
            // 
            // principalesToolStripMenuItem
            // 
            this.principalesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacienteToolStripMenuItem,
            this.examenToolStripMenuItem,
            this.tipoDeExamenToolStripMenuItem});
            this.principalesToolStripMenuItem.Image = global::Laboratorio.View.Properties.Resources.panel64x;
            this.principalesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.principalesToolStripMenuItem.Name = "principalesToolStripMenuItem";
            this.principalesToolStripMenuItem.Size = new System.Drawing.Size(152, 68);
            this.principalesToolStripMenuItem.Text = "Principales";
            // 
            // pacienteToolStripMenuItem
            // 
            this.pacienteToolStripMenuItem.Name = "pacienteToolStripMenuItem";
            this.pacienteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pacienteToolStripMenuItem.Text = "Paciente";
            this.pacienteToolStripMenuItem.Click += new System.EventHandler(this.pacienteToolStripMenuItem_Click);
            // 
            // examenToolStripMenuItem
            // 
            this.examenToolStripMenuItem.Name = "examenToolStripMenuItem";
            this.examenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.examenToolStripMenuItem.Text = "Examen";
            this.examenToolStripMenuItem.Click += new System.EventHandler(this.examenToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Image = global::Laboratorio.View.Properties.Resources.exit48x;
            this.salirToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 52);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tipoDeExamenToolStripMenuItem
            // 
            this.tipoDeExamenToolStripMenuItem.Name = "tipoDeExamenToolStripMenuItem";
            this.tipoDeExamenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoDeExamenToolStripMenuItem.Text = "Tipo de examen";
            this.tipoDeExamenToolStripMenuItem.Click += new System.EventHandler(this.tipoDeExamenToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Laboratorio.View.Properties.Resources.lab;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 353);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laboratorioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEmpleadosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroLaboratoristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroGeneroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEstadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem principalesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeExamenToolStripMenuItem;
    }
}