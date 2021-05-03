using System;
using System.Text.RegularExpressions;

namespace DisplayDataChart.Converters
{
    public class TempConverter
    {
        public String ConvertTemperature(String s)
        {
            Regex re = new Regex(@"^\d*\.?\d*");
            Match m = re.Match(s);
            if (m.Success && !m.Value.Equals(""))
            {
                if (m.Value.Substring(m.Value.Length - 1).Equals("."))
                {
                    switch (s.Substring(s.Length - 3,3))
                    {
                        case "jan":
                            return $"{m.Value}1";
                        case "feb":
                            return $"{m.Value}2";
                        case "mar":
                            return $"{m.Value}3";
                        case "apr":
                            return $"{m.Value}4";
                        case "may":
                            return $"{m.Value}5";
                        case "jun":
                            return $"{m.Value}6";
                        case "jul":
                            return $"{m.Value}7";
                        case "aug":
                            return $"{m.Value}8";
                        case "sep":
                            return $"{m.Value}9";
                        case "oct":
                            return $"{m.Value}10";
                        case "nov":
                            return $"{m.Value}11";
                        case "dec":
                            return $"{m.Value}12";
                    }
                } else {
                    return m.Value;
                }
            }
            return "-1";
        }
    }
}