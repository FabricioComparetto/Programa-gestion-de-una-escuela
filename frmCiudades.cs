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
    public partial class frmCiudades : Form
    {
        BindingSource BindingSourceCiudades = new BindingSource();

        bool blnNuevo = true;
        public frmCiudades()
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
            if (txtPostal.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código Postal", "Grabado de Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNomCiudad.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Nombre de Ciudad", "Grabado de Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.CommandText = "INS_CIUDAD";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("POSCIU", txtPostal.Text);
                        cmd.Parameters.AddWithValue("NOMCIU", txtNomCiudad.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtPostal.Text = "";
                        txtNomCiudad.Text = "";

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
                        cmd.CommandText = "UPD_CIUDAD";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("POSCIU", txtPostal.Text);
                        cmd.Parameters.AddWithValue("NOMCIU", txtNomCiudad.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtPostal.Text = "";
                        txtNomCiudad.Text = "";

                    }
                }
            }
            BindingSourceCiudades.DataSource = GetCiudades("SEL_CIUDADES");

            dgCiudades.DataSource = BindingSourceCiudades;

            CargarCiudades();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtPostal.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código Postal", "Búsqueda de Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    cmd.CommandText = "SEL_CIUDAD";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;


                    //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN LA CAJA DE TEXTO
                    cmd.Parameters.AddWithValue("POSCIU", txtPostal.Text);

                    //Ejecuta el comando y trata de llenar el data reader que se crea en la misma línea con los datos del registro

                    SqlDataReader DatosCiudad = cmd.ExecuteReader();

                    if (DatosCiudad.HasRows) //trajo algo? Tiene filas?
                    {
                        //Encontré al alumno cuya matrícula es la ingresada
                        while (DatosCiudad.Read())
                        {
                            txtPostal.Text = DatosCiudad["POSCIU"].ToString();
                            txtNomCiudad.Text = DatosCiudad["NOMCIU"].ToString();

                            blnNuevo = false; // Hace que si modifico el registro y grabo, vaya por el else (upd) en el botón Grabar
                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontró el Código Postal ingresada", "Búsqueda de Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnNuevo = true;
                    }

                    DatosCiudad.Close();

                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == false)//Buscó la matrícula y la encontró
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show("¿Desea borrar este Código Postal?", "Borrar Alumno", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

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
                            cmd.CommandText = "DEL_CIUDAD";//Nombre procedure
                            cmd.CommandType = CommandType.StoredProcedure;//Tipo
                            cmd.Connection = con;

                            //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                            //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT - LA PK
                            cmd.Parameters.AddWithValue("POSCIU", txtPostal.Text);


                            //EJECUTA EL COMANDO
                            cmd.ExecuteNonQuery();

                            txtPostal.Text = "";
                            txtNomCiudad.Text = "";

                            blnNuevo = true;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe buscar un Código Postal para poder borrarlo", "Borrado de Ciudad", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            BindingSourceCiudades.DataSource = GetCiudades("SEL_CIUDADES");

            dgCiudades.DataSource = BindingSourceCiudades;

            CargarCiudades();
        }

        private void frmCiudades_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            BindingSourceCiudades.DataSource = GetCiudades("SEL_CIUDADES");

            dgCiudades.DataSource = BindingSourceCiudades;

            CargarCiudades();

            SetCiudades();
        }
        private void CargarCiudades()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter("SEL_CIUDADES", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Ciudades");
                    cboCiudades.DisplayMember = "NOMCIU";
                    cboCiudades.ValueMember = "POSCIU";
                    cboCiudades.DataSource = ds.Tables["Ciudades"];
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
        private void SetCiudades()
        {
            dgCiudades.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgCiudades.Columns[0].HeaderText = "Código Postal";
            dgCiudades.Columns[1].HeaderText = "Nombre Ciudad";

            //Números y fechas van por defecto a la derecha
            dgCiudades.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private DataTable GetCiudades(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtCiudades = new DataTable();


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
                    SqlDataAdapter daCiudades = new SqlDataAdapter();



                    daCiudades = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbCiudades = new SqlCommandBuilder(daCiudades);
                    //
                    daCiudades.Fill(dtCiudades);

                    //

                    return dtCiudades;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de Ciudades", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtCiudades;
        }

        private void cboCiudades_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPostal.Text = cboCiudades.SelectedValue.ToString();

            btnBuscar.PerformClick();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPostal.Text = "";
            txtNomCiudad.Text = "";

            blnNuevo = true;
        }
    }
}
