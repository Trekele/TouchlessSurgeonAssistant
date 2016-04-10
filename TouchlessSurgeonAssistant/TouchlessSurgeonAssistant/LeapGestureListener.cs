using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchlessSurgeonAssistant
{
    class LeapGestureListener : Listener
    {
        public delegate void SwipeEvent(SwipeDirection sd);
        public delegate void FingerLocation(Finger finger, Screen screen);
        public delegate void ScreenTap();
        public delegate void ZOOM(Zoom type);
        public event ZOOM ZoomEvent;
        public event ScreenTap screenTap;
        public event FingerLocation fingerLocation;
        public event SwipeEvent LeapSwipe;

        public override void OnConnect(Controller controller)
        {
            controller.Config.SetFloat("Gesture.Swipe.MinLength", 10);
            controller.Config.SetFloat("Gesture.Swipe.MinVelocity", 100);
            controller.Config.Save();
            controller.EnableGesture(Gesture.GestureType.TYPESWIPE);
            controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        }

        public override void OnFrame(Controller controller)
        {
            // Get the most recent frame and report some basic information
            Frame frame = controller.Frame();

            //check for only if there is only one hand
            if (frame.Hands.Count == 1)
            {
                //check to see if there is only the index finger is extended
                FingerList fingers = frame.Hands[0].Fingers;
                if (fingers[Finger.FingerType.TYPE_INDEX.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_MIDDLE.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_RING.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_PINKY.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_THUMB.GetHashCode()].IsExtended)
                {
                    fingerLocation(fingers[Finger.FingerType.TYPE_INDEX.GetHashCode()], controller.LocatedScreens.ClosestScreenHit(fingers[Finger.FingerType.TYPE_INDEX.GetHashCode()]));
                }
                if (fingers[Finger.FingerType.TYPE_INDEX.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_MIDDLE.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_RING.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_PINKY.GetHashCode()].IsExtended
                 && fingers[Finger.FingerType.TYPE_THUMB.GetHashCode()].IsExtended)
                {
                    screenTap();
                }

            }

            //check for custom gestures
            CustomGesture cg = new CustomGesture(frame);

            switch (cg.GestureType)
            {
                case CustomGesture.GestureTypes.INVALID:
                    // Get gestures
                    GestureList gestures = frame.Gestures();
                    for (int i = 0; i < gestures.Count; i++)
                    {
                        Gesture gesture = gestures[i];

                        switch (gesture.Type)
                        {
                            case Gesture.GestureType.TYPE_CIRCLE:
                                CircleGesture circle = new CircleGesture(gesture);

                                // Calculate clock direction using the angle between circle normal and pointable
                                string clockwiseness;
                                if (circle.Pointable.Direction.AngleTo(circle.Normal) <= Math.PI / 2)
                                {
                                    //Clockwise if angle is less than 90 degrees
                                    clockwiseness = "clockwise";
                                    ZoomEvent(Zoom.IN);
                                }
                                else
                                {
                                    ZoomEvent(Zoom.OUT);
                                    clockwiseness = "counterclockwise";
                                }

                                float sweptAngle = 0;

                                // Calculate angle swept since last frame
                                if (circle.State != Gesture.GestureState.STATE_START)
                                {
                                    CircleGesture previousUpdate = new CircleGesture(controller.Frame(1).Gesture(circle.Id));
                                    sweptAngle = (circle.Progress - previousUpdate.Progress) * 360;
                                }

                                break;
                            case Gesture.GestureType.TYPE_SWIPE:
                                SwipeGesture swipe = new SwipeGesture(gesture);
                                if (Math.Abs(swipe.Direction.x) > Math.Abs(swipe.Direction.y)) // Horizontal swipe
                                {
                                    if (swipe.Direction.x > 0) // right swipe
                                    {
                                        SwipeAction(swipe.Hands[0].Fingers, SwipeDirection.Right); Console.WriteLine();
                                    }
                                    else // left swipe
                                    {
                                        SwipeAction(swipe.Hands[0].Fingers, SwipeDirection.Left); Console.WriteLine();
                                    }
                                }
                                else // Vertical swipe
                                {
                                    if (swipe.Direction.y > 0) // upward swipe
                                    {
                                        SwipeAction(swipe.Hands[0].Fingers, SwipeDirection.Up); Console.WriteLine();
                                    }
                                    else // downward swipe
                                    {
                                        SwipeAction(swipe.Hands[0].Fingers, SwipeDirection.Down); Console.WriteLine();
                                    }
                                }

                                break;
                            case Gesture.GestureType.TYPE_KEY_TAP:
                                KeyTapGesture keytap = new KeyTapGesture(gesture);
                                break;
                            case Gesture.GestureType.TYPE_SCREEN_TAP:
                                ScreenTapGesture screentap = new ScreenTapGesture(gesture);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case CustomGesture.GestureTypes.PEACE:
                    break;
                default:
                    break;
            }

        }
        public void SwipeAction(FingerList fingers, SwipeDirection sd)
        {

            switch (sd)
            {
                case SwipeDirection.Left:
                    if (LeapSwipe != null)
                    {
                        LeapSwipe(SwipeDirection.Left);
                    }
                    break;
                case SwipeDirection.Right:
                    if (LeapSwipe != null)
                    {
                        LeapSwipe(SwipeDirection.Right);
                    }
                    break;
                case SwipeDirection.Up:
                    if (LeapSwipe != null)
                    {
                        LeapSwipe(SwipeDirection.Up);
                    }
                    break;
                case SwipeDirection.Down:
                    if (LeapSwipe != null)
                    {
                        LeapSwipe(SwipeDirection.Down);
                    }
                    break;
            }
        }
    }

}
