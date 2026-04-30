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
    public partial class frmNotasAlumno : Form
    {
        BindingSource BindingSourceNotasAlumno = new BindingSource();

        public frmNotasAlumno()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNotasAlumno_Load(object sender, EventArgs e)
        {

            dgNotasAlumno.DataSource = BindingSourceNotasAlumno;

            lblApellido.Text = "";
            lblNombre.Text = "";
            lblCP.Text = "";
            lblFecNac.Text = "";
            lblNotMin.Text = "";
            lblNotMax.Text = "";
            lblPromedio.Text = "";

            dgNotasAlumno.Visible = false;

            CargarNotasAlumno();
        }
        private void CargarNotasAlumno()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SEL_ALUMNOS", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Alumnos");
                    cboNotasAlumno.DisplayMember = "NOMBRE";
                    cboNotasAlumno.ValueMember = "MATALU";
                    cboNotasAlumno.DataSource = ds.Tables["Alumnos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
     
        private void Promedio()
        {
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Escuela; Integrated Security = true";

                con.Open();


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SEL_NOTAS_PROMEDIO";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);

                    SqlDataReader NotasAlumno = cmd.ExecuteReader();

                    if (NotasAlumno.HasRows)
                    {
                        while (NotasAlumno.Read())
                        {
                            lblPromedio.Text = NotasAlumno["PROMEDIO"].ToString();
                            lblNotMin.Text = NotasAlumno["MINIMO"].ToString();
                            lblNotMax.Text = NotasAlumno["MAXIMO"].ToString();
                        }

                    }

                }

            }
        }

        ///PROCEDIMIENTO/FUNCION APARTE

        private void GetNotas(string SPnombre)
        {
            //Procedimiento porque no devuelve ningún valor
            //Void en este contexto es null/nada
            //SPnombre es el nombre del procedimiento almacenado que llega como parámetro de ESTE procedimiento

            try
            {

                SqlConnection cn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true");
                //Se ejecuta completo en tanto no haya errores


                SqlCommand cmd = new SqlCommand();
                //Creo una datatable (matriz) - no permite modificar/solo mostrar
                DataTable dtNotas = new DataTable();

                //Instancio un obj de clase dataadapter (nueva variable)
                SqlDataAdapter daNotas = new SqlDataAdapter();


                cmd.CommandText = "SEL_NOTAS_ALUMNO";
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);
                cmd.Connection.Open();

                daNotas.SelectCommand = cmd;

                //Conecta a la bdd y llena la datatable
                daNotas.Fill(dtNotas);

                //Me fijo si mi tabla tiene filas, si tiene muestro la grilla cambiando el boolean a true
                if (dtNotas.Rows.Count > 0)
                {
                    dgNotasAlumno.Visible = true;
                }
                else
                {
                    lblPromedio.Text = "Sin notas";
                    lblNotMin.Text = "Sin notas";
                    lblNotMax.Text = "Sin notas";

                    //Otra opción: agregar un message box
                }

                //Le asigno al bindign mi datatable llena y así se muestran finalmente
                BindingSourceNotasAlumno.DataSource = dtNotas;

                cmd.Connection.Close();
                cmd.Dispose();
                daNotas.Dispose();
                dtNotas.Dispose();
                cn.Close();
                cn.Dispose();

            }
            catch (SqlException exc)
            {
                //Sólo se ejecuta en caso de error dentro del bloque try
                MessageBox.Show(exc.Message.ToString());

            }
            finally
            {
                //Con error o sin error se ejecuta
            }

        }

        private void cboNotasAlumno_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMatricula.Text = cboNotasAlumno.SelectedValue.ToString();

            btnBuscar.PerformClick();
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgNotasAlumno.Visible = false;


            if (txtMatricula.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para la matrícula", "Búsqueda de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true";

                con.Open();



                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SEL_ALUMNO";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;



                    cmd.Parameters.AddWithValue("MATALU", txtMatricula.Text);



                    SqlDataReader DatosAlumno = cmd.ExecuteReader();

                    if (DatosAlumno.HasRows)
                    {

                        while (DatosAlumno.Read())
                        {
                            lblApellido.Text = DatosAlumno["APEALU"].ToString();   //Asignación de campo de un data reader a una caja de texto
                            lblNombre.Text = DatosAlumno["NOMALU"].ToString();
                            lblCP.Text = DatosAlumno["POSALU"].ToString();
                            lblFecNac.Text = DatosAlumno["FNAALU"].ToString().Substring(0, 10);

                            GetNotas("SEL_NOTAS_ALUMNO");

                            dgNotasAlumno.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                            dgNotasAlumno.Columns[0].HeaderText = "Fecha";
                            dgNotasAlumno.Columns[1].HeaderText = "Asignatura";
                            dgNotasAlumno.Columns[2].HeaderText = "Tipo Examen";
                            dgNotasAlumno.Columns[3].HeaderText = "Nota";



                            dgNotasAlumno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                            dgNotasAlumno.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



                            //Antes de sacar el promedio, me fijo si traje notas
                            if (dgNotasAlumno.Visible)
                            {
                                Promedio();
                            }

                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontró la matrícula ingresada", "Búsqueda de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }

                    DatosAlumno.Close();

                }

            }
        }
    }
    
}
