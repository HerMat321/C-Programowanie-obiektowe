using System;
using System.Collections.Generic;
namespace SoszApp;

class Pracownik : Uzytkownik
{
    //Metoda dziedziczaca po klasie abstrakcyjnej Uzytkownik
    public override bool CzyMozeUsunacZlecenie()
    {
        return false;
    }

    //Konstruktor wywołany z klasy bazowej
    public Pracownik(string login, string haslo)
        : base(login,haslo)
    {
        
    }

}