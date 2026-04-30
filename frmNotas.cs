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
    public partial class frmNotas : Form
    {
        BindingSource BindingSourceNotas = new BindingSource();

        bool blnNuevo = true;
        public frmNotas()
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
                MessageBox.Show("Debe ingresar un valor para la Matrícula", "Grabado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtAsignatura.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Asignatura", "Grabado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtTipoNota.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para Tipo de Nota", "Grabado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtFechaNota.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para la Fecha de la Nota", "Grabado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtValorNota.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor de Nota", "Grabado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cmd.CommandText = "INS_NOTA";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("ASINOT", txtAsignatura.Text);
                        cmd.Parameters.AddWithValue("TIPNOT", txtTipoNota.Text);
                        cmd.Parameters.AddWithValue("FECNOT", txtFechaNota.Text);
                        cmd.Parameters.AddWithValue("VALNOT", txtValorNota.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtMatricula.Text = "";
                        txtAsignatura.Text = "";
                        txtTipoNota.Text = "";
                        txtFechaNota.Text = "";
                        txtValorNota.Text = "";

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
                        cmd.CommandText = "UPD_NOTA";//Nombre procedure
                        cmd.CommandType = CommandType.StoredProcedure;//Tipo. es importante esta buena practica.
                        cmd.Connection = con;

                        //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                        //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT
                        cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);
                        cmd.Parameters.AddWithValue("ASINOT", txtAsignatura.Text);
                        cmd.Parameters.AddWithValue("TIPNOT", txtTipoNota.Text);
                        cmd.Parameters.AddWithValue("FECNOT", txtFechaNota.Text);
                        cmd.Parameters.AddWithValue("VALNOT", txtValorNota.Text);

                        //YO mando datos/insertar, borrar o actualizar
                        cmd.ExecuteNonQuery();

                        txtMatricula.Text = "";
                        txtAsignatura.Text = "";
                        txtTipoNota.Text = "";
                        txtFechaNota.Text = "";
                        txtValorNota.Text = "";

                    }
                }
            }
            
            BindingSourceNotas.DataSource = GetNotas("SEL_NOTAS");

            dgNotas.DataSource = BindingSourceNotas;

            CargarMatricula();

            CargarAsignatura();

            CargarTipoNota();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtMatricula.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar un valor para la matrícula", "Búsqueda de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    cmd.CommandText = "SEL_NOTA";//Nombre procedure
                    cmd.CommandType = CommandType.StoredProcedure;//Tipo
                    cmd.Connection = con;


                    //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN LA CAJA DE TEXTO
                    cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);
                    cmd.Parameters.AddWithValue("ASINOT", txtAsignatura.Text);
                    cmd.Parameters.AddWithValue("TIPNOT", txtTipoNota.Text);
                    cmd.Parameters.AddWithValue("FECNOT", txtFechaNota.Text);

                    //Ejecuta el comando y trata de llenar el data reader que se crea en la misma línea con los datos del registro

                    SqlDataReader DatosNota = cmd.ExecuteReader();

                    if (DatosNota.HasRows) //trajo algo? Tiene filas?
                    {
                        //Encontré al alumno cuya matrícula es la ingresada
                        while (DatosNota.Read())
                        {

                            txtValorNota.Text = DatosNota["VALNOT"].ToString();

                            blnNuevo = false; // Hace que si modifico el registro y grabo, vaya por el else (upd) en el botón Grabar
                        }
                    }
                    else
                    {
                        //NO se encontró la matrícula ingresada
                        //Message box parámetros: mensaje/titulocaja/Boton/Icono
                        MessageBox.Show("No se encontraron los datos ingresados", "Búsqueda de Nota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        blnNuevo = true;
                    }

                    DatosNota.Close();

                }
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (blnNuevo == false)//Buscó la matrícula y la encontró
            {
                DialogResult respuesta;

                respuesta = MessageBox.Show("¿Desea borrar esta Nota?", "Borrar Nota", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

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
                            cmd.CommandText = "DEL_NOTA";//Nombre procedure
                            cmd.CommandType = CommandType.StoredProcedure;//Tipo
                            cmd.Connection = con;

                            //SETEO PARAMETROS. ASIGNACION DE VALORES A LOS PARAMETROS
                            //LE ASIGNO AL PARAMETRO EL VALOR QUE ESTE EN EL INPUT - LA PK
                            cmd.Parameters.AddWithValue("MATNOT", txtMatricula.Text);
                            cmd.Parameters.AddWithValue("ASINOT", txtAsignatura.Text);
                            cmd.Parameters.AddWithValue("TIPNOT", txtTipoNota.Text);
                            cmd.Parameters.AddWithValue("FECNOT", txtFechaNota.Text);


                            //EJECUTA EL COMANDO
                            cmd.ExecuteNonQuery();

                            txtMatricula.Text = "";
                            txtAsignatura.Text = "";
                            txtTipoNota.Text = "";
                            txtFechaNota.Text = "";
                            txtValorNota.Text = "";
                            

                            blnNuevo = true;
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe buscar una Nota para poder borrarlo", "Borrado de Nota", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            BindingSourceNotas.DataSource = GetNotas("SEL_NOTAS");

            dgNotas.DataSource = BindingSourceNotas;

            CargarMatricula();

            CargarAsignatura();

            CargarTipoNota();
        }

        private void frmNotas_Load(object sender, EventArgs e)
        {
            //Asigno a mi fuente de dato, la variable que cree
            BindingSourceNotas.DataSource = GetNotas("SEL_NOTAS");

            dgNotas.DataSource = BindingSourceNotas;

            CargarMatricula();

            CargarAsignatura();

            CargarTipoNota();

            SetNotas();
        }
        private void CargarMatricula()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {
                    SqlDataAdapter da = new SqlDataAdapter("SEL_ALUMNOS", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Alumnos");
                    cboMatricula.DisplayMember = "NOMBRE";
                    cboMatricula.ValueMember = "MATALU";
                    cboMatricula.DataSource = ds.Tables["Alumnos"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
        private void CargarAsignatura()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter("SEL_ASIGNATURAS", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Asignaturas");
                    cboAsignatura.DisplayMember = "NOMASI";
                    cboAsignatura.ValueMember = "CODASI";
                    cboAsignatura.DataSource = ds.Tables["Asignaturas"];
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }
        private void CargarTipoNota()
        {
            using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=Escuela;Integrated Security=true"))
            {
                try
                {

                    SqlDataAdapter da = new SqlDataAdapter("SEL_TIPOS_EXAMEN", con);
                    con.Open();
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Tipos_Examen");
                    cboTipoNota.DisplayMember = "NOMTIP";
                    cboTipoNota.ValueMember = "CODTIP";
                    cboTipoNota.DataSource = ds.Tables["Tipos_Examen"];
                }
                catch (Exception ex)
                {

                    MessageBox.Show("No se pudo cargar.");
                }
            }
        }


        private void SetNotas()
        {
            dgNotas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgNotas.Columns[0].HeaderText = "Matrícula";
            dgNotas.Columns[1].HeaderText = "Asignatura";
            dgNotas.Columns[2].HeaderText = "Tipo de Nota";
            dgNotas.Columns[3].HeaderText = "Fecha de Nota";
            dgNotas.Columns[4].HeaderText = "Valor de Nota";

            //Números y fechas van por defecto a la derecha
            dgNotas.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotas.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotas.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotas.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgNotas.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                     
        }


        private DataTable GetNotas(string SPNombre)
        {

            // Procedimiento pq no devuelve ningun valor
            //SPNombre es el nombre del procedimiento almacenado que llega como parámetro del procedimiento
            DataTable dtNotas = new DataTable();


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
                    SqlDataAdapter daNotas = new SqlDataAdapter();



                    daNotas = new SqlDataAdapter(SPNombre, con);

                    SqlCommandBuilder cbNotas = new SqlCommandBuilder(daNotas);
                    //
                    daNotas.Fill(dtNotas);

                    //

                    return dtNotas;

                }

                catch (SqlException exc)

                {

                    //sólo se ejecuta si se produjo algún error dentro del bloque try
                    MessageBox.Show("No se pudieron recuperar los datos de Notas", exc.Message.ToString());


                }
                finally
                {

                    //Con error o sin error se ejecuta


                }

            }
            return dtNotas;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtMatricula.Text = "";
            txtAsignatura.Text = "";
            txtTipoNota.Text = "";
            txtFechaNota.Text = "";
            txtValorNota.Text = "";

            blnNuevo = true;
        }

        private void cboMatricula_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMatricula.Text = cboMatricula.SelectedValue.ToString();
        }

        private void cboAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAsignatura.Text = cboAsignatura.SelectedValue.ToString();
        }

        private void cboTipoNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTipoNota.Text = cboTipoNota.SelectedValue.ToString();
        }
    }   
}
