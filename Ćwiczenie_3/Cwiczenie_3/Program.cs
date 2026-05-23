using System;
using System.Collections.Generic;

namespace Cwiczenie_3
{
    class Program
    {
        static void Main()
        {
           Super_student s = new Super_student("Mateusz",31,"Informatyka",true);
           s.zainteresowania_naukowe = new List<string>
           {
               "Sieci komputerowe",
               "Systemy Operacyjne",
               "Sztuczna Inteligencja"
           };

           if(s.Stypendium == true)
            {
                Console.WriteLine("Stypendium: Przyznano");
            }
            else
            {
                Console.WriteLine("Stypendium: Nie przyznano");
            }

            Console.WriteLine(s);


        Lista_zakupow lista = new Lista_zakupow();

        lista.dodajElement("Chleb");
        lista.dodajElement("Masło");
        lista.dodajElement("Mleko");
        lista.dodajElement("Jajka");

        Console.WriteLine("Cała lista:");
        lista.wyswietl();

        lista.usunElement("Masło");
        
        Console.WriteLine("Lista bez jednego elementu:");
        lista.wyswietl();

        Console.WriteLine("Dwa pierwsze elementy:");
        lista.wyswietl(2);

        }
    }
}
