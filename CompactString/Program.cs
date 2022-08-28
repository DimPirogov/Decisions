using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompactStringOvning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompactString Sträng = new CompactString("Hej");
            CompactString Str = new CompactString(Sträng);
            CompactString Str1 = new CompactString();
            Console.WriteLine(Sträng);
            Console.ReadLine();
        }
    }
    public class CompactString
    {
        public string saveString;
        public CompactString(string a = "")
        {
            saveString = a.Replace(" ", string.Empty);
        }
        public CompactString(CompactString orig)
        {
            this.saveString = orig.saveString;
        }

        public override string ToString()
        {
            return saveString;
        }
    }
}
