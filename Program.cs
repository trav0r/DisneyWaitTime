using System;
using DisneyWaitTime.DataObjects;
using DisneyWaitTime.DataObjects.RawJSON;
using Newtonsoft.Json;

namespace DisneyWaitTime
{
    public class Program
    {
        static void Main(string[] args)
        {
            string rawJson = Api.GetWaitTimes();

            DisneyJson response = JsonConvert.DeserializeObject<DisneyJson>(rawJson);

            List<AttractionWaitTime> waitTimes = new List<AttractionWaitTime>();

            foreach(Entry entry in response.entries)
            {
                AttractionWaitTime waitTime = new AttractionWaitTime()
                {
                    ID = Int32.Parse(entry.id),
                    Name = entry.name,
                    AttractionType = entry.type,
                    FastPass = entry.waitTime.fastPass.available,
                    SingleRider = entry.waitTime.singleRider,
                    PostedWaitMinutes = entry.waitTime.postedWaitMinutes == null ? 0 : (int)entry.waitTime.postedWaitMinutes,
                    Status = entry.waitTime.status,
                    RollUpStatus = entry.waitTime.rollUpStatus,
                    RollUpWaitTimeMessage = entry.waitTime.rollUpWaitTimeMessage
                };

            }

            Console.WriteLine(response.entries.Count);
        }
    }
}