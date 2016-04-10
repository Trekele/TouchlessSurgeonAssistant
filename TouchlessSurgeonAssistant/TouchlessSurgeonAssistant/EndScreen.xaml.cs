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
using System.Windows.Shapes;

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for EndScreen.xaml
    /// </summary>
    public partial class EndScreen : Window
    {
        private PatientClass patient;

        public EndScreen(PatientClass patient, int TimeEnlapsed, Dictionary<string, int> supplies)
        {
            InitializeComponent();
            this.patient = patient;
            lblPatient.Content = string.Format(lblPatient.Content.ToString(), patient.FirstName + patient.LastName);
            lblDate.Content = string.Format(DateTime.Now.ToString("HH:mm:ss"));
            lblTimeEnlpased.Content = string.Format(lblTimeEnlpased.Content.ToString(), string.Format("{0}:0{1}:{2}", TimeEnlapsed / 86400, TimeEnlapsed / 60, TimeEnlapsed % 60));
            foreach (KeyValuePair<string, int> item in supplies)
            {
                lblSupplies.Content += string.Format("{0}:{1}\n", item.Key, item.Value);
            }
        }


    }
}
