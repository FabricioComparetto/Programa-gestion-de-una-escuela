
namespace Escuela
{
    partial class frmNotasLista
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.dgNotasLista = new System.Windows.Forms.DataGridView();
            this.cboOrdenNotas = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgNotasLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(691, 319);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(60, 28);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // dgNotasLista
            // 
            this.dgNotasLista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNotasLista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNotasLista.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgNotasLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNotasLista.Location = new System.Drawing.Point(42, 87);
            this.dgNotasLista.Name = "dgNotasLista";
            this.dgNotasLista.Size = new System.Drawing.Size(709, 198);
            this.dgNotasLista.TabIndex = 8;
            // 
            // cboOrdenNotas
            // 
            this.cboOrdenNotas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOrdenNotas.FormattingEnabled = true;
            this.cboOrdenNotas.Items.AddRange(new object[] {
            "Fecha de Nota",
            "Matricula",
            "Tipo de Examen",
            "Asignatura"});
            this.cboOrdenNotas.Location = new System.Drawing.Point(113, 23);
            this.cboOrdenNotas.Name = "cboOrdenNotas";
            this.cboOrdenNotas.Size = new System.Drawing.Size(121, 21);
            this.cboOrdenNotas.TabIndex = 9;
            this.cboOrdenNotas.SelectedIndexChanged += new System.EventHandler(this.cboOrdenNotas_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ordenación: ";
            // 
            // frmNotasLista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 371);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboOrdenNotas);
            this.Controls.Add(this.dgNotasLista);
            this.Controls.Add(this.btnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmNotasLista";
            this.Text = "Listado de Notas";
            this.Load += new System.EventHandler(this.frmNotasLista_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgNotasLista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.DataGridView dgNotasLista;
        private System.Windows.Forms.ComboBox cboOrdenNotas;
        private System.Windows.Forms.Label label1;
    }
}