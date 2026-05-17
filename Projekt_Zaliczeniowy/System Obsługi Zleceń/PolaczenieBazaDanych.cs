using MySql.Data.MySqlClient;
namespace SoszApp;

//Klasa finalna - polaczenie z baza danych nie ma potrzeby dziedziczenia, nie bedzie rozszerzane , pelni tylko jedna funkcje, polaczenia z baza danych
sealed class PolaczenieBazaDanych
{
    //zmienna przechowujaca dane potrzebne do polaczenia z baza danych
    private static string polaczenie = "server=localhost;user=root;password=;database=soszapp;";

    //Metoda ktora zwraca nam polaczenie z baza danych w MySQL
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(polaczenie);
    }
}