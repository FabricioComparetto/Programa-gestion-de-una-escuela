
namespace Escuela
{
    partial class frmNotasAlumno
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
            this.txtMatricula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgNotasAlumno = new System.Windows.Forms.DataGridView();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPromedio = new System.Windows.Forms.Label();
            this.lblNotMin = new System.Windows.Forms.Label();
            this.lblNotMax = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCP = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFecNac = new System.Windows.Forms.Label();
            this.cboNotasAlumno = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgNotasAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatricula
            // 
            this.txtMatricula.Location = new System.Drawing.Point(71, 12);
            this.txtMatricula.Name = "txtMatricula";
            this.txtMatricula.Size = new System.Drawing.Size(100, 20);
            this.txtMatricula.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matrícula:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(76, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Promedio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(336, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Nota Mínima:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(336, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nota Máxima:";
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(459, 378);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 15;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgNotasAlumno
            // 
            this.dgNotasAlumno.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNotasAlumno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNotasAlumno.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgNotasAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNotasAlumno.Location = new System.Drawing.Point(15, 198);
            this.dgNotasAlumno.Name = "dgNotasAlumno";
            this.dgNotasAlumno.Size = new System.Drawing.Size(519, 150);
            this.dgNotasAlumno.TabIndex = 16;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(129, 48);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(35, 13);
            this.lblApellido.TabIndex = 17;
            this.lblApellido.Text = "label8";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(129, 81);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(35, 13);
            this.lblNombre.TabIndex = 18;
            this.lblNombre.Text = "label9";
            // 
            // lblPromedio
            // 
            this.lblPromedio.AutoSize = true;
            this.lblPromedio.Location = new System.Drawing.Point(413, 48);
            this.lblPromedio.Name = "lblPromedio";
            this.lblPromedio.Size = new System.Drawing.Size(41, 13);
            this.lblPromedio.TabIndex = 20;
            this.lblPromedio.Text = "label12";
            // 
            // lblNotMin
            // 
            this.lblNotMin.AutoSize = true;
            this.lblNotMin.Location = new System.Drawing.Point(413, 81);
            this.lblNotMin.Name = "lblNotMin";
            this.lblNotMin.Size = new System.Drawing.Size(41, 13);
            this.lblNotMin.TabIndex = 21;
            this.lblNotMin.Text = "label13";
            // 
            // lblNotMax
            // 
            this.lblNotMax.AutoSize = true;
            this.lblNotMax.Location = new System.Drawing.Point(413, 111);
            this.lblNotMax.Name = "lblNotMax";
            this.lblNotMax.Size = new System.Drawing.Size(41, 13);
            this.lblNotMax.TabIndex = 22;
            this.lblNotMax.Text = "label14";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Código Postal:";
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(129, 111);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(41, 13);
            this.lblCP.TabIndex = 24;
            this.lblCP.Text = "label10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 140);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Fecha de Nacimiento:";
            // 
            // lblFecNac
            // 
            this.lblFecNac.AutoSize = true;
            this.lblFecNac.Location = new System.Drawing.Point(129, 140);
            this.lblFecNac.Name = "lblFecNac";
            this.lblFecNac.Size = new System.Drawing.Size(41, 13);
            this.lblFecNac.TabIndex = 26;
            this.lblFecNac.Text = "label11";
            // 
            // cboNotasAlumno
            // 
            this.cboNotasAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNotasAlumno.FormattingEnabled = true;
            this.cboNotasAlumno.Location = new System.Drawing.Point(177, 12);
            this.cboNotasAlumno.Name = "cboNotasAlumno";
            this.cboNotasAlumno.Size = new System.Drawing.Size(121, 21);
            this.cboNotasAlumno.TabIndex = 27;
            this.cboNotasAlumno.SelectedIndexChanged += new System.EventHandler(this.cboNotasAlumno_SelectedIndexChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(332, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click_1);
            // 
            // frmNotasAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 413);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboNotasAlumno);
            this.Controls.Add(this.lblFecNac);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblCP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblNotMax);
            this.Controls.Add(this.lblNotMin);
            this.Controls.Add(this.lblPromedio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.dgNotasAlumno);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMatricula);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmNotasAlumno";
            this.Text = "Notas de Alumno";
            this.Load += new System.EventHandler(this.frmNotasAlumno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNotasAlumno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMatricula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgNotasAlumno;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPromedio;
        private System.Windows.Forms.Label lblNotMin;
        private System.Windows.Forms.Label lblNotMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFecNac;
        private System.Windows.Forms.ComboBox cboNotasAlumno;
        private System.Windows.Forms.Button btnBuscar;
    }
}