
namespace Escuela
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal = new System.Windows.Forms.MenuStrip();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listadoDeNotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasDeAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciudadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignaturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeExamenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // mnuPrincipal
            // 
            this.mnuPrincipal.BackColor = System.Drawing.SystemColors.Control;
            this.mnuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.notasToolStripMenuItem,
            this.coToolStripMenuItem});
            this.mnuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnuPrincipal.Name = "mnuPrincipal";
            this.mnuPrincipal.Size = new System.Drawing.Size(800, 24);
            this.mnuPrincipal.TabIndex = 0;
            this.mnuPrincipal.Text = "menuStrip1";
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeAlumnosToolStripMenuItem,
            this.listadoDeAlumnoToolStripMenuItem});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // gestionDeAlumnosToolStripMenuItem
            // 
            this.gestionDeAlumnosToolStripMenuItem.Name = "gestionDeAlumnosToolStripMenuItem";
            this.gestionDeAlumnosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.gestionDeAlumnosToolStripMenuItem.Text = "Gestión de Alumnos";
            this.gestionDeAlumnosToolStripMenuItem.Click += new System.EventHandler(this.gestionDeAlumnosToolStripMenuItem_Click);
            // 
            // listadoDeAlumnoToolStripMenuItem
            // 
            this.listadoDeAlumnoToolStripMenuItem.Name = "listadoDeAlumnoToolStripMenuItem";
            this.listadoDeAlumnoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.listadoDeAlumnoToolStripMenuItem.Text = "Listado de Alumno";
            this.listadoDeAlumnoToolStripMenuItem.Click += new System.EventHandler(this.listadoDeAlumnoToolStripMenuItem_Click);
            // 
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDeNotasToolStripMenuItem,
            this.listadoDeNotasToolStripMenuItem,
            this.notasDeAlumnoToolStripMenuItem});
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.notasToolStripMenuItem.Text = "Notas";
            // 
            // gestionDeNotasToolStripMenuItem
            // 
            this.gestionDeNotasToolStripMenuItem.Name = "gestionDeNotasToolStripMenuItem";
            this.gestionDeNotasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.gestionDeNotasToolStripMenuItem.Text = "Gestión de Notas";
            this.gestionDeNotasToolStripMenuItem.Click += new System.EventHandler(this.gestionDeNotasToolStripMenuItem_Click);
            // 
            // listadoDeNotasToolStripMenuItem
            // 
            this.listadoDeNotasToolStripMenuItem.Name = "listadoDeNotasToolStripMenuItem";
            this.listadoDeNotasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listadoDeNotasToolStripMenuItem.Text = "Listado de Notas";
            this.listadoDeNotasToolStripMenuItem.Click += new System.EventHandler(this.listadoDeNotasToolStripMenuItem_Click);
            // 
            // notasDeAlumnoToolStripMenuItem
            // 
            this.notasDeAlumnoToolStripMenuItem.Name = "notasDeAlumnoToolStripMenuItem";
            this.notasDeAlumnoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.notasDeAlumnoToolStripMenuItem.Text = "Notas de Alumno";
            this.notasDeAlumnoToolStripMenuItem.Click += new System.EventHandler(this.notasDeAlumnoToolStripMenuItem_Click);
            // 
            // coToolStripMenuItem
            // 
            this.coToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ciudadesToolStripMenuItem,
            this.asignaturaToolStripMenuItem,
            this.tipoDeExamenToolStripMenuItem});
            this.coToolStripMenuItem.Name = "coToolStripMenuItem";
            this.coToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.coToolStripMenuItem.Text = "Configuración";
            // 
            // ciudadesToolStripMenuItem
            // 
            this.ciudadesToolStripMenuItem.Name = "ciudadesToolStripMenuItem";
            this.ciudadesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ciudadesToolStripMenuItem.Text = "Ciudades";
            this.ciudadesToolStripMenuItem.Click += new System.EventHandler(this.ciudadesToolStripMenuItem_Click);
            // 
            // asignaturaToolStripMenuItem
            // 
            this.asignaturaToolStripMenuItem.Name = "asignaturaToolStripMenuItem";
            this.asignaturaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.asignaturaToolStripMenuItem.Text = "Asignaturas";
            this.asignaturaToolStripMenuItem.Click += new System.EventHandler(this.asignaturaToolStripMenuItem_Click);
            // 
            // tipoDeExamenToolStripMenuItem
            // 
            this.tipoDeExamenToolStripMenuItem.Name = "tipoDeExamenToolStripMenuItem";
            this.tipoDeExamenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tipoDeExamenToolStripMenuItem.Text = "Tipos de Examen";
            this.tipoDeExamenToolStripMenuItem.Click += new System.EventHandler(this.tipoDeExamenToolStripMenuItem_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mnuPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.mnuPrincipal;
            this.Name = "frmPrincipal";
            this.Text = "Sistema de escuela";
            this.mnuPrincipal.ResumeLayout(false);
            this.mnuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDeNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciudadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignaturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeExamenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listadoDeNotasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasDeAlumnoToolStripMenuItem;
    }
}

