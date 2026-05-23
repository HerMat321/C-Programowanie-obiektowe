using System;
using System.Collections.Generic;

namespace Cwiczenie_3;

class Lista_zakupow : ILista_zakupow
{
    private List<string> lista = new List<string>();

    public void dodajElement(string pozycja)
    {
        lista.Add(pozycja);
    }

    public void usunElement(string pozycja)
    {
        lista.Remove(pozycja);
    }

    public void wyswietl()
    {
        foreach(var element in lista)
        {
            Console.WriteLine(element);
        }
    }

    public void wyswietl(int ile_pozycji)
    {
        for(int i = 0; i < ile_pozycji && i < lista.Count; i++ )
        {
            Console.WriteLine(lista[i]);
        }
    }
}