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
using System.Windows.Threading;

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for ctrlPatientInfo.xaml
    /// </summary>
    public partial class ctrlPatientInfo : UserControl
    {
        public Window parentWindow  { get; set; }

        private DispatcherTimer timer;
        private int totalSeconds;
        public ctrlPatientInfo()
        {
            InitializeComponent();
            //disable the endButton
            btnEnd.IsEnabled = true;

            timer = new DispatcherTimer();
            timer.Tick += dispatcherTimer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);

            //disable the start button and enable the end button
            btnEnd.IsEnabled = true;
            btnStart.IsEnabled = false;

            //start timing
            timer.Start();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            winChecklist window = new winChecklist();
            window.ShowDialog(); 
            
            if (window.checklistApproved == true)
            {
                winOperation opWindow = new winOperation();
                opWindow.Show(); 
                this.parentWindow.Close(); 
            }
        }

        private void btnEnd_Click(object sender, RoutedEventArgs e)
        {
            //disable the end button and enable the start button
            btnStart.IsEnabled = true;
            btnEnd.IsEnabled = false;

            timer.Stop();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            totalSeconds++;
            // code goes here
            lblTimer.Content = string.Format("{0}:0{1}:{2}", totalSeconds / 86400, totalSeconds / 60, totalSeconds % 60);
        }
    }
}
