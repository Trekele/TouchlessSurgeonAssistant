using Leap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchlessSurgeonAssistant
{
    class CustomGesture
    {
        private Frame currentFrame;
        public GestureTypes GestureType { get; set; }

        public CustomGesture(Frame frame)
        {
            currentFrame = frame;
            //immediately check to see if the frame contains a custom gesture
            GestureType = DetermineGesture();
        }

        public GestureTypes DetermineGesture()
        {
            //get the hands
            HandList hands = currentFrame.Hands;
            //if there is only one hand in the frame, check for peace sign
            if (hands.Count == 1)
            {

                FingerList fingers = hands[0].Fingers;
                //check to see if the only fingers that are extended are the index and middle
                if (fingers[Finger.FingerType.TYPE_INDEX.GetHashCode()].IsExtended
                 && fingers[Finger.FingerType.TYPE_MIDDLE.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_RING.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_PINKY.GetHashCode()].IsExtended
                 && !fingers[Finger.FingerType.TYPE_THUMB.GetHashCode()].IsExtended)
                {
                    return GestureTypes.PEACE;
                }
            }
            return GestureTypes.INVALID;
        }

        public enum GestureTypes
        {
            INVALID = -1,
            PEACE = 1
        }
    }
}
