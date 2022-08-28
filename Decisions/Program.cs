using System;

namespace Decisions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Bob's Big Giveaway");
            Console.Write("Choose a door: 1, 2 or 3: ");
            string userValue = Console.ReadLine();
            string message = "";

            if(userValue == "1")
                message = "You won an old car!";
            else if (userValue == "2")
                message = "You won a new boat!";
            else if (userValue == "3")
                message = "You won a old cat!";
            else
            {
                message = "sorry, we didn't understand.";
                //message = (message + " You lose!");
                message += " You lose!";
            }

            Console.WriteLine(message);
            Console.ReadLine();
            */

            Console.WriteLine("Bob's Big Giveaway");
            Console.Write("Choose a door: 1, 2 or 3: ");
            string userValue = Console.ReadLine();

            string message = (userValue == "1") ? "boat" : (userValue == "2" ? "Console.Beep() we tried" : "strand of lint");
            Console.WriteLine("You chose {0}. Therefore you won a {1}.", userValue, message);
            Console.Beep(1000, 1000);
            Console.ReadLine();

        }
    }
}

