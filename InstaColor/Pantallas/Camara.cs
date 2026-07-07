using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV.Structure;
using Emgu.CV;
using Emgu.CV.Ocl;
using System.Drawing.Imaging;
using Emgu.Util;

namespace InstaColor.Pantallas
{
    public partial class Camara : Form
    {
        public Camara()
        {
            InitializeComponent();
            v.active = false;
            v.detect = false;
            v.filtrar = false;
            v.select = -1;
            v.selectCam = 0;
            v.rostrosCount = 0;
            v.nfotos = 0;
            v.cam = new VideoCaptureDevice();
            v.filtros = new Filtros();
        }

        private struct CamaraV
        {
            internal VideoCaptureDevice cam;
            internal FilterInfoCollection devices;
            internal bool active;
            internal bool detect;
            internal bool filtrar;
            internal int selectCam;
            internal int select;
            internal int rostrosCount;
            internal int nfotos;
            internal Bitmap frame, filteredFrame;
            internal Filtros filtros;
        }

        CamaraV v;

        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");

        private void bn_activar_Click(object sender, EventArgs e)
        {
            ActivarDispositivo();
        }

        private void bn_detectar_Click(object sender, EventArgs e)
        {
            DetectarRostros();
        }

        private void bn_capturar_Click(object sender, EventArgs e)
        {
            CapturarFoto();
        }

        private void bn_aplicar_Click(object sender, EventArgs e)
        {
            v.filtrar = ActivarFiltro();
        }

        private void btn_actualizar_Click(object sender, EventArgs e)
        {
            AgregarDispositivos();
        }

        private void cb_dispos_SelectedIndexChanged(object sender, EventArgs e)
        {
            v.selectCam = CambioDispositivos();
        }

        private void cb_filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            v.select = CambioFiltros();
        }

        private void bn_guardar_Click(object sender, EventArgs e)
        {
            GuardarFoto();
        }

        private void Camara_Load(object sender, EventArgs e)
        {
            AgregarFiltros();
        }

        private void Camara_Shown(object sender, EventArgs e)
        {
            AgregarDispositivos();
        }

        private void Camara_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarForm(e);
        }


        //Falta etiquetas

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

        private void ActivarDispositivo()
        {
            try
            {
                if (v.selectCam >= 0)
                {
                    if (v.active == false)
                    {
                        v.active = true;
                        bn_activar.BackColor = Color.Salmon;
                        v.cam = new VideoCaptureDevice(v.devices[v.selectCam].MonikerString);
                        v.cam.NewFrame += new NewFrameEventHandler(CapturarFrames);
                        v.cam.Start();
                        bn_capturar.Enabled = true;
                    }
                    else
                    {
                        bn_activar.BackColor = Color.Gainsboro;
                        v.active = false;
                        v.cam.SignalToStop();
                        pb_webcam.Image = null;
                        bn_capturar.Enabled = false;
                    }
                }
                else
                {
                    Mensaje("No ha seleccionado un dispositivo", "Dispositivo no encontrado", 3);
                    cb_dispos.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                Mensaje($"Error al cargar dispositivos: {ex.Message}", "Error dispositivo", 1);
            }
        }

        private void DetectarRostros()
        {
            if (v.selectCam > -1)
            {
                if (v.detect == false)
                {
                    v.detect = true;
                    bn_detectar.BackColor = Color.Salmon;
                    lb_contador.Visible = true;
                    ContarRostros();
                }
                else
                {
                    v.detect = false;
                    bn_detectar.BackColor = Color.Gainsboro;
                    lb_contador.Visible = false;
                }
            }
            else
            {
                Mensaje("No ha seleccionado un dispositivo", "Dispositivo no encontrado", 3);
            }
        }

        private int CambioDispositivos()
        {
            return cb_dispos.SelectedIndex;
        }

        private void AgregarDispositivos()
        {
            if(v.devices != null)
            {
                int dis = v.devices.Count;
                v.devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if(v.devices.Count != dis && v.devices.Count > 0)
                {
                    cb_dispos.Items.Clear();
                    foreach (FilterInfo cam in v.devices)
                    {
                        cb_dispos.Items.Add(cam.Name);
                    }
                }
                else if(v.devices.Count == dis)
                {
                    Mensaje("La lista de dispositivos ya está actualizada", "Aviso", 0);
                }
                else
                {
                    Mensaje("No hay dispositivos de vídeo conectados", "Dispositivos no encontrados", 3);
                }
            }
            else
            {
                v.devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (v.devices.Count > 0)
                {
                    foreach (FilterInfo cam in v.devices)
                    {
                        cb_dispos.Items.Add(cam.Name);
                    }
                }
                else
                {
                    Mensaje("No hay dispositivos de vídeo conectados", "Dispositivos no encontrados", 3);
                }
            }
        }

        private void CapturarFoto()
        {
            if (v.cam != null && v.cam.IsRunning)
            {
                if(v.detect == true) 
                {
                    DetectarRostros();
                }
                pb_foto.Image = pb_webcam.Image;
                bn_guardar.Enabled = true;
            }
        }

        private void GuardarFoto()
        {
            try
            {
                if (pb_foto.Image != null)
                {
                    Image foto = pb_foto.Image;
                    using (SaveFileDialog img = new SaveFileDialog())
                    {
                        img.Filter = "Imagen JPEG|*.jpg;*.jpeg|Imagen PNG|*.png|Bitmap|*.bmp|Imagen GIF|*.gif|Imagen Exif|*.exif|Imagen TIFF|*.tiff|Imagen EMF|*.emf|Imagen WMF|*.wmf";
                        img.Title = "Guardar imagen como";
                        img.FileName = $"FotoCaptura_{v.nfotos}";

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

                            foto.Save(img.FileName, format);
                        }
                        v.nfotos++;
                        img.Dispose();
                        foto.Dispose();
                    }
                }
            }catch (Exception ex)
            {
                Mensaje($"Ha ocurrido un error: {ex.Message}", "Error Cámara", 1);
            }
        }

        private void AgregarFiltros()
        {
            cb_dispos.SelectedIndex = v.select;
            cb_filtros.DataSource = v.filtros.listaFiltrosVid;
            cb_filtros.SelectedIndex = 0;
        }

        private void CapturarFrames(object sender, NewFrameEventArgs eventArgs)
        {
            if(eventArgs.Frame != null)
            {
                v.frame = (Bitmap)eventArgs.Frame.Clone();
                v.filteredFrame = (Bitmap)v.frame.Clone();

                if (v.filtrar)
                {
                    CapturarFramesFiltro();
                    CapturarRostro(v.filteredFrame);
                    v.filteredFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pb_webcam.Image = v.filteredFrame;
                }
                else
                {
                    CapturarRostro(v.frame);
                    v.frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    pb_webcam.Image = v.frame;
                }

                //frame.SetResolution(511, 411);
                
                //Bitmap rFrame = new Bitmap(frame, pb_cam.Width, pb_cam.Height);

            }
            else
            {
                Mensaje("Ha ocurrido un error, no se detecta vídeo en el dispositivo", "Error", 1);
            }
        }

        private int CambioFiltros()
        {
            return cb_filtros.SelectedIndex;
        }

        private bool ActivarFiltro()
        {
            if(v.select == 0)
            {
                Mensaje("No se ha seleccionado un filtro", "Aviso", 3);
                return false;
            }
            return true;
        }

        private Bitmap CapturarFramesFiltro()
        {
            if (v.filteredFrame != null)
            {
                switch (v.select)
                {
                    case 1:
                        v.filtros.InvertirVid(v.filteredFrame);
                        break;
                    case 2:
                        v.filtros.MonocromaticoVid(v.filteredFrame);
                        break;
                    case 3:
                        v.filtros.NegativoVid(v.filteredFrame);
                        break;
                    case 4:
                        v.filtros.TonosGrisesVid(v.filteredFrame);
                        break;
                    case 5:
                        v.filtros.GammaVid(v.filteredFrame);
                        break;
                    case 6:
                        v.filtros.SurrealVid(v.filteredFrame);
                        break;
                    case 7:
                        v.filtros.PsicodelicoVid(v.filteredFrame);
                        break;
                    case 8:
                        v.filtros.CruzadoVid(v.filteredFrame);
                        break;
                    case 9:
                        v.filtros.AberracionVid(v.filteredFrame);
                        break;
                    case 10:
                        v.filtros.IntensidadVid(v.filteredFrame);
                        break;
                    case 11:
                        v.filtros.ContrasteVid(v.filteredFrame);
                        break;
                    case 12:
                        v.filtros.BrilloVid(v.filteredFrame);
                        break;
                    case 13:
                        v.filtros.PixeladoVid(v.filteredFrame);
                        break;
                    case 14:
                        Random rnd = new Random();
                        v.filtros.RuidoVid(v.filteredFrame, rnd);
                        break;
                    case 15:
                        v.filtros.FiltroColorVid(v.filteredFrame, 1);
                        break;
                    case 16:
                        v.filtros.FiltroColorVid(v.filteredFrame, 2);
                        break;
                    case 17:
                        v.filtros.FiltroColorVid(v.filteredFrame, 3);
                        break;
                    case 18:
                        v.filtros.FiltroColorVid(v.filteredFrame, 4);
                        break;
                    case 19:
                        v.filtros.FiltroColorVid(v.filteredFrame, 5);
                        break;
                    case 20:
                        v.filtros.FiltroColorVid(v.filteredFrame, 6);
                        break;
                }
            }
            else
            {
                Mensaje("No se detecta vídeo en el dispositivo", "Error", 1);
            }
            return v.filteredFrame;
        }

        private void ContarRostros(Rectangle[] r = null)
        {
            if (r != null)
            {
                v.rostrosCount = r.Length;
                lb_contador.Invoke((MethodInvoker)(() => lb_contador.Text = "Rostros identificados: " + v.rostrosCount.ToString()));
            }
            else
            {
                lb_contador.Text = "Rostros identificados: " + v.rostrosCount.ToString();
            }
        }

        private void CapturarRostro(Bitmap frame)
        {
            if (v.detect)
            {
                Image<Bgr, byte> grayImage = new Image<Bgr, byte>(frame);
                Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
                foreach (Rectangle rect in rectangles)
                {
                    using (Graphics graphics = Graphics.FromImage(frame))
                    {
                        using (Pen pen = new Pen(Color.Red, 2))
                        {
                            graphics.DrawRectangle(pen, rect);
                        }
                    }
                }
                ContarRostros(rectangles);
            }
        }

        private void Limpiar()
        {
            if (v.cam.IsRunning)
            {
                v.cam.Stop();
            }
            else if (v.frame != null)
            {
                v.frame.Dispose();
                v.filteredFrame.Dispose();
                v.cam = null;
                v.devices.Clear();
                v.filtros = null;
            }
        }

        private void CerrarForm(FormClosingEventArgs e)
        {
            bool c = inicioUC1.cerrar;

            if (c)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    DialogResult result = MessageBox.Show("¿Deseas cerrar la aplicación?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        Limpiar();
                        Application.Exit();
                    }
                }
            }
            else
            {
                Limpiar();
            }
        }
    }
}
