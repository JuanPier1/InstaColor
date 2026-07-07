using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstaColor.Pantallas
{
    public partial class InicioUC : UserControl
    {
        public InicioUC()
        {
            InitializeComponent();
        }

        internal bool cerrar;

        private void bn_Inicio_Click(object sender, EventArgs e)
        {
            cerrar = false;
            var seg = Application.OpenForms[1];
            var ini = Application.OpenForms[0];
            ini.Show();
            seg.Close();
            //int formulariosAbiertos = Application.OpenForms.Count;
            //MessageBox.Show("Formularios abiertos: " + formulariosAbiertos);
        }

        private void InicioUC_Load(object sender, EventArgs e)
        {
            cerrar = true;
        }
    }
}
