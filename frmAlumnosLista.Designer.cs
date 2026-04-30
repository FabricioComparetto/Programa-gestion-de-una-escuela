
namespace Escuela
{
    partial class frmAlumnosLista
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
            this.dgAlumnos = new System.Windows.Forms.DataGridView();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cboOrden = new System.Windows.Forms.ComboBox();
            this.lblOrdenacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgAlumnos
            // 
            this.dgAlumnos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAlumnos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAlumnos.Location = new System.Drawing.Point(36, 73);
            this.dgAlumnos.Name = "dgAlumnos";
            this.dgAlumnos.Size = new System.Drawing.Size(672, 192);
            this.dgAlumnos.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(633, 271);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 1;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cboOrden
            // 
            this.cboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrden.FormattingEnabled = true;
            this.cboOrden.Items.AddRange(new object[] {
            "Alfabetico",
            "Matricula",
            "Nacimiento",
            "Fecha de carga"});
            this.cboOrden.Location = new System.Drawing.Point(104, 25);
            this.cboOrden.Name = "cboOrden";
            this.cboOrden.Size = new System.Drawing.Size(121, 21);
            this.cboOrden.TabIndex = 2;
            this.cboOrden.SelectedIndexChanged += new System.EventHandler(this.cboOrden_SelectedIndexChanged);
            // 
            // lblOrdenacion
            // 
            this.lblOrdenacion.AutoSize = true;
            this.lblOrdenacion.Location = new System.Drawing.Point(33, 28);
            this.lblOrdenacion.Name = "lblOrdenacion";
            this.lblOrdenacion.Size = new System.Drawing.Size(65, 13);
            this.lblOrdenacion.TabIndex = 3;
            this.lblOrdenacion.Text = "Ordenación:";
            // 
            // frmAlumnosLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 313);
            this.Controls.Add(this.lblOrdenacion);
            this.Controls.Add(this.cboOrden);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.dgAlumnos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAlumnosLista";
            this.Text = "Listado de Alumnos";
            this.Load += new System.EventHandler(this.frmAlumnosLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgAlumnos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cboOrden;
        private System.Windows.Forms.Label lblOrdenacion;
    }
}