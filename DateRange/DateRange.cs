using System;
using System.Globalization;
using System.Reflection;
using log4net;

namespace DateRange
{
    /// <summary>
    ///     Class providing date range in correct format.
    /// </summary>
    internal class DateRange
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Gets date range based on string array.
        /// </summary>
        /// <param name="args">Array of two consecutive dates.</param>
        /// <returns>String containing date range.</returns>
        public string GetRange(string[] args)
        {
            if (!Validation.ValidateInputSize(args)) return null;

            var (firstDate, secondDate) = ConvertInputToDates(args);

            if (firstDate == default(DateTime) || secondDate == default(DateTime)) return null;

            if (!Validation.ValidateTimeDifference(firstDate, secondDate)) return null;

            return PrepareRange(firstDate, secondDate);
        }

        private static  (DateTime, DateTime) ConvertInputToDates(string[] dateStrings)
        {
            var firstDate = default(DateTime);
            var secondDate = default(DateTime);
            try
            {
                firstDate = Convert.ToDateTime(dateStrings[0], new CultureInfo("pl-PL"));
                secondDate = Convert.ToDateTime(dateStrings[1], new CultureInfo("pl-PL"));
            }
            catch (FormatException ex)
            {
                Log.Error("Given argument is not a date.", ex);
            }

            return (firstDate, secondDate);
        }

        private static string PrepareRange(DateTime firstDate, DateTime secondDate)
        {
            var secondDateString = secondDate.ToShortDateString();
            var result = firstDate.ToShortDateString() + " - " + secondDateString;

            if (firstDate.Month.Equals(secondDate.Month) && firstDate.Year.Equals(secondDate.Year))
                result = firstDate.Day.ToString("00") + " - " + secondDateString;
            else if (firstDate.Year.Equals(secondDate.Year))
                result = firstDate.Day.ToString("00") + "." + firstDate.Month.ToString("00") + " - " + secondDateString;
            return result;
        }
    }
}