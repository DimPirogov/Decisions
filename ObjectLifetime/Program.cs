using System;

namespace ObjectLifetime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            Car.MyMethod();
            /*
            myCar.Make = "oldmobile";
            myCar.Model = "Cutlas";
            myCar.Year = 1986;
            myCar.Color = "Silver";
            

            Car myThirdCar = new Car("Ford", "Escape", 2005, "White");

            Car myOtherCar = myCar;

            Console.WriteLine("{0} {1} {2} {3}", myOtherCar.Make, myOtherCar.Model, myOtherCar.Year, myOtherCar.Color);

            myOtherCar.Model = "98";

            Console.WriteLine("{0} {1} {2} {3}", myCar.Make, myCar.Model, myCar.Year, myCar.Color);

            myOtherCar = null;

            //Console.WriteLine("{0} {1} {2} {3}", myOtherCar.Make, myOtherCar.Model, myOtherCar.Year, myOtherCar.Color);
            myCar = null;
             
            */

            Console.ReadLine();
        }
    }

   class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        public Car()
        {
            Make = "Nissan";
        }

        public Car(string make, string model, int year, string color)
        {
            Make=make;
            Model=model;
            Year=year;
            Color=color;
        }

        public static void MyMethod()
        {
            Console.WriteLine("Called the static MyMethod");
        }

    }
}
