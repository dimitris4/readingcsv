using System;
using System.Runtime.Serialization;

namespace DisplayDataChart.Models
{
    [DataContract]
    public class EnergyObservation
    {
        public DateTime Timestamp { get; set; }
        public String Energy { get; set; }
        public String TempForward { get; set; }
        public String TempReturn { get; set; }
        public String TempDiff { get; set; }
    }
}