using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using DisplayDataChart.Converters;
using DisplayDataChart.Mapper;
using DisplayDataChart.Models;

namespace DisplayDataChart.App_Data
{
    public class DataImporter
    {
        public DataImporter()
        {
        }

        public List<EnergyObservation> Import()
        {
            using(var streamReader = new StreamReader(@"C:\Users\dimit\Downloads\Hourly_readings_clean.csv"))
			{
				var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = ";" };
				using (var csvReader = new CsvReader(streamReader, config))
				{
					// DATA IMPORTING
					csvReader.Context.RegisterClassMap<EnergyObservationMapper>();
					var records =
						csvReader
							.GetRecords<EnergyObservation>()
							.ToList();	

					// DATA CLEANING
					DateTime startDate = new DateTime(2020, 3, 11, 1, 57, 0);
					DateTime endDate = new DateTime(2020, 3, 11, 2,0,0);
					var filteredRecords = records 
						// filters the data based on a given date and orders by date
						.Where(m => DateTime.Compare(m.Timestamp, startDate) > 0 & DateTime.Compare(m.Timestamp, endDate) < 0).OrderBy(m => m.Timestamp)
						// removes null values
						.Where(m => !m.TempForward.Equals("") & !m.TempReturn.Equals("") & !m.Energy.Equals("") & !m.TempDiff.Equals(""))
						.ToList();
					TempConverter converter = new TempConverter();
					// mutates Energy, TempForward and TempReturn values to strings convertible to doubles 
					filteredRecords.ForEach(m =>
						{
							m.TempForward = converter.ConvertTemperature(m.TempForward);
							m.TempReturn = converter.ConvertTemperature(m.TempReturn);
							m.Energy = converter.ConvertTemperature(m.Energy);
							m.TempDiff = converter.ConvertTemperature(m.TempDiff);
						});
					// remove rows with null values 
					filteredRecords.RemoveAll(item => item.TempForward == null || item.TempReturn == null || item.TempDiff == null);
					return filteredRecords;
				}
			}
        }
    }
}