using HelixToolkit.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TouchlessSurgeonAssistant
{
    /// <summary>
    /// Interaction logic for ctrl3DModelViewer.xaml
    /// </summary>
    public partial class ctrl3DModelViewer : UserControl
    {
        private const string MODEL_PATH = @"C:\Users\Trekele\Downloads\ca5rmhx7l4-Human Heart 2\Human Heart 2\Heart.obj";
        Model3D device = null;
        private Controller controller;
        private LeapGestureListener listener;

        public ctrl3DModelViewer()
        {
            InitializeComponent();

            ModelVisual3D device3D = new ModelVisual3D();
            device3D.Content = Display3d(MODEL_PATH);
            viewPort3d.Children.Add(device3D);

            //initialize the leap controller and listener
            controller = new Controller();
            listener = new LeapGestureListener();
            controller.AddListener(listener);
            listener.LeapSwipe += SwipeAction;
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
    }
}
