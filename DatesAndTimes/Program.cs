using System;

namespace DatesAndTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime myValue = DateTime.Now;
            Console.WriteLine(myValue.ToString());
            Console.WriteLine(myValue.ToShortDateString());
            Console.WriteLine(myValue.Year);
            Console.WriteLine(myValue.Month);
            Console.WriteLine(myValue.Day);
            //Console.WriteLine(myValue.ToShortTimeString());
            //Console.WriteLine(myValue.ToLongDateString());
            //Console.WriteLine(myValue.ToLongTimeString());

            //Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            //Console.WriteLine(myValue.AddHours(3).ToLongTimeString());
            //Console.WriteLine(myValue.Month);

            //DateTime myBirthday = new DateTime(1969, 12, 7);
            //Console.WriteLine(myBirthday.ToShortDateString());

            
            DateTime myBirthday = DateTime.Parse("1973,08,18");
            Console.WriteLine(myBirthday.ToShortDateString());
            if(myValue < myBirthday)
                Console.WriteLine("My birthday är större" + myBirthday.ToShortDateString());
            else if (myValue > myBirthday)
                Console.WriteLine("myValue är större" + myValue.ToShortDateString());
            
            /*DateTime day = DateTime.Parse(Console.ReadLine());
            if(myBirthday == day)
                Console.WriteLine("Det funkade");
            else
                Console.WriteLine("nehe");
            */
            //TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            //Console.WriteLine(myAge.TotalDays);


            Console.ReadLine();
        }
    }
}
