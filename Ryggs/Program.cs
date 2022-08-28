using System;

namespace Ryggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vi skapar en bool till while loop
            bool killWhile = true;
            //skapar föremål variabel
            string myStuff = "";


            while (killWhile)
            {
                //skapa menyn och rensa innan
                Console.Clear();
                Console.WriteLine();    //skapa lite utrymme
                Console.WriteLine("Välkommen till ryggsäcken!");
                Console.WriteLine(); //skapa lite utrymme
                Console.WriteLine("[1] Lägg till ett föremål");
                Console.WriteLine("[2] Skriv ut innehållet");
                Console.WriteLine("[3] Rensa innehållet");
                Console.WriteLine("[4] Avsluta");
                Console.WriteLine(); //skapa lite utrymme

                //skapar menyvariabeln och läser in den
                Console.WriteLine("Välj från meny: ");
                int menyVal = Convert.ToInt32(Console.ReadLine());


                //vi skapar switch sats för menyVal
                switch (menyVal)
                {
                    case 1:
                        Console.WriteLine("Var god och skriv föremålet du ska lägga till: ");
                        myStuff = Console.ReadLine();
                        Console.WriteLine("Du har lagt in {0}", myStuff);
                        //lägger till denna för att se innehållet eftersom console clear tar bort allt
                        Console.WriteLine("Tryck valfri knapp för att gå vidare: ");
                        Console.ReadKey();
                        break;
                    case 2:
                        //visar
                        Console.WriteLine("Ryggsäcken innehåller: - {0}", myStuff);
                        //lägger till denna för att se innehållet eftersom console clear tar bort allt
                        Console.WriteLine("Tryck valfri knapp för att gå vidare: "); 
                        Console.ReadKey();
                        break;
                    case 3:
                        //skriver ut den sparade variabel och nollställer den använder readkey så att man ser meddelandet innan clear tar bort det
                        Console.WriteLine("{0} kastas, tryck valfri knapp för att gå vidare: ", myStuff);
                        Console.ReadKey();
                        myStuff = "";
                        break;
                    case 4:
                        //ändrar variabeln för loopen för att hoppa av loopen
                        killWhile = false;
                        break;

                    default:
                        //vid ogiltig siffra
                        Console.WriteLine("Var god och ange giltiga val från menyn");
                        Console.WriteLine("Tryck valfri knapp för att gå vidare: ");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
