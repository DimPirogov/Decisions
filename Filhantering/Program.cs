using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filhantering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("\n\t\tAnge namn på filen\t");
            string filNamn = Console.ReadLine();
            Console.Write("\t\tAnge strängen\t");
            string inmatning = Console.ReadLine();
            
            StreamWriter fil = new StreamWriter(filNamn + ".txt");
            fil.WriteLine(inmatning);
            fil.Close();
        }
    }
}
