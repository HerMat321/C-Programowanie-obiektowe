using System;

namespace Cwiczenie_3;

class Student
{
    //Wyciszenie warningów na początku programu
    #pragma warning disable
    public string Imie { get ; set ; }
    public int Wiek { get ; set ; } 
    public string Kierunek { get ; set ; } 

    //Konstruktory
    public Student (string imie, int wiek, string kierunek)
    {
        this.Imie = imie;
        this.Wiek = wiek;
        this.Kierunek = kierunek;
    }

    public Student(string imie, int wiek)
    {
        this.Imie = imie;
        this.Wiek = wiek;
        this.Kierunek = "Nieznany";
    }

    public Student()
    {
        
    }

    //Override bo nadpisujemy klase bazowa
    public override string ToString()
    {
        return $"Imię: {Imie}, Wiek: {Wiek}, Kierunek: {Kierunek}";
    }
}