using System;
using System.Collections.Generic;
namespace SoszApp;

class Administrator : Uzytkownik
{
    //Metoda dziedziczaca po klasie abstrakcyjnej Uzytkownik
    public override bool CzyMozeUsunacZlecenie()
    {
        return true;
    }

    //Konstruktor wywołany z klasy bazowej
    public Administrator(string login, string haslo)
        : base(login,haslo)
    {
        
    }

}