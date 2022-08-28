using System;

namespace Rygga
{
    internal class Rygga
    {
        static void Main(string[] args)
        {
            //skapar bool variabel för while loopen
            bool mainLoop = true;
            //vi skapar föremål vektorn.
            string[] items = new string[5];

            //skapar huvud loopen
            while (mainLoop)
            {
                //vi rensar consol fönstret
                Console.Clear();
                //Vi skapar huvudmeny
                Console.WriteLine("\n\t Välkommen till Ryggsäcken!");
                Console.WriteLine("\n\n\t\t [1] Lägg till 5 föremål");
                Console.WriteLine("\n\t\t [2] Skriv ut alla föremål");
                Console.WriteLine("\n\t\t [3] Sök i ryggsäcken");
                Console.WriteLine("\n\t\t [4] Rensa innehållet");
                Console.WriteLine("\n\t\t [5] Avsluta programmet");
                //skapar variabel för meny val utanför
                int menyVal;
                //vi felbehandlar användarens inmatning med en whileloop av TryParse
                while (!Int32.TryParse(Console.ReadLine(), out menyVal)) ;
                //skapar switch case för menyval
                switch (menyVal)
                {
                    //fall 1 för att skriva in föremål
                    case 1:
                        Console.WriteLine("\n\t\t Skriv in dina föremål! ");
                        for (int i = 0; i < items.Length; i++)
                        {
                            //vi loopar igenom elementen för att skriva in dem
                            Console.WriteLine("\n\t\t Ange föremål nr {0}: ", i + 1 );
                            items[i] = Console.ReadLine();
                        }
                        //vi pausar här så att vi hinner se resultat
                        Console.ReadLine();
                        break;
                    //fall 2 för att skriva ut föremål
                    case 2:
                        //vi loopar igenom elementen av items för att skriva ut dem
                        for (int i = 0; i < items.Length; i++)
                        {
                            Console.WriteLine(items[i]);
                        }
                        //vi pausar här så att vi hinner se resultat
                        Console.ReadLine();
                        break;
                    //fall 3 för sökningen
                    case 3:
                        Console.WriteLine("\n\t\t Var god och ange föremålet för sökning: ");
                        //vi läser in föremålet för sökningen
                        string item = Console.ReadLine();
                        //vi skapar en variabel för att se om sökningen var tom
                        bool fynd = false;  
                        //vi loopar igenom elementen för sökningen och gör dem till små bokstäver
                        for (int i = 0; i < items.Length; i++)
                        {
                            if(items[i].ToLower() == item.ToLower())
                            {
                                //vi listar ut namnet på föremålet som söktes och platsen den ligger i ryggsäcken och avbryter loopen
                                Console.WriteLine("\n\t\t {0} hittades på plats nr {1}", item , i + 1 );
                                fynd = true;
                                break;
                            }
                        }
                        //om fynd är fortfarande falsk så får vi detta meddelande
                        if(fynd == false)
                        {
                            //meddelar om att sökningen misslyckades och anger sökföremålet
                            Console.WriteLine("\n\t\t Vi har inte hittat {0} i ryggsäcken", item);
                        }
                        //vi pausar här så att vi hinner se resultat
                        Console.ReadLine();
                        break;
                    //fall 4 för att rensa
                    case 4:
                        //vi loopar igenom elementen av items för att rensa dem eller ange tom sträng
                        for (int i = 0; i < items.Length; i++)
                        {
                            items[i] = "";
                        }
                        Console.WriteLine("\n\t\t Ryggsäcken är tom!");
                        //vi pausar här så att vi hinner se meddelandet
                        Console.ReadLine();
                        break;
                    //här avslutar vi programmet, jag lägger till ett meddelande att vi avslutar 
                    case 5:
                        Console.WriteLine("\n\t\t Vi avslutar!");
                        //vi pausar här så att vi hinner se meddelandet
                        Console.ReadLine();
                        //main loopens villkor blir falskt som gör att den avslutas
                        mainLoop = false;
                        break;
                    //fallet för alla andra sifferval vid inmatning av menyVal
                    default:
                        Console.WriteLine("\n\n\t\t Var god ange [1] till [5}!");
                        //vi pausar här så att vi hinner se meddelandet
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
