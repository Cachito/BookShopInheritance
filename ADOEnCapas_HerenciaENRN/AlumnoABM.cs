using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using BE;

namespace ADOEnCapas_HerenciaENRN
{
    public partial class AlumnoABM : Form
    {

        internal Constantes.TiposOperacion TipoOperacion { get; set; }
        internal Alumno AlumnoAEditar { get; set; }

        public AlumnoABM()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlumnoABM_Load(object sender, EventArgs e)
        {
            InicializarPagina();
            this.Height = btnCancelar.Top + btnCancelar.Height + 80;
        }

        private void InicializarPagina()
        {
            switch (TipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    LimpiarCampos();
                    lblAlumnos.Text = "Alta de Alumno";

                    break;
                case Constantes.TiposOperacion.Modificacion:
                    if (AlumnoAEditar == null)
                    {
                        MessageBox.Show("No se ha especificado el Alumno a modificar");
                        this.Close();
                    }
                    CargarCampos(AlumnoAEditar);
                    lblAlumnos.Text = "Modificación de Alumno";
                    break;
                case Constantes.TiposOperacion.Baja:
                    if (AlumnoAEditar == null)
                    {
                        MessageBox.Show("No se ha especificado el Alumno a eliminar");
                        this.Close();
                    }
                    CargarCampos(AlumnoAEditar);
                    DeshabilitarCampos();
                    lblAlumnos.Text = "¿Seguro desea eliminar a el Alumno?";
                    lblAlumnos.ForeColor = Color.Red;
                    btnGuardar.Text = "Eliminar";
                    break;
                case Constantes.TiposOperacion.Consulta:
                    if (AlumnoAEditar == null)
                    {
                        MessageBox.Show("No se ha especificado el Alumno");
                        this.Close();
                    }
                    CargarCampos(AlumnoAEditar);
                    DeshabilitarCampos();
                    lblAlumnos.Text = "Detalle del Alumno";
                    this.Controls.Remove(this.btnGuardar);
                    btnCancelar.Text = "Cerrar";
                    btnCancelar.Left = btnCancelar.Parent.Width / 2 - btnCancelar.Width / 2;
                    break;
            }
        }


        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDocumento.Text = "";
            txtLegajo.Text = "";
            txtAnio.Text = "";
        }

        private void DeshabilitarCampos()
        {
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            txtDocumento.Enabled = false;
            txtAnio.Enabled = false;
            txtLegajo.Enabled = false;
        }

        private void CargarCampos(Alumno pAlumno)
        {
            txtNombre.Text = pAlumno.Nombre;
            txtApellido.Text = pAlumno.Apellido;
            txtDocumento.Text = pAlumno.Documento;
            txtLegajo.Text = pAlumno.Legajo;
            txtAnio.Text = pAlumno.AnioIngreso.ToString();
        }

        private void ValorizarEntidad(Alumno pAlumno)
        {
            pAlumno.Nombre = txtNombre.Text;
            pAlumno.Apellido = txtApellido.Text;
            pAlumno.Documento = txtDocumento.Text;
            pAlumno.Legajo = txtLegajo.Text;
            pAlumno.AnioIngreso = int.Parse(txtAnio.Text);
        }

        private void b_Click(object sender, EventArgs e)
        {
            AlumnoBL mPBL;
            switch (TipoOperacion)
            {
                case Constantes.TiposOperacion.Alta:
                    AlumnoAEditar = new Alumno();
                    ValorizarEntidad(AlumnoAEditar);
                    mPBL = new AlumnoBL();
                    mPBL.Guardar(AlumnoAEditar);
                    this.Close();
                    break;
                case Constantes.TiposOperacion.Modificacion:
                    ValorizarEntidad(AlumnoAEditar);
                    mPBL = new AlumnoBL();
                    mPBL.Guardar(AlumnoAEditar);
                    this.Close();
                    break;
                case Constantes.TiposOperacion.Baja:
                    mPBL = new AlumnoBL();
                    mPBL.Eliminar(AlumnoAEditar);
                    this.Close();
                    break;
            }
        }
    }
}
