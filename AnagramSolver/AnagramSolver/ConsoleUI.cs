using System;

namespace AnagramSolver.ConsoleApp
{
    public class ConsoleUI
    {
        public DateTime[] Initialize()
        {
            Console.WriteLine("Enter the date to search from:");
            string input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime fromDate);

            Console.WriteLine("Enter date to search to:");
            input = Console.ReadLine();
            DateTime.TryParse(input, out DateTime toDate);

            if (fromDate > toDate)
            {
                throw new ArgumentException("Date to search from has to be equal or greater than date to searh to");
            }

            return new DateTime[2] { fromDate, toDate };
        }
    }
}
