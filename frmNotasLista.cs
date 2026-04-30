using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Escuela
{
    public partial class frmNotasLista : Form
    {
        BindingSource BindingSourceNotas = new BindingSource();

        public frmNotasLista()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotasLista_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            dgNotasLista.DataSource = BindingSourceNotas;



            BindingSourceNotas.DataSource = GetNotasLista("SEL_NOTAS");// metodo datasource soporta
                                                                        // o tolera muchos archivos. xml,matrices,vectores,datatable,datareader,dataset,dataview


            SetNotasLista();
        }
        private void SetNotasLista()
        {
            dgNotasLista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgNotasLista.Columns[0].HeaderText = "Matrícula";
            dgNotasLista.Columns[1].HeaderText = "Asignatura";
            dgNotasLista.Columns[2].HeaderText = "Tipo de Nota";
            dgNotasLista.Columns[3].HeaderText = "Fecha de Nota";
            dgNotasLista.Columns[4].HeaderText = "Valor de Nota";

            //Números y fechas van por defecto a la derecha
            dgNotasLista.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotasLista.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotasLista.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotasLista.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotasLista.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

  
        }
        private DataTable GetNotasLista(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtNotasLista = new DataTable();


            using (SqlConnection con = new SqlConnection())
            {
                //Abrir conexión
                // cadena de conexión o connect string: donde se tiene q conectar mi programa
                // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true";
                //Conecto 
                con.Open();


                try
                {
                    //se ejecuta completo en tanto no haya ningún error

                    // definimos un dataadapter llamado daAlumnos
                    SqlDataAdapter daNotasLista = new SqlDataAdapter();



                    daNotasLista = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbNotasLista = new SqlCommandBuilder(daNotasLista);
                    //
                    daNotasLista.Fill(dtNotasLista);

                    //

                    return dtNotasLista;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de las Notas", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtNotasLista;
        }

        private void cboOrdenNotas_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboOrdenNotas.SelectedItem.ToString())
            {
                case "Matricula":
                    BindingSourceNotas.DataSource = GetNotasLista("SEL_NOTAS");
                    break;

                case "Asignatura":
                    BindingSourceNotas.DataSource = GetNotasLista("SEL_NOTAS_ASIGNATURA");
                    break;

                case "Tipo de Examen":
                    BindingSourceNotas.DataSource = GetNotasLista("SEL_NOTAS_TIPO_NOTA");
                    break;

                case "Fecha de Nota":
                    BindingSourceNotas.DataSource = GetNotasLista("SEL_NOTAS_FECHA_NOTA");
                    break;
            }
        }
    }
}
