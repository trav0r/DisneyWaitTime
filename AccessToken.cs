using System;
using System.Xml;
using System.Collections.Generic;
using System.Net;

namespace DisneyWaitTime
{
    ///
    public class AccessToken
    {
        /// <summary>
        /// Test
        /// </summary>
        /// <returns></returns>
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string scope { get; set; }
        public int expires_in { get; set; }

    }
}