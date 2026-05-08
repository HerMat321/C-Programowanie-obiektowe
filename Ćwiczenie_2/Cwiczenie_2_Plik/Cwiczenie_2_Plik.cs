using System;
namespace Cwiczenie_2;

    class Plik
    {   
        //Wyciszenie warningow na poczatku programu
        #pragma warning disable
        public string sciezka {get; set;}
        public string nazwaPliku {get; set;}
        public string tekst {get; set;}

        //Konstruktor
        public Plik (string sciezka, string nazwa , string tekst)
        {
            this.sciezka = sciezka;
            this.nazwaPliku = nazwa;
            this.tekst = tekst;
        }

        public Plik (string sciezka, string nazwa)
        {
            this.sciezka = sciezka;
            this.nazwaPliku = nazwa;
        }

        //Metody

        //Override bo nadpisujemy klase bazowa
        public override string ToString()
        {
            return $"Sciezka pliku: {sciezka}, Nazwa pliku: {nazwaPliku}, Zawartość: {tekst}";
        }

        public void SkopiujPlik(Plik plik)
        {
            string sciezkaZrodlo = Path.Combine(plik.sciezka , plik.nazwaPliku);
            string sciezkaCel = Path.Combine(this.sciezka , this.nazwaPliku);

            //Pozwala zapisać nam sciezke bez uzycia podwojnych "//"
            //Path.Combine();

            string zawartoscZrodlo = File.ReadAllText(sciezkaZrodlo);
            File.WriteAllText(sciezkaCel,zawartoscZrodlo);

            
        }
    }
    

    class Program
    {
        static void Main()
        {
            string sciezka = "/home/mateusz/Programowanie/C#/Programowanie_Obiektowe_Cwiczenia/Ćwiczenie_2/Cwiczenie_2_Plik/test";

            string nazwaPliku = "pliktestowy.txt";

            //Stworzenie obiektu oraz zapis tekstu do pliku
            Plik plik = new Plik(sciezka,nazwaPliku,"Hello World");

            string pelnaSciezka = Path.Combine(sciezka, nazwaPliku);
            File.WriteAllText(pelnaSciezka, plik.tekst);

            //Kopiowanie
            Plik kopia = new Plik(sciezka,"kopia.txt");
            kopia.SkopiujPlik(plik);

        }
    }

