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
        private PatientClass patient;
        private List<CheckBox> checkBoxes;

        public winChecklist(PatientClass Patient)
        {
            InitializeComponent();
            checkBoxes = new List<CheckBox>();
            int topMargin = 20;
            int count = 0;
            patient = Patient;

            foreach (string checklistItem in patient.procedure.CheckList)
            {
                CheckBox temp = new CheckBox();
                temp.Content = checklistItem;
                temp.HorizontalAlignment = HorizontalAlignment.Left;
                temp.VerticalAlignment = VerticalAlignment.Top;
                ScaleTransform scale = new ScaleTransform(2.0, 2.0);
                //temp.RenderTransformOrigin = new Point(0.5, 0.5);
                temp.RenderTransform = scale;
                temp.LayoutTransform.Value.Scale(6, 6);
                Thickness margin = temp.Margin;
                margin.Left = 0;
                margin.Top = topMargin;
                margin.Right = 0;
                temp.Margin = margin;

                stackPanel.Children.Add(temp);
                checkBoxes.Add(temp);

                topMargin += count == 2 ? 40 : 5;
                count++;
            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            bool allChecked;
            foreach (CheckBox item in checkBoxes)
            {
                if (item.IsChecked == false)
                {
                    MessageBox.Show("Select all boxes");
                    return;
                }

            }
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
