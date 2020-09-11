using System;
using System.Collections.Generic;
using System.Text;

namespace mobile_test.Core
{
    public enum DraggingCardPosition
    {
        Start = 0,
        UnderThreshold = 1,
        OverThreschold = 2,
        FinishedUnderThreshold = 4,
        FinishedOverThreshold = 8
    }
}
