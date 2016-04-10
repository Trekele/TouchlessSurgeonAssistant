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
    /// Interaction logic for winOperstionSummary.xaml
    /// </summary>
    public partial class winOperstionSummary
    {
        private PatientClass currentPatient;

        public winOperstionSummary(PatientClass patient)
        {
            InitializeComponent();
            this.currentPatient = patient;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ctrlPatient.lblPatientName.Content = currentPatient.LastName + ", " + currentPatient.FirstName + " " + currentPatient.MiddleName;
            ctrlPatient.lblSurgeryType.Content = currentPatient.procedure.Name;
            lblDOB.Content = currentPatient.dob;
            lblPatientID.Content = currentPatient.ID;
            lblNotes.Content = currentPatient.Notes;
            lblProcedureNotes.Content = currentPatient.procedure.Notes;

            ctrlPatient.parentWindow = this; 
            ctrlPatient.patient = currentPatient;
        }
    }
}
