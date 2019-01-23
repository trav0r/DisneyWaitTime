using System;
using System.Net;
using System.Collections.Generic;
using DisneyWaitTime.DataObjects;

namespace DisneyWaitTime.DatabaseConnector
{
    public interface IWaitTimeDatabaseConnector
    {
        void OpenConnection();
        void CloseConnection();
        void SendWaitTimeData(List<AttractionWaitTime> data);

    }

}