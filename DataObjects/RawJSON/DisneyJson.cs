using System;
using System.Collections.Generic;

namespace DisneyWaitTime.DataObjects.RawJSON
{
    public class DisneyJson
    {
        public Links links { get; set; } 
        public int offset { get; set; }
        public int limit { get; set; } 
        public int total { get; set; }
        public List<Entry> entries { get; set; }
    }
}