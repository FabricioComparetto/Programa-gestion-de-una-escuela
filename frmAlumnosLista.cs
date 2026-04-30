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
    public partial class frmAlumnosLista : Form
    {
        BindingSource BindingSourceAlumnos = new BindingSource();
        public frmAlumnosLista()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAlumnosLista_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            dgAlumnos.DataSource = BindingSourceAlumnos;



            BindingSourceAlumnos.DataSource = GetAlumnos("SEL_ALUMNOS");// metodo datasource soporta
                                                                        // o tolera muchos archivos. xml,matrices,vectores,datatable,datareader,dataset,dataview
            

            SetAlumnos();
        }
        private void SetAlumnos()
        {
            dgAlumnos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgAlumnos.Columns[0].HeaderText = "Matrícula";
            dgAlumnos.Columns[1].HeaderText = "Apellido";
            dgAlumnos.Columns[2].HeaderText = "Nombre";
            dgAlumnos.Columns[3].HeaderText = "DNI";
            dgAlumnos.Columns[4].HeaderText = "Código Postal";
            dgAlumnos.Columns[5].HeaderText = "Fecha de Nacimiento";
            dgAlumnos.Columns[6].HeaderText = "Fecha carga";
            dgAlumnos.Columns[7].HeaderText = "Usuario";

            //Números y fechas van por defecto a la derecha
            dgAlumnos.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumnos.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumnos.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumnos.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            
            dgAlumnos.Columns[7].Visible = false;
            dgAlumnos.Columns[8].Visible = false;        
        }

        private DataTable GetAlumnos(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtAlumnos = new DataTable();


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
                    SqlDataAdapter daAlumnos = new SqlDataAdapter();



                    daAlumnos = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbAlumnos = new SqlCommandBuilder(daAlumnos);
                    //
                    daAlumnos.Fill(dtAlumnos);

                    //

                    return dtAlumnos;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de alumnos", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtAlumnos;
        }
      
        private void cboOrden_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cboOrden.SelectedItem.ToString())
            {
                case "Alfabetico":
                    BindingSourceAlumnos.DataSource = GetAlumnos("SEL_ALUMNOS");
                    dgAlumnos.Columns[8].Visible = false;
                    break;
                
                case "Matricula":
                    BindingSourceAlumnos.DataSource = GetAlumnos("SEL_ALUMNOS_MATRICULA");
                    break;
                
                case "Nacimiento":
                    BindingSourceAlumnos.DataSource = GetAlumnos("SEL_ALUMNOS_NACIMIENTO");
                    break;
                
                case "Fecha de carga":
                    BindingSourceAlumnos.DataSource = GetAlumnos("SEL_ALUMNOS_CARGA");
                    break;
            }
        }
    }
}
