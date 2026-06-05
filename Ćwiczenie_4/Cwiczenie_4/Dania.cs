using System;
using System.Collections.Generic;

namespace Cwiczenie_4;
#pragma warning disable
abstract class Dania : IDanie
{
    protected string nazwaDania;
    protected string rodzajDania;
    protected List<string> lista_alergenow;

    public abstract double czasOczekiwania();
    public abstract double iloscKalorii();

}