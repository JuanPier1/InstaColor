using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.Util.TypeEnum;
using InstaColor.Pantallas;
using Accord;
using Accord.Video;
using Accord.Video.FFMPEG;

namespace InstaColor
{
    internal class Filtros
    {
        //15 filtros + 2 flips + 7 colores = 24 filtros
        //Filtro IMAGENES

        internal List<string> listaFiltros = new List<string>
        {
            "Ninguno",
            "Invertir",
            "Monocromático",
            "Negativo",
            "Tonos Grises",
            "Gamma",
            "Surreal",
            "Psicodélico",
            "Cruzado",
            "Gradiente",
            "Aberración",
            "Intensidad",
            "Contraste",
            "Brillo",
            "Pixelado",
            "Ruido",
            "Color Rojo",
            "Color Verde",
            "Color Azul",
            "Color Amarillo",
            "Color Cyan",
            "Color Magenta",
            "Color Personalizado"
        };

        internal List<string> listaFiltrosVid = new List<string>
        {
            "Ninguno",
            "Invertir",
            "Monocromático",
            "Negativo",
            "Tonos Grises",
            "Gamma",
            "Surreal",
            "Psicodélico",
            "Cruzado",
            "Aberración",
            "Intensidad",
            "Contraste",
            "Brillo",
            "Pixelado",
            "Ruido",
            "Color Rojo",
            "Color Verde",
            "Color Azul",
            "Color Amarillo",
            "Color Cyan",
            "Color Magenta"
        };

        internal Bitmap Invertir(Bitmap inv, int ajuste)
        {
            int factor = ajuste;

            for (int i = 0; i < inv.Width; i++)
            {
                for (int j = 0; j < inv.Height; j++)
                {
                    Color color = inv.GetPixel(i, j);

                    int red = (1 - factor) * color.R + factor * color.B;
                    int green = (1 - factor) * color.G + factor * color.G;
                    int blue = (1 - factor) * color.B + factor * color.R;

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    inv.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return inv;
        }

        internal Bitmap Monocromatico(Bitmap mn, int ajuste)
        {
            int mono = 0;
            int factor = ajuste;

            for (int i = 0; i < mn.Width; i++)
            {
                for (int j = 0; j < mn.Height; j++)
                {
                    Color color = mn.GetPixel(i, j);

                    mono = (color.R + color.G + color.B) / 3;

                    int r = (1 - factor) * color.R + factor * mono;
                    int g = (1 - factor) * color.G + factor * mono;
                    int b = (1 - factor) * color.B + factor * mono;

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    mn.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return mn;
        }

        internal Bitmap Negativo(Bitmap neg, int ajuste)
        {
            int factor = ajuste;

            for (int i = 0; i < neg.Width; i++)
            {
                for (int j = 0; j < neg.Height; j++)
                {
                    Color color = neg.GetPixel(i, j);

                    int redN = Math.Abs(color.R - 255);
                    int greenN = Math.Abs(color.G - 255);
                    int blueN = Math.Abs(color.B - 255);

                    int red = (1 - factor) * color.R + factor * redN;
                    int green = (1 - factor) * color.G + factor * greenN;
                    int blue = (1 - factor) * color.B + factor * blueN;

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    neg.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return neg;
        }

        internal Bitmap Aberracion(Bitmap ab, int ajuste)
        {
            int factor = ajuste * 5;

            if (ajuste == 0)
            {
                return ab;
            }

            for (int i = 0; i < ab.Width; i++)
            {
                for (int j = 0; j < ab.Height; j++)
                {
                    Color color = ab.GetPixel(i, j);

                    int green = color.G;
                    //int red = (j + factor < ab.Height && j + factor >= 0) 
                    //? ab.GetPixel(i, j + factor).R
                    //: color.R;
                    //int blue = (j - factor >= 0 && j - factor < ab.Width) 
                    //? ab.GetPixel(i, j - factor).B
                    //: color.B;

                    int red = (i + factor < ab.Width && i + factor >= 0)
                    ? ab.GetPixel(i + factor, j).R
                    : color.R;
                    int blue = (i - factor >= 0 && i - factor < ab.Width)
                    ? ab.GetPixel(i - factor, j).B
                    : color.B;

                    ab.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return ab;
        }

        internal Bitmap TonosGrises(Bitmap gr, int ajuste)
        {
            float rg = 0.2126f;
            float gg = 0.7152f;
            float bg = 0.7222f;
            float factor = ajuste;

            for (int i = 0; i < gr.Width; i++)
            {
                for (int j = 0; j < gr.Height; j++)
                {
                    Color color = gr.GetPixel(i, j);

                    float gris = (color.R * rg) + (color.G * gg) + (color.B * bg);

                    //int grisN = (int)(gris * factor);
                    //grisN = Math.Min(255, Math.Max(0, grisN));

                    int r = (int)((1 - factor) * color.R + factor * gris);
                    int g = (int)((1 - factor) * color.G + factor * gris);
                    int b = (int)((1 - factor) * color.B + factor * gris);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    gr.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return gr;
        }

        internal Bitmap Gamma(Bitmap gm, int ajuste)
        {
            //factor para gamma
            float rg = 1.1f;
            float gg = 1.5f;
            float bg = 0.9f;

            //Rampas de color
            int[] rGamma = new int[256];
            int[] gGamma = new int[256];
            int[] bGamma = new int[256];

            for (int n = 0; n < 256; n++)
            {
                rGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / rg)) + 0.5f));
                gGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / gg)) + 0.5f));
                bGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / bg)) + 0.5f));
            }

            //Imagen
            for (int i = 0; i < gm.Width; i++)
            {
                for (int j = 0; j < gm.Height; j++)
                {
                    Color color = gm.GetPixel(i, j);

                    float factor = ajuste;

                    int red = (int)((1 - factor) * color.R + factor * rGamma[color.R]);
                    int green = (int)((1 - factor) * color.G + factor * gGamma[color.G]);
                    int blue = (int)((1 - factor) * color.B + factor * bGamma[color.B]);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    gm.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return gm;
        }

        internal Bitmap Surreal(Bitmap s, int ajuste)
        {
            int factor = ajuste;

            for (int i = 0; i < s.Width; i++)
            {
                for (int j = 0; j < s.Height; j++)
                {
                    Color color = s.GetPixel(i, j);

                    float rS = Math.Min(255, color.R * color.B / 255);
                    float gS = Math.Min(255, color.G * color.G / 255);
                    float bS = Math.Min(255, color.B * color.R / 255);

                    int r = (int)((1 - factor) * color.R + factor * rS);
                    int g = (int)((1 - factor) * color.G + factor * gS);
                    int b = (int)((1 - factor) * color.B + factor * bS);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    s.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return s;
        }

        internal Bitmap Psicodelico(Bitmap s, int ajuste)
        {
            int factor = ajuste;

            for (int i = 0; i < s.Width; i++)
            {
                for (int j = 0; j < s.Height; j++)
                {
                    Color color = s.GetPixel(i, j);

                    float rS = Math.Min(255, color.R * color.G / 255);
                    float gS = Math.Min(255, color.G * color.B / 255);
                    float bS = Math.Min(255, color.B * color.R / 255);

                    int r = (int)((1 - factor) * color.R + factor * rS);
                    int g = (int)((1 - factor) * color.G + factor * gS);
                    int b = (int)((1 - factor) * color.B + factor * bS);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    s.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return s;
        }

        internal Bitmap Cruzado(Bitmap s, int ajuste)
        {
            int factor = ajuste;

            for (int i = 0; i < s.Width; i++)
            {
                for (int j = 0; j < s.Height; j++)
                {
                    Color color = s.GetPixel(i, j);

                    float rS = Math.Min(255, color.R * color.B / 255);
                    float gS = Math.Min(255, color.G * color.R / 255);
                    float bS = Math.Min(255, color.B * color.G / 255);

                    int r = (int)((1 - factor) * color.R + factor * rS);
                    int g = (int)((1 - factor) * color.G + factor * gS);
                    int b = (int)((1 - factor) * color.B + factor * bS);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    s.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return s;
        }

        internal Bitmap Gradiente(Bitmap gr, float r1, float g1, float b1, float r2, float g2, float b2)
        {

            r1 = Math.Min(255, Math.Max(0, r1));
            g1 = Math.Min(255, Math.Max(0, g1));
            b1 = Math.Min(255, Math.Max(0, b1));
            r2 = Math.Min(255, Math.Max(0, r2));
            g2 = Math.Min(255, Math.Max(0, g2));
            b2 = Math.Min(255, Math.Max(0, b2));

            //interpolación
            float dr = (r2 - r1) / gr.Width;
            float dg = (g2 - g1) / gr.Width;
            float db = (b2 - b1) / gr.Width;

            //TonosGrises(gr, 10);

            for (int i = 0; i < gr.Width; i++)
            {
                for (int j = 0; j < gr.Height; j++)
                {
                    Color color = gr.GetPixel(i, j);

                    //Calcular color
                    int r = Math.Min(255, Math.Max(0, (int)((r1 / 255) * color.R)));
                    int g = Math.Min(255, Math.Max(0, (int)((g1 / 255) * color.G)));
                    int b = Math.Min(255, Math.Max(0, (int)((b1 / 255) * color.B)));

                    gr.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
                //Avanzar color *checar el float*
                r1 = (r1 + dr);
                g1 = (g1 + dg);
                b1 = (b1 + db);
            }

            return gr;
        }

        internal Bitmap Intensidad(Bitmap ind, int ajuste)
        {
            float intensidad = ajuste * 10.0f;
            float factor = (100.0f + intensidad) / 100.0f;
            factor *= factor;

            for (int i = 0; i < ind.Width; i++)
            {
                for (int j = 0; j < ind.Height; j++)
                {
                    Color color = ind.GetPixel(i, j);

                    //color base en canal cuadrado
                    int rI = Math.Min(255, color.R * color.R / 255);
                    int gI = Math.Min(255, color.G * color.G / 255);
                    int bI = Math.Min(255, color.B * color.B / 255);

                    //ajuste
                    int r = (int)((1 - factor) * color.R + factor * rI);
                    int g = (int)((1 - factor) * color.G + factor * gI);
                    int b = (int)((1 - factor) * color.B + factor * bI);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    ind.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return ind;
        }

        internal Bitmap Contraste(Bitmap con, int ajuste)
        {
            //rangor de -100 a 100
            float contraste = ajuste * 10.0f; // valor -10 a 10
            float factor = (100.0f + contraste) / 100.0f;
            factor *= factor;

            for (int i = 0; i < con.Width; i++)
            {
                for (int j = 0; j < con.Height; j++)
                {
                    Color color = con.GetPixel(i, j);

                    //ajuste
                    float r = ((((color.R / 255.0f) - 0.5f) * factor) + 0.5f) * 255;
                    float g = ((((color.G / 255.0f) - 0.5f) * factor) + 0.5f) * 255;
                    float b = ((((color.B / 255.0f) - 0.5f) * factor) + 0.5f) * 255;

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    con.SetPixel(i, j, Color.FromArgb((int)r, (int)g, (int)b));
                }
            }

            return con;
        }

        internal Bitmap Brillo(Bitmap br, int ajuste)
        {
            // método 1 valor -255 a 255 igual a sumar
            // método 2 valor 0 - 2 igual a multiplicar

            float brillo = 1.0f + (ajuste * 10.0f);  //valor -100 a 100

            for (int i = 0; i < br.Width; i++)
            {
                for (int j = 0; j < br.Height; j++)
                {
                    Color color = br.GetPixel(i, j);

                    int r = (int)(color.R * brillo);
                    int g = (int)(color.G * brillo);
                    int b = (int)(color.B * brillo);

                    r = Math.Min(255, Math.Max(0, r));
                    g = Math.Min(255, Math.Max(0, g));
                    b = Math.Min(255, Math.Max(0, b));

                    br.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return br;
        }

        internal Bitmap Mosaicos(Bitmap mos, int ajuste)
        {
            int mosaicos; //Pixelado

            if (ajuste > 0)
            {
                mosaicos = ajuste * 10;
            }
            else
            {
                return mos;
            }

            for (int i = 0; i < mos.Width - mosaicos; i += mosaicos)
            {
                for (int j = 0; j < mos.Height - mosaicos; j += mosaicos)
                {
                    int sr = 0, sg = 0, sb = 0; //Sumar
                    int pixelcount = 0;

                    //recorrido
                    for (int im = i; im < i + mosaicos && im < mos.Width; im++)
                    {
                        for (int jm = j; jm < j + mosaicos && jm < mos.Height; jm++)
                        {
                            Color color = mos.GetPixel(im, jm);
                            sr += color.R;
                            sg += color.G;
                            sb += color.B;
                            pixelcount++;
                        }
                    }

                    //Promedio color
                    int r = sr / pixelcount;
                    int g = sg / pixelcount;
                    int b = sb / pixelcount;
                    Color avg = Color.FromArgb(r, g, b);


                    //Aplicar promedio a cada pixel del mosaico
                    for (int im = i; im < i + mosaicos && im < mos.Width; im++)
                    {
                        for (int jm = j; jm < j + mosaicos && jm < mos.Height; jm++)
                        {
                            mos.SetPixel(im, jm, avg);
                        }
                    }

                }
            }

            return mos;
        }

        internal Bitmap Ruido(Bitmap ns, int ajuste, Random rnd)
        {
            int porcentaje = ajuste * 10;

            Color color = new Color();

            for (int i = 0; i < ns.Width; i++)
            {
                for (int j = 0; j < ns.Height; j++)
                {
                    if (rnd.Next(0, 100) < porcentaje)
                    {
                        // rango 0 - 200
                        float brillo = rnd.Next(0, 200) / 100.0f;
                        color = ns.GetPixel(i, j);

                        int r = Math.Min(255, Math.Max(0, ((int)(color.R * brillo))));
                        int g = Math.Min(255, Math.Max(0, ((int)(color.G * brillo))));
                        int b = Math.Min(255, Math.Max(0, ((int)(color.B * brillo))));

                        ns.SetPixel(i, j, Color.FromArgb(r, g, b));
                    }
                    else
                    {
                        ns.SetPixel(i, j, ns.GetPixel(i, j));
                    }
                }
            }

            return ns;
        }

        //Espejo
        internal Bitmap FlipHorizontal(Bitmap fh)
        {
            //agregar una copia de los pixeles para que funcione
            Bitmap flip = (Bitmap)fh.Clone();

            for (int i = 0; i < fh.Width; i++)
            {
                for (int j = 0; j < fh.Height; j++)
                {
                    Color color = flip.GetPixel(i, j);

                    fh.SetPixel(fh.Width - i - 1, j, color);
                }
            }

            return fh;
        }

        internal Bitmap FlipVertical(Bitmap fv)
        {
            //agregar una copia de los pixeles para que funcione
            Bitmap flip = (Bitmap)fv.Clone();

            for (int i = 0; i < fv.Width; i++)
            {
                for (int j = 0; j < fv.Height; j++)
                {
                    Color color = flip.GetPixel(i, j);

                    fv.SetPixel(i, fv.Height - j - 1, color);
                }
            }

            return fv;
        }

        //Filtro de colores
        internal Bitmap FiltroColor(Bitmap img, int opc, int a, int r = 0, int g = 0, int b = 0)
        {
            //6 colores
            switch (opc)
            {
                case 0:
                    FiltroPersonalizado(img, a, r, g, b);
                    break;
                case 1:
                    FiltroRojo(img, a);
                    break;
                case 2:
                    FiltroVerde(img, a);
                    break;
                case 3:
                    FiltroAzul(img, a);
                    break;
                case 4:
                    FiltroAmarillo(img, a);
                    break;
                case 5:
                    FiltroCian(img, a);
                    break;
                case 6:
                    FiltroMagenta(img, a);
                    break;
            }

            return img;
        }

        private Bitmap FiltroRojo(Bitmap fr, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fr.Width; i++)
            {
                for (int j = 0; j < fr.Height; j++)
                {
                    Color color = fr.GetPixel(i, j);

                    //int filteredColor = color.R;
                    int red = color.R * factor + color.R * (1 - factor);
                    int green = color.G * (1 - factor);
                    int blue = color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fr.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fr;
        }

        private Bitmap FiltroVerde(Bitmap fv, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fv.Width; i++)
            {
                for (int j = 0; j < fv.Height; j++)
                {
                    Color color = fv.GetPixel(i, j);

                    //int filteredColor = color.G;
                    int red = color.R * (1 - factor);
                    int green = color.G * factor + color.G * (1 - factor);
                    int blue = color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fv.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fv;
        }

        private Bitmap FiltroAzul(Bitmap fa, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fa.Width; i++)
            {
                for (int j = 0; j < fa.Height; j++)
                {
                    Color color = fa.GetPixel(i, j);

                    //int filteredColor = color.R;
                    int red = color.R * (1 - factor);
                    int green = color.G * (1 - factor);
                    int blue = color.B * factor + color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fa.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fa;
        }

        private Bitmap FiltroCian(Bitmap fc, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fc.Width; i++)
            {
                for (int j = 0; j < fc.Height; j++)
                {
                    Color color = fc.GetPixel(i, j);

                    //int filteredColor = color.G;
                    //int filteredColor2 = color.B;
                    int red = color.R * (1 - factor);
                    int green = color.G * factor + color.G * (1 - factor);
                    int blue = color.B * factor + color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fc.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fc;
        }

        private Bitmap FiltroMagenta(Bitmap fm, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fm.Width; i++)
            {
                for (int j = 0; j < fm.Height; j++)
                {
                    Color color = fm.GetPixel(i, j);

                    //int filteredColor = color.R;
                    //int filteredColor2 = color.B;
                    int red = color.R * factor + color.R * (1 - factor);
                    int green = color.G * (1 - factor);
                    int blue = color.B * factor + color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fm.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fm;
        }

        private Bitmap FiltroAmarillo(Bitmap fy, int ajuste)
        {
            int factor = ajuste / 10;

            for (int i = 0; i < fy.Width; i++)
            {
                for (int j = 0; j < fy.Height; j++)
                {
                    Color color = fy.GetPixel(i, j);

                    //int filteredColor = color.R;
                    //int filteredColor2 = color.G;
                    int red = color.R * factor + color.R * (1 - factor);
                    int green = color.G * factor + color.G * (1 - factor);
                    int blue = color.B * (1 - factor);

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fy.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fy;
        }

        private Bitmap FiltroPersonalizado(Bitmap fp, int ajuste, int r, int g, int b)
        {
            r = Math.Min(255, Math.Max(0, r));
            g = Math.Min(255, Math.Max(0, g));
            b = Math.Min(255, Math.Max(0, b));

            int factor = ajuste / 10;

            for (int i = 0; i < fp.Width; i++)
            {
                for (int j = 0; j < fp.Height; j++)
                {
                    Color original = fp.GetPixel(i, j);

                    int red = original.R + r * factor - 255;
                    int green = original.G + g * factor - 255;
                    int blue = original.B + b * factor - 255;

                    red = Math.Min(255, Math.Max(0, red));
                    green = Math.Min(255, Math.Max(0, green));
                    blue = Math.Min(255, Math.Max(0, blue));

                    fp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return fp;
        }

        //Procesar Vídeo

        internal void ProcesarVideo(string entrada, string salida, int opc, int ajuste)//Func<Bitmap, Bitmap> filtro, int ajuste)
        {
            using (var lector = new VideoFileReader())
            {
                lector.Open(entrada);
                using(var escritor = new VideoFileWriter())
                {
                    escritor.Open(entrada, lector.Width, lector.Height, lector.FrameRate, VideoCodec.MPEG4);

                    for(int i = 0; i < lector.FrameCount; i++)
                    {
                        using (Bitmap frame = lector.ReadVideoFrame())
                        {
                            if (frame == null) { break; }

                            switch (opc)
                            {
                                case 1:
                                    InvertirVid(frame, ajuste);
                                    break;
                                case 2:
                                    MonocromaticoVid(frame, ajuste);
                                    break;
                                case 3:
                                    NegativoVid(frame, ajuste);
                                    break;
                                case 4:
                                    AberracionVid(frame, ajuste);
                                    break;
                            }
                            escritor.WriteVideoFrame(frame);
                        }
                    }
                    escritor.Close();
                }
                lector.Close();
            }
        }

        internal void GuardarVideo(string salida, VideoCapture vc, Func<Bitmap, Bitmap>AplicarFiltro)
        {
            using (var escritor = new VideoFileWriter())
            {
                escritor.Open(salida, (int)vc.GetCaptureProperty(CapProp.FrameWidth),
                              (int)vc.GetCaptureProperty(CapProp.FrameHeight),
                              (int)vc.GetCaptureProperty(CapProp.Fps),
                              VideoCodec.MPEG4);

                Mat frame = new Mat();
                while (vc.Grab())
                {
                    vc.Read(frame);
                    if (!frame.IsEmpty)
                    {
                        Bitmap originalFrame = frame.Bitmap;
                        Bitmap processedFrame = AplicarFiltro(originalFrame);
                        escritor.WriteVideoFrame(processedFrame);

                        originalFrame.Dispose();
                        processedFrame.Dispose();
                    }
                    else
                    {
                        break;
                    }
                }

                escritor.Close();
            }

            MessageBox.Show("Video guardado exitosamente en: " + salida);
        }

        //## FILTROS DE VÍDEO

        /* Matriz Identidad
            new float[] {1, 0, 0, 0, 0}, // Rojo
            new float[] {0, 1, 0, 0, 0}, // Verde
            new float[] {0, 0, 1, 0, 0}, // Azul
            new float[] {0, 0, 0, 1, 0}, // Alfa
            new float[] {0, 0, 0, 0, 1}  // Constante
         */

        private Bitmap FiltroMatriz(float[][] colorMatrix, Bitmap frameFiltered)
        {
            ColorMatrix color = new ColorMatrix(colorMatrix);

            try
            {
                ImageAttributes imgAtt = new ImageAttributes();
                imgAtt.SetColorMatrix(color);

                Rectangle rect = new Rectangle(0, 0, frameFiltered.Width, frameFiltered.Height);

                using (Graphics gph = Graphics.FromImage(frameFiltered))
                {
                    gph.DrawImage(frameFiltered, rect, 0, 0, frameFiltered.Width, frameFiltered.Height, GraphicsUnit.Pixel, imgAtt);
                }
            }
            catch (OutOfMemoryException ex)
            {
                MessageBox.Show("Se produjo una excepción por falta de memoria", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return frameFiltered;
        }

        readonly float[] red = { 1, 0, 0, 0, 0 };
        readonly float[] green = { 0, 1, 0, 0, 0 };
        readonly float[] blue = { 0, 0, 1, 0, 0 };
        readonly float[] alpha = { 0, 0, 0, 1, 0 };
        readonly float[] constant = { 0, 0, 0, 0, 1 };
        const int ajuste = 1;

        private float[][] matrizIdentidad()
        {
            float[][] matrizIdentidad =
            {
                red,
                green, 
                blue, 
                alpha,
                constant
            };

            return matrizIdentidad;
        }

        private float[][] matrizNueva()
        {
            float[][] fN =
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };
            return fN;
        }

        internal Bitmap InvertirVid(Bitmap vid, int a = ajuste)
        {
            float factor = a;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] invM =
            {
                new float[] { 1-factor, 0, 0+factor, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0+factor, 0, 1-factor, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + invM[r][c];
                }
            }


            return FiltroMatriz(fM, vid);
        }

        internal Bitmap MonocromaticoVid(Bitmap vid, int a = ajuste)
        {
            float factor = a;
            float mono = 0.333f;
            float m = mono * factor;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] monoM =
            {
                new float[] { 1-(factor+m), 0+m, 0+m, 0, 0 },
                new float[] { 0+m, 1-(factor+m), 0+m, 0, 0 },
                new float[] { 0+m, 0+m, 1-(factor+m), 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + monoM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap NegativoVid(Bitmap vid, int a = ajuste)
        {
            float factor = a;
            float f = factor * -2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] nM =
            {
                new float[] { f, 0, 0, 0, 0 },
                new float[] { 0, f, 0, 0, 0 },
                new float[] { 0, 0, f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { factor, factor, factor, 0, 0 }
            };


            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + nM[r][c];
                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap AberracionVid(Bitmap vid, int a = ajuste)
        {
            if (a == 0)
            {
                return vid;
            }

            // Bloquear bits de la imagen para acceso directo
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            IntPtr ptr = data.Scan0;
            int width = vid.Width;
            int height = vid.Height;

            // Leer datos de píxeles
            byte[] pixels = new byte[Math.Abs(stride) * height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

            // Crear una copia para manipular canales
            byte[] originalPixels = (byte[])pixels.Clone();

            // Definir desplazamiento basado en ajuste
            int offset = a * 2;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int currentPos = (y * stride) + (x * 3); // Posición del píxel actual (BGR)

                    // Calcular desplazamiento para cada canal
                    int redOffsetPos = (y * stride) + ((x + offset) * 3);   // Rojo desplazado a la derecha
                    int blueOffsetPos = (y * stride) + ((x - offset) * 3);  // Azul desplazado a la izquierda

                    // Evitar salirse de los límites
                    byte red = (x + offset < width) ? originalPixels[redOffsetPos + 2] : originalPixels[currentPos + 2];
                    byte green = originalPixels[currentPos + 1]; // El canal verde permanece en su lugar
                    byte blue = (x - offset >= 0) ? originalPixels[blueOffsetPos] : originalPixels[currentPos];

                    // Aplicar los nuevos valores
                    pixels[currentPos] = blue;      // Canal azul
                    pixels[currentPos + 1] = green; // Canal verde
                    pixels[currentPos + 2] = red;   // Canal rojo
                }
            }

            // Escribir los datos de píxeles de vuelta a la imagen
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap TonosGrisesVid(Bitmap vid, int a = ajuste)
        {
            
            float rg = 0.2126f * a;
            float gg = 0.7152f * a;
            float bg = 0.7222f * a;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();
            
            float[][] tn =
            {
                new float[] { 1-(a*2-rg), 0+rg, 0+rg, 0, 0 },
                new float[] { 0+gg, 1-(a*2-gg), 0+gg, 0, 0 },
                new float[] { 0+bg, 0+bg, 1-(a*2-bg), 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + tn[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap SurrealVid(Bitmap vid, int a = ajuste)
        {
            float f = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();
            //BGR
            float[][] nM =
            {
                new float[] { 1-f, 0, 0+a, 0, 0 },
                new float[] { 0, 1-a, 0, 0, 0 },
                new float[] { 0+a, 0, 1-f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };


            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + nM[r][c];
                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap PsicodelicoVid(Bitmap vid, int a = ajuste)
        {
            float f = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();
            //GBR
            float[][] nM =
            {
                new float[] { 1-f, 0+a, 0, 0, 0 },
                new float[] { 0, 1-f, 0+a, 0, 0 },
                new float[] { 0+a, 0, 1-f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };


            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + nM[r][c];
                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap CruzadoVid(Bitmap vid, int a = ajuste)
        {
            float f = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();
            //BRG
            float[][] nM =
            {
                new float[] { 1-f, 0, 0+a, 0, 0 },
                new float[] { 0+a, 1-f, 0, 0, 0 },
                new float[] { 0, 0+a, 1-f, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };


            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + nM[r][c];
                }
            }

            return FiltroMatriz(fM, vid);
        }

        internal Bitmap GammaVid(Bitmap vid, int a = ajuste)
        {
            // Factores gamma
            float rg = 1.1f;
            float gg = 1.5f;
            float bg = 0.9f;

            // Rampas de color
            int[] rGamma = new int[256];
            int[] gGamma = new int[256];
            int[] bGamma = new int[256];

            for (int n = 0; n < 256; n++)
            {
                rGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / rg)) + 0.5f));
                gGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / gg)) + 0.5f));
                bGamma[n] = Math.Min(255, (int)((255.0f * Math.Pow(n / 255.0f, 1.0f / bg)) + 0.5f));
            }

            // Bloquear los bits del Bitmap
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            byte[] pixels = new byte[stride * vid.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            float factor = a;

            for (int y = 0; y < vid.Height; y++)
            {
                for (int x = 0; x < vid.Width; x++)
                {
                    int pos = (y * stride) + (x * 3);

                    // Obtener canales RGB
                    int r = pixels[pos + 2]; // R
                    int g = pixels[pos + 1]; // G
                    int b = pixels[pos];     // B

                    // Ajustar gamma
                    r = (int)((1 - factor) * r + factor * rGamma[r]);
                    g = (int)((1 - factor) * g + factor * gGamma[g]);
                    b = (int)((1 - factor) * b + factor * bGamma[b]);

                    // Clamping
                    pixels[pos + 2] = (byte)Math.Min(255, Math.Max(0, r));
                    pixels[pos + 1] = (byte)Math.Min(255, Math.Max(0, g));
                    pixels[pos] = (byte)Math.Min(255, Math.Max(0, b));
                }
            }

            // Copiar los datos de vuelta al Bitmap
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap IntensidadVid(Bitmap vid, int a = ajuste * 10)
        {
            // Calcular el factor de intensidad
            float intensidad = a * 10.0f;
            float factor = (100.0f + intensidad) / 100.0f;
            factor *= factor;

            // Bloquear los bits del Bitmap para acceso rápido
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            byte[] pixels = new byte[stride * vid.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            for (int y = 0; y < vid.Height; y++)
            {
                for (int x = 0; x < vid.Width; x++)
                {
                    int pos = (y * stride) + (x * 3);

                    // Obtener canales RGB
                    int r = pixels[pos + 2]; // R
                    int g = pixels[pos + 1]; // G
                    int b = pixels[pos];     // B

                    // Canal cuadrático
                    int rI = Math.Min(255, r * r / 255);
                    int gI = Math.Min(255, g * g / 255);
                    int bI = Math.Min(255, b * b / 255);

                    // Ajuste de intensidad
                    r = (int)((1 - factor) * r + factor * rI);
                    g = (int)((1 - factor) * g + factor * gI);
                    b = (int)((1 - factor) * b + factor * bI);

                    // Clamping
                    pixels[pos + 2] = (byte)Math.Min(255, Math.Max(0, r));
                    pixels[pos + 1] = (byte)Math.Min(255, Math.Max(0, g));
                    pixels[pos] = (byte)Math.Min(255, Math.Max(0, b));
                }
            }

            // Copiar los datos de vuelta al Bitmap
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap ContrasteVid(Bitmap vid, int a = ajuste * 10)
        {
            // Calcular el factor de contraste
            float contraste = a * 10.0f; // Ajuste de -10 a 10 (escala de usuario)
            float factor = (100.0f + contraste) / 100.0f;
            factor *= factor;

            // Bloquear los bits del Bitmap para acceso rápido
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            byte[] pixels = new byte[stride * vid.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            for (int y = 0; y < vid.Height; y++)
            {
                for (int x = 0; x < vid.Width; x++)
                {
                    int pos = (y * stride) + (x * 3);

                    // Ajustar los canales RGB
                    for (int c = 0; c < 3; c++) // Procesar R, G, B
                    {
                        float color = pixels[pos + c] / 255.0f; // Normalizar [0, 1]
                        color = ((((color - 0.5f) * factor) + 0.5f) * 255.0f); // Ajuste de contraste
                        pixels[pos + c] = (byte)Math.Min(255, Math.Max(0, (int)color));
                    }
                }
            }

            // Copiar los datos de vuelta al Bitmap
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap BrilloVid(Bitmap vid, int a = ajuste * 10)
        {
            float brillo = 1.0f + (a * 10.0f) / 100.0f;

            // Bloquear los bits de la imagen
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                          ImageLockMode.ReadWrite,
                                          PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            byte[] pixels = new byte[stride * vid.Height];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0, pixels, 0, pixels.Length);

            for (int y = 0; y < vid.Height; y++)
            {
                for (int x = 0; x < vid.Width; x++)
                {
                    int pos = (y * stride) + (x * 3); // Posición del píxel actual

                    // Ajustar brillo
                    pixels[pos + 2] = (byte)Math.Min(255, Math.Max(0, (int)(pixels[pos + 2] * brillo)));
                    pixels[pos + 1] = (byte)Math.Min(255, Math.Max(0, (int)(pixels[pos + 1] * brillo)));
                    pixels[pos] = (byte)Math.Min(255, Math.Max(0, (int)(pixels[pos] * brillo)));
                }
            }

            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, data.Scan0, pixels.Length);
            vid.UnlockBits(data);
            return vid;
        }

        internal Bitmap PixeladoVid(Bitmap vid, int a = ajuste)
        {
            if (a <= 0)
            {
                return vid;
            }

            int mosaicos = a * 5;

            // Bloquear bits de la imagen para acceder directamente a los datos de píxeles
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
            ImageLockMode.ReadWrite,
            PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            IntPtr ptr = data.Scan0;
            int width = vid.Width;
            int height = vid.Height;

            // Leer píxeles en memoria
            byte[] pixels = new byte[Math.Abs(stride) * height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

            for (int i = 0; i < width; i += mosaicos)
            {
                for (int j = 0; j < height; j += mosaicos)
                {
                    int sr = 0, sg = 0, sb = 0;
                    int pixelCount = 0;

                    // Calcular promedio
                    for (int im = i; im < i + mosaicos && im < width; im++)
                    {
                        for (int jm = j; jm < j + mosaicos && jm < height; jm++)
                        {
                            int pos = (jm * stride) + (im * 3); // 24bpp: 3 bytes por píxel (BGR)
                            sb += pixels[pos];
                            sg += pixels[pos + 1];
                            sr += pixels[pos + 2];
                            pixelCount++;
                        }
                    }

                    byte avgR = (byte)(sr / pixelCount);
                    byte avgG = (byte)(sg / pixelCount);
                    byte avgB = (byte)(sb / pixelCount);

                    // Aplicar promedio a cada píxel del bloque
                    for (int im = i; im < i + mosaicos && im < width; im++)
                    {
                        for (int jm = j; jm < j + mosaicos && jm < height; jm++)
                        {
                            int pos = (jm * stride) + (im * 3);
                            pixels[pos] = avgB;
                            pixels[pos + 1] = avgG;
                            pixels[pos + 2] = avgR;
                        }
                    }
                }
            }

            // Escribir píxeles de vuelta a la imagen
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap RuidoVid(Bitmap vid, Random rnd, int a = ajuste)
        {
            int porcentaje = a * 5;

            // Bloquear los bits de la imagen para acceso directo
            BitmapData data = vid.LockBits(new Rectangle(0, 0, vid.Width, vid.Height),
                                           ImageLockMode.ReadWrite,
                                           PixelFormat.Format24bppRgb);

            int stride = data.Stride;
            IntPtr ptr = data.Scan0;
            int width = vid.Width;
            int height = vid.Height;

            // Leer los píxeles de la imagen en memoria
            byte[] pixels = new byte[Math.Abs(stride) * height];
            System.Runtime.InteropServices.Marshal.Copy(ptr, pixels, 0, pixels.Length);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int pos = (y * stride) + (x * 3); // Posición del píxel actual (BGR)

                    if (rnd.Next(0, 100) < porcentaje)
                    {
                        // Generar un factor de brillo aleatorio en el rango [0.0, 2.0]
                        float brillo = rnd.Next(0, 200) / 100.0f;

                        // Modificar cada canal aplicando el brillo y limitando a 0-255
                        pixels[pos + 2] = (byte)Math.Max(0, Math.Min(255, (int)(pixels[pos + 2] * brillo)));
                        pixels[pos + 1] = (byte)Math.Max(0, Math.Min(255, (int)(pixels[pos + 1] * brillo)));
                        pixels[pos] = (byte)Math.Max(0, Math.Min(255, (int)(pixels[pos] * brillo)));
                    }
                }
            }

            // Escribir los píxeles de vuelta a la imagen
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, ptr, pixels.Length);
            vid.UnlockBits(data);

            return vid;
        }

        internal Bitmap FlipHVid(Bitmap fh)
        {
            // Crear una copia para modificar sin afectar el original
            Bitmap flip = new Bitmap(fh.Width, fh.Height, fh.PixelFormat);

            // Bloquear bits del bitmap original
            BitmapData dataOriginal = fh.LockBits(
                new Rectangle(0, 0, fh.Width, fh.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb);

            // Bloquear bits del bitmap de destino
            BitmapData dataFlip = flip.LockBits(
                new Rectangle(0, 0, flip.Width, flip.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int stride = dataOriginal.Stride;
            byte[] pixelsOriginal = new byte[stride * fh.Height];
            byte[] pixelsFlip = new byte[stride * flip.Height];

            // Copiar datos del bitmap original a un array de bytes
            System.Runtime.InteropServices.Marshal.Copy(dataOriginal.Scan0, pixelsOriginal, 0, pixelsOriginal.Length);

            // Procesar píxeles para hacer el flip horizontal
            for (int y = 0; y < fh.Height; y++)
            {
                for (int x = 0; x < fh.Width; x++)
                {
                    int srcPos = (y * stride) + (x * 3);
                    int destPos = (y * stride) + ((fh.Width - 1 - x) * 3);

                    // Copiar píxeles (BGR)
                    pixelsFlip[destPos] = pixelsOriginal[srcPos];     // Blue
                    pixelsFlip[destPos + 1] = pixelsOriginal[srcPos + 1]; // Green
                    pixelsFlip[destPos + 2] = pixelsOriginal[srcPos + 2]; // Red
                }
            }

            // Copiar datos procesados al bitmap de destino
            System.Runtime.InteropServices.Marshal.Copy(pixelsFlip, 0, dataFlip.Scan0, pixelsFlip.Length);

            // Desbloquear los bits
            fh.UnlockBits(dataOriginal);
            flip.UnlockBits(dataFlip);

            return flip;
        }

        internal Bitmap FlipVVid(Bitmap fv)
        {
            // Crear una copia para modificar sin afectar el original
            Bitmap flip = new Bitmap(fv.Width, fv.Height, fv.PixelFormat);

            // Bloquear bits del bitmap original
            BitmapData dataOriginal = fv.LockBits(
                new Rectangle(0, 0, fv.Width, fv.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format24bppRgb); // Asegúrate de usar el formato adecuado

            // Bloquear bits del bitmap de destino
            BitmapData dataFlip = flip.LockBits(
                new Rectangle(0, 0, flip.Width, flip.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format24bppRgb);

            int stride = dataOriginal.Stride;
            byte[] pixelsOriginal = new byte[stride * fv.Height];
            byte[] pixelsFlip = new byte[stride * flip.Height];

            // Copiar datos del bitmap original a un array de bytes
            System.Runtime.InteropServices.Marshal.Copy(dataOriginal.Scan0, pixelsOriginal, 0, pixelsOriginal.Length);

            // Procesar píxeles para hacer el flip vertical
            for (int y = 0; y < fv.Height; y++)
            {
                for (int x = 0; x < fv.Width; x++)
                {
                    int srcPos = (y * stride) + (x * 3);
                    int destPos = ((fv.Height - 1 - y) * stride) + (x * 3);

                    // Copiar píxeles (BGR)
                    pixelsFlip[destPos] = pixelsOriginal[srcPos];     // Blue
                    pixelsFlip[destPos + 1] = pixelsOriginal[srcPos + 1]; // Green
                    pixelsFlip[destPos + 2] = pixelsOriginal[srcPos + 2]; // Red
                }
            }

            // Copiar datos procesados al bitmap de destino
            System.Runtime.InteropServices.Marshal.Copy(pixelsFlip, 0, dataFlip.Scan0, pixelsFlip.Length);

            // Desbloquear los bits
            fv.UnlockBits(dataOriginal);
            flip.UnlockBits(dataFlip);

            return flip;
        }

        //Filtro Colores
        internal Bitmap FiltroColorVid(Bitmap img, int opc, int a = ajuste, int r = 0, int g = 0, int b = 0)
        {
            //6 colores
            switch (opc)
            {
                case 0:
                    FiltroPersonalizadoVid(img, a, r, g, b);
                    break;
                case 1:
                    FiltroRojoVid(img, a);
                    break;
                case 2:
                    FiltroVerdeVid(img, a);
                    break;
                case 3:
                    FiltroAzulVid(img, a);
                    break;
                case 4:
                    FiltroAmarilloVid(img, a);
                    break;
                case 5:
                    FiltroCianVid(img, a);
                    break;
                case 6:
                    FiltroMagentaVid(img, a);
                    break;
            }

            return img;
        }

        private Bitmap FiltroRojoVid(Bitmap vid, int a)
        {
            float factor = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, -factor, 0, 0, 0 },
                new float[] { 0, 0, -factor, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroVerdeVid(Bitmap vid, int a)
        {
            float factor = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { -factor, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, -factor, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroAzulVid(Bitmap vid, int a)
        {
            float factor = a * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { -factor, 0, 0, 0, 0 },
                new float[] { 0, -factor, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroCianVid(Bitmap vid, int a)
        {
            float factor = ajuste * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { -factor, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroMagentaVid(Bitmap vid, int a)
        {
            float factor = ajuste * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, -factor, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroAmarilloVid(Bitmap vid, int a)
        {
            float factor = ajuste * 2;

            float[][] iM = matrizIdentidad();
            float[][] fM = matrizNueva();

            float[][] colorM =
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, -factor, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 }
            };

            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    fM[r][c] = iM[r][c] + colorM[r][c];

                }
            }

            return FiltroMatriz(fM, vid);
        }

        private Bitmap FiltroPersonalizadoVid(Bitmap vid, int a, int r = 0, int g = 0, int b = 0)
        {

            return vid;
        }

    }
}
