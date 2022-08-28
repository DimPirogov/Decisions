using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotekarie
{
    class Roman : Bok   // skapar första underklassen Roman
    {
        public Roman(string titel, string skribent, int utgivninsar)    // vi skapar en konstruktör för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Roman"; // anger typen "roman"
            this.Utgivningsar = utgivninsar;
        }

        public override string ToString()   // skapar egen utsriftmetod
        {
            return "\n\t\t \"" + Titel + "\" av " + Skribent + ". Utgivningår: " + Utgivningsar + " (" + Typ + ")" +
                "\n\t\tromanen finns i romanhyllan!";
        }
    }
}
