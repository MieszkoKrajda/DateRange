using System;
using log4net.Config;

namespace DateRange
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure();

            var dateRange = new DateRange();
            var rangeToDisplay = dateRange.GetRange(args);
            Console.WriteLine(rangeToDisplay);
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
