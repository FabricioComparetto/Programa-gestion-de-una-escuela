
namespace Escuela
{
    partial class frmTiposExamen
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnGrabar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoExamen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreExamen = new System.Windows.Forms.TextBox();
            this.cboTiposExamen = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgTiposExamen = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgTiposExamen)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(212, 17);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(106, 263);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 1;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnGrabar
            // 
            this.btnGrabar.Location = new System.Drawing.Point(12, 263);
            this.btnGrabar.Name = "btnGrabar";
            this.btnGrabar.Size = new System.Drawing.Size(75, 23);
            this.btnGrabar.TabIndex = 2;
            this.btnGrabar.Text = "Grabar";
            this.btnGrabar.UseVisualStyleBackColor = true;
            this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(339, 263);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Código Examen:";
            // 
            // txtCodigoExamen
            // 
            this.txtCodigoExamen.Location = new System.Drawing.Point(106, 19);
            this.txtCodigoExamen.Name = "txtCodigoExamen";
            this.txtCodigoExamen.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoExamen.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nombre Examen:";
            // 
            // txtNombreExamen
            // 
            this.txtNombreExamen.Location = new System.Drawing.Point(106, 57);
            this.txtNombreExamen.Name = "txtNombreExamen";
            this.txtNombreExamen.Size = new System.Drawing.Size(100, 20);
            this.txtNombreExamen.TabIndex = 7;
            // 
            // cboTiposExamen
            // 
            this.cboTiposExamen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTiposExamen.FormattingEnabled = true;
            this.cboTiposExamen.Location = new System.Drawing.Point(293, 17);
            this.cboTiposExamen.Name = "cboTiposExamen";
            this.cboTiposExamen.Size = new System.Drawing.Size(121, 21);
            this.cboTiposExamen.TabIndex = 9;
            this.cboTiposExamen.SelectedIndexChanged += new System.EventHandler(this.cboTiposExamen_SelectedIndexChanged);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(212, 55);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgTiposExamen
            // 
            this.dgTiposExamen.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgTiposExamen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTiposExamen.Location = new System.Drawing.Point(15, 95);
            this.dgTiposExamen.Name = "dgTiposExamen";
            this.dgTiposExamen.Size = new System.Drawing.Size(272, 150);
            this.dgTiposExamen.TabIndex = 11;
            // 
            // frmTiposExamen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 298);
            this.Controls.Add(this.dgTiposExamen);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cboTiposExamen);
            this.Controls.Add(this.txtNombreExamen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigoExamen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGrabar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTiposExamen";
            this.Text = "Tipos de Examen";
            this.Load += new System.EventHandler(this.frmTiposExamen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgTiposExamen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnGrabar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoExamen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreExamen;
        private System.Windows.Forms.ComboBox cboTiposExamen;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgTiposExamen;
    }
}