using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MathTestsX86
{
    public static class EngineeringFormatHelper
    {
        public static string ToEngineeringString(this BigInteger i, int places = 6)
        {
            //Use the out of the box API to convert from BigInteger to Engineering String
            //However keep the entire precision  of the value when converting
            //This will provide a number that looks like 9.031457927716431901820E+020
            var formattedString = string.Format("{0:E" + i.ToString().Length + "}", i);

            //Take the part before the E convert it to a decimal and round it appropriately
            var roundedNumber = Math.Round(decimal.Parse(formattedString.Substring(0, formattedString.IndexOf('E'))), places);

            //take the rounded decimal and tack back on the part after the E
            return roundedNumber.ToString() + formattedString.Substring(formattedString.IndexOf('E'));
        }
    }
}
