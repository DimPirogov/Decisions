using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filhantering2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> minLista = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                minLista.Add("Värde " + (i+1));
            }

            using (StreamWriter sw = new StreamWriter("minText.txt"))
            {
                foreach (string a in minLista)
                    sw.WriteLine(a);
            }

            using (StreamReader sr = new StreamReader("minText.txt"))
            {
                string temp = "";
                while((temp = sr.ReadLine()) != null)
                {
                    Console.WriteLine(temp);
                }
            }
            Console.ReadLine();
        }
    }
}
