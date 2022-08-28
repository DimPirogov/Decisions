using System;
using System.Collections.Generic;
using System.Threading;

namespace BloggEx
{
    internal class Blogg
    {
        /*
         * När jag började med sortering och binärsökning av datum, förstod jag att jag skulle ha skapat
         * en ytterligare array element för att spara på inläggsnummer
         * då det är sent och det skulle innebära många ändringar och försena arbetet
         * har jag låtit det vara  :(
         */
        static void Main(string[] args)
        {
            // skapar listan med sträng vektorn, listan innehåller vektorer där varje string vektor är ett inlägg
            List<string[]> bloggInlaggLista = new List<string[]>();
            bool isRunning = true;  // skapar boolean för while-loopen
            // skapar huvudmenyns while-loopen
            while (isRunning)
            {
                Console.Clear();    // vi rensar skärmen
                // börjar med att skapa huvudmenyn
                Console.WriteLine("\n\tVälkommen till blogg skapandet!" +
                    "\n\tTryck siffran i hakparentes för att välja: " +
                    "\n\n\t[1] Skriv ut alla inlägg" +
                    "\n\t[2] För nya inlägg" +
                    "\n\t[3] Ange sökord för att söka igenom Titlar och inlägg" +
                    "\n\t\t och att radera inlägg" +
                    "\n\t[4] Datumsök inlägg(just nu stämmer inte inläggsnummren)" +
                    "\n\t[5] Avsluta programmet");
                // läser in inmatningen med tryparse som felhantering
                Int32.TryParse(Console.ReadLine(), out int menyVal);
                //skapar switch för hela programmet
                switch (menyVal)
                {
                    case 1:
                        //kontrollerar att det finns inlägg att skriva ut
                        if (bloggInlaggLista.Count <= 0)
                        {
                            Console.WriteLine("\n\tTyvärr, det finns inga inlägg att skriva ut!" +
                                "\n\n\tSkapa inlägg i menyn nr 2!");
                            MenyAvslut();
                        }
                        else
                        {
                            Utskrift(bloggInlaggLista); //skriver ut listan
                            MenyAvslut();   // pausar det som finns på skärmen
                        }
                        break;
                    case 2:
                        // skapar ny inlägg med hjälp av sträng vektor med 3 element
                        Console.WriteLine("\n\tSkriv in rubriken: "); 
                        string[] inlagg = new string[3];    // skapar ett nytt inlägg vektor med 3 element
                        inlagg[1] = Console.ReadLine(); //läser in rubrik
                        DateTime datumStamp = DateTime.Now; // skapar datumstämpel just efter att man är klar med rubriken
                        inlagg[0] = datumStamp.ToString();  // lägger in datumstämpel i 1a elementet som sträng

                        Console.WriteLine("\n\tSkriv in blogginlägget: ");
                        inlagg[2] = Console.ReadLine(); // läser in själva bloggen

                        bloggInlaggLista.Add(inlagg);// sparar inlägger in i listan
                        MenyAvslut();
                        break;
                    case 3:
                        //kontrollerar att det finns inlägg att skriva ut
                        if (bloggInlaggLista.Count <= 0)
                        {
                            Console.WriteLine("\n\tTyvärr, det finns inga inlägg att söka i!" +
                                "\n\n\tSkapa inlägg i menyn nr 2!");
                            MenyAvslut();
                        }
                        else
                        {
                            Console.WriteLine("\n\tAnge ord för sökning i inläggen eller rubrik början: ");
                            string sokOrd = Console.ReadLine(); // läser in sökningen
                            if (sokOrd.Length <= 0) //vi ser till att det finns något att söka på
                                sokOrd = "a";
                            int raknare = 1;    // skapar räknare för att hålla reda på elementen
                            int traff = 0;  // skapar räknare för att hålla reda på om det blev träffar
                            foreach (string[] ord in bloggInlaggLista)
                            {
                                // om titel är likadan då visar vi upp inlägget
                                if(sokOrd.ToLower() == ord[1].ToLower())
                                {
                                    Console.WriteLine("\t\nHittade {1} i titel på inlägget nr {0}", raknare, sokOrd);
                                    UtskriftMeddelande(bloggInlaggLista[raknare - 1], raknare); // tillkallar Utskriftsmetod för enstaka inlägg
                                    traff++;
                                }
                                // vi söker på början av inläggen som är lika lång som själva sökningen
                                else if (sokOrd.ToLower() == ord[2].ToLower())
                                {
                                    Console.WriteLine("\t\nHittade {1} i inlägget nr {0}", raknare, sokOrd);
                                    UtskriftMeddelande(bloggInlaggLista[raknare - 1], raknare);
                                    traff++;
                                }
                                // vi söker på början av inläggen när dem är längre
                                else if (ord[2].Length > sokOrd.Length)
                                {
                                    // när sökordet är längre än själva inlägget då gå går det att använda remove()
                                    if (sokOrd.ToLower() == ord[2].ToLower().Remove(sokOrd.Length))
                                    {
                                        Console.WriteLine("\t\nHittade {1} i inlägget nr {0}", raknare, sokOrd);
                                        UtskriftMeddelande(bloggInlaggLista[raknare - 1], raknare);
                                        traff++;
                                    }
                                }
                                raknare++;
                            }
                            // vid misslyckad sökning där träff är fortfarande 0 vi skriver in antal sökningar
                            // en i titel och en i inlägget och sökordet och inga träffar
                            if(traff <= 0)
                                Console.WriteLine("\n\tSökningen på {1} gav inga träffar. Vi har sökt igenom {0} gånger", raknare * 2, sokOrd);
                            RaderaInlagg(bloggInlaggLista);
                            MenyAvslut();
                        }
                        break;
                    case 4:
                        // datum sökning anger första träffen på datumet
                        // vi kontrollerar att det finns inlägg i listan
                        if (bloggInlaggLista.Count <= 0)
                        {
                            Console.WriteLine("\n\tTyvärr, det finns inga inlägg att söka i!" +
                                "\n\n\tSkapa inlägg i menyn nr 2!");
                            MenyAvslut();
                        }
                        else
                        {
                            DateTime datumNu = DateTime.Now;    // vi skapar dagens datum
                            bool inläsning = true;   //vi skapar en bool för while-loop för datumsökning
                            int aret = 0;   // initialisierar datum delar för att kunna komma åt efter inläsningen
                            int manad = 0;
                            int dagen = 0;
                            while (inläsning)   // while-loop för att få rätt inmatning
                            {
                                Console.WriteLine("\n\tAnge Året att söka: ");  // vi meddelar och efterfrågar året
                                Int32.TryParse(Console.ReadLine(), out aret); // läser in året
                                if (aret <= datumNu.Year && aret > 1950)
                                    inläsning = false;  // vid giltig svar vi avbryter
                                else
                                    Console.WriteLine("\n\tAnge giltig år!");
                            }
                            inläsning = true;   //ställer om inläsning
                            while (inläsning)
                            {
                                Console.WriteLine("\n\tAnge Månad att söka: "); // vi meddelar och efterfrågar månad
                                Int32.TryParse(Console.ReadLine(), out manad); // läser in månad
                                if(manad <= 12 && manad >= 1)
                                    inläsning = false;  // vid giltig svar vi avbryter
                                else
                                    Console.WriteLine("\n\tAnge giltig månad!");
                            }
                            inläsning = true;
                            while (inläsning)
                            {
                                Console.WriteLine("\n\tAnge Dagen att söka: ");
                                Int32.TryParse(Console.ReadLine(), out dagen); // läser in året
                                if (dagen <= 31 && dagen >= 1)
                                    inläsning = false;  // vid giltig svar vi avbryter
                                else
                                    Console.WriteLine("\n\tAnge giltig dagnummer!");
                            }
                            // skapar sökningsdatum
                            DateTime sökDatum = DateTime.Parse(aret.ToString() + "-" + manad.ToString() + "-"
                                + dagen.ToString());
                            List<string[]> bloggInlaggListaKopia = new List<string[]>();// skapar en kopia av listan
                            bloggInlaggListaKopia = bloggInlaggLista;
                            // sorterar inläggen i datum ordning
                            // går igenom varje sträng element i listan
                            for (int i = 0; i < bloggInlaggListaKopia.Count - 1; i++)
                            {
                                // här går vi igenom varje datum i inläggen och flyttar på dem
                                for (int j = 0; j < bloggInlaggListaKopia.Count - 1 - i; j++)
                                {
                                    // jämför datumen
                                    if (DateTime.Parse(bloggInlaggListaKopia[j][0]) > DateTime.Parse(bloggInlaggListaKopia[j + 1][0]))
                                    {
                                        // byter plats på inläggen
                                        string[] temp = bloggInlaggListaKopia[j];
                                        bloggInlaggListaKopia[j] = bloggInlaggListaKopia[j + 1];
                                        bloggInlaggListaKopia[j + 1] = temp;
                                    }
                                }
                            }
                            // binärsökning med hjälp av kopia på listan
                            int first = 0;
                            int last = bloggInlaggLista.Count -1; // antal inlägg
                            while(first <= last)    // så länge det finns mer element än 
                            {
                                // räknar ut mittnummer av element listan
                                int mid = (first + last) / 2;
                                // jämför sökdatum med datum i mitten genom att ta bort timmar, minuter och sekunder
                                if(DateTime.Parse(sökDatum.ToShortDateString()) > DateTime.Parse(DateTime.Parse(bloggInlaggListaKopia[mid][0]).ToShortDateString()))
                                    //om sökdatumet är mer än mittendatum då flyttar vi första till nästa efter mittendatum element
                                    first = mid + 1;
                                else if(DateTime.Parse(sökDatum.ToShortDateString()) < DateTime.Parse(DateTime.Parse(bloggInlaggListaKopia[mid][0]).ToShortDateString()))
                                    //om sökdatumer är mindre än mittendatum då flyttar vi sista till en innan mittendatum element
                                    last = mid - 1;
                                else
                                {   // här skriver vi ut när vi får träff
                                    Console.WriteLine("\n\tSkriver ut inlägget med samma datum, observera att inläggsnr är fel!");
                                    UtskriftMeddelande(bloggInlaggListaKopia[mid], mid);
                                    break;
                                }
                            }
                            if(first > last)    // utan träff på datum
                                Console.WriteLine("\n\tSökning på {0} misslyckades!", sökDatum);
                            MenyAvslut();   // vi fryser resultat på skärmen
                        }
                        break;
                    case 5:
                        Console.WriteLine("\n\tAvslutar programmet");
                        Thread.Sleep(2000);
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Ange val 1,2,3,4 eller 5!");
                        MenyAvslut();
                        break;
                }
            }
        }

        // skapar separat utskrift metod för hela listan
        static void Utskrift(List<string[]> bloggInlaggLista)
        {
            int raknare = 1; // för att hålla reda på elementen vi skapar en räknare
            //skapar en foreach-loop för utskrift av inlägg
            foreach (string[] meddelanden in bloggInlaggLista)
            {
                UtskriftMeddelande(meddelanden,raknare);
                raknare++;  // vi ökar raknare med 1 för att motsvara elementnummer
            }
        }

        // skapar en metod för ett inlägg i taget och skickar ett inlägg vektor och räknare
        static void UtskriftMeddelande(string[] inlagg, int raknare)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;  // färgar bokstäverna gult för lättare och bättre läsning
            Console.WriteLine("\n\t//////////////////////////////////////////////////////////");
            // skriver ut varje element i bloggInläggslistans vektorer
            Console.WriteLine("\n\tBlogginlägg nr {0}" +
                "\n\tDatum: {1}" +
                "\n\tRubrik: {2}" +
                "\n\n\t{3}", raknare, inlagg[0], inlagg[1], inlagg[2]);
            Console.ForegroundColor = ConsoleColor.Gray;    // återställer färgen
        }

        // skapar överlagrat metod för att radera inlägg
        // skickar en lista
        static List<string[]> RaderaInlagg(List<string[]> inlaggsLista)
        {
            if(inlaggsLista.Count > 0)  // vi kontrollerar att det finns inlägg
            {
                bool radera = true; //bool för while-loopen
                while (radera)
                {
                    //Console.Clear();
                    // efterfrågar om användaren vill radera inlägg
                    Console.WriteLine("\n\tVill du radera inlägg?" +
                    "\n\t Tryck [1] för 'ja' och [2] för 'nej'");
                    // läser in inmatningen med tryparse som felhantering
                    Int32.TryParse(Console.ReadLine(), out int raderaVal);
                    switch (raderaVal)
                    {
                        // val för att radera inlägg
                        case 1:
                            Console.WriteLine("\n\tAnge inläggets nummer för att radera: ");
                            Int32.TryParse(Console.ReadLine(), out int raderaInläggNr); // läser in nummer på inlägget att radera med felhantering
                            if (inlaggsLista.Count >= raderaInläggNr)   // Om inmatningen finns i listan
                            {
                                inlaggsLista.RemoveAt(raderaInläggNr - 1);  //vi tar bort inlägget ifrån listan med nummer minus ett
                                Console.WriteLine("\n\tInlägg nr {0} raderad", raderaInläggNr);
                            }
                            // om inmatningen finns inte som element i listan
                            else
                            {
                                Console.WriteLine("\n\tDet finns inga inlägg med detta nummer!");
                                MenyAvslut();
                            }
                            break;                            
                        case 2: // avsluta while-loopen när man väljer att inte radera
                            radera = false;
                            break;
                        default:    // när man matar in annat nummer än 1 eller 2
                            Console.WriteLine("\n\tAnge [1] eller [2]!");
                            MenyAvslut();
                            break;
                    }
                }
                return inlaggsLista;    //vi returnerar ändrad lista
            }
            else
            {
                //  när det inte finns inlägg
                Console.WriteLine("\n\tDet finns inga inlägg att radera!");
                return inlaggsLista;    //vi returnerar oförändrad lista
            }
        }

        static void MenyAvslut()    // flyttar ut menyavslut
        {
            Console.WriteLine("\n\n\tTryck enter för att återgå: ");    //vi uppehåller det som finns på skärmen
            Console.ReadKey();
        }
    }
}
