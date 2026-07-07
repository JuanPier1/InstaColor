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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void bn_Imagen_Click(object sender, EventArgs e)
        {
            var img = new Imagen();
            img.Show();
            this.Hide();
        }

        private void bn_Video_Click(object sender, EventArgs e)
        {
            var vid = new Video();
            vid.Show();
            this.Hide();
        }

        private void bn_Camara_Click(object sender, EventArgs e)
        {
            var cam = new Camara();
            cam.Show();
            this.Hide();
        }

        private void bn_Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ColorButton(btn, true);
        }

        private void bn_Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ColorButton(btn, false);
        }


        private void ColorButton(Button b, bool o)
        {

            if (o)
            {
                b.BackColor = Color.Gainsboro;
            }
            else
            {
                b.BackColor = Color.FromArgb(255, 221, 174);
            }
        }
    }
}
