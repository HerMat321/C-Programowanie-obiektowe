using System;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

class Program
{

    /*
    1. Pobierz z klawiatury dwie wartości, które będą bokami prostokąta. Następnie oblicz jego
    pole i obwód
    */
    static void Figura()
    {
        Console.WriteLine("Podaj długość boku A");
        int.TryParse(Console.ReadLine(), out int bokA);

        Console.WriteLine("Podaj długość boku B");
        int.TryParse(Console.ReadLine(), out int bokB);

        int pole = bokA * bokB;
        int obwod = (2*bokA) + (2*bokB);

        Console.WriteLine($"Pole wynosi {pole} cm , a obwód wynosi {obwod} cm");

    }

    /*
    2. Oblicz sumę początkowych n liczb naturalnych, gdzie wartość n będzie pobrana z
    klawiatury.
    */
    static void SumaLiczb()
    {
        Console.Write("Podaj liczbę naturalną:");
        int.TryParse(Console.ReadLine(), out int n);

        Console.WriteLine("Suma początkowych liczb podanych przez użytkownika:");
        int suma = 0;

        for(int i = 0; i <= n; i++)
        {
            
            suma +=i;
            Console.Write($"{suma} , ");
        }
        Console.WriteLine($"\nOstateczna suma wynosi: {suma}");
    }

    /*
    3. Sprawdź, czy pobrana z klawiatury liczba jest doskonała.
    */
    static void LiczbaDoskonala()
    {
        Console.Write("Podaj liczbę :");
        int.TryParse(Console.ReadLine(), out int n);

        int suma = 0;

        for(int i = 1; i <= (n-1); i++)
        {
            if (n % i == 0)
            {
                suma += i;
            }
        }

        if(suma == n)
        {
            Console.WriteLine($"Liczba {n} jest liczbą doskonałą!");
        }
        else
        {
            Console.WriteLine($"Liczba {n} nie jest liczbą doskonałą!");
        }
    }

    /*
    4. Pobierz z klawiatury liczbę zmiennoprzecinkową, a następnie oblicz wartości funkcji
    trygonometrycznych dla tej wartości. biblioteka Math
    */
    static void FunkcjeTrygonometryczne()
    {
        Console.Write("Podaj liczbę :");
        double.TryParse(Console.ReadLine(), out double x);

        Console.WriteLine($"Sinus liczby wynosi:{Math.Sin(x)}");
        Console.WriteLine($"Cosinus liczby wynosi:{Math.Cos(x)}");
        Console.WriteLine($"Tangens liczby wynosi:{Math.Tan(x)}");
    }

    //##################################################################

    /*
    1. sprawdzi, czy podane liczby mogą być bokami trójkąta prostokątnego. 
    */
    static void TrojkatProstokatny(int a, int b, int c)
    {
      
        if (((a*a) + (b*b)) == (c*c) || ((b*b) + (c*c)) == (a*a) || ((a*a) + (c*c)) == (b*b) )
        {
            Console.WriteLine("Liczby podane w argumentach funkcji mogą być bokami trójkąta prostokątnego");
        }
        else
        {
            Console.WriteLine("Liczby podane w argumentach funkcji nie mogą być bokami trójkąta prostokątnego");
        }
    }

    /*
    2. dla zadanej tablicy liczb zwróci te wartości początkowe, których suma nie przekracza
    pewnego zadanego progu.
    */
    static void TablicaLiczb(int[] liczby,int prog)
    {
        int suma = 0;

        foreach(var element in liczby)
        {
            suma += element;

            if(suma < prog)
            {
                Console.WriteLine($"{element}");
            }
            else
            {
                break;
            }
        }
    }

    /*
    3. sprawdzi, czy podane 2 tablice mają równe elementy. 
    */
    static void RownoscTablic(int[] tablica1, int[] tablica2)
    {
        bool flaga = true;
        if(tablica1.Length == tablica2.Length)
        {
            
            for(int i = 0; i < tablica1.Length; i++)
            {
                if(tablica1[i] != tablica2[i])
                {
                    flaga = false;
                    break;
                }
            }

            if(flaga == true)
            {
                Console.WriteLine("Tablice są równe!");
            }
            else
            {
                Console.WriteLine("Tablice nie są równe!");
            }  
        }
        else
        {
            Console.WriteLine("Tablice nie są równe!");
        }
    }

    /*
    4.dla zadanej tablicy liczb całkowitych sprawdzi, które z nich są większe od pewnego
    zadanego progu.
    */
    static void TablicaCzyWieksze(int[] liczby, int prog)
    {   
        Console.Write("Te liczby są większe od podanego progu: ");

        foreach(var element in liczby)
        {
            if(element > prog)
            {
                Console.Write($"{element},");
            }
        }
    }


    static void Main()
    {
        // Pierwsza częśc zadań ######
        /*
        1.
        Figura();
        */

        /*
        2.
        SumaLiczb();
        */
        
        /*
        3.
        LiczbaDoskonala();
        */

        /*
        4.
        FunkcjeTrygonometryczne();
        */
        
        //Druga część zadań #######

        /*
        1.
        TrojkatProstokatny(7,24,25); TAK
        TrojkatProstokatny(2,3,4); NIE
        */
    

        /*
        2.
        TablicaLiczb([3,4,5,6,7,8,9],15);
        */
        
        /*
        3.
        RownoscTablic([1,2,3,4],[1,2,3,4,5]); NIE
        RownoscTablic([1,2,3,4,5],[1,2,3,4,5]); TAK
        RownoscTablic([1,2,3,4,6],[1,2,3,4,5]); NIE
        */

        /*
        4.
        TablicaCzyWieksze([1,4,5,6,7,8,3,2,5,7,3],2);
        */
    }
}