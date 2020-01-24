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
            pbAvanzar.Value = reader.CurrentTime.Seconds;
        }

        private void BtnReproducir_Click(object sender, RoutedEventArgs e)
        {
            pbAvanzar.Visibility = Visibility.Visible;
            btnReproducir.Visibility = Visibility.Collapsed;

            reader = new AudioFileReader(@"Cancion.mp3");
            output = new WaveOut();

            output.Init(reader);
            output.Play();

            pbAvanzar.Maximum = reader.TotalTime.TotalSeconds;

            timer.Start();
        }
    }
}
