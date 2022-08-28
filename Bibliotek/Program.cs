using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotek
{
    class Bok   // skapar klassen Bok med Titel, Skribent, Typ och Utgivningsår egenskaper med respektive variabel typ.
    {
        public string Titel;
        public string Skribent;
        public string Typ;
        public int Utgivningsar;

        // skapar to string metod för utskrifter
        public override string ToString() 
        {
            return  "\n\t\t \"" + Titel + "\" av " + Skribent + ". Utgivningår: " + Utgivningsar + " (" + Typ + ")";
        }
    }

    class Roman : Bok   // skapar första underklassen Roman
    {
        public Roman(string titel, string skribent, int utgivninsar)    // vi skapar en konstructor för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Roman"; // anger typen "roman"
            this.Utgivningsar = utgivninsar;
        }
    }
    class Novellsamling : Bok   // skapar andra underklassen
    {
        public Novellsamling(string titel, string skribent, int utgivninsar)    // vi skapar en konstructor för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Novellsamling"; //anger sin typ
            this.Utgivningsar = utgivninsar;
        }
    }
    class Tidskrift : Bok   // skapar tredje underklassen
    {
        public Tidskrift(string titel, string skribent, int utgivninsar)    // vi skapar en konstructor för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Tidskrift"; //samma här
            this.Utgivningsar = utgivninsar;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;  // bool för huvud while-loopen
            List<Bok> bibliotek = new List<Bok>();  // skapar listan för alla böcker
            while (isRunning)
            {   // skapar huvudmenyn
                Console.Clear();    // rensar consolen
                Console.ForegroundColor = ConsoleColor.Yellow;  // ändrar färg till gul
                Console.WriteLine("\n\n\t\tVälkommna till biblioteket!" +   //skapar huvudmenynssträng
                    "\n\t\t[1] Registrera ny bok" +
                    "\n\t\t[2] Visa böcker" +
                    "\n\t\t[3] Radera alla böcker" +
                    "\n\t\t[4] Avsluta");
                Console.ResetColor();   // återställer färgen
                Console.Write("\t\t");    // testar skjuta fram inmatningen
                if (Int32.TryParse(Console.ReadLine(),out int val))  // läser in valet med tryparse felhantering
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
                                    if(årtal <= DateTime.Now.Year)  // så länge ingen framtid
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
                                if(Int32.TryParse(Console.ReadLine(), out int inmatning))
                                {
                                    switch (inmatning)  // skapar switch case för val av typ av bok
                                    {
                                        case 1: // för val av Roman typ
                                            Roman nyRoman = new Roman(_titel, _skribent, _utgivninsar); // vi skapar ny roman
                                            bibliotek.Add(nyRoman); // lägger till nya Romanen till listan
                                            Console.WriteLine("\n\t\tRoman tillagd");
                                            typInmatning = false;    // avbryter loopen
                                            break;
                                        case 2: // för val av Novellsamling
                                            Novellsamling nyNovellsamling = new Novellsamling(_titel, _skribent, _utgivninsar); // vi skapar ny Novellsamling
                                            bibliotek.Add(nyNovellsamling); // lägger till nya nyNovellsamlingen till listan
                                            Console.WriteLine("\n\t\tNovellsamling tillagd");
                                            typInmatning = false;
                                            break;
                                        case 3: // för val av Tidskrift
                                            Tidskrift nyTidskrift = new Tidskrift(_titel, _skribent, _utgivninsar); // vi skapar ny roman
                                            bibliotek.Add(nyTidskrift); // lägger till nya Tidskriften till listan
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
                            if(bibliotek.Count > 0) // kontrollerar att det finns element i listan
                            {
                                foreach(Bok item in bibliotek)  // vi går igenom elementerna i listan
                                    Console.WriteLine(item);    // varje bok skrivs ut med hjälp av ToString metoden
                                Console.WriteLine("\n\t\tDet finns {0} böcker i biblioteket", bibliotek.Count);   // vi anger total antal böcker
                            }
                            else
                                Console.WriteLine("\n\t\tBiblioteket innehåller inga böcker!");   // när listan är tom
                            MenyAvslut();
                            break;

                        case 3: // här raderas listan
                            if (bibliotek.Count > 0)    // kontrollerar att det finns element i listan
                            {
                                bibliotek.Clear();  // raderar elementerna i listan bibliotek
                                Console.WriteLine("\n\t\tAlla böcker är raderade");   // meddelar att det är raderat
                            }
                            else
                                Console.WriteLine("\n\t\tBiblioteket innehåller inga böcker!");
                            MenyAvslut();   // ser till att man kan se meddelandena innan
                            break;

                        case 4:
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
