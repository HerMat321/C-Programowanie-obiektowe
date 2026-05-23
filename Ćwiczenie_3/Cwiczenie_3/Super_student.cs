using System;

namespace Cwiczenie_3;

class Super_student : Student
{
    public bool Stypendium {get; set; }
    public List<string> zainteresowania_naukowe = new List<string>() ;

    public Super_student(string imie, int wiek, string kierunek, bool stypendium) : base(imie,wiek,kierunek)
    {
        this.Stypendium = stypendium;
    }

    //Override bo nadpisujemy klase bazowa
    public override string ToString()
    {

        //string.Join zeby uzyc tej metody w celu dodania wpisanych stringow do listy
        return $"Imię: {Imie}, Wiek: {Wiek}, Kierunek: {Kierunek}, Stypendium: {Stypendium}, Zainteresowania naukowe: {string.Join(", ",zainteresowania_naukowe)} ";
    }
}