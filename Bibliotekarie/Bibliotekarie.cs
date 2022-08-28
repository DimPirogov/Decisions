using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarie
{

    class Program
    {
        static void Main(string[] args)
        {
            Biblioteket Centralen = new Biblioteket();  // vi skapar en instans av biblioteket lista, "Biblioteket i centrum"
            bool isRunning = true;  // bool för huvud while-loopen
            // List<Bok> bibliotek = new List<Bok>();  // skapar listan för alla böcker
            while (isRunning)
            {   // skapar huvudmenyn
                Console.Clear();    // rensar consolen
                Console.ForegroundColor = ConsoleColor.Yellow;  // ändrar färg till gul
                Console.WriteLine("\n\n\t\tVälkomna till biblioteket!" +   //skapar huvudmenynssträng
                    "\n\t\t[1] Registrera ny bok" +
                    "\n\t\t[2] Visa böcker" +
                    "\n\t\t[3] Sökningar" +
                    "\n\t\t[4] Radera alla böcker" +
                    "\n\t\t[5] Avsluta");
                Console.ResetColor();   // återställer färgen
                Console.Write("\t\t");    // testar skjuta fram inmatningen
                if (Int32.TryParse(Console.ReadLine(), out int val))  // läser in valet med tryparse felhantering
                {
                    switch (val)
                    {
                        case 1:
                            string _titel = ""; // börjar med att initiera temporära variabler för att sparas i klassernas instanser
                            string _skribent = "";
                            int _utgivninsar = 0;
                            Console.Write("\n\t\tAnge titel: ");
                            Console.Write("\t\t");    // testar skjuta fram inmatningen
                            _titel = Console.ReadLine(); // läser in titel variabel

                            Console.Write("\n\t\tAnge författarens namn: ");
                            Console.Write("\t\t");    // testar skjuta fram inmatningen
                            _skribent = Console.ReadLine(); // läser in titel variabel

                            bool utgivInmatning = true; // bool för inmatning av utgivningsår while-loop
                            while (utgivInmatning)
                            {
                                Console.Write("\n\t\tAnge utgivningårtalet");    // vi söker utgivningåret
                                Console.Write("\t\t");    // testar skjuta fram inmatningen
                                if (Int32.TryParse(Console.ReadLine(), out int årtal))  // vid giltig inmatning
                                {
                                    if (årtal <= DateTime.Now.Year)  // så länge ingen framtid
                                    {
                                        _utgivninsar = årtal;   // vi spara utgivningsår
                                        utgivInmatning = false; // vi abryter loopen
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\t\tAnge giltig årtal fram till i år.");   // ingen framtid
                                        MenyAvslut();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\n\t\tAnge giltig årtal");   // vid felinmatning
                                    MenyAvslut();
                                }
                            }

                            bool typInmatning = true; // skapar bool för while-loop för val av typ
                            while (typInmatning)
                            {
                                Console.WriteLine("\n\t\tVälj typ av bok: [1] Roman, [2] Novellsamling, [3] Tidskrift");    // skapar en liten meny
                                Console.Write("\t\t");    // testar skjuta fram inmatningen
                                if (Int32.TryParse(Console.ReadLine(), out int inmatning))
                                {
                                    switch (inmatning)  // skapar switch case för val av typ av bok
                                    {
                                        case 1: // för val av Roman typ
                                            Roman nyRoman = new Roman(_titel, _skribent, _utgivninsar); // vi skapar ny roman
                                            Centralen.LaggTill(nyRoman); // lägger till nya Romanen till listan
                                            Console.WriteLine("\n\t\tRoman tillagd");
                                            typInmatning = false;    // avbryter loopen
                                            break;
                                        case 2: // för val av Novellsamling
                                            Novellsamling nyNovellsamling = new Novellsamling(_titel, _skribent, _utgivninsar); // vi skapar ny Novellsamling
                                            Centralen.LaggTill(nyNovellsamling); // lägger till nya nyNovellsamlingen till listan
                                            Console.WriteLine("\n\t\tNovellsamling tillagd");
                                            typInmatning = false;
                                            break;
                                        case 3: // för val av Tidskrift
                                            Tidskrift nyTidskrift = new Tidskrift(_titel, _skribent, _utgivninsar); // vi skapar ny roman
                                            Centralen.LaggTill(nyTidskrift); // lägger till nya Tidskriften till listan
                                            Console.WriteLine("\n\t\tTidskrift tillagd");
                                            typInmatning = false;
                                            break;
                                        default:    // vid inmatning av andra tal än 1,2 eller 3
                                            Console.WriteLine("\n\t\tAnge [1], [2] eller [3]");
                                            break;
                                    }
                                }
                                else
                                    Console.WriteLine("\n\t\tAnge [1], [2] eller [3]");   // vid felinmatning
                                MenyAvslut();
                            }
                            break;

                        case 2:
                            if ( Centralen.Antal() > 0) // kontrollerar att det finns element i listan
                            {
                                Centralen.SkrivUtAlla();
                                Console.WriteLine("\n\t\tDet finns {0} böcker i biblioteket", Centralen.Antal());   // vi anger total antal böcker
                            }
                            else
                                Console.WriteLine("\n\t\tBiblioteket innehåller inga böcker!");   // när listan är tom
                            MenyAvslut();
                            break;

                        case 3: // sökning alternativet
                            if(Centralen.Antal() > 0)   // återigen kontrollerar att det finns böcker i listan
                            {   // börjar bygga upp meny för sökningar och starta while-loop
                                bool sok = true;
                                while (sok) // startar while-loop för inmatning av val
                                {   // bygger menyn
                                    Console.Clear();
                                    Console.WriteLine("\n\n\t\t[1] För sökning i \"Titel\"" +
                                        "\n\t\t[2] För sökning i \"Skribent\"" +
                                        "\n\t\t[3] För sökning i \"Utgivningsår\"");
                                    Console.Write("\n\t\t");
                                    if(Int32.TryParse(Console.ReadLine(), out int sokVal))  // felhantering för intmatning
                                    {
                                        switch (sokVal) // menyns switch block
                                        {
                                            case 1: // val för att söka i titel
                                                Console.Write("\n\t\tAnge titel: ");
                                                Centralen.Sok(Console.ReadLine(), 1);   // vi söker bland titlar
                                                sok = false;    // avbryter sökning while-loop
                                                break;

                                            case 2: // val för att söka i skribenter
                                                Console.Write("\n\t\tAnge skribent: ");
                                                Centralen.Sok(Console.ReadLine(), 2);   // vi söker bland skribenter
                                                sok = false;    // avbryter sökning while-loop
                                                break;

                                            case 3: // val för att söka bland utgivningsår
                                                Console.Write("\n\t\tAnge utgivningsåret: ");
                                                // felhanterar inmatning och kollar att det är inte framtiden heller
                                                if(Int32.TryParse(Console.ReadLine(), out int utgAr) && utgAr <= DateTime.Now.Year)
                                                {
                                                    Centralen.Sok(utgAr);   // vi söker bland utgivningsår
                                                    sok = false;    // avbryter sökning while-loop
                                                }
                                                else
                                                {
                                                    Console.WriteLine("\n\t\tAnge giltig årtal, fram till i år");   // ingen framtid och siffra
                                                    MenyAvslut();
                                                }
                                                break;

                                            default:    // vid inmatning av andra tal än 1,2 eller 3
                                                Console.WriteLine("\n\t\tVälj [1], [2] eller [3]");
                                                MenyAvslut();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n\t\tAnge [1], [2] eller [3]");   // vid felinmatning
                                        MenyAvslut();
                                    }   
                                }
                            }
                            else
                                Console.WriteLine("\n\t\tBiblioteket innehåller inga böcker!");   // när listan är tom
                            MenyAvslut();
                            break;

                        case 4: // här raderas listan
                            if (Centralen.Antal() > 0)    // kontrollerar att det finns element i listan
                            {
                                Centralen.Rensa();  // raderar elementerna i listan bibliotek
                                Console.WriteLine("\n\t\tAlla böcker är raderade");   // meddelar att det är raderat
                            }
                            else
                                Console.WriteLine("\n\t\tBiblioteket innehåller inga böcker!");
                            MenyAvslut();   // ser till att man kan se meddelandena innan
                            break;

                        case 5:
                            isRunning = false;  // avslutar huvuloopen och programmet
                            break;

                        default:    // vid inmatning av andra siffror än 1 till 4 vid huvudmenyn
                            Console.WriteLine("\n\t\tOgiltig val. Välj [1] till [4].");
                            MenyAvslut();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n\t\tOgiltig inmatning! Försök igen");    //vid fel inmatning av val i huvudmenyn
                    MenyAvslut();   // för att se meddelandet innan console.clear tar det bort
                }
            }
        }

        static void MenyAvslut()
        {
            Console.WriteLine("\n\n\t\tTryck enter för att gå vidare");
            Console.ReadKey();
        }
    }
}
