using System;
using System.Collections.Generic;

namespace Cwiczenie_3;

interface ILista_zakupow
{
    void dodajElement(string pozycja); 
    //dodaje element do listy
    void usunElement(string pozycja); //usuwa element z listy
    void wyswietl(); //wyświetla wszystkie pozycje listy
    void wyswietl(int ile_pozycji); //wyświetla początk owych ile_pozycji z listy
}

