namespace Bibliotekarie
{
    class Novellsamling : Bok   // skapar andra underklassen
    {
        public Novellsamling(string titel, string skribent, int utgivninsar)    // vi skapar en konstruktör för underklassen
        {
            this.Titel = titel;
            this.Skribent = skribent;
            this.Typ = "Novellsamling"; //anger sin typ
            this.Utgivningsar = utgivninsar;
        }

        public override string ToString()   // skapar egen tostring metod
        {
            return "\n\t\t \"" + Titel + "\" av " + Skribent + ". Utgivningår: " + Utgivningsar + " (" + Typ + ")" +
                "\n\t\tnovellen finns i novellhyllan!";
        }

    }
}
