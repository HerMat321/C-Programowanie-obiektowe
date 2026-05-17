using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace SoszApp;

class BazaZlecen : IBazaZlecen
{
    //Wyciszenie warningów na początku programu
    #pragma warning disable
    //Kolekcja w postaci listy przechowująca zlecenia
    private List<Zlecenie> listaZlecen = new List<Zlecenie>();

    //Metoda pozwalająca dodać zlecenie
    public void DodajZlecenie(string klient, string opis)
    {   
        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();

            //Zapytanie do bazy danych
            string zapytanie = "INSERT INTO zlecenia (klient, opis, data_utworzenia, status) VALUES (@klient, @opis, @data, @status)";

            //Dodanie wartosci do bazy danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@klient", klient);
                komenda.Parameters.AddWithValue("@opis", opis);
                komenda.Parameters.AddWithValue("@data", DateTime.Now.Date);
                komenda.Parameters.AddWithValue("@status", "Nowe");
                
                //Wykonanie zapytania
                komenda.ExecuteNonQuery();
            }
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Zlecenie zostało dodane do bazy danych!");
        Console.ResetColor();
    }


    //Metoda pozwalająca pobrać zlecenia (zwraca nam cała liste zlecen)
    public List<Zlecenie> PobierzZlecenia()
    {
        //Tworzymy liste jako obiekt w ktorej beda zapisywane dane z bazy danych
        List<Zlecenie> listaZlecen = new List<Zlecenie>();

        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();

            //Zapytanie do bazy danych
            string zapytanie = "SELECT * FROM zlecenia";

            //Odczytanie wartosci z bazy danych
            using (MySqlCommand komenda = new MySqlCommand (zapytanie,polaczenie))
            using (MySqlDataReader odczyt = komenda.ExecuteReader())
            {
                while (odczyt.Read())
                {
                    int id = Convert.ToInt32(odczyt["id"]);
                    string klient = odczyt["klient"].ToString();
                    string opis = odczyt["opis"].ToString();

                    DateTime data = Convert.ToDateTime(odczyt["data_utworzenia"]);

                    string status = odczyt["status"].ToString();
                    string serwisant = odczyt["serwisant"].ToString();

                    double iloscGodzin = 0;
                    //Walidacja danych - sprawdzenie czy wartosci w bazie danych nie sa puste
                    if (odczyt["ilosc_godzin"] != DBNull.Value)
                    {
                        iloscGodzin = Convert.ToDouble(odczyt["ilosc_godzin"]);
                    }

                    double iloscKilometrow= 0;
                    //Walidacja danych - sprawdzenie czy wartosci w bazie danych nie sa puste
                    if (odczyt["ilosc_kilometrow"] != DBNull.Value)
                    {
                        iloscKilometrow = Convert.ToDouble(odczyt["ilosc_kilometrow"]);
                    }

                    double koszt = 0;
                    //Walidacja danych - sprawdzenie czy wartosci w bazie danych nie sa puste
                    if (odczyt["koszt_zlecenia"] != DBNull.Value)
                    {
                        koszt = Convert.ToDouble(odczyt["koszt_zlecenia"]);
                    }

                    //Stworzenie obiektu zlecenie
                    Zlecenie zlecenie = new Zlecenie(klient, opis, data);
                    
                    zlecenie.Id = id;
                    zlecenie.Status = status;
                    zlecenie.Serwisant = serwisant;
                    zlecenie.IloscGodzin = iloscGodzin;
                    zlecenie.IloscKilometrow = iloscKilometrow;
                    zlecenie.KosztZlecenia = koszt;

                    //Dodawanie zlecenia pobranego z MySQL do listy
                    listaZlecen.Add(zlecenie);
                }
            }

        }
        return listaZlecen;
    }

    //Metoda pozwalająca zmienić status dodanego zlecenia
    public void ZmienStatus(int id,string status)
    {
        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();
            
            //Zapytanie do bazy danych
            string zapytanie = "UPDATE zlecenia SET status = @status WHERE id = @id";

            //Zmiana wartosci w bazie danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@status", status);
                komenda.Parameters.AddWithValue("@id",id);

                //Pobranie liczby wierszy z bazy danych (sprawdzenie czy zlecenie istnieje)
                int wiersze = komenda.ExecuteNonQuery();

                //Informacja o zmianie statusu
                if(wiersze > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Status został zmieniony!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Zlecenie nie istnieje!");
                    Console.ResetColor();
                }
            }
        }
    }

    public void ZamknijZlecenie(int id)
    {
        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();
            
            //Zapytanie do bazy danych
            string zapytanie = "UPDATE zlecenia SET status = 'Zamknięte' WHERE id = @id";

            //Zmiana wartosci w bazie danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@id",id);

                //Pobranie liczby wierszy z bazy danych (sprawdzenie czy zlecenie istnieje)
                int wiersze = komenda.ExecuteNonQuery();

                //Informacja o zmianie statusu
                if(wiersze > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Zlecenie zostało zamknięte!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Zlecenie nie istnieje!");
                    Console.ResetColor();
                }
            }
        }
    }

    public void UsunZlecenie(int id)
    {
        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();
            
            //Zapytanie do bazy danych
            string zapytanie = "DELETE FROM zlecenia WHERE id = @id";

            //Zmiana wartosci w bazie danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@id",id);

                //Pobranie liczby wierszy z bazy danych (sprawdzenie czy zlecenie istnieje)
                int wiersze = komenda.ExecuteNonQuery();

                //Informacja o zmianie statusu
                if(wiersze > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Zlecenie zostało usunięte!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Zlecenie nie istnieje!");
                    Console.ResetColor();
                }
            }
        }
    }

    public void PrzypiszSerwisanta(int id,string serwisant)
    {
        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();
            
            //Zapytanie do bazy danych
            string zapytanie = "UPDATE zlecenia SET serwisant = @serwisant WHERE id = @id";

            //Zmiana wartosci w bazie danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@serwisant", serwisant);
                komenda.Parameters.AddWithValue("@id",id);

                //Pobranie liczby wierszy z bazy danych (sprawdzenie czy zlecenie istnieje)
                int wiersze = komenda.ExecuteNonQuery();

                //Informacja o zmianie statusu
                if(wiersze > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Przypisano serwisanta!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Zlecenie nie istnieje!");
                    Console.ResetColor();
                }
            }
        }
    }

    public void KosztZlecenia(int id, double godziny, double kilometry)
    {
        //Tworzymy obiekt do obliczenia kosztu
        Zlecenie zlecenie = new Zlecenie("","",DateTime.Now);

        //Ustawienie danych
        zlecenie.IloscGodzin = godziny;
        zlecenie.IloscKilometrow = kilometry;

        //Obliczamy koszt przez metode
        double koszt = zlecenie.ObliczKoszt();

        //Otwarcie polaczenia z baza danych
        using (MySqlConnection polaczenie = PolaczenieBazaDanych.GetConnection())
        {
            polaczenie.Open();
            
            //Zapytanie do bazy danych
            string zapytanie = "UPDATE zlecenia SET ilosc_godzin = @godziny, ilosc_kilometrow = @kilometry, koszt_zlecenia = @koszt WHERE id = @id";

            //Zmiana wartosci w bazie danych
            using (MySqlCommand komenda = new MySqlCommand(zapytanie, polaczenie))
            {
                komenda.Parameters.AddWithValue("@godziny", godziny);
                komenda.Parameters.AddWithValue("@kilometry",kilometry);
                komenda.Parameters.AddWithValue("@koszt",koszt);
                komenda.Parameters.AddWithValue("@id",id);

                //Pobranie liczby wierszy z bazy danych (sprawdzenie czy zlecenie istnieje)
                int wiersze = komenda.ExecuteNonQuery();

                //Informacja o zmianie statusu
                if(wiersze > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Koszt został zaaktualizowany!");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Zlecenie nie istnieje!");
                    Console.ResetColor();
                }
            }
        }
    }

    public void RaporMiesieczny(int miesiac)
    {
        double sumaKosztow = 0;
        string nazwaMiesiaca = "Nieznany miesiąc";
        if (miesiac > 0 && miesiac < 13)
        {
            switch (miesiac)
            {
                case 1:
                    nazwaMiesiaca = "Styczeń";
                    break;
                case 2:
                    nazwaMiesiaca = "Luty";
                    break;
                case 3:
                    nazwaMiesiaca = "Marzec";
                    break;
                case 4:
                    nazwaMiesiaca = "Kwiecień";
                    break;
                case 5:
                    nazwaMiesiaca = "Maj";
                    break;
                case 6:
                    nazwaMiesiaca = "Czerwiec";
                    break;
                case 7:
                    nazwaMiesiaca = "Lipiec";
                    break;
                case 8:
                    nazwaMiesiaca = "Sierpień";
                    break;
                case 9:
                    nazwaMiesiaca = "Wrzesień";
                    break;
                case 10:
                    nazwaMiesiaca = "Październik";
                    break;
                case 11:
                    nazwaMiesiaca = "Listopad";
                    break;
                case 12:
                    nazwaMiesiaca = "Grudzień";
                    break;

            }

            //Pobranie listy zlecen z Bazy danych
            List<Zlecenie> listaZlecen = PobierzZlecenia();

            foreach (Zlecenie zlecenie in listaZlecen)
            {
                if (zlecenie.DataUtworzenia.Month == miesiac)
                {
                    sumaKosztow += zlecenie.KosztZlecenia;
                }  
            }
            
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Podany miesiąc jest nieprawidłowy!");
            Console.ResetColor();
        }
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Koszty zleceń w miesiącu {nazwaMiesiaca} wynoszą: {sumaKosztow} zł ");
        Console.ResetColor();
    }
        
};