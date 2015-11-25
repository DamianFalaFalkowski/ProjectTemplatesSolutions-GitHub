using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace $safeprojectname$.Tools
{
    // implemented only for horizontal gesture
    public class GesturesDetector
    {
        private const double MinXaxisDistanceForHorizontalGesture = 80;
        private double OverThisYaxisDistanceHorizontalGestureDetectionWillAbort = 40;

        private Point StartPoint { get; set; }
        private bool DetectingInProgress { get; set; }

        public void GestureStarted(Point point)
        {
            StartPoint = point;
            DetectingInProgress = true;
        }

        public int GestureInProgress(Point point)
        {
            if (DetectingInProgress)
            {
                if (StartPoint.Y - point.Y > OverThisYaxisDistanceHorizontalGestureDetectionWillAbort ||
                    StartPoint.Y - point.Y < -OverThisYaxisDistanceHorizontalGestureDetectionWillAbort)
                {
                    DetectingInProgress = false;
                    return 0; // detecting aborted but nothing happens
                }
                else if (point.X - StartPoint.X > MinXaxisDistanceForHorizontalGesture)
                {
                    DetectingInProgress = false;
                    return 1; // right
                }
                else if (point.X - StartPoint.X < -MinXaxisDistanceForHorizontalGesture)
                {
                    DetectingInProgress = false;
                    return -1; // left
                }
            }
            return 0; // nothing happens
        }

        public int GestureEnded(Point point)
        {
            if (DetectingInProgress)
            {
                return GestureInProgress(point);
            }
            DetectingInProgress = false;
            return 0; // detecting ended, nothing happens
        }
    }
}
