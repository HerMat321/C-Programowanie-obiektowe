using System;
using Cwiczenie_4;
#pragma warning disable

namespace Ćwiczenie_4
{
    class Program
    {
        static void Main()
        {
            Rolada r = new Rolada();

            Console.WriteLine(r.czasOczekiwania());
            Console.WriteLine(r.iloscKalorii());
        }
    }
}
