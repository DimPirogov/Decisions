using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp3
{
    class Dices
    {
        // detta är en statisk metod med en int som ett returvärde
        // metoden tar en parameter i form av ett random objekt av
        // randomklassen
        // vi utökar med en parameter till för antal sidor på tärningar
        static int RullaTärning(Random slumpObjekt, int sidor)
        {
            // här ska du skapa kod som slumpar fram ett tal
            // mellan 1 och 6, så att metoden "rullar" en 6 sidig
            // tärning när vi kallar på den
            // vi använder parameter sidor för att simulera antal sidor på tärningar
            int slump = slumpObjekt.Next(1, sidor + 1);
            // metoden ska sedan returnera det rullade värdet
            return slump;
        }

        static void Main()
        {
            Random slump = new Random(); // Skapar en instans av klassen Random för vårt slumptal
            List<int> tärningar = new List<int>(); // listan för att spara våra rullade tärningar
            // jag skapar antal och sidor variabler här ute för att kunna spara dem och ange deras värde i Fall 2
            int antal = 0;
            int sidor = 0;

            Console.WriteLine("\n\tVälkommen till tärningsgeneratorn!");

            bool kör = true;

            while (kör)
            {
                Console.WriteLine("\n\t[1] Rulla tärning\n" +
                    "\t[2] Kolla vad du rullade\n" +
                    "\t[3] Sök tärningskast\n" +
                    "\t[4] Sortera tärningskast\n" +
                    "\t[5] Rensa tärningar\n" +
                    "\t[6] Avsluta");
                Console.Write("\tVälj: ");
                int val;
                int.TryParse(Console.ReadLine(), out val);

                switch (val)
                {
                    case 1:
                        Console.Write("\n\tHur många tärningar vill du rulla: ");
                        bool inmatning = int.TryParse(Console.ReadLine(), out antal);
                        //vi skapar en ny inmatning där man väljer sidor på tärningar
                        Console.Write("\n\tHur många sidor på tärningar vill du rulla: ");
                        bool inmatning2 = int.TryParse(Console.ReadLine(), out sidor);

                        if (inmatning && inmatning2)
                        {
                            for (int i = 0; i < antal; i++)
                            {
                                // här kallar vi på metoden RullaTärning
                                // och sparar det returnerade värdet i 
                                // listan tärningar och skickar antal sidor på tärningar
                                tärningar.Add(RullaTärning(slump, sidor));
                            }
                        }
                        break;

                    case 2:
                        int sum = 0; // Skapar en int som ska innehålla medelvärdet av alla tärningsrullningar.
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            // vi lägger till antal tärningar och antal sidor på tärningarna
                            Console.WriteLine("\n\tDu rullade " + antal + " tärningar med " + sidor + " sidor: ");
                            foreach (int tärning in tärningar)
                            {
                                //vi summerar varje tärningkasts resultat i listan tärningar in i sum variabel
                                sum += tärning;
                                Console.WriteLine("\tDu rullade \t" + tärning);
                            }
                            Console.WriteLine("\n\tMedelvärdet på alla tärningsrull: " + sum/tärningar.Count); // Här ska medelvärdet skrivas ut
                        }
                       break;

                    // sökning av kast(linjär)
                    case 3:
                        // vi kontrollerar att det finns en sparad kastning
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            // vi ber att ange kast vi vill söka
                            Console.Write("\n\tAnge tärningskast du vill söka: ");
                            bool inMat = int.TryParse(Console.ReadLine(), out int sökKast);
                            if (inMat)
                            {
                                // vi använder for-loop iställer för foreach-loop för att lättare komma åt element/index nummer på elementet i listan
                                for(int i = 0; i < tärningar.Count; i++)
                                {
                                    if (tärningar[i] == sökKast)
                                    {
                                        // Vi skriver ut första träffen med platsen i listan. 
                                        Console.WriteLine("\tTärning nr {0} kastade {1}", i + 1, sökKast);
                                        break;
                                    }
                                }
                            }
                        }
                        break;

                    // häs sorterar vi elementerna i listan (bubbelsökning)
                    case 4:
                        // vi kontrollerar att det finns en sparad kastning
                        if (tärningar.Count <= 0)
                        {
                            Console.WriteLine("\n\tDet finns inga sparade tärningsrull! ");
                        }
                        else
                        {
                            // vi ska igenom listan lika många gånger som det finns element i listan minus en
                            int max = tärningar.Count - 1;
                            // yttre loopen
                            for (int i = 0; i < max; i++)
                            {
                                //nu går vi igenom element per element
                                int  nrKvar = max - i; //elementen kvar att sortera
                                for (int j = 0; j < nrKvar; j++)
                                {
                                    if (tärningar[j] > tärningar[j + 1])    //om elementet till höger är mindre då byts platsen
                                    {
                                        // för att kunna byta plats vi sparar första värdet i en temporär variabel
                                        int temp = tärningar[j];
                                        tärningar[j] = tärningar[j + 1];
                                        tärningar[j+1] = temp;
                                        // intellisense visar det här => (tärningar[j+1],tärningar[j]=tärningar[j],tärningar[j+1])
                                    }
                                }
                            }
                            Console.WriteLine("\n\tNya listan kan ses med hjälp av val [2]");
                            Thread.Sleep(1000);
                        }
                        break;

                    //Vi rensar tärningar
                    case 5:
                        tärningar.Clear();
                        Console.WriteLine("\n\tTärningar rensade!");
                        Thread.Sleep(1000);
                        break;
                    case 6:
                        Console.WriteLine("\n\tTack för att du rullade tärning!");
                        Thread.Sleep(1000);
                        kör = false;
                        break;
                    default:
                        Console.WriteLine("\n\tVälj 1-4 från menyn.");
                        break;
                }
            }
        }
    }
}
