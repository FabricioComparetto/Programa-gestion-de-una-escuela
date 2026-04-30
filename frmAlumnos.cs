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
    public partial class frmAlumnos : Form
    {
        
        BindingSource BindingSourceAlumno = new BindingSource();

        bool blnNuevo = true;
        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            //Validaciones
            if (txtMatricula.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para la matrícula", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Apellido", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Nombre", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtDNI.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para DNI", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPostal.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Código Postal", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFecNac.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Fecha de Nacimiento", "Grabado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            if (blnNuevo)//Si es un booleano no es necesario poner la asignación
            {
                // Conexión a la BDD
                //Declaro variable con tipo nombre = new..
                using (SqlConnection con = new SqlConnection())
                {
                    //Abrir conexión
                    // cadena de conexión o connect string: donde se tiene q conectar mi programa
                    // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                    con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Escuela; Integrated Security = true";
                    //Conecto 
                con.Open();

                    //Defino el comando que apunta a ins_alumno
                    //Representa el objeto q vos queres usar en la BDD
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "INS_ALUMNO";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("MATALU", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("APEALU", txtApellido.Text);
                        cmd.Parameters.AddWithValue("NOMALU", txtNombre.Text);
                        cmd.Parameters.AddWithValue("DNIALU", txtDNI.Text);
                        cmd.Parameters.AddWithValue("POSALU", txtPostal.Text);
                        cmd.Parameters.AddWithValue("FNAALU", txtFecNac.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtMatricula.Text = "";
                        txtApellido.Text = "";
                        txtNombre.Text = "";
                        txtDNI.Text = "";
                        txtPostal.Text = "";
                        txtFecNac.Text = "";

                    }
                }
            }
            else
            {
                // Conexión a la BDD
                //Declaro variable con tipo nombre = new..
                using (SqlConnection con = new SqlConnection())
                {
                    //Abrir conexión
                    // cadena de conexión o connect string: donde se tiene q conectar mi programa
                    // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                    con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Escuela; Integrated Security = true";
                    //Conecto 
                    con.Open();

                    //Defino el comando que apunta a ins_alumno
                    //Representa el objeto q vos queres usar en la BDD
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "UPD_ALUMNO";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("MATALU", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("APEALU", txtApellido.Text);
                        cmd.Parameters.AddWithValue("NOMALU", txtNombre.Text);
                        cmd.Parameters.AddWithValue("DNIALU", txtDNI.Text);
                        cmd.Parameters.AddWithValue("POSALU", txtPostal.Text);
                        cmd.Parameters.AddWithValue("FNAALU", txtFecNac.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtMatricula.Text = "";
                        txtApellido.Text = "";
                        txtNombre.Text = "";
                        txtDNI.Text = "";
                        txtPostal.Text = "";
                        txtFecNac.Text = "";

                    }
                }
            }
            BindingSourceAlumno.DataSource = GetAlumno("SEL_ALUMNOS");

            dgAlumno.DataSource = BindingSourceAlumno;

            CargarAlumnos();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == false)//Buscó la matrícula y la encontró
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show("¿Desea borrar este alumno?", "Borrar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (respuesta == DialogResult.Yes) //Si presionó el botón SI
                {
                    //Borro registro
                    using (SqlConnection con = new SqlConnection())
                    {
                        //Abrir conexión
                        // cadena de conexión o connect string: donde se tiene q conectar mi programa
                        // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                        con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true";
                        //Conecto 
                        con.Open();

                        //Defino el comando que apunta a del_alumno
                        //Representa el objeto q vos queres usar en la BDD
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "DEL_ALUMNO";//Nombre procedure
                            cmd.CommandType = CommandType.StoredProcedure;//Tipo
                            cmd.Connection = con;

                            //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                            //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT - LA PK
                            cmd.Parameters.AddWithValue("MATALU", txtMatricula.Text);


                            //EJECUTA EL COMANDO
                            cmd.ExecuteNonQuery();

                            txtMatricula.Text = "";
                            txtApellido.Text = "";
                            txtNombre.Text = "";                           
                            txtPostal.Text = "";
                            txtFecNac.Text = "";
                            txtDNI.Text = "";

                            blnNuevo = true;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe buscar un alumno para poder borrarlo", "Borrado de alumno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            BindingSourceAlumno.DataSource = GetAlumno("SEL_ALUMNOS");

            dgAlumno.DataSource = BindingSourceAlumno;

            CargarAlumnos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para la matrícula", "Búsqueda de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Busca la mat especificada y si la encuentra blnNuevo pasa a false.
            //Si no la encuentra debe permanecer en true.
            using (SqlConnection con = new SqlConnection())
            {
                //Abrir conexión
                // cadena de conexión o connection string: donde se tiene q conectar mi programa
                // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"; //copiar cadena del botón Grabar
                //Abro conexión
                con.Open();


                //Representa el objeto que utiliza el SP para ejecutarse
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SEL_ALUMNO";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;


                    //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN LA CAJA DE TEXTO
                    cmd.Parameters.AddWithValue("MATALU", txtMatricula.Text);

                    //Ejecuta el comando y trata de llenar el data reader que se crea en la misma línea con los datos del registro

                    SqlDataReader DatosAlumno = cmd.ExecuteReader();

                    if (DatosAlumno.HasRows) //trajo algo? Tiene filas?
                    {
                        //Encontré al alumno cuya matrícula es la ingresada
                        while (DatosAlumno.Read())
                        {
                            txtApellido.Text = DatosAlumno["APEALU"].ToString();
                            txtNombre.Text = DatosAlumno["NOMALU"].ToString();
                            txtPostal.Text = DatosAlumno["POSALU"].ToString();
                            txtFecNac.Text = DatosAlumno["FNAALU"].ToString().Substring(0, 10);
                            txtDNI.Text = DatosAlumno["DNIALU"].ToString();

                            blnNuevo = false; // Hace que si modifico el registro y grabo, vaya por el else (upd) en el botón Grabar
                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontró la matrícula ingresada", "Búsqueda de alumno", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnNuevo = true;
                    }

                    DatosAlumno.Close();

                }
            }
        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {
            BindingSourceAlumno.DataSource = GetAlumno("SEL_ALUMNOS");

            dgAlumno.DataSource = BindingSourceAlumno;           

            SetAlumno();

            CargarAlumnos();

            
        }
        private void CargarAlumnos()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SEL_ALUMNOS", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Alumnos");
                    cboAlumnos.DisplayMember = "NOMBRE";
                    cboAlumnos.ValueMember = "MATALU";
                    cboAlumnos.DataSource = ds.Tables["Alumnos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
        private void SetAlumno()
        {
            dgAlumno.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgAlumno.Columns[0].HeaderText = "Matrícula";
            dgAlumno.Columns[1].HeaderText = "Apellido";
            dgAlumno.Columns[2].HeaderText = "Nombre";
            dgAlumno.Columns[3].HeaderText = "DNI";
            dgAlumno.Columns[4].HeaderText = "Código Postal";
            dgAlumno.Columns[5].HeaderText = "Fecha de Nacimiento";

            //Números y fechas van por defecto a la derecha
            dgAlumno.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumno.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumno.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgAlumno.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgAlumno.Columns[6].Visible = false;
            dgAlumno.Columns[7].Visible = false;
            dgAlumno.Columns[8].Visible = false;
        }


        private DataTable GetAlumno(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtAlumno = new DataTable();


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
                    SqlDataAdapter daAlumno = new SqlDataAdapter();



                    daAlumno = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbAlumnos = new SqlCommandBuilder(daAlumno);
                    //
                    daAlumno.Fill(dtAlumno);

                    //

                    return dtAlumno;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de alumno", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtAlumno;
        }

        private void cboAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {         
            txtMatricula.Text = cboAlumnos.SelectedValue.ToString();

            btnBuscar.PerformClick();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDNI.Text = "";
            txtPostal.Text = "";
            txtFecNac.Text = "";

            blnNuevo = true;
        }
    }  
}
