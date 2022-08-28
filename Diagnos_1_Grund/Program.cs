using System;

namespace Diagnos_1_Grund
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

    }
}
