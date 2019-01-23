using System;

namespace DisneyWaitTime.DataObjects.RawJSON
{
    public class Entry
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public WaitTime waitTime { get; set; }
    }
}
