using CsvHelper.Configuration;
using DisplayDataChart.Models;

namespace DisplayDataChart.Mapper
{
    public sealed class EnergyObservationMapper: ClassMap<EnergyObservation>
    {
        public EnergyObservationMapper()
        {
            Map(m => m.Timestamp).Name("Timestamp");
            Map(m => m.Energy).Name("Energy");
            Map(m => m.TempForward).Name("TempForward");
            Map(m => m.TempReturn).Name("TempReturn");
            Map(m => m.TempDiff).Name("valueTempDiff");
        }
    }
}