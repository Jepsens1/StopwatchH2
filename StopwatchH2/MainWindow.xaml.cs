using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace StopwatchH2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread thread;
        Dispatcher dispatcher;
        Timer timer;
        public MainWindow()
        {
            dispatcher = Application.Current.MainWindow.Dispatcher;

            timer = new Timer();
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            thread = new Thread(TimerRun);
            thread.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.IsFinished = true;
            CountLabel.Content = timer.ShowElapsedTime();
            timer.StopTimer();
            thread.Join();
        }
        private void TimerRun()
        {
            timer.IsFinished = false;
            timer.StartTimer();
            while (!timer.IsFinished)
            {
                dispatcher.BeginInvoke(new Action(() =>
                {
                    CountLabel.Content = timer.GetRemaningTimeLeft(Convert.ToInt32(NumberFromTextBox.Text));
                }));
                Thread.Sleep(1000);
            }
        }
    }
}
