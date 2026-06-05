using System;
using System.Collections.Generic;

namespace Cwiczenie_4;

sealed class Rolada : Dania_miesne
{
    public override double czasOczekiwania()
    {
        double czas = 30.0;
        return czas;
    }

    public override double iloscKalorii()
    {
        double kalorie = 450.00;
        return kalorie;
    }
}