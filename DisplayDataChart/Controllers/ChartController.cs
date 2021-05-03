using System;
using System.Web.Mvc;
using System.Globalization;
using System.Linq;
using System.Web.Helpers;
using DisplayDataChart.App_Data;

namespace DisplayDataChart.Controllers
{
    public class ChartController : Controller
    {
        // GET
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult EnergyChart()
        {
            var dataImporter = new DataImporter();
            var filteredRecords = dataImporter.Import();
            // DATA VISUALIZATION
            var timestamp = filteredRecords.Select(v => v.Timestamp);
            var tempForward = filteredRecords.Select(v => double.Parse(v.TempForward, CultureInfo.InvariantCulture));
            var tempReturn = filteredRecords.Select(v => double.Parse(v.TempReturn, CultureInfo.InvariantCulture));
            var energy = filteredRecords.Select(v => double.Parse(v.Energy, CultureInfo.InvariantCulture));
            var tempDiff = filteredRecords.Select(v => double.Parse(v.TempDiff, CultureInfo.InvariantCulture));
            new Chart(width: 1000, height: 300, ChartTheme.Blue)  
                .AddTitle("Energy consumption between 01:57 and 02:00 on the 11.03.2020")  
                .AddSeries (
                    chartType: "line",  
                    xValue: timestamp.ToArray(),  
                    yValues: energy.ToArray())
                .SetYAxis(min:0.0, max:40)
                .Write("png");
            return null;
        }
        
        public ActionResult TemperatureChart()
        {
            var dataImporter = new DataImporter();
            var filteredRecords = dataImporter.Import();
            // DATA VISUALIZATION
            var timestamp = filteredRecords.Select(v => v.Timestamp);
            var tempForward = filteredRecords.Select(v => double.Parse(v.TempForward, CultureInfo.InvariantCulture));
            var tempReturn = filteredRecords.Select(v => double.Parse(v.TempReturn, CultureInfo.InvariantCulture));
            var energy = filteredRecords.Select(v => double.Parse(v.Energy, CultureInfo.InvariantCulture));
            var tempDiff = filteredRecords.Select(v => double.Parse(v.TempDiff, CultureInfo.InvariantCulture));
            new Chart(width: 1000, height: 300, ChartTheme.Blue)  
                .AddTitle("Temperatures Chart")
                .AddSeries(
                    chartType: "line",
                    xValue: timestamp.ToArray(),
                    yValues: tempReturn.ToArray(),
                    name: "Temp Return")
                .AddSeries (
                    chartType: "line",  
                    xValue: timestamp.ToArray(),  
                    yValues: tempForward.ToArray(),
                    name:"Temp Forward") 
                .AddLegend()
                .SetYAxis(min:0.0, max:85)
                .Write("png");
            return null;
        }
    }
}