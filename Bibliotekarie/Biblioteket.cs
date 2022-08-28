using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarie
{
    // skapar nya klassen för lista, eftersom själva projektet heter Bibliotekarie så blev jag tvungen
    // att ändra lite i namnet, så det här representerar ett visst bibliotek
    class Biblioteket
    {
        private List<Bok> bibliotek = new List<Bok>();  // skapar listan för alla böcker

        public void LaggTill(Bok bok)   // skapar llägga till metod
        {
            bibliotek.Add(bok); // lägger till en bok
        }

        public void Rensa() // var tvungen att skapa en radera metod
        {
            bibliotek.Clear();  // vi rensar hela listan
        }

        public int Antal()  // var tvungen att skapa en metod för att få antal böcker i listan
        {
            return bibliotek.Count;
        }

        public void SkrivUtAlla()   // skapar skriv ut metoden
        {
            Console.ForegroundColor = ConsoleColor.Green ;   // ställer om färgen till vit
            foreach (Bok bok in bibliotek)  // vi går igenom varje element i listan
            {
                Console.WriteLine(bok); // skriver ut varje bok i listan
            }
            Console.ResetColor();   // återsträller färgen
        }

        public void Sok(string bokSok, int typ)   // skapar sök metoden läser in söknings sträng och typen
        {
            bool miss = true; // variabel för att hålla koll på träffar
            foreach (Bok bok in bibliotek)   // går igenom alla vöcker
            {   
                if(bokSok.ToLower() == bok.titelNamn().ToLower() && typ == 1)   // en enkel sökning på fullständig titel
                {
                    Console.WriteLine(bok); // skriver ut boken
                    miss = false;   // vi ändrar bool till false när det finns en träff
                }
                else if(bokSok.ToLower() == bok.skribNamn().ToLower() && typ == 2)
                {
                    Console.WriteLine(bok); // skriver ut boken
                    miss = false;   // vi ändrar bool till false när det finns en träff
                }
            }
            if(miss)    // vid ingen träff
                Console.WriteLine("\n\t\tIngen träff!");    // när sökningen har inga träffar
        }

        public void Sok(int aretSok)   // skapar sökning bland utgivninsår
        {
            bool miss = true; // variabel för att hålla koll på träffar
            foreach (Bok bok in bibliotek)   // vi kör en vanlig sökning
            {
                if(aretSok == bok.utgAret())    //// vid träff i utgivningsår
                {
                    Console.WriteLine(bok); // skriver ut boken
                    miss = false;   // vi ändrar bool till false när det finns en träff
                }   
             }
            if (miss)    // vid ingen träff
                Console.WriteLine("\n\t\tIngen träff!");    // när sökningen har inga träffar
        }
    }
}
