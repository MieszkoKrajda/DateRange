using log4net;
using System;
using System.Reflection;

namespace DateRange
{
    /// <summary>
    /// Validation of input date arguments.
    /// </summary>
    internal static class Validation
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            
        /// <summary>
        /// Validates size of input arguments array.
        /// </summary>
        /// <param name="dateStrings">Input arguments array.</param>
        /// <returns>True if input arguments array contains 2 elements, else False.</returns>
        internal static bool ValidateInputSize(string[] dateStrings)
        {
            if (dateStrings?.Length != 2)
            {
                Log.Error("Wrong number of input arguments.");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks whether given dates are consecutive.
        /// </summary>
        /// <param name="firstDate">First input date.</param>
        /// <param name="secondDate">Second input date.</param>
        /// <returns>True if second date is later than the first, else False.</returns>
        internal static bool ValidateTimeDifference(DateTime firstDate, DateTime secondDate)
        {
            if (secondDate.CompareTo(firstDate) <= 0)
            {
                Log.Error("Second date is not later than first.");
                return false;
            }
            return true;
        }
    }
}
