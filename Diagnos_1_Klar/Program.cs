using System;
using System.Collections.Generic;
/*
* 
*                              Det här är ett exempel på hur vi skulle kunna utveckla programmet utifrån den grundläggande klassen.
*                              Här under står några exempel på hur de första fyra frågorna kan besvaras;
*                              
*                              1.
*                              Bil nyBil = new Bil("ABC123","Volvo",1991,false);
*                              
*                              2.
*                              Console.WriteLine(nyBil);
*                              
*                              3.
*                              nyBil.Årtal = 1997;
*                              
*                              4.
*                              Bil gammalBil = new Bil("DEF456","Toyota","1985",true)
*                              if(nyBil.Årtal < gammalBil.Årtal)
*                              {
*                                   Console.WriteLine(nyBil);
*                              }
*                              else
*                              {
*                                   Console.WriteLine(gammalBil);
*                              }
* 
*/

namespace Diagnos_1_Klar
{

    class Bil
    {
        public string RegistreringsNummer;  // Här sparas varje bils registreringsnummer
        public string Tillverkare;          // Här sparas varje bils tillverkare
        public int Årtal;                   // Här sparas varje bils tillverkningsår
        public bool Besiktad;               // Här sparas information huruvida bilen är besiktad

        public Bil(string _registrering, string _tillverkare, int _årtal, bool _besiktad) // Här startar bilens konstruktor
        {
            RegistreringsNummer = _registrering;          // Mottaget registreringsnummer tilldelas till objektets registreringsnummer
            Tillverkare = _tillverkare;                   // Mottaget tillverkare tilldelas till objektets tillverkare
            Årtal = _årtal;                               // Mottaget årtal tilldelas till objektets årtal
            Besiktad = _besiktad;                         // Mottagen besiktningsinformation tilldelas till objektets besiktning
        }

        public override string ToString() // Här börjar Bilklassens ToString. Dess standardiserade utskrift
        {
            if (Besiktad)                                                // En utskrift om bilen är besiktad

                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                + "\n\t\t" + RegistreringsNummer
                + "\n\t\tBesiktad";

            else
                // En utskrift om bilen är obesiktad
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"
                + "\n\t\t" + RegistreringsNummer
                + "\n\t\tObesiktad";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;                                                  // Här deklarerar vi variabeln som styr vår huvudloop
            List<Bil> bilLista = new List<Bil>();                                   // En lista som innehåller alla Bil-objekt
            while (isRunning)                                                       // Här startar vår while-loop
            {
                Console.Clear();                                                    // Rensa ut konsolfönstret
                Console.ForegroundColor = ConsoleColor.White;                       // Ändrar textfärgen
                Console.WriteLine("\n\n\t * * * * * * * * * * * * * * * *"          // Skriver ut huvudmenyn
                + "\n\t * Välkommen till Bilregistret *"
                + "\n\t * * * * * * * * * * * * * * * *"
                + "\n\n\t [1] Registrera ny bil"
                + "\n\t [2] Se alla registrerade bilar"
                + "\n\t [3] Importera bil"
                + "\n\t [4] Avsluta");
                Console.ResetColor();                                               // Återställer färgen
                if (Int32.TryParse(Console.ReadLine(), out int resultat))           // Tar in användarens menyval
                {
                    switch (resultat)                                               // Selektion med switch
                    {
                        case 1:                                                     // Menyval 1
                            string registreringsNummer = "";                        // Initierar registreringsplåt, tillverkare och besiktad-variablerna
                            string tillverkare = "";
                            int årtal = 0;
                            bool besiktad = false;

                            while (registreringsNummer.Length != 6)                 // Startar en loop så länge registreringsnummer inte är 6 symboler
                            {
                                Console.Clear();                                    // Rensar konsolfönstret
                                Console.ForegroundColor = ConsoleColor.White;       // Ändrar textfärg
                                Console.WriteLine("\n\n\t * Då börjar vi med att välja bilens registreringsnummer. Var god skriv in 6 symboler *"); // Instruktion till användaren
                                Console.ResetColor();                               // Nollställer textfärgen
                                Console.Write("\t * ");                             // Skjuter fram textraden
                                registreringsNummer = Console.ReadLine().ToUpper(); // Tar in användarens registreringsnummer, gör om det till stora symboler
                                if (registreringsNummer.Length != 6)                // Om användaren inte skriver in en giltig mängd symboler
                                    Felmeddelande("Registrering sker med 6 symboler, utan mellanslag"); // Kallar vi på felmeddelande
                            }



                            Console.ForegroundColor = ConsoleColor.White;           // Ändrar textfärg
                            Console.WriteLine("\n\n\t * Vilken tillverkare har bilen? *"); // Instruktion till användaren
                            Console.ResetColor();                                   // Nollställer färg
                            Console.Write("\t * ");                                 // Skjuter fram raden
                            tillverkare = Console.ReadLine().ToUpper();             // Tar in användarens tillverkare, gör om det till stor text
                            if (tillverkare == "")                                  // Om användaren inte har skrivit in något...
                                tillverkare = "OKÄND";                              // Så blir tillverkaren "OKÄND"



                            while (årtal < 1900)                                    // En ny loop börjar, och fortsätter så länge "årtal" är mindre än 1900
                            {
                                Console.ForegroundColor = ConsoleColor.White;       // Ändrar textfärg
                                Console.WriteLine("\n\n\t * Var god skriv in året då bilen tillverkades *");    // Instruktion till användaren
                                Console.ResetColor();                               // Nollställer färg
                                Console.Write("\t * ");                             // Skjuter fram raden
                                if (Int32.TryParse(Console.ReadLine(), out årtal))  // Konverterar användarens inmatning till heltal
                                {
                                    if (årtal < 1900 || årtal > DateTime.Now.Year)  // Om användarens tal är mindre än 1900 och högre än nuvarande år
                                        Felmeddelande("Måste välja mellan 1900 till i år"); // Anropa felmeddelande
                                }
                            }


                            string input = "";                                      // Initierar en tom strängvariabel
                            while (input == "")                                     // Så länge strängvariabeln är tom
                            {
                                Console.ForegroundColor = ConsoleColor.White;       // Ändrar textfärg
                                Console.WriteLine("\n\n\t * Är bilen besiktad? (Ja / Nej) *"); // Ger användaren instruktioner
                                Console.ResetColor();                               // Nollställer textfärg
                                Console.Write("\t * ");                             // Skjuter fram raden
                                input = Console.ReadLine();                         // Användaren skriver sitt val
                                if (input.Length > 0)                                // Om användaren inte har "lämnat in blankt"
                                {
                                    if (input[0] == 'j' || input[0] == 'J')         // Om användarens första bokstav i input börjar på "j" eller "J"
                                    {
                                        besiktad = true;                            // Besiktad blir sann
                                        Console.WriteLine("\n\n\t * Noterat - Bilen är besiktad. * ");      // Informerar användaren
                                    }
                                    else if (input[0] == 'n' || input[0] == 'N')    // Om användarens första input börjar på "n" eller "N"
                                    {
                                        besiktad = false;                           // Besiktad blir falsk
                                        Console.WriteLine("\n\n\t * Noterat - Bilen är inte besiktad. *");  // Informerar användaren
                                    }
                                    else
                                    {                                               // Om användarens första bokstav i input börjar på "n" eller "N"
                                        input = "";
                                        Felmeddelande("Du behöver skriva in Ja eller Nej"); // Skriv ut felmeddelande
                                    }
                                }
                                else                                                // Om användaren har lämnat in blankt
                                {
                                    Felmeddelande("Du måste göra ett val");         // Skriv ut ett felmeddelande
                                }

                            }


                            Bil nyBil = new Bil(registreringsNummer, tillverkare, årtal, besiktad);
                            // Skapar en ny bil med registreringsnummer, tillverkare, årtal och besiktningsinformation
                            bilLista.Add(nyBil);                                    // Lägger till bilen till listan med bilar


                            break;





                        case 2:                                                     // Menyval 2
                            if (bilLista.Count > 0)                                  // Om listan med bilar inte är tom
                            {
                                Console.Clear();                                    // Rensar konsolfönstret
                                Console.ForegroundColor = ConsoleColor.White;       // Ändrar textfärg
                                foreach (Bil item in bilLista)                       // För varje bil i vår lista med bilar...
                                {
                                    Console.WriteLine(item);                        // ...så ska vi skriva ut bilens standardiserade utskrift (ToString)
                                }
                                Console.WriteLine("\n\n\t * " + bilLista.Count + " bilar är totalt registrerade. * ");  // Informerar användaren
                                Console.ResetColor();                               // Nollställ färgen
                                Console.ReadLine();                                 // Stannar upp programmet en stund
                            }
                            else
                            {                                                       // Om listan med bilar är tom
                                Felmeddelande("Det finns inga registrerade bilar i dagsläget"); // Skriv ut felmeddelande
                            }
                            break;





                        case 3:
                            Random newRandom = new Random();                        // Skapar ett Random-objekt

                            string[] slumpABC = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö" };
                            // Sätter alla möjliga bokstäver i en vektor
                            string[] slumpTillverkare = new string[] { "Toyota", "Volkswagen", "General Motors", "Hyundai", "Ford", "Nissan", "Honda", "Fiat Chrysler", "Renault", "Volvo" };
                            // Skapar en lista med vanliga tillverkare
                            Console.Clear();                                        // Rensar konsolfönstret
                            Console.ForegroundColor = ConsoleColor.White;           // Ändrar textfärgen
                            Console.WriteLine("\n\n\t * Hur många bilar vill du importera? *"); // Frågar användaren hur många bilar de vill importera
                            Console.Write("\t * ");                                 // Skjuter fram textraden
                            if (Int32.TryParse(Console.ReadLine(), out int antalBilar)) // Kollar om användaren skriver in en giltig siffra
                            {
                                if (antalBilar > 0)                                  // Kollar om antalet bilar importerade är över noll
                                {
                                    for (int i = 0; i < antalBilar; i++)             // En loop som upprepas för varje bil som ska importeras
                                    {
                                        string register_slump = "";                 // Initierar en variabel för registreringsnumret
                                        for (int a = 0; a < 3; a++)                  // Loopar tre gånger
                                        {
                                            register_slump += slumpABC[newRandom.Next(0, slumpABC.Length)]; // Lägger till en slumpad bokstav till registreringsnumret
                                        }
                                        for (int b = 0; b < 3; b++)                  // En till loop, tre gånger
                                        {
                                            register_slump += newRandom.Next(0, 10);// Lägger till tre slumpade siffror mellan 0-9
                                        }

                                        string tillverkare_slump = slumpTillverkare[newRandom.Next(0, slumpTillverkare.Length)];
                                        // Väljer en slumpvald tillverkare, från strängvektorn med tillverkare

                                        int årtal_slump = newRandom.Next(1920, (DateTime.Now.Year + 1));
                                        // Väljer ett tal mellan 1920 till nuvarande år.

                                        bool besiktad_slump = false;                // Initierar besiktningsvariabel
                                        if (newRandom.Next(0, 2) == 0)                // Slumpar fram värde 0 eller 1, och kollar om värdet blir 0
                                        {
                                            besiktad_slump = true;                  // Om värdet blir 0 är bilen obesiktad. 50/50
                                        }
                                        bilLista.Add(new Bil(register_slump, tillverkare_slump, årtal_slump, besiktad_slump));
                                        // Lägger till en ny bil med alla slumpade värden

                                    }
                                    Console.WriteLine("\t * " + antalBilar + " bilar registrerade *");  // Informerar användaren om antalet bilar totalt
                                    Console.ResetColor();                           // Nollställer textfärg
                                    Console.ReadLine();                             // Stannar upp programmet lite
                                }
                                else
                                {                                                   // Om användaren vill generera 0 bilar
                                    Console.WriteLine("\t * Återvänder till huvudmeny *");  // Informerar användaren
                                    Console.ResetColor();                           // Nollställer textfärg
                                    Console.ReadLine();                             // Stannar upp programmet
                                }
                            }
                            else
                            {                                                       // Om användaren inte skriver in en giltig siffra                                          
                                Felmeddelande("Du har inte valt ett giltigt antal!");   // Skriver ut felmeddelande
                            }
                            break;





                        case 4:                                                     // Menyval 4
                            isRunning = false;                                      // Stänger av programmets huvudloop
                            break;
                    }
                }
                else
                {                                                                   // Om användaren skriver in ett ogiltigt menyval
                    Felmeddelande("Ogiltigt menyval");                              // Skriver ut felmeddelande
                }
            }
        }

        static void Felmeddelande(string kontext)                                   // Skapar en metod för felmeddelanden
        {
            Console.Clear();                                                        // Rensar konsolfönstret
            Console.ForegroundColor = ConsoleColor.Yellow;                          // Ändrar textfärg till gul
            Console.WriteLine("\n\n\t * " + kontext + " *");                        // Skriver ut det felmeddelande som metoden mottar
            Console.ResetColor();                                                   // Nollställer textfärg
            Console.WriteLine("\t * (Tryck ENTER för att fortsätta)");              // Informerar användaren
            Console.ReadLine();                                                     // Inväntar en enter-tryckning
        }
    }
}
