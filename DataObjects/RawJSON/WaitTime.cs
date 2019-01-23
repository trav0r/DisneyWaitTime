using System;

namespace DisneyWaitTime.DataObjects.RawJSON
{
    public class WaitTime
    {
        public FastPass fastPass { get; set; }
        public string status { get; set; }
        public bool singleRider { get; set; }
        public string rollUpStatus { get; set; }
        public string rollUpWaitTimeMessage { get; set; }
        public int? postedWaitMinutes { get; set; }
    }
}