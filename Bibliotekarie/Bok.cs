using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarie
{
    class Bok   // skapar klassen Bok med Titel, Skribent, Typ och Utgivningsår egenskaper med respektive variabel typ.
    {
        protected string Titel;
        protected string Skribent;
        protected string Typ;
        protected int Utgivningsar;

        public int utgAret()    // skapar en metod för att komma åt utgivningsår utifrån,
                                // kanske en vanlig "get" skulle suttit fint när man skapade egenskaper
        {
            return Utgivningsar;
        }

        public string titelNamn()   // skapar en metod för att komma åt Titel utifrån
        {
            return Titel;
        }
        public string skribNamn()   // skapar en metod för att komma åt Skribent utifrån
        {
            return Skribent;
        }
        // skapar to string metod för utskrifter
        public override string ToString()
        {
            return "\n\t\t \"" + Titel + "\" av " + Skribent + ". Utgivningår: " + Utgivningsar + " (" + Typ + ")";
        }
    }
}
