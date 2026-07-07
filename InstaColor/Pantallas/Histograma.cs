using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace InstaColor.Pantallas
{
    public partial class Histograma : Form
    {
        public Histograma(Bitmap imagen, int opcion)
        {
            InitializeComponent();
            this.imagenH = imagen;
            this.opc = opcion;
        }

        private Filtros filtros = new Filtros();
        private int opc;
        private Bitmap imagenH;

        private void Histograma_Load(object sender, EventArgs e)
        {
            switch (opc)
            {
                case 0:
                    HistogramaRGB(imagenH);
                    break;
                case 1:
                    HistogramaR(imagenH);
                    break;
                case 2:
                    HistogramaG(imagenH);
                    break;
                case 3:
                    HistogramaB(imagenH);
                    break;
                case 4:
                    HistogramaGray(imagenH);
                    break;
            }
        }

        private void HistogramaRGB(Bitmap img)
        {
            //RGB zedgraph
            GraphPane panelRGB = zgc_Histograma.GraphPane;
            panelRGB.CurveList.Clear();
            panelRGB.Title.Text = "RGB";
            panelRGB.XAxis.Title.Text = "Intensidad de Color";
            panelRGB.YAxis.Title.Text = "Frecuencia";

            //Canal RGB
            PointPairList redPoints = new PointPairList();
            PointPairList greenPoints = new PointPairList();
            PointPairList bluePoints = new PointPairList();

            int[] redFrequency = new int[256];
            int[] greenFrequency = new int[256];
            int[] blueFrequency = new int[256];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    redFrequency[pixelColor.R]++;
                    greenFrequency[pixelColor.G]++;
                    blueFrequency[pixelColor.B]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                redPoints.Add(i, redFrequency[i]);
                greenPoints.Add(i, greenFrequency[i]);
                bluePoints.Add(i, blueFrequency[i]);
            }

            LineItem redCurve = panelRGB.AddCurve("Rojo", redPoints, Color.Red, SymbolType.None);
            LineItem greenCurve = panelRGB.AddCurve("Verde", greenPoints, Color.Green, SymbolType.None);
            LineItem blueCurve = panelRGB.AddCurve("Azul", bluePoints, Color.Blue, SymbolType.None);

            redCurve.Line.Width = 2.0f;
            greenCurve.Line.Width = 2.0f;
            blueCurve.Line.Width = 2.0f;

            zgc_Histograma.AxisChange();
            zgc_Histograma.Invalidate();
        }

        private void HistogramaGray(Bitmap imgColor)
        {
            //Grises
            Bitmap img = (Bitmap)imgColor.Clone();
            filtros.TonosGrises(img, 10);
            GraphPane panelGray = zgc_Histograma.GraphPane;
            panelGray.CurveList.Clear();
            panelGray.Title.Text = "Tonos Grises";
            panelGray.XAxis.Title.Text = "Intensidad de Color";
            panelGray.YAxis.Title.Text = "Frecuencia";

            //Personalización
            panelGray.Fill = new Fill(Color.Black);        // Fondo general del panel
            panelGray.Chart.Fill = new Fill(Color.Black);   // Fondo dentro del área de trazado
            panelGray.Legend.Fill = new Fill(Color.Black);  // Fondo de la leyenda
            panelGray.Chart.Border.Color = Color.White;
            panelGray.Border.Color = Color.White;
            panelGray.Title.FontSpec.FontColor = Color.White;   // Título del gráfico
            panelGray.XAxis.Title.FontSpec.FontColor = Color.White; // Título del eje X
            panelGray.YAxis.Title.FontSpec.FontColor = Color.White; // Título del eje Y
            panelGray.XAxis.Scale.FontSpec.FontColor = Color.White; // Etiquetas del eje X
            panelGray.YAxis.Scale.FontSpec.FontColor = Color.White; // Etiquetas del eje Y
            panelGray.XAxis.MajorGrid.Color = Color.White;  // Cuadrícula principal eje X
            panelGray.YAxis.MajorGrid.Color = Color.White;  // Cuadrícula principal eje Y
            panelGray.Legend.Border.Color = Color.White;    // Borde de la leyenda en blanco
            panelGray.Legend.FontSpec.FontColor = Color.White;


            PointPairList redPoints = new PointPairList();
            PointPairList greenPoints = new PointPairList();
            PointPairList bluePoints = new PointPairList();

            int[] redFrequency = new int[256];
            int[] greenFrequency = new int[256];
            int[] blueFrequency = new int[256];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    redFrequency[pixelColor.R]++;
                    greenFrequency[pixelColor.G]++;
                    blueFrequency[pixelColor.B]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                redPoints.Add(i, redFrequency[i]);
                greenPoints.Add(i+1, greenFrequency[i]);
                bluePoints.Add(i-1, blueFrequency[i]);
            }

            LineItem redCurve = panelGray.AddCurve("Rojo", redPoints, Color.Cyan, SymbolType.None);
            LineItem greenCurve = panelGray.AddCurve("Verde", greenPoints, Color.Magenta, SymbolType.None);
            LineItem blueCurve = panelGray.AddCurve("Azul", bluePoints, Color.Yellow, SymbolType.None);

            redCurve.Line.Width = 1.0f;
            greenCurve.Line.Width = 1.0f;
            blueCurve.Line.Width = 1.0f;

            zgc_Histograma.AxisChange();
            zgc_Histograma.Invalidate();
        }

        private void HistogramaR(Bitmap img)
        {
            //RGB zedgraph
            GraphPane panelRGB = zgc_Histograma.GraphPane;
            panelRGB.CurveList.Clear();
            panelRGB.Title.Text = "Rojo";
            panelRGB.XAxis.Title.Text = "Intensidad de Color";
            panelRGB.YAxis.Title.Text = "Frecuencia";

            //Canal R
            PointPairList redPoints = new PointPairList();

            int[] redFrequency = new int[256];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    redFrequency[pixelColor.R]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                redPoints.Add(i, redFrequency[i]);
            }

            LineItem redCurve = panelRGB.AddCurve("Rojo", redPoints, Color.Red, SymbolType.None);

            redCurve.Line.Width = 2.0f;

            zgc_Histograma.AxisChange();
            zgc_Histograma.Invalidate();
        }

        private void HistogramaG(Bitmap img)
        {
            //RGB zedgraph
            GraphPane panelRGB = zgc_Histograma.GraphPane;
            panelRGB.CurveList.Clear();
            panelRGB.Title.Text = "Verde";
            panelRGB.XAxis.Title.Text = "Intensidad de Color";
            panelRGB.YAxis.Title.Text = "Frecuencia";

            //Canal G
            PointPairList greenPoints = new PointPairList();

            int[] greenFrequency = new int[256];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    greenFrequency[pixelColor.G]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                greenPoints.Add(i, greenFrequency[i]);
            }

            LineItem greenCurve = panelRGB.AddCurve("Verde", greenPoints, Color.Green, SymbolType.None);

            greenCurve.Line.Width = 2.0f;

            zgc_Histograma.AxisChange();
            zgc_Histograma.Invalidate();
        }

        private void HistogramaB(Bitmap img)
        {
            //RGB zedgraph
            GraphPane panelRGB = zgc_Histograma.GraphPane;
            panelRGB.CurveList.Clear();
            panelRGB.Title.Text = "Azul";
            panelRGB.XAxis.Title.Text = "Intensidad de Color";
            panelRGB.YAxis.Title.Text = "Frecuencia";

            //Canal RGB
            PointPairList bluePoints = new PointPairList();

            int[] blueFrequency = new int[256];

            for (int y = 0; y < img.Height; y++)
            {
                for (int x = 0; x < img.Width; x++)
                {
                    Color pixelColor = img.GetPixel(x, y);
                    blueFrequency[pixelColor.B]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                bluePoints.Add(i, blueFrequency[i]);
            }

            LineItem blueCurve = panelRGB.AddCurve("Azul", bluePoints, Color.Blue, SymbolType.None);

            blueCurve.Line.Width = 2.0f;

            zgc_Histograma.AxisChange();
            zgc_Histograma.Invalidate();
        }

    }
}
