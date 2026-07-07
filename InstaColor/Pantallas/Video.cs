using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Drawing.Imaging;
using System.Threading;
using AForge.Controls;
using Accord.Video.FFMPEG;
using Accord;
using Emgu.CV.Face;
using static Emgu.CV.VideoCapture;

namespace InstaColor.Pantallas
{
    public partial class Video : Form
    {
        public Video()
        {
            InitializeComponent();
            v.filtros = new Filtros();
            v.original = new Mat();
            v.nuevo = new Mat();
            v.playing = false;
            v.stopped = !v.playing;
            v.select = 0;
            v.contador = 1;
            v.frames = new List<Bitmap>();
        }

        private struct VideoV
        {
            internal VideoCapture vc;
            internal bool playing;
            internal bool stopped;
            internal bool filter;
            internal int select;
            internal Filtros filtros;
            internal Mat original;
            internal Mat nuevo;
            internal List<Bitmap> frames;
            internal int contador;
            internal string nombre;
        }

        VideoV v;
        Mat frame;
        Bitmap ff;

        private void bn_Subir_Click(object sender, EventArgs e)
        {
            CargarVideo();
        }

        private void bn_Bajar_Click(object sender, EventArgs e)
        {
            DescargarVideo();
        }

        private void bn_Res_Click(object sender, EventArgs e)
        {
            ReestablecerVideo();
        }

        private void bn_Stop_Click(object sender, EventArgs e)
        {
            StopVideo();
        }

        private void bn_Play_Click(object sender, EventArgs e)
        {
            PlayVideo();
        }

        private void bn_Pause_Click(object sender, EventArgs e)
        {
            PauseVideo();
        }

        private void bn_Aplicar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void cb_Filtros_SelectedIndexChanged(object sender, EventArgs e)
        {
            CambioFiltros();
        }

        private void Video_Load(object sender, EventArgs e)
        {
            CargarFiltros();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            Reproducir();
        }

        private void bn_RGB_Click(object sender, EventArgs e)
        {
            if (!v.filter)
            {
                CrearHistograma(frame.Bitmap, 0);
            }
            else
            {
                CrearHistograma(ff, 0);
            }
        }

        private void bn_Red_Click(object sender, EventArgs e)
        {
            if (!v.filter)
            {
                CrearHistograma(frame.Bitmap, 1);
            }
            else
            {
                CrearHistograma(ff, 1);
            }
        }

        private void bn_Green_Click(object sender, EventArgs e)
        {
            if (!v.filter)
            {
                CrearHistograma(frame.Bitmap, 2);
            }
            else
            {
                CrearHistograma(ff, 2);
            }
        }

        private void bn_Blue_Click(object sender, EventArgs e)
        {
            if (!v.filter)
            {
                CrearHistograma(frame.Bitmap, 3);
            }
            else
            {
                CrearHistograma(ff, 3);
            }
        }

        private void Video_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarForm(e);
        }

        // ##Funciones
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

        private void CargarVideo()
        {
            using (OpenFileDialog vid = new OpenFileDialog())
            {
                vid.Filter = "Archivos de vídeo(*.mp4; *.wmv; *.mkv; *.avi; *.gif) | *.mp4; *.wmv; *.mkv; *.avi; *.gif;|Todos los archivos(*.*) | *.*";
                vid.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                vid.Title = "Seleccione un vídeo";
                if (vid.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //v.entrada = vid.FileName;
                        //Capturamos el vídeo
                        v.nombre = System.IO.Path.GetFileName(vid.FileName);
                        v.vc = new VideoCapture(vid.FileName);
                        //Guardamos el primer frame en un bitmap y los frames en un Mat
                        Bitmap firstframe;
                        firstframe = v.vc.QuerySmallFrame().Bitmap;
                        v.vc.Read(v.original);
                        v.nuevo = v.original.Clone();

                        if (firstframe != null)
                        {
                            pb_video.Image?.Dispose();
                            firstframe.SetResolution(pb_video.Width, pb_video.Height);
                            //CvInvoke.Resize(firstframe, firstframe, new Size(873, 530));
                            pb_video.Image = firstframe;
                        }
                        else
                        {
                            Mensaje("No se pudo cargar la miniatura del vídeo", "Error nulo", 1);
                        }

                        bn_Play.Enabled = true;
                        //MessageBox.Show("Video cargado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        Mensaje($"Ocurrió un error al cargar el vídeo: {ex.Message}", "Error", 1);
                    }
                }
            }
        }

        private void DescargarVideo()
        {
            if(v.frames.Count > 0)
            {
                try
                {
                    using(SaveFileDialog save = new SaveFileDialog())
                    {
                        save.Filter = "Vídeo MP4(*.mp4) | *.mp4 | Vídeo H.264(*.mp4) | *.mp4 | Vídeo H.265(*.hevc) | *.hevc | Vídeo MPEG4-2(*.mp4) | *.mp4 | Vídeo WMF8(*.wmf) | *.wmf | Vídeo WMF(*.wmf) | *.wmf | Vídeo Flash(*.FLV1) | *.flv | Vídeo MPEG2(*.mp2) | *.mp2 | Vídeo RAW(.raw) | *.raw | Todos los archivos(*.*)| *.*";
                        save.Title = "Guardar Vídeo";
                        save.FileName = v.nombre + $"_{v.contador}";
                        int codec = save.FilterIndex;

                        if (save.ShowDialog() == DialogResult.OK)
                        {
                            using (VideoFileWriter escritor = new VideoFileWriter())
                            {
                                escritor.Open(save.FileName, v.frames[0].Width, v.frames[0].Height, (int)v.vc.GetCaptureProperty(CapProp.Fps), ElegirCodec(codec));
                                foreach (Bitmap frame in v.frames)
                                {
                                    escritor.WriteVideoFrame(frame);
                                }
                                escritor.Close();
                            }
                            v.contador++;
                            Mensaje("Video Procesado Guardado", "Exito al guardar", 0);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Mensaje($"Ha ocurrido un error: {ex.Message}", "Error Vídeo", 1);
                }
            }
            else
            {
                Mensaje("No hay vídeo procesado", "Error Vídeo", 1);
            }
        }

        private VideoCodec ElegirCodec(int index)
        {
            VideoCodec codec = new VideoCodec();

            switch (index)
            {
                case 1:
                    //MP4 trad
                    codec = VideoCodec.MPEG4;
                    break;
                case 2:
                    //H264
                    codec = VideoCodec.H264;
                    break;
                case 3:
                    //H265 4K
                    codec = VideoCodec.H265;
                    break;
                case 4:
                    //MP4-2
                    codec = VideoCodec.MSMPEG4v2;
                    break;
                case 5:
                    //WMF8
                    codec = VideoCodec.WMV2;
                    break;
                case 6:
                    codec = VideoCodec.WMV1;
                    break;
                case 7:
                    //Flash
                    codec = VideoCodec.FLV1;
                    break;
                case 8:
                    //MP2
                    codec = VideoCodec.MPEG2;
                    break;
                case 9:
                    codec = VideoCodec.Default;
                    break;
            }

            return codec;
        }

        private void ReestablecerVideo()
        {
            v.nuevo = v.original.Clone();
            pb_video.Image = v.nuevo.Bitmap;
            cb_Filtros.SelectedIndex = 0;
            v.frames.Clear();
        }

        private void Habilitar()
        {
            bn_Res.Enabled = true;
            bn_RGB.Enabled = true;
            bn_Red.Enabled = true;
            bn_Green.Enabled = true;
            bn_Blue.Enabled = true;
        }

        private void StopVideo()
        {
            if (v.playing && !v.stopped)
            {
                v.playing = false;
                v.stopped = true;
                timer.Stop();
                v.vc.SetCaptureProperty(CapProp.PosFrames, 0);
                //MessageBox.Show("Reproducción detenida.");
            }
        }

        private void PauseVideo()
        {
            if (v.playing)
            {
                v.playing = false;
                bn_Pause.BackColor = Color.White;
                //MessageBox.Show("Reproducción Pausada.");
            }
        }

        private void PlayVideo()
        {
            if (!v.playing && v.stopped)
            {
                v.playing = true;
                v.stopped = false;
                bn_Pause.Enabled = true;
                bn_Pause.BackColor = Color.LightGray;
                bn_Stop.Enabled = true;
                timer.Interval = (int)(1000 / v.vc.GetCaptureProperty(CapProp.Fps)); // Ajustar a la velocidad de fotogramas
                timer.Start();
                //MessageBox.Show("Reproducción iniciada.");
            }else if(!v.playing && !v.stopped)
            {
                v.playing = true;
            }
        }

        private void AplicarFiltro()
        {
            if (v.select > 0)
            {
                if (!v.playing)
                {
                    v.filter = true;
                    Bitmap firstframe = v.vc.QuerySmallFrame().Bitmap;
                    if (firstframe != null)
                    {
                        pb_video.Image?.Dispose();
                        firstframe.SetResolution(pb_video.Width, pb_video.Height);
                        pb_video.Image = FiltrarVideo(firstframe); ;
                    }
                    else
                    {
                        Mensaje("No se pudo cargar el primer cuadro del video.", "Error vídeo", 1);
                    }
                }
                else
                {
                    Mensaje("Detenga el reproductor", "Vídeo reproduciendose", 2);
                }
            }
            else
            {
                Mensaje("No se ha seleccionado un filtro", "Sin filtro", 3);
            }
        }

        private Bitmap FiltrarVideo(Bitmap filteredFrame)
        {
            int a = tbar_Ajuste.Value;
            if (!v.filter) { return filteredFrame; }

            try
            {
                switch (v.select)
                {
                    case 1:
                        v.filtros.InvertirVid(filteredFrame, a);
                        break;
                    case 2:
                        v.filtros.MonocromaticoVid(filteredFrame, a);
                        break;
                    case 3:
                        v.filtros.NegativoVid(filteredFrame, a);
                        break;
                    case 4:
                        v.filtros.TonosGrisesVid(filteredFrame, a);
                        break;
                    case 5:
                        v.filtros.Gamma(filteredFrame, a);
                        break;
                    case 6:
                        v.filtros.Surreal(filteredFrame, a);
                        break;
                    case 7:
                        v.filtros.Psicodelico(filteredFrame, a);
                        break;
                    case 8:
                        v.filtros.Cruzado(filteredFrame, a);
                        break;
                    case 9:
                        v.filtros.AberracionVid(filteredFrame, a);
                        break;
                    case 10:
                        v.filtros.Intensidad(filteredFrame, a);
                        break;
                    case 11:
                        v.filtros.Contraste(filteredFrame, a);
                        break;
                    case 12:
                        v.filtros.Brillo(filteredFrame, a);
                        break;
                    case 13:
                        v.filtros.PixeladoVid(filteredFrame, a);
                        break;
                    case 14:
                        Random rnd = new Random();
                        v.filtros.RuidoVid(filteredFrame, rnd, a);
                        break;
                    case 15:
                        v.filtros.FiltroColorVid(filteredFrame, 1, a);
                        break;
                    case 16:
                        v.filtros.FiltroColorVid(filteredFrame, 2, a);
                        break;
                    case 17:
                        v.filtros.FiltroColorVid(filteredFrame, 3, a);
                        break;
                    case 18:
                        v.filtros.FiltroColorVid(filteredFrame, 4, a);
                        break;
                    case 19:
                        v.filtros.FiltroColorVid(filteredFrame, 5, a);
                        break;
                    case 20:
                        v.filtros.FiltroColorVid(filteredFrame, 6, a);
                        break;
                    default:
                        MessageBox.Show("Filtro no implementado.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al aplicar el filtro: {ex.Message}");
            }

            return filteredFrame;
        }

        private void CambioFiltros()
        {
            v.select = cb_Filtros.SelectedIndex;
            if (v.select <= 0)
            {
                tbar_Ajuste.Enabled = false;
                v.filter = false;

            }
            else if (v.select > 10 && v.select < 13)
            {
                //tbar2 -10 a 10
                tbar_Ajuste.Visible = false;
                //tbar_Ajuste.Maximum = 10;
                tbar_Ajuste.Minimum = -10;
                tbar_Ajuste.Value = 0;
                lb_A1.Text = "-10";
                lb_A2.Text = "0";
                lb_A3.Text = "10";
                pl_RGB.Visible = false;
                pl_Grad.Visible = false;
            }
            else if (v.select == 22)
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
                tbar_Ajuste.Value = 10;
                lb_A1.Text = "0";
                lb_A2.Text = "5";
                lb_A3.Text = "10";
                //panel1
                pl_RGB.Visible = false;
                //panel2
                pl_Grad.Visible = false;
                v.filter = true;
            }
        }

        private void CargarFiltros()
        {
            cb_Filtros.DataSource = v.filtros.listaFiltrosVid;
            cb_Filtros.SelectedIndex = v.select;
        }

        private void Reproducir()
        {
            if (v.vc != null)
            {
                frame = v.nuevo;
                Habilitar();
                v.vc.Read(frame);

                // Leer fotogramas
                if (!frame.IsEmpty)
                {
                    if (v.playing && !v.stopped)
                    {
                        if (v.filter)
                        {
                            ff = (Bitmap)frame.Bitmap.Clone();
                            pb_video.Image = FiltrarVideo(ff);
                            v.frames.Add(ff);
                        }
                        else
                        {
                            pb_video.Image = frame.Bitmap;
                        }
                    }
                    else if(!v.playing && v.stopped)
                    {
                        StopVideo();
                    }
                }
                else if (frame.IsEmpty && v.filter)
                {
                    StopVideo();
                    bn_Bajar.Enabled = true;
                    Mensaje("Vídeo procesado con éxito.", "Vídeo filtrado", 0);
                }
                else
                {
                    StopVideo();
                    //MessageBox.Show("Reproducción finalizada.");
                }
            }
            else
            {
                Mensaje("No se ha cargado un vídeo en el reproductor", "Vídeo vacío", 2);
            }
        }

        private void CrearHistograma(Bitmap histograma, int opc)
        {
            Histograma h = new Histograma(histograma, opc);
            h.Show();
        }

        private void Limpiar()
        {
            if (v.stopped)
            {
                v.frames.Clear();
                v.vc.Dispose();
                v.filtros = null;
                v.original.Dispose();
                v.nuevo.Dispose();
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
