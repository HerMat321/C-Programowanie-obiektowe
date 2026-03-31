using System;

namespace wykl_1
{
    class Program
    {
        static double srednia(params int[] arg) {
            //liczy średnią arytmetyczną dla dynamicznie określonych argumentów
            double temp = 0;
            foreach (var i in arg)
                temp += i;
            return temp/arg.Length;
        }
        static int fib(int n) {
            //zwraca n-ta liczbę Fibonacciego
            if (n == 1 || n == 2)
                return 1;
            else
                return fib(n - 1) + fib(n - 2);
        }
        static int[] podwojenie(int[] tab) {
            //podwaja elementy tablicy
            int[] temp = new int[tab.Length];
            for (int i = 0; i < tab.Length; i++)
                temp[i] = tab[i] * 2;
            return temp;
        }
        static double suma(double a, double b)
        {
            //zwraca podwojoną sumę liczb, parametry są typu double
            return 2*(a + b);
        }

        static int suma(int a, int b) {
            //zwraca sumę liczb, parametry są typu int
            return a + b;
        }
        static void powitanie(string imie) {
            //zwraca string z powitaniem Hello...
            Console.WriteLine($"Hello {imie}");
        }
        static void Main(string[] args)
        {
            //przykład tablicy, inicjacja, wyświetlenie w konsoli
            int[] tab = new int[] { 1, 2, 3 };

            Console.WriteLine("Elementy tablicy to: (pętla for)");
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(tab[i]);
            }

            Console.WriteLine("Elementy tablicy to: (pętla foreach)");
            foreach (var i in tab)
            {
                Console.WriteLine(i);
            }


            //wywołanie metody powitanie
            powitanie("Ala");

            //tablica, w której zostanie zapisany wynik metody podwojenie
            int[] wynik = podwojenie(new int[] { 1, 2, 3, 4 });

            Console.WriteLine("Wynik działania metody podwojenie:");
            foreach (var i in wynik)
                Console.WriteLine(i);

            //metoda liczy sumę liczb (wariant z podwajaniem)
            Console.WriteLine("Wynik działania metody suma(1.0,2.0)");
            Console.WriteLine(suma(1.0, 2.0));

            //metoda wywołana rekurencyjnie - liczby Fibonacciego
            int n = 40;
            Console.WriteLine($"{n}. liczba Fibonacciego to {fib(n)}");

            //metoda ze zmienną ilością argumentów - średnia arytmetyczna
            Console.WriteLine($"Srednia arytmetyczna liczb 1,2,3 to {srednia(1, 2, 3)}");

            //typ zmiennej zależy od jej wartości
            dynamic x = "ala lubi C#";
            x = 1;

            
        }
    }
}
