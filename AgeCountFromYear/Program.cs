using System;

namespace AgeCountFromYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Var god och ange året ni föddes: ");
            int myBirthYear = Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Ni är {0} år gammal", 2022 - myBirthYear);

        }
    }
}

