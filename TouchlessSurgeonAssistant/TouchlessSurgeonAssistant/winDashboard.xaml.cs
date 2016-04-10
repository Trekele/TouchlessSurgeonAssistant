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
using System.Data.SqlServerCe;
using System.Data;
using Leap;

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for winDashboard.xaml
    /// </summary>
    public partial class winDashboard
    {
        private Controller controller;
        private LeapGestureListener listener;
        private Point coords;

        public winDashboard()
        {
            InitializeComponent();

            coords = new Point();
            controller = new Controller();
            listener = new LeapGestureListener();
            controller.AddListener(listener);
            listener.fingerLocation += Listener_fingerLocation;
            listener.screenTap += Listener_screenTap;
        }

        private void Listener_screenTap()
        {
            MouseMovement.LeftMouseClick((int)coords.X, (int)coords.Y);
        }

        private void Listener_fingerLocation(Finger finger, Screen screen)
        {
            //change the mouse location based on the location of the finger.
            coords = MouseMovement.GetPointFromFingers(finger, screen);
            MouseMovement.SetCursorPos((int)coords.X, (int)coords.Y);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //declare sqlce objects
            SqlCeConnection conn = null;
            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;
            SqlCeDataAdapter da = null;

            //create list of patients
            List<PatientClass> list_patients = new List<PatientClass>();

            try
            {
                //path to the database
                string connString = "Data Source = PatientData.sdf";
                conn = new SqlCeConnection(connString);
                conn.Open();

                //query to run on the database
                string selectCmd = "SELECT * FROM PatientInfo";
                cmd = conn.CreateCommand();
                cmd.CommandText = selectCmd;

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    list_patients.Add(new PatientClass(rdr));
                }
                patientDataGrid.DataContext = list_patients;
                patientDataGrid.ItemsSource = list_patients;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }

        private void patientDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            winOperstionSummary window = new winOperstionSummary((PatientClass) patientDataGrid.SelectedItem);
            window.Show();
            this.Close(); 
        }
    }
}
