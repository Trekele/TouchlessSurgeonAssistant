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

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for winLogin.xaml
    /// </summary>
    public partial class winLogin 
    {
        private const string BACKGROUND_PATH = @"bkgrnd.png";
        public winLogin()
        {
            InitializeComponent();
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //declare sqlce objects
            SqlCeConnection conn = null;
            SqlCeCommand cmd = null;
            SqlCeDataReader rdr = null;

            try
            {
                //path to the database
                string connString = "Data Source = PatientData.sdf";
                conn = new SqlCeConnection(connString);
                conn.Open();

                //query to run on the database
                string selectCmd = "SELECT id from DoctorInfo WHERE username = '" + textBox.Text + "' AND password = '" + PasswordBox.Password + "'";
                cmd = conn.CreateCommand();
                cmd.CommandText = selectCmd;

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    winDashboard window = new winDashboard(rdr.GetInt32(0));
                    window.Show();
                    this.Close();
                }
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }
             
        }
    }
}
