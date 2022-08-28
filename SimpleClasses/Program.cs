using System;

namespace SimpleClasses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();
            myCar.Make = "old";
            myCar.Model = "Cutlas";
            myCar.Year = 1986;
            myCar.Color = "Silver";

            //decimal value = DetermineMarketValue(myCar);
            //Console.WriteLine("{0}", value);
            //Console.WriteLine("{0:C}", value);

            Console.WriteLine(myCar.Year);
            Console.WriteLine("{0:C}", myCar.DetermineMarketValue()); 

            
        }

        private static decimal DetermineMarketValue(Car car)
        {
            decimal carValue = 100.0M;
            //Someday
            //someting
            //from web
            return carValue;
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public decimal DetermineMarketValue()
        {
            decimal carValue;
            if (Year > 1990)
                carValue = 10000;
            else
                carValue = 2000;

            return carValue;
        }

    }


}
