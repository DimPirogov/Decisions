using System;
using System.Collections.Generic;

namespace ListorOchVektorer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> intVektorLista = new List<int[]>();
            // Äpplen Påron Kiwifrukter
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("\n\tSkriv [1] för att spara värden" +
                    "\n\tSkriv [2] för att visa värden" +
                    "\n\tSkriv [3] för att avsluta program");
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                switch (menyVal)
                {
                    case 1:
                        int[] antalFrukter = new int[3];
                        Console.WriteLine("\n\tSkriv in antalet Äpplen: ");
                        Int32.TryParse(Console.ReadLine(), out antalFrukter[0]);
                        Console.WriteLine("\tSkriv in antalet Päron: ");
                        Int32.TryParse(Console.ReadLine(), out antalFrukter[1]);
                        Console.WriteLine("\tSkriv in antalet Kiwifrukter: ");
                        Int32.TryParse(Console.ReadLine(), out antalFrukter[2]);

                        intVektorLista.Add(antalFrukter);

                        Console.WriteLine("\n\tDina frukter har sparats!");
                        break;

                    case 2:
                        /*for (int i = 0; i < intVektorLista.Count; i++)
                        {
                            Console.WriteLine("\n\t-------------------------");
                            Console.WriteLine("\tOrdernummer: " + (i+1));
                            Console.WriteLine("\tÄpplen: " + intVektorLista[i][0]);
                            Console.WriteLine("\tPäron: " + intVektorLista[i][1]);
                            Console.WriteLine("\tKiwifrukter" + intVektorLista[i][2]);
                            
                        }*/
                        int räknare = 1;
                        foreach (int[] fruktVektor in intVektorLista)
                        {
                            Console.WriteLine("\n\t-------------------------");
                            Console.WriteLine("\tOrdernummer: " + räknare);
                            räknare++;
                            Console.WriteLine("\tÄpplen: " + fruktVektor[0]);
                            Console.WriteLine("\tPäron: " + fruktVektor[1]);
                            Console.WriteLine("\tKiwifrukter: " + fruktVektor[2]);
                        }
                        break;

                    case 3:
                        isRunning = false;
                        break;
                                    
                    default:
                        Console.WriteLine("\n\tDu måste skriva antingen 1, 2 eller 3!");
                        break;
                }
                Console.WriteLine("\n\tTryck ENTER för att återgå!");
                Console.ReadLine();                

            }

        }
    }
}
