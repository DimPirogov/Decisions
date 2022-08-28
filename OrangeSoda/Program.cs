using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeSoda
{
    public class ApelsinLäsk
    {
        protected string smak = "Apelsin";
        public virtual string HämtaSmak()
        {
            return smak;
        }
    }
    
    public class LimeLäsk : ApelsinLäsk
    {
        public override string HämtaSmak()
        {
            return "Apelsin och Lime."; 
        }
    }
    
    class Program
    {   
        static void Main(string[] args)
        {
            ApelsinLäsk Läsk1 = new ApelsinLäsk();
            Console.WriteLine(Läsk1.HämtaSmak());
            
            LimeLäsk Läsk = new LimeLäsk();
            Console.WriteLine(Läsk.HämtaSmak());
            Console.ReadLine();
        }
    }
}
