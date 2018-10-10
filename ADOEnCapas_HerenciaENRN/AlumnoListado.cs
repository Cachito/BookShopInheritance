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
    public partial class AlumnoListado : Form
    {
        public AlumnoListado()
        {
            InitializeComponent();
        }

        private void AlumnoListado_Load(object sender, EventArgs e)
        {
            grdAlumnos.Columns.Add("Id", "Id");
            grdAlumnos.Columns["Id"].Visible = false;
            grdAlumnos.Columns.Add("Nombre", "Nombre");
            grdAlumnos.Columns["Nombre"].Width = 200;
            grdAlumnos.Columns.Add("Apellido", "Apellido");
            grdAlumnos.Columns["Apellido"].Width = 200;
            grdAlumnos.Columns.Add("Documento", "Documento");
            grdAlumnos.Columns["Documento"].Width = grdAlumnos.Width - 403;
            grdAlumnos.RowHeadersVisible = false;
            grdAlumnos.AllowUserToAddRows = false;
            grdAlumnos.AllowUserToDeleteRows = false;
            grdAlumnos.EditMode = DataGridViewEditMode.EditProgrammatically;
            grdAlumnos.MultiSelect = false;
            grdAlumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            Actualizar();
        }

        private void Actualizar()
        {
            grdAlumnos.Rows.Clear();
            foreach (Alumno mPers in (new AlumnoBL()).Listar())
            {
                grdAlumnos.Rows.Add(mPers.Id, mPers.Nombre, mPers.Apellido, mPers.Documento);

            }
        }

        private void b_Click(object sender, EventArgs e)
        {
            AlumnoABM mForm = new AlumnoABM();
            mForm.StartPosition = FormStartPosition.CenterParent;
            mForm.TipoOperacion = Constantes.TiposOperacion.Alta;
            mForm.ShowDialog(this);
            Actualizar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (grdAlumnos.SelectedRows.Count > 0)
            {
                int mId = int.Parse(grdAlumnos.SelectedRows[0].Cells[0].Value.ToString());
                AlumnoABM mForm = new AlumnoABM();
                mForm.StartPosition = FormStartPosition.CenterParent;
                mForm.AlumnoAEditar = (new AlumnoBL()).Obtener(mId);
                mForm.TipoOperacion = Constantes.TiposOperacion.Modificacion;
                mForm.ShowDialog(this);
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Alumno para modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (grdAlumnos.SelectedRows.Count > 0)
            {
                int mId = int.Parse(grdAlumnos.SelectedRows[0].Cells[0].Value.ToString());
                AlumnoABM mForm = new AlumnoABM();
                mForm.StartPosition = FormStartPosition.CenterParent;
                mForm.AlumnoAEditar = (new AlumnoBL()).Obtener(mId);
                mForm.TipoOperacion = Constantes.TiposOperacion.Baja;
                mForm.ShowDialog(this);
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Alumno para eliminar");
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (grdAlumnos.SelectedRows.Count > 0)
            {
                int mId = int.Parse(grdAlumnos.SelectedRows[0].Cells[0].Value.ToString());
                AlumnoABM mForm = new AlumnoABM();
                mForm.StartPosition = FormStartPosition.CenterParent;
                mForm.AlumnoAEditar = (new AlumnoBL()).Obtener(mId);
                mForm.TipoOperacion = Constantes.TiposOperacion.Consulta;
                mForm.ShowDialog(this);
                Actualizar();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Alumno para eliminar");
            }
        }
    }
}
