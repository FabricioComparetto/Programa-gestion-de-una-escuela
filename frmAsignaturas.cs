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
    public partial class frmAsignaturas : Form
    {
        BindingSource BindingSourceAsignaturas = new BindingSource();

        bool blnNuevo = true;
        public frmAsignaturas()
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
            if (txtCodAsignatura.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código de Asignatura", "Grabado de Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNomAsignatura.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Nombre de Asignatura", "Grabado de Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.CommandText = "INS_ASIGNATURA";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("CODASI", txtCodAsignatura.Text);
                        cmd.Parameters.AddWithValue("NOMASI", txtNomAsignatura.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtCodAsignatura.Text = "";
                        txtNomAsignatura.Text = "";

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
                        cmd.CommandText = "UPD_ASIGNATURA";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("CODASI", txtCodAsignatura.Text);
                        cmd.Parameters.AddWithValue("NOMASI", txtNomAsignatura.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtCodAsignatura.Text = "";
                        txtNomAsignatura.Text = "";

                    }
                }
            }
            BindingSourceAsignaturas.DataSource = GetAsignaturas("SEL_ASIGNATURAS");

            dgAsignaturas.DataSource = BindingSourceAsignaturas;

            CargarAsignaturas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodAsignatura.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código de Asignatura", "Búsqueda de Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Busca la mat especificada y si la encuentra blnNuevo pasa a false.
            //Si no la encuentra debe permanecer en true.
            using (SqlConnection con = new SqlConnection())
            {
                //Abrir conexión
                // cadena de conexión o connection string: donde se tiene q conectar mi programa
                // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Escuela; Integrated Security = true"; //copiar cadena del botón Grabar
                //Abro conexión
                con.Open();


                //Representa el objeto que utiliza el SP para ejecutarse
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SEL_ASIGNATURA";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;


                    //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN LA CAJA DE TEXTO
                    cmd.Parameters.AddWithValue("CODASI", txtCodAsignatura.Text);

                    //Ejecuta el comando y trata de llenar el data reader que se crea en la misma línea con los datos del registro

                    SqlDataReader DatosAsignatura = cmd.ExecuteReader();

                    if (DatosAsignatura.HasRows) //trajo algo? Tiene filas?
                    {
                        //Encontré al alumno cuya matrícula es la ingresada
                        while (DatosAsignatura.Read())
                        {
                            txtCodAsignatura.Text = DatosAsignatura["CODASI"].ToString();
                            txtNomAsignatura.Text = DatosAsignatura["NOMASI"].ToString();

                            blnNuevo = false; // Hace que si modifico el registro y grabo, vaya por el else (upd) en el botón Grabar
                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontró el Código de Asignatura ingresada", "Búsqueda de Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnNuevo = true;
                    }

                    DatosAsignatura.Close();

                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == false)//Buscó la matrícula y la encontró
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show("¿Desea borrar este Código de Asignatura?", "Borrar Asignatura", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (respuesta == DialogResult.Yes) //Si presionó el botón SI
                {
                    //Borro registro
                    using (SqlConnection con = new SqlConnection())
                    {
                        //Abrir conexión
                        // cadena de conexión o connect string: donde se tiene q conectar mi programa
                        // a qué servidor, credenciales (nombre de usuario y contraseña o credenciales de usuario de windows)
                        con.ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Escuela; Integrated Security = true";
                        //Conecto 
                        con.Open();

                        //Defino el comando que apunta a del_alumno
                        //Representa el objeto q vos queres usar en la BDD
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.CommandText = "DEL_ASIGNATURA";//Nombre procedure
                            cmd.CommandType = CommandType.StoredProcedure;//Tipo
                            cmd.Connection = con;

                            //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                            //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT - LA PK
                            cmd.Parameters.AddWithValue("CODASI", txtCodAsignatura.Text);


                            //EJECUTA EL COMANDO
                            cmd.ExecuteNonQuery();

                            txtCodAsignatura.Text = "";
                            txtNomAsignatura.Text = "";

                            blnNuevo = true;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe buscar un Código de Asignatura para poder borrarlo", "Borrado de Asignatura", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindingSourceAsignaturas.DataSource = GetAsignaturas("SEL_ASIGNATURAS");

            dgAsignaturas.DataSource = BindingSourceAsignaturas;
            
            CargarAsignaturas();
        }

        private void frmAsignaturas_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            BindingSourceAsignaturas.DataSource = GetAsignaturas("SEL_ASIGNATURAS");

            dgAsignaturas.DataSource = BindingSourceAsignaturas;

            SetAsignaturas();

            CargarAsignaturas();
        }
        private void CargarAsignaturas()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter("SEL_ASIGNATURAS", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Asignaturas");
                    cboAsignaturas.DisplayMember = "NOMASI";
                    cboAsignaturas.ValueMember = "CODASI";
                    cboAsignaturas.DataSource = ds.Tables["Asignaturas"];
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo cargar.");
                }
                
            }
        }

        private void SetAsignaturas()
        {
            dgAsignaturas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgAsignaturas.Columns[0].HeaderText = "Código Asignatura";
            dgAsignaturas.Columns[1].HeaderText = "Nombre Asignatura";

            //Números y fechas van por defecto a la derecha
            dgAsignaturas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private DataTable GetAsignaturas(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtAsignaturas = new DataTable();


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
                    SqlDataAdapter daAsignaturas = new SqlDataAdapter();



                    daAsignaturas = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbAsignaturas = new SqlCommandBuilder(daAsignaturas);
                    //
                    daAsignaturas.Fill(dtAsignaturas);

                    //

                    return dtAsignaturas;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de Asignaturas", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtAsignaturas;
        }

        private void cboAsignaturas_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodAsignatura.Text = cboAsignaturas.SelectedValue.ToString();

            btnBuscar.PerformClick();
        }

        private void lblLimpiar_Click(object sender, EventArgs e)
        {
            txtCodAsignatura.Text = "";
            txtNomAsignatura.Text = "";

            blnNuevo = true;
        }
    }
}
    

