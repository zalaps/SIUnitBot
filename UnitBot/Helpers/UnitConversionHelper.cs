using UnitsNet;

namespace Bot_Application1.Helpers
{
    public class UnitConversionHelper
    {
        public static string Convert(double amount, string from, string to)
        {
            string result = UnitConverter.ConvertByAbbreviation(amount, "Mass", from, to).ToString();

            return result;
        }
    }
}