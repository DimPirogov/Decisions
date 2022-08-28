using System;

namespace Uppgift_4
{
    /*      Precis efter inklistring så uppvisas syntax fel på rad 27 (saknas plus tecken)

            Logiskt fel på rad 30 där man istället för att jämföra tal och speltal
            så tilldelar man speltals värde till tal variabel vilket inte fungerar inne
            i en IF villkorparantes där man läser av antingen falskt eller sant.

            I kommentarer står det att slumpat.Next() ska slumpa mellan 1 och 20 men det anges inte inne i parenteserna
            vi rättar till det till slumpat.Next(1, 20).

            WHILE loopen går aldrig igång eftersom den läser in falsk vi ändrar det till sant genom att ta bort "!" tecknet.

            Vi har ingen felhantering på tal inläsningen vilket gör att programmet kan krascha
            Vi skapar en Int32.tryParse där vi passar på och skapar int tal.

            Nu ser vi att det är 3 stycken IF satser nästintill varandra vilket är fel
            vi omvandlar den andra till ELSE IF och sista till ELSE för tillfället.

            IF och ELSE IF behöver inga klammerparantes däremot ELSE behöver det eftersom kodblocket består av mer än en rad
            så att spela ska tilldelas falsk värde och WHILE loopen avslutas.

            ELSE behöver inga villkor parentes vilka vi tar bort.

            Nu prövar vi köra.

            Programmet fungerar utan krasch däremot om man skriver in text istället för siffra
            så fortsätter programmet och skriver att siffra 0 är för litet vilket är missvisande.

            Vi nästlar in IF sats i en annan IF sats med TryParse som villkor och en ELSE sats där vi anvisar att skriva endast tal.    */
    class Slumpat
    {
        static void Main(string[] args)
        {
            // ny bool till en while loop för nya försök
            bool start = true;
            int totBestGuess = 0; // vi skapar variabel för att förvara totala bästa minsta gissningar

            // huvud while loop
            while (start)
            {
                // Vi kör allt på nytt så att alla variabler nollställs
                // Deklaration av variabler
                Random slumpat = new Random(); // skapar ett random objekt
                int speltal = slumpat.Next(1, 21); // anropar Next metoden för att skapa ett slumptal mellan 1 och 20
                bool spela = true; // bool variabel för att kontrollera om spelet ska fortsätta köras
                int gissningar = 0; // Variabel för att räkna antal gissninar

                while (spela)
                {
                    Console.Write("\n\tGissa på ett tal mellan 1 och 20: ");
                    // vi räknar på antal gissninar
                    gissningar++;
                    //bestGuess = (bestGuess > gissningar) ? gissningar : ;

                    if (Int32.TryParse(Console.ReadLine(), out int tal))
                    {
                        if (tal < speltal)
                            Console.WriteLine("\tDet inmatade talet " + tal + " är för litet, försök igen.");
                        else if (tal > speltal)
                            Console.WriteLine("\tDet inmatade talet " + tal + " är för stort, försök igen.");
                        else
                        {
                            // vi visar upp antal gissningar vid rätt svar
                            Console.WriteLine("\n\tGrattis, du gissade rätt! Antal gissningar är {0} gånger", gissningar);
                            // Vi kontrollerar värdet på bästa/minsta antal gissningar och ändrar den ifall den är större än nuvarande gissning
                            // samtidigt som vi kontrollerar att den är inte 0 som vid första gissning
                            if (totBestGuess == 0 || totBestGuess > gissningar)
                                totBestGuess = gissningar;
                            // vi visar upp bästa gissningar hittills
                            Console.WriteLine("\tMinsta antal gissningar hittills är {0}", totBestGuess);
                            // vi avslutar gissningens omgång
                            spela = false;
                        }
                    }
                    else
                        Console.WriteLine("\n\tDu måste skriva ett tal!");
                }
                // vi frågar användaren om den vill spela på nytt
                Console.WriteLine("\n\tVill du spela igen?\n\tTryck [1] för 'ja' eller valfri nummer för 'nej': ");
                // vi felhanterar inmatningen för att undvika krasch
                if (Int32.TryParse(Console.ReadLine(), out int vidare))
                {
                    // vid inmatning av 1 vi går vidare till början av första while loop
                    if (vidare == 1)
                        continue;
                    //vid all annan inmatning avslutas hela programmet
                    else
                        start = false;
                }
                else
                    Console.WriteLine("\n\tVar god och skriv in siffror");
            } 
        }
    }
}
