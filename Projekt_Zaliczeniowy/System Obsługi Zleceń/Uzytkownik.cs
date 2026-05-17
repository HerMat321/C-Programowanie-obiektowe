using System;
using System.Collections.Generic;
namespace SoszApp;

//Klasa abstrakcyjna (czyli wzor z ktorego dziedzicza inne klasy)
abstract class Uzytkownik
{
    public string Login {get; protected set;}
    public string Haslo {get; protected set;}

    //Konstruktor
    public Uzytkownik (string login, string haslo)
    {
        this.Login = login;
        this.Haslo = haslo;
    }

    //Metoda abstrakcyjna
    public abstract bool CzyMozeUsunacZlecenie();
}