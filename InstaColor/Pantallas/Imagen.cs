using Emgu.CV.ImgHash;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace InstaColor.Pantallas
{
    public partial class Imagen : Form
    {
        public Imagen()
        {
            InitializeComponent();
            v.girar = false;
            v.select = 0;
            v.filtros = new Filtros();
            v.contador = 1;
        }

        private struct ImagenV
        {
            internal Image original;
            internal Image nueva;
            internal string nombre;
            internal bool girar;
            internal int select;
            internal Filtros filtros;
            internal int contador;
        }

        ImagenV v;

        private void bn_Subir_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }

        private void bn_Bajar_Click(object sender, EventArgs e)
        {
            DescargarImagen();
        }

        private void bn_Res_Click(object sender, EventArgs e)
        {
            ReestablecerImagen();
        }

        private void bn_IZ_Click(object sender, EventArgs e)
        {
            ZoomImagen(1, pb_Original.Image);
        }

        private void bn_IN_Click(object sender, EventArgs e)
        {
            ZoomImagen(2, pb_Original.Image);
        }

        private void bn_FH_Click(object sender, EventArgs e)
        {
            GirarImagen(1, v.nueva);
        }

        private void bn_FV_Click(object sender, EventArgs e)
        {
            GirarImagen(2, v.nueva);
        }

        private void bn_Aplicar_Click(object sender, EventArgs e)
        {
            AplicarImagen(v.select, v.nueva);
        }

        private void cb_Filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            v.select = CambioFiltros();
        }

        private void Imagen_Load(object sender, EventArgs e)
        {
            CargarFiltros();
        }

        private void bn_RGB_Click(object sender, EventArgs e)
        {
            CrearHistograma(v.nueva, 0);
        }

        private void bn_Red_Click(object sender, EventArgs e)
        {
            CrearHistograma(v.nueva, 1);
        }

        private void bn_Green_Click(object sender, EventArgs e)
        {
            CrearHistograma(v.nueva, 2);
        }

        private void bn_Blue_Click(object sender, EventArgs e)
        {
            CrearHistograma(v.nueva, 3);
        }

        private void Imagen_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarForm(e);
        }

        // FUNCIONES
        public void Mensaje(string m, string t, int opc)
        {
            switch (opc)
            {
                case 1: //Error
                    MessageBox.Show($"{m}", $"{t}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2: //Advertencia
                    MessageBox.Show($"{m}", $"{t}", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3: //Exclamación
                    MessageBox.Show($"{m}", $"{t}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;
                default:
                    MessageBox.Show($"{m}", $"{t}", MessageBoxButtons.OK, MessageBoxIcon.None);
                    break;
            }
        }

        private void CargarImagen()
        {
            using (OpenFileDialog img = new OpenFileDialog())
            {
                try
                {
                    img.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.webp;*.gif;*.wmd;*emf;*.exif;*.heif;*.ico;|Todos los archivos|*.*";
                    img.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                    img.Title = "Seleccione una imagen";
                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        v.nombre = System.IO.Path.GetFileName(img.FileName);
                        v.original = Image.FromFile(img.FileName);
                        v.nueva = (Bitmap)v.original.Clone();
                        pb_Original.Image = v.original;
                        pb_Nueva.Image = v.nueva;
                        HabilitarComp();
                    }
                }
                catch (Exception ex)
                {
                    Mensaje($"Error al cargar la imagen: {ex.Message}", "Error", 1);
                }

                img.Dispose();
            }
        }

        private void DescargarImagen()
        {
            try
            {
                using (SaveFileDialog img = new SaveFileDialog())
                {
                    img.Filter = "Imagen JPEG|*.jpg;*.jpeg|Imagen PNG|*.png|Bitmap|*.bmp|Imagen GIF|*.gif|Imagen Exif|*.exif|Imagen TIFF|*.tiff|Imagen EMF|*.emf|Imagen WMF|*.wmf";
                    img.Title = "Guardar imagen como";
                    img.FileName = v.nombre + $"_{v.contador}";

                    if (img.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format;
                        switch (img.FilterIndex)
                        {
                            case 0:
                                format = ImageFormat.Jpeg;
                                break;
                            case 1:
                                format = ImageFormat.Png;
                                break;
                            case 2:
                                format = ImageFormat.Bmp;
                                break;
                            case 3:
                                format = ImageFormat.Gif;
                                break;
                            case 4:
                                format = ImageFormat.Exif;
                                break;
                            case 5:
                                format = ImageFormat.Tiff;
                                break;
                            case 6:
                                format = ImageFormat.Emf;
                                break;
                            case 7:
                                format = ImageFormat.Wmf;
                                break;
                            default:
                                format = ImageFormat.Jpeg;
                                break;
                        }

                        v.nueva.Save(img.FileName, format);
                    }
                    v.contador++;
                    img.Dispose();
                }
            }catch (Exception ex)
            {
                Mensaje($"Ha ocurrido un error: {ex.Message}", "Error Imagen", 1);
            }
        }

        private void ReestablecerImagen()
        {
            v.nueva = (Bitmap)v.original.Clone();
            pb_Nueva.Image = v.nueva;
        }

        private void ZoomImagen(int opc, Image img)
        {
            if (img != null)
            {
                if (opc == 1 && pb_Nueva.SizeMode == PictureBoxSizeMode.Zoom)
                {
                    //Checar scrollbars
                    pl_img.AutoScroll = true;
                    pl_img.VerticalScroll.Value = 0;
                    pl_img.HorizontalScroll.Value = 0;
                    pl_img.AutoScrollMinSize = new Size(pb_Nueva.Image.Width, pb_Nueva.Image.Height);
                    pb_Nueva.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                else if (opc == 2 && pb_Nueva.SizeMode == PictureBoxSizeMode.AutoSize)
                {
                    pl_img.AutoScrollMinSize = new Size(pl_img.Width, pl_img.Height);
                    pl_img.AutoScroll = false;
                    pb_Nueva.SizeMode = PictureBoxSizeMode.Zoom;

                }
                else
                {
                    Mensaje("Ocurrió un error al aplicar el zoom", "Error", 1);
                }
            }
            else
            {
                Mensaje("No ha subido subido una imagen", "Aviso", 3);
            }
        }

        private void GirarImagen(int opc, Image img)
        {
            if (img != null)
            {
                if(opc == 1)
                {
                    pb_Nueva.Image = v.filtros.FlipHorizontal((Bitmap)img);
                }
                else if(opc == 2)
                {
                    pb_Nueva.Image = v.filtros.FlipVertical((Bitmap)img);
                }
            }
            else
            {
                Mensaje("Imagen a modificar se encuentra vacía", "Problema nulo", 3);
            }
        }

        private void AplicarImagen(int select, Image nuevo)
        {
            if (select > 0)
            {
                if (nuevo != null)
                {
                    Bitmap img = (Bitmap)nuevo.Clone();
                    int a = tbar_Ajuste.Value;
                    int r = '\0', g = '\0', b = '\0', r2 = '\0', g2 = '\0', b2 = '\0';
                    bool rgb1 = false, rgb2 = false;

                    if (pl_RGB.Visible == true)
                    {
                        //validaciones
                        if (!int.TryParse(tb_R.Text, out int resultR))
                        {
                            Mensaje("Debes agregar en R un número entre 0-255", "Aviso", 2);
                        }
                        else if (!int.TryParse(tb_G.Text, out int resultG))
                        {
                            Mensaje("Debes agregar en G un número entre 0-255", "Aviso", 2);
                        }
                        else if (!int.TryParse(tb_B.Text, out int resultB))
                        {
                            Mensaje("Debes agregar en B un número entre 0-255", "Aviso", 2);
                        }
                        else
                        {
                            r = resultR;
                            g = resultG;
                            b = resultB;
                            rgb1 = true;
                        }

                        if (pl_Grad.Visible == true)
                        {
                            //validaciones rgb2
                            if (!int.TryParse(tb_R2.Text, out int resultR2))
                            {
                                Mensaje("Debes agregar un número entre 0-255", "Aviso", 2);
                            }
                            else if (!int.TryParse(tb_G2.Text, out int resultG2))
                            {
                                Mensaje("Debes agregar un número entre 0-255", "Aviso", 2);
                            }
                            else if (!int.TryParse(tb_B2.Text, out int resultB2))
                            {
                                Mensaje("Debes agregar un número entre 0-255", "Aviso", 2);
                            }
                            else
                            {
                                r2 = resultR2;
                                g2 = resultG2;
                                b2 = resultB2;
                                rgb2 = true;
                            }
                        }
                    }

                    switch (select)
                    {
                        case 1:
                            v.filtros.Invertir(img, a);
                            break;
                        case 2:
                            v.filtros.Monocromatico(img, a);
                            break;
                        case 3:
                            v.filtros.Negativo(img, a);
                            break;
                        case 4:
                            v.filtros.TonosGrises(img, a);
                            break;
                        case 5:
                            v.filtros.Gamma(img, a);
                            break;
                        case 6:
                            v.filtros.Surreal(img, a);
                            break;
                        case 7:
                            v.filtros.Psicodelico(img, a);
                            break;
                        case 8:
                            v.filtros.Cruzado(img, a);
                            break;
                        case 9:
                            if (rgb1 && rgb2)
                            {
                                v.filtros.Gradiente(img, r, g, b, r2, g2, b2);
                            }
                            else
                            {
                                Mensaje("No se ha validado los datos para los colores", "Aviso", 3);
                            }
                            break;
                        case 10:
                            v.filtros.Aberracion(img, a);
                            break;
                        case 11:
                            v.filtros.Intensidad(img, a);
                            break;
                        case 12:
                            v.filtros.Contraste(img, a);
                            break;
                        case 13:
                            v.filtros.Brillo(img, a);
                            break;
                        case 14:
                            v.filtros.Mosaicos(img, a);
                            break;
                        case 15:
                            Random rnd = new Random();
                            v.filtros.Ruido(img, a, rnd);
                            break;
                        case 16:
                            v.filtros.FiltroColor(img, 1, a);
                            break;
                        case 17:
                            v.filtros.FiltroColor(img, 2, a);
                            break;
                        case 18:
                            v.filtros.FiltroColor(img, 3, a);
                            break;
                        case 19:
                            v.filtros.FiltroColor(img, 4, a);
                            break;
                        case 20:
                            v.filtros.FiltroColor(img, 5, a);
                            break;
                        case 21:
                            v.filtros.FiltroColor(img, 6, a);
                            break;
                        case 22:
                            if (rgb1)
                            {
                                v.filtros.FiltroColor(img, 0, a, r, g, b);
                            }
                            else
                            {
                                Mensaje("No se ha validado los datos para los colores", "Aviso", 2);
                            }
                            break;
                    }

                    v.nueva = (Bitmap)img.Clone();
                    pb_Nueva.Image = img;
                }
                else
                {
                    Mensaje("No ha cargado una imagen a la aplicación", "Error Imagen", 2);
                }
            }
            else
            {
                Mensaje("No ha seleccionado un filtro", "Selecciona un filtro", 2);
            }
            nuevo.Dispose();
        }

        private int CambioFiltros()
        {
            int select = cb_Filtros.SelectedIndex;

            if (select <= 0)
            {
                tbar_Ajuste.Enabled = false;

            }
            else if (select == 9)
            {
                //Gradiente
                pl_RGB.Visible = true;
                pl_Grad.Visible = true;
                tbar_Ajuste.Enabled = false;
            }
            else if (select > 9 && select < 14)
            {
                //tbar2 -10 a 10
                tbar_Ajuste.Enabled = true;
                tbar_Ajuste.Visible = true;
                //tbar_Ajuste.Maximum = 10;
                tbar_Ajuste.Minimum = -10;
                tbar_Ajuste.Value = 0;
                lb_A1.Text = "-10";
                lb_A2.Text = "0";
                lb_A3.Text = "10";
                pl_RGB.Visible = false;
                pl_Grad.Visible = false;
            }
            else if (select == 22)
            {
                //Color
                pl_RGB.Visible = true;
                pl_Grad.Visible = false;
                tbar_Ajuste.Visible = true;
                tbar_Ajuste.Enabled = true;
            }
            else
            {
                //tbar 0 a 10
                tbar_Ajuste.Enabled = true;
                tbar_Ajuste.Visible = true;
                //tbar_Ajuste.Maximum = 10;
                tbar_Ajuste.Minimum = 0;
                tbar_Ajuste.Value = 0;
                lb_A1.Text = "0";
                lb_A2.Text = "5";
                lb_A3.Text = "10";
                //paneles
                pl_RGB.Visible = false;
                pl_Grad.Visible = false;
            }

            return select;
        }

        private void CargarFiltros()
        {
            cb_Filtros.DataSource = v.filtros.listaFiltros;
            cb_Filtros.SelectedIndex = v.select;
        }

        private void HabilitarComp()
        {
            bn_Bajar.Enabled = true;
            bn_Res.Enabled = true;
            bn_RGB.Enabled = true;
            bn_Red.Enabled = true;
            bn_Green.Enabled = true;
            bn_Blue.Enabled = true;
        }

        private void CrearHistograma(Image histograma, int opc)
        {
            Histograma h = new Histograma((Bitmap)histograma, opc);
            h.Show();
        }

        private void Limpiar(Image original, Image nuevo, Filtros f)
        {
            if (original != null)
            {
                original.Dispose();
                nuevo.Dispose();
                f = null;
            }
        }

        private void CerrarForm(FormClosingEventArgs e)
        {
            bool c = inicioUC1.cerrar;

            if (c)
            {
                if(e.CloseReason == CloseReason.UserClosing)
                {DialogResult result = MessageBox.Show("¿Deseas cerrar la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        Limpiar(v.original, v.nueva, v.filtros);
                        Application.Exit();
                    }
                }
            }
            else
            {
                Limpiar(v.original, v.nueva, v.filtros);
            }
        }

    }
}
