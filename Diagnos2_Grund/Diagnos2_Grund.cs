using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagnos2_Grund
{
    class Bil
    {
        protected string RegistreringsNummer; // De grundläggande egenskaperna, alla markerade som "private"
        protected string Tillverkare;         //
        protected int Årtal;                  //
        protected bool Besiktad;              //

        public Bil(string _registrering, string _tillverkare, int _årtal, bool _besiktad)     // Grundläggande konstruktor, tar in värden och tilldelar dem.
        {                                                                                     //
            RegistreringsNummer = _registrering;                                              // Registreringsnummer
            Tillverkare = _tillverkare;                                                       // Tillverkare
            Årtal = _årtal;                                                                   // Årtal
            Besiktad = _besiktad;                                                             // Huruvida bilen är besiktad
        }

        public virtual string Korkort()
        {
            return "De flest former av bilar kräver en form av körkort, som minst med B-behörighet.";
        }

        public override string ToString()                                   // Standardiserad utskrift som anpassar sig efter huruvida bilen är besiktad.
        {
            if (Besiktad)
                // Utskrift om bilen är besiktad
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"          //
                + "\n\t\t" + RegistreringsNummer                            //
                + "\n\t\tBesiktad"
                + "\n\t\t" + Korkort();                                     //
                                                                            //
            else
                // Utskrift om bilen inte är besiktad
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"          //
                + "\n\t\t" + RegistreringsNummer                            //
                + "\n\t\tObesiktad"
                + "\n\t\t" + Korkort();                                     //
        }
    }

    class Lastbil : Bil
    {
        private int Vikt;
        public Lastbil(string _registrering, string _tillverkare, int _årtal, bool _besiktad, int _vikt) : base (_registrering, _tillverkare, _årtal, _besiktad)
        {
            Vikt = _vikt;
        }
        public override string Korkort()
        {
            return "Lastbilar kräver variationer C-körkort för att framföras.";
        }

        public string ViktKontroll(int vikt)
        {
            if (vikt <= Vikt)
            {
                return "Godkänd viktklass!";
            }
            else
                return "Övervikt, ej godkänd!";
        }
        public override string ToString()                                   // Standardiserad utskrift som anpassar sig efter huruvida bilen är besiktad.
        {
            if (Besiktad)
                // Utskrift om bilen är besiktad
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"          //
                + "\n\t\t" + RegistreringsNummer                            //
                + "\n\t\tBesiktad" +
                "\n\t\tMax vikt: " + Vikt
                + "\n\t\t" + Korkort();                                         //
                                                                            //
            else
                // Utskrift om bilen inte är besiktad
                return "\n\t\t" + Tillverkare + " (" + Årtal + ")"          //
                + "\n\t\t" + RegistreringsNummer                            //
                + "\n\t\tObesiktad" +
                "\n\t\tMax vikt: " + Vikt
                + "\n\t\t" + Korkort();                                        //
        }
    }

    class Program
    {  
        static void Main(string[] args)
        {
            Random rnd = new Random();  // initierar random
            List<Bil> register = new List<Bil>();   // skapar en tom lista
            bool isRunning = true;  // bool for while - loop
            while (isRunning)
            {
                Console.Clear();    // rensar skärmen
                Console.WriteLine("\n\t\tVälkommen till Bil vikt diagnos" +
                "\n\t\t[1] Importera fordon" +
                "\n\t\t[2] Skriv ut fordon" +
                "\n\t\t[3] Skriv in vikt för lastning" +
                "\n\t\t[4] Avsluta");
                Console.Write("\n\t\t");
                Int32.TryParse(Console.ReadLine(), out int result); // läser in inmatning
                switch (result) // 
                {
                    case 1:
                        string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "Å", "Ä", "Ö" };
                        // Sätter alla möjliga bokstäver i en vektor
                        string[] brand = new string[] { "Toyota", "Volkswagen", "General Motors", "Hyundai", "Ford", "Nissan", "Honda", "Fiat Chrysler", "Renault", "Volvo" };
                        // Skapar en lista med vanliga tillverkare
                        for (int i = 0; i < 3; i++) // vi skapar 3 bilar och 3 lastbilar
                        {
                            string reg_SlumpBil = "";
                            string reg_SlumpLastBil = "";

                            for (int b = 0; b < 3; b++)
                            {
                                reg_SlumpBil += letters[rnd.Next(0, letters.Length)];  // skapar bokstäver
                                reg_SlumpLastBil += letters[rnd.Next(0, letters.Length)];  // skapar bokstäver
                            }
                            for (int c = 0; c < 3; c++)
                            {
                                reg_SlumpBil += rnd.Next(0, 10);  // skapar siffror för bil
                                reg_SlumpLastBil += rnd.Next(0, 10);  // skapar siffror för Lastbil
                            }

                            string tillverkareBil = brand[rnd.Next(0, brand.Length)]; // tillverkare till bil
                            string tillverkarLastbil = brand[rnd.Next(0, brand.Length)];  // tillverkare till lastbil

                            int prodYearBil = rnd.Next(1920, DateTime.Now.Year + 1);    // anger år av tillverkning
                            int prodYearLastbil = rnd.Next(1920, DateTime.Now.Year + 1);    // anger år av tillverkning

                            bool besikt = false;    // anger besiktigad som falsk i början
                            if(rnd.Next(2) == 0)
                            {
                                besikt = true;  // annars blir besiktigad om man får en nolla
                            }

                            int weight = rnd.Next(1, 100);  // anger maxvikt för Lastbilar

                            register.Add(new Bil(reg_SlumpBil, tillverkareBil, prodYearBil, besikt));   // lägger ny bill
                            register.Add(new Lastbil(reg_SlumpLastBil, tillverkarLastbil, prodYearLastbil, besikt, weight));
                            // ny lstbil
                        }
                        Console.WriteLine("\n\t\t3 bilar och 3 lastbilar inlagda");
                        Console.ReadLine();
                        
                        break;
                    case 2:
                        foreach (Bil _bil in register)  // vi går igenom varje element i registret
                        {
                            Console.WriteLine(_bil.ToString()); // skriver ut varje bil
                            //_bil.ToString();
                        }
                        Console.ReadLine();
                        
                        break;
                    case 3:
                        Console.Write("\t\n\n Ange tonvikt att testa mot lastbilar"); // ange vikt
                        int vikt;
                        while (!Int32.TryParse(Console.ReadLine(), out vikt)); // läser in inmatning
                        foreach (Bil _bil in register)  // vi går igenom varje element i registret
                        {
                            if(_bil is Lastbil _Lastbil)
                            {
                                Console.WriteLine(_Lastbil.ToString() + " " + _Lastbil.ViktKontroll(vikt)); // skriver ut
                                         // varje lastbil och dennes vikt om den passar
                            }
                        }
                        Console.ReadLine();
                        
                        break;

                    case 4:
                        isRunning = false;  // avslutar programmet

                        break;
                    default:
                        Console.WriteLine("\n\t\tAnge [1], [2] eller [3]");
                        Console.ReadLine();

                        break;

                }
            }
        }



    }
}
