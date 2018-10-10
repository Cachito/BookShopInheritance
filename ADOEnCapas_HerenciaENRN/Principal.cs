using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOEnCapas_HerenciaENRN
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlumnoListado mForm = new AlumnoListado();
            mForm.MdiParent = this;
            mForm.WindowState = FormWindowState.Maximized;
            mForm.MinimizeBox = false;
            mForm.MaximizeBox = false;
            mForm.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 600;
        }
    }
}
