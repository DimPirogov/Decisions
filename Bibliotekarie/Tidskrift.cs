namespace Bibliotekarie
{
    class Tidskrift : Bok   // skapar tredje underklassen
    {
        public Tidskrift(string titel, string skribent, int utgivninsar)    // vi skapar en konstruktör för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Tidskrift"; //samma här
            this.Utgivningsar = utgivninsar;
        }
        public override string ToString()   // skapar egen utskriftsmetod
        {
            return "\n\t\t \"" + Titel + "\" av " + Skribent + ". Utgivningår: " + Utgivningsar + " (" + Typ + ")" +
                "\n\t\ttidskriften finns i tidskriftshyllan!";
        }
    }
}
