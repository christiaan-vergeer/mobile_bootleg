using mobile_test.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_test.Core
{
    public class DraggingCardEventArgs : System.EventArgs
    {
        public DraggingCardEventArgs(object person, object parameter, SwipeCardDirection direction, DraggingCardPosition position, double distanceDraggedX, double distanceDraggedY)
        {
            Person = person;
            Parameter = parameter;
            Direction = direction;
            Position = position;
            DistanceDraggedX = distanceDraggedX;
            DistanceDraggedY = distanceDraggedY;
        }

        public object Person { get; private set; }

        public object Parameter { get; private set; }

        public SwipeCardDirection Direction { get; private set; }

        public DraggingCardPosition Position { get; private set; }

        public double DistanceDraggedX { get; private set; }

        public double DistanceDraggedY { get; private set; }

    }
}
