using System;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;
namespace SoszApp;

class BazaZlecen
{
    //Wyciszenie warningów na początku programu
    #pragma warning disable
    //Kolekcja w postaci listy przechowująca zlecenia
    private List<Zlecenie> listaZlecen = new List<Zlecenie>();

    //Licznik ID
    private int licznikId = 1;


    //Metoda pozwalająca dodać zlecenie i zwiekszyc licznik ID
    public void DodajZlecenie(string klient)
    {
        Zlecenie noweZlecenie = new Zlecenie(licznikId,klient);
        listaZlecen.Add(noweZlecenie);
        licznikId ++;
    }


    //Metoda pozwalająca pobrać zlecenia (zwraca nam cała liste zlecen)
    public List<Zlecenie> PobierzZlecenia()
    {
        return listaZlecen;
    }

    //Metoda pozwalająca zmienić status dodanego zlecenia
    public void ZmienStatus(int id,string status)
    {
        int aktualneId = id;
        bool czyIstnieje = false;
        foreach (Zlecenie zlecenie in listaZlecen)
        {
            if(zlecenie.Id == aktualneId)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                zlecenie.Status = status;
                Console.WriteLine("Status został zmieniony!\n");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
        }
        
        //Sprawdzenie czy zlecenie istnieje
        if(czyIstnieje == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie nie istnieje!\n");
                Console.ResetColor();
            }
    }

    public void ZamknijZlecenie(int id)
    {
        int idZlecenia = id;
        bool czyIstnieje = false;
        //Pętla foreach w kazdej metodzie sluzy do iterowania po zleceniach
        foreach (Zlecenie zlecenie in listaZlecen)
        {
            //Walidacja statusu zlecenia
            if((zlecenie.Status == "Zamknięte") && (zlecenie.Id == id))
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Próbujesz zamknąć zlecenie które jest zamkniętę!\n");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
            else if ((zlecenie.Status != "Zamknięte") && zlecenie.Id == id)
            {
                ZmienStatus(idZlecenia,"Zamknięte");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zlecenie zostało zamknięte!\n");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
        }

        //Sprawdzenie czy zlecenie istnieje
        if(czyIstnieje == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie nie istnieje!\n");
                Console.ResetColor();
            }
    }

    public void UsunZlecenie(int id)
    {
        bool czyIstnieje = false;
        bool czyUsunac = false;

        //Zmienna przechowujaca referencje do obiektu ktory usuwamy
        Zlecenie usuwaneZlecenie = null;
        //Pętla foreach w kazdej metodzie sluzy do iterowania po zleceniach
        foreach (Zlecenie zlecenie in listaZlecen)
        {
            //Walidacja statusu zlecenia
            if(zlecenie.Id == id)
            {
                usuwaneZlecenie = zlecenie;
                czyIstnieje = true;
                czyUsunac = true;
                break;
            }
        }

        //Usuwanie zlecenia
        if(czyUsunac == true)
        {
            listaZlecen.Remove(usuwaneZlecenie);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Zlecenie zostało usunięte!\n");
            Console.ResetColor();
        }

        //Sprawdzenie czy zlecenie istnieje
        if(czyIstnieje == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie nie istnieje!\n");
                Console.ResetColor();
            }
    }

    public void PrzypiszSerwisanta(int id,string serwisant)
    {
        string daneSerwisanta = serwisant;
        bool czyIstnieje = false;

        //Pętla foreach w kazdej metodzie sluzy do iterowania po zleceniach
        foreach (Zlecenie zlecenie in listaZlecen)
        {
            //Walidacja zlecenia (nie przypisujemy serwisanta do zamknietego zlecenia)
            if((zlecenie.Id == id) && (zlecenie.Status != "Zamknięte"))
            {
                zlecenie.Serwisant = daneSerwisanta;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Serwisant został przypisany do zlecenia!\n");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
            else if(zlecenie.Id == id)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie istnieje ale jest zamknięte! - nie można przypisać serwisanta\n");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
        }

        //Sprawdzenie czy zlecenie istnieje
        if(czyIstnieje == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie nie istnieje!\n");
                Console.ResetColor();
            }
    }

    public void KosztZlecenia(int id, double godziny, double kilometry)
    {
        bool czyIstnieje = false;
        double iloscGodzin = godziny;
        double iloscKilometrow = kilometry;
        //Pętla foreach w kazdej metodzie sluzy do iterowania po zleceniach
        if((iloscGodzin >= 0) && (iloscKilometrow >= 0))
        {
            foreach (Zlecenie zlecenie in listaZlecen)
        {
            if(zlecenie.Id == id)
            {
                zlecenie.IloscGodzin = iloscGodzin;
                zlecenie.IloscKilometrow = iloscKilometrow;
                double kosztyZlecenia = zlecenie.ObliczKoszt();
                zlecenie.KosztZlecenia = kosztyZlecenia;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Dodano koszty do zlecenia!");
                Console.ResetColor();
                czyIstnieje = true;
                break;
            }
        }

        //Sprawdzenie czy zlecenie istnieje
        if(czyIstnieje == false)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Zlecenie nie istnieje!\n");
                Console.ResetColor();
            }
        }
    }
        
};