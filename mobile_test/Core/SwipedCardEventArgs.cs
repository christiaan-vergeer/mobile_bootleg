using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_test.Core
{
    public class SwipedCardEventArgs : System.EventArgs
    {
        public SwipedCardEventArgs(object person, object parameter, SwipeCardDirection direction)
        {
            Person = person;
            Parameter = parameter;
            Direction = direction;
        }

        public object Person { get; private set; }

        public object Parameter { get; private set; }

        public SwipeCardDirection Direction { get; private set; }
    }
}
