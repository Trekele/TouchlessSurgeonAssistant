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
    /// Interaction logic for winChecklist.xaml
    /// </summary>
    public partial class winChecklist
    {
        public bool checklistApproved { get; set; }

        public winChecklist()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            checklistApproved = true;
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            checklistApproved = false;
            this.Close();  
        }
    }
}
