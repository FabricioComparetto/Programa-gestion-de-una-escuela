using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escuela
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gestionDeAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnos Alumnos = new frmAlumnos();

            Alumnos.Show();
        }

        private void gestionDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotas Notas = new frmNotas();

            Notas.Show();
        }

        private void ciudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCiudades Ciudades = new frmCiudades();

            Ciudades.Show();
        }

        private void asignaturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAsignaturas Asignaturas = new frmAsignaturas();

            Asignaturas.Show();
        }

        private void tipoDeExamenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposExamen TiposExamen = new frmTiposExamen();

            TiposExamen.Show();
        }

        private void listadoDeNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotasLista ListaNotas = new frmNotasLista();

            ListaNotas.Show();
        }

        private void notasDeAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNotasAlumno AlumnoNotas = new frmNotasAlumno();

            AlumnoNotas.Show();
        }

        private void listadoDeAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAlumnosLista ListaAlumnos = new frmAlumnosLista();
           
            ListaAlumnos.Show();
        }
    }
}
