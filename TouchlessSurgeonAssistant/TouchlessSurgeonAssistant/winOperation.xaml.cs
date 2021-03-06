﻿using HelixToolkit.Wpf;
using Leap;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class winOperation
    {

        private string MODEL_PATH = @"Heart.obj";
        Model3D device = null;
        private Controller controller;
        private LeapGestureListener listener;
        private Point coords;
        private PatientClass currentPatient; 

        public winOperation(PatientClass patient)
        {

            InitializeComponent();
            this.currentPatient = patient;
            MODEL_PATH = patient.OBJFile;
            ModelVisual3D device3D = new ModelVisual3D();
            device3D.Content = Display3d(MODEL_PATH);
            viewPort3d.Children.Add(device3D);
            //initialize the leap controller and listener
            coords = new Point();
            controller = new Controller();
            listener = new LeapGestureListener();
            controller.AddListener(listener);
            listener.LeapSwipe += SwipeAction;
            listener.fingerLocation += Listener_fingerLocation; ;
            listener.screenTap += Listener_screenTap;
            listener.ZoomEvent += Listener_ZoomEvent;

            

            ctrlPatient.timerStart();

            Gauze.Value = 0;
            Towels.Value = 0;
            Screws.Value = 0;

        }

        private void Listener_ZoomEvent(Zoom type)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                var matrix = device.Transform.Value;
                double scaleFactor = 1;

                switch (type)
                {
                    case Zoom.IN:
                        scaleFactor = 1.001;
                        break;
                    case Zoom.OUT:
                        scaleFactor = 1 / 1.001;
                        break;
                    default:
                        break;
                }

                Vector3D v = new Vector3D(scaleFactor, scaleFactor, scaleFactor);
                matrix.Scale(v);
                device.Transform = new MatrixTransform3D(matrix);
            }));
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

        private Model3D Display3d(string model)
        {
            try
            {
                //Adding a gesture here
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                device = import.Load(model);
            }
            catch (Exception e)
            {
                // Handle exception in case can not find the 3D model file
                MessageBox.Show("Exception Error : " + e.StackTrace);
            }
            return device;
        }

        private void SwipeAction(SwipeDirection sd)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Input, new ThreadStart(() =>
            {
                try
                {
                    var matrix = device.Transform.Value;

                    Vector3D axis = new Vector3D();
                    int angle = 0;

                    switch (sd)
                    {
                        case SwipeDirection.Up:
                            angle = 1;
                            axis = new Vector3D(1, 0, 0);
                            break;
                        case SwipeDirection.Down:
                            angle = -1;
                            axis = new Vector3D(1, 0, 0);
                            break;
                        case SwipeDirection.Left:
                            angle = 1;
                            axis = new Vector3D(0, 1, 0);
                            break;
                        case SwipeDirection.Right:
                            angle = -1;
                            axis = new Vector3D(0, 1, 0);
                            break;
                    }

                    matrix.Rotate(new Quaternion(axis, angle));
                    device.Transform = new MatrixTransform3D(matrix);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }));
        }
        public Dictionary<string, int> getSupplies()
        {
            Dictionary<string, int> returnSupplies = new Dictionary<string, int>();
            returnSupplies.Add("Gauze", (int) Gauze.Value != null ? (int)Gauze.Value : 0);
            returnSupplies.Add("Towels", (int) Towels.Value);
            returnSupplies.Add("Screws", (int) Screws.Value);
            return returnSupplies;
        }

        private void ctrlPatient_Loaded(object sender, RoutedEventArgs e)
        {
            ctrlPatient.parentWindow = this;
            ctrlPatient.patient = currentPatient;

            ctrlPatient.lblPatientName.Content = currentPatient.LastName + ", " + currentPatient.FirstName + " " + currentPatient.MiddleName;
            ctrlPatient.lblSurgeryType.Content = currentPatient.procedure.Name;
        }
    }
}
