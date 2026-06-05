using System;
using System.Collections.Generic;

namespace Cwiczenie_4;

static class Statystyka
{
    public static double min(double[] tablica_liczb)
    {
        double minElement = tablica_liczb[0];

        foreach(var element in tablica_liczb)
        {
            if (element < minElement)
            {
                minElement = element;
            }
        }

        return minElement;
    }

     public static double max(double[] tablica_liczb)
    {
        double maxElement = tablica_liczb[0];

        foreach(var element in tablica_liczb)
        {
            if (element > maxElement)
            {
                maxElement = element;
            }
        }

        return maxElement;
    }

    public static double suma(double[] tablica_liczb)
    {
        double suma = 0;

        foreach (var element in tablica_liczb)
        {
            suma += element;
        }

        return suma;
    }

    public static int ile_elementow(double[] tablica_liczb)
    {
        return tablica_liczb.Length;
    }

    public static double rozstep(double[] tablica_liczb)
    {
        return max(tablica_liczb) - min(tablica_liczb);
    }

    public static double srednia(double[] tablica_liczb, string rodzaj_sredniej)
    {
        string rodzaj = rodzaj_sredniej;
        return suma(tablica_liczb) / ile_elementow(tablica_liczb);
    }

}