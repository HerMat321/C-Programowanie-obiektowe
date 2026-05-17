using System;
namespace SoszApp;

class Zlecenie
{
    //Wyciszenie warningów na początku programu
    #pragma warning disable
   private int id;

    //Poprzez get i set "udostepniamy wlasciwosci pola id dla innych klas"
   public int Id
    {
        get { return id; }
        set { id = value; }
    }


   private DateTime dataUtworzenia;
   public DateTime DataUtworzenia
    {
        get { return dataUtworzenia ; }
        set { dataUtworzenia = value; }
    }
   private string klient;
   public string Klient
    {
        get { return klient ; }
        set { klient = value ;}
    }
   private string opis;
   public string Opis
    {
        get { return opis ; }
        set { opis = value ;}
    }

   private string status;
    public string Status
    {
        get { return status ; }
        set { status = value ;}
    }
   private double iloscGodzin;
   public double IloscGodzin
    {
        get { return iloscGodzin ; }
        set { iloscGodzin = value ;}
    }
   private double iloscKilometrow;
   public double IloscKilometrow
    {
        get { return iloscKilometrow ; }
        set { iloscKilometrow = value ;}
    }

   private double kosztZlecenia;
   public double KosztZlecenia
    {
        get { return kosztZlecenia ; }
        set { kosztZlecenia = value ;}
    }
   private string serwisant;
   public string Serwisant
    {
        get { return serwisant ; }
        set { serwisant = value ;}
    }

    //Konstruktor
    public Zlecenie(int id, string klient)
    {
        this.id = id;
        this.klient = klient;
        this.dataUtworzenia = DateTime.Now;
        this.status = "Nowe";
        this.serwisant = "Nie przypisano";
        this.kosztZlecenia = 0;
    }

    public Zlecenie(int id, string klient, string opis)
    {
        this.id = id;
        this.klient = klient;
        this.dataUtworzenia = DateTime.Now;
        this.status = "Nowe";
        this.serwisant = "Nie przypisano";
        this.kosztZlecenia = 0;
        this.opis = opis;
    }

     public Zlecenie(string klient, string opis, DateTime data)
    {
        this.id = id;
        this.klient = klient;
        this.dataUtworzenia = data;
        this.status = "Nowe";
        this.serwisant = "Nie przypisano";
        this.kosztZlecenia = 0;
        this.opis = opis;
    }

    //Metoda obliczająca koszt zlecenia
    public double ObliczKoszt()
    {
        double stawkaGodzina = 120.00;
        double stawkaKilometry = 2.50;

        double kosztZlecenia = (iloscGodzin * stawkaGodzina) + (iloscKilometrow * stawkaKilometry);

        return kosztZlecenia;
    }
}