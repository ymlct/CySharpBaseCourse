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

namespace L12Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        public event EventHandler OnStartEvent = null;
        
        public event EventHandler OnStopEvent = null;
        
        public event EventHandler OnResetEvent = null;

        public void SetTimerValue(string timerValue)
        {
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            OnStartEvent?.Invoke(sender, e);
        }
        
        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            OnStopEvent?.Invoke(sender, e);
        }
        
        private void OnResetButtonClick(object sender, RoutedEventArgs e)
        {
            OnResetEvent?.Invoke(sender, e);
        }

    }
}