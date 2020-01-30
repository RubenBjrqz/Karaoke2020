using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.Windows.Threading;

namespace Karaoke2020
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        AudioFileReader reader;
        WaveOut output;

        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var segundosActuales = reader.CurrentTime.TotalSeconds;
            var segundosTotales = reader.TotalTime.TotalSeconds;
            var porcentaje = segundosActuales / segundosTotales * 100;

            pbAvanzar.Value = porcentaje;

            if(pbAvanzar.Value > 16 && pbAvanzar.Value < 21)
            {
                txtEspañol.Text = "Sueños, sueños, sueños, sueños,";
                txtJapones.Text = "Yume, yume, yume, yume,";
            }
            if(pbAvanzar.Value > 21 && pbAvanzar.Value < 28)
            {
                txtEspañol.Text = "tan pronto como llegue a la meta, es como todo cae de nuevo";
                txtJapones.Text = "kanaeru tabi kowareteyuku yume";
            }
            if(pbAvanzar.Value > 28 && pbAvanzar.Value < 33)
            {
                txtEspañol.Text = "entonces, ¿Por qué intento correr...";
                txtJapones.Text = "naze sore demo mata";
            }
            if(pbAvanzar.Value > 33 && pbAvanzar.Value < 41)
            {
                txtEspañol.Text = "Mas allá de mi sueño se encuentra otro sueño... ¿Y lo busco a pesar de eso?";
                txtJapones.Text = "boku wa sagasu hashiritsuzukeru";
            }
            if (pbAvanzar.Value > 41 && pbAvanzar.Value < 43)
            {
                txtEspañol.Text = "nos hemos reunido después de tanto tiempo";
                txtJapones.Text = "hisashiburi ni deatta";
            }
            if (pbAvanzar.Value > 43 && pbAvanzar.Value < 45)
            {
                txtEspañol.Text = "¿Han cambiado su humor por nosotros?";
                txtJapones.Text = "funiki kawatta?";
            }
            if (pbAvanzar.Value > 45 && pbAvanzar.Value < 48)
            {
                txtEspañol.Text = "tanto tiempo ha pasado";
                txtJapones.Text = "tsukihi wa nagareta darou";
            }
            if (pbAvanzar.Value > 48 && pbAvanzar.Value < 55)
            {
                txtEspañol.Text = "parecia mas divertido en aquel entonces";
                txtJapones.Text = "ano koro no hou ga tanoshisou";
            }
            if (pbAvanzar.Value > 55 && pbAvanzar.Value < 60)
            {
                txtEspañol.Text = "hemos perdido mucho";
                txtJapones.Text = "takusan nakushita";
            }
            if (pbAvanzar.Value > 60 && pbAvanzar.Value < 70)
            {
                txtEspañol.Text = "aunque ya lo sé";
                txtJapones.Text = "sonna koto wa kizuiteru n da";
            }
            if (pbAvanzar.Value > 70 && pbAvanzar.Value < 76)
            {
                txtEspañol.Text = "no dejare de gritar, no dejare de luchar";
                txtJapones.Text = "sakebitsuzukero mogakitsuzukero";
            }
            if (pbAvanzar.Value > 76 && pbAvanzar.Value < 83)
            {
                txtEspañol.Text = "¿Has hecho mucho por los demás?";
                txtJapones.Text = "dare no tame ni nanka mou ii darou";
            }
            if (pbAvanzar.Value > 83 && pbAvanzar.Value < 90)
            {
                txtEspañol.Text = "todavia, todavia hay algo que no te he dicho";
                txtJapones.Text = "mada mada tsutaetai koto ga aru mada mada mada";
            }
            if (pbAvanzar.Value > 90 && pbAvanzar.Value < 96)
            {
                txtEspañol.Text = "mas allá de mi sueño se encuentra otro sueño";
                txtJapones.Text = "yume no saki ni wa yume shika nai";
            }



        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            pbAvanzar.Visibility = Visibility.Visible;
            btnReproducir.Visibility = Visibility.Collapsed;
            txtEspañol.Visibility = Visibility.Visible;
            txtJapones.Visibility = Visibility.Visible;
            txtCancion.Visibility = Visibility.Collapsed;

            reader = new AudioFileReader(@"Opening.mp3");
            output = new WaveOut();

            output.Init(reader);
            output.Play();

            

            timer.Start();
        }
    }
}
