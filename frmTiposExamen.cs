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
    public partial class frmTiposExamen : Form
    {
        BindingSource BindingSourceTiposExamen = new BindingSource();

        bool blnNuevo = true;
        public frmTiposExamen()
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
            if (txtCodigoExamen.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código de Examen ", "Grabado del Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNombreExamen.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Nombre de Examen", "Grabado del Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.CommandText = "INS_TIPO_EXAMEN";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("CODTIP", txtCodigoExamen.Text);
                        cmd.Parameters.AddWithValue("NOMTIP", txtNombreExamen.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtCodigoExamen.Text = "";
                        txtNombreExamen.Text = "";

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
                        cmd.CommandText = "UPD_TIPO_EXAMEN";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("CODTIP", txtCodigoExamen.Text);
                        cmd.Parameters.AddWithValue("NOMTIP", txtNombreExamen.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtCodigoExamen.Text = "";
                        txtNombreExamen.Text = "";

                    }
                }
            }
            BindingSourceTiposExamen.DataSource = GetTiposExamen("SEL_TIPOS_EXAMEN");

            dgTiposExamen.DataSource = BindingSourceTiposExamen;

            CargarTiposExamen();
        }
     
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigoExamen.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para el Código de Examen", "Búsqueda de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    cmd.CommandText = "SEL_TIPO_EXAMEN";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;

                    //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN LA CAJA DE TEXTO
                    cmd.Parameters.AddWithValue("CODTIP", txtCodigoExamen.Text);

                    //Ejecuta el comando y trata de llenar el data reader que se crea en la misma línea con los datos del registro

                    SqlDataReader DatosTipoExamen = cmd.ExecuteReader();

                    if (DatosTipoExamen.HasRows) //trajo algo? Tiene filas?
                    {
                        //Encontré al alumno cuya matrícula es la ingresada
                        while (DatosTipoExamen.Read())
                        {
                            txtCodigoExamen.Text = DatosTipoExamen["CODTIP"].ToString();
                            txtNombreExamen.Text = DatosTipoExamen["NOMTIP"].ToString();

                            blnNuevo = false; // Hace que si modifico el registro y grabo, vaya por el else (upd) en el botón Grabar
                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontró el Código de Examen ingresado", "Búsqueda de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnNuevo = true;
                    }
                    DatosTipoExamen.Close();
                }
            }
        }
      
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == false)//Buscó la matrícula y la encontró
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show("¿Desea borrar este Código de Examen?", "Borrar Tipo de Examen", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

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
                            cmd.CommandText = "DEL_TIPO_EXAMEN";//Nombre procedure
                            cmd.CommandType = CommandType.StoredProcedure;//Tipo
                            cmd.Connection = con;

                            //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                            //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT - LA PK
                            cmd.Parameters.AddWithValue("CODTIP", txtCodigoExamen.Text);

                            //EJECUTA EL COMANDO
                            cmd.ExecuteNonQuery();

                            txtCodigoExamen.Text = "";
                            txtNombreExamen.Text = "";

                            blnNuevo = true;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe buscar un Código de Examen para poder borrarlo", "Borrado de Tipo de Examen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindingSourceTiposExamen.DataSource = GetTiposExamen("SEL_TIPOS_EXAMEN");

            dgTiposExamen.DataSource = BindingSourceTiposExamen;

            CargarTiposExamen();
        }

        private void frmTiposExamen_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            BindingSourceTiposExamen.DataSource = GetTiposExamen("SEL_TIPOS_EXAMEN");

            dgTiposExamen.DataSource = BindingSourceTiposExamen;

            SetTiposExamen();

            CargarTiposExamen();
        }
        
        private void CargarTiposExamen()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter("SEL_TIPOS_EXAMEN", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Tipos_Examen");
                    cboTiposExamen.DisplayMember = "NOMTIP";
                    cboTiposExamen.ValueMember = "CODTIP";
                    cboTiposExamen.DataSource = ds.Tables["Tipos_Examen"];
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
        private void SetTiposExamen()
        {
            dgTiposExamen.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgTiposExamen.Columns[0].HeaderText = "Código Examen";
            dgTiposExamen.Columns[1].HeaderText = "Nombre Examen";

            //Números y fechas van por defecto a la derecha
            dgTiposExamen.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private DataTable GetTiposExamen(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtTiposExamen = new DataTable();


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
                    SqlDataAdapter daTiposExamen = new SqlDataAdapter();



                    daTiposExamen = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbTiposExamen = new SqlCommandBuilder(daTiposExamen);
                    //
                    daTiposExamen.Fill(dtTiposExamen);

                    //

                    return dtTiposExamen;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de los Tipos de Examen", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtTiposExamen;
        }

        private void cboTiposExamen_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCodigoExamen.Text = cboTiposExamen.SelectedValue.ToString();

            btnBuscar.PerformClick();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigoExamen.Text = "";
            txtNombreExamen.Text = "";

            blnNuevo = true;
        }
    }
}