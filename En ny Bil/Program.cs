using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace En_ny_Bil
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lastbil minLastbil = new Lastbil("Volvo", "Blå",false);
            Console.WriteLine(minLastbil);
            Bil minBil = new Bil("BMW", "White", true);
            Console.WriteLine(minBil);
            Console.ReadLine();
        }
    }
    public class Bil
    {
        protected string körkort = "B";
        protected string modell = "";
        protected string färg = "";
        protected bool besiktad = false;
        public Bil(string a, string b, bool c)
        {
            modell = a;
            färg = b;
            besiktad = c;
        }
        public override string ToString()
        {
            if (besiktad)
                return "En besiktad, " + färg + " " + modell + "-bil. Den kräver " + körkort + " körkort.";
            else
                return "En obesiktad, " + färg + " " + modell + "-bil. Den kräver " + körkort + " körkort.";
        }
    }
    public class Lastbil : Bil
    {
        public Lastbil(string a, string b, bool c) : base(a, b, c)
        {
            this.körkort = "C";
        }
    }
}
