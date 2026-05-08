using System;
namespace SoszApp;
class Program
{
    //Funkcje Menu
    static int WybierzOpcje()
    {
        //Wyciszenie warningów na początku programu
        #pragma warning disable

        //Wybor opcji przez uzytkownika
        string wyborOpcji = Console.ReadLine();

        //Walidacja wybranej opcji przez uzytkownika
        if(int.TryParse(wyborOpcji, out int opcjaUzytkownika) && (opcjaUzytkownika < 10) && (opcjaUzytkownika > 0))
        {
            return opcjaUzytkownika;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Taka opcja nie istnieje!\n");
            Console.ResetColor();
            System.Threading.Thread.Sleep(1500);
        }
        return opcjaUzytkownika;
    }

    static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n");
        Console.WriteLine("\t\t\t\t\t\t Witamy w SOZS M&R Tech Services!");
        Console.WriteLine("\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Wybierz jedną z poniższych opcji w Menu Nawigacyjnym\n");
        Console.ResetColor();

        Console.WriteLine("-------------------------------");
        Console.WriteLine("1. Dodaj nowe zlecenie serwisowe");
        Console.WriteLine("2. Wyświetl zlecenia serwisowe");
        Console.WriteLine("3. Zamknij zlecenie serwisowe");
        Console.WriteLine("4. Usuń zlecenie serwisowe");
        Console.WriteLine("5. Oblicz koszty danego zlecenia");
        Console.WriteLine("6. Przypisz zlecenie do serwisanta");
        Console.WriteLine("7. Nadaj status zlecenia");
        Console.WriteLine("8. Generuj raport miesięczny");
        Console.WriteLine("9. Wyjdź z aplikacji");
        Console.WriteLine("-------------------------------");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Wybierz opcję: ");
        Console.ResetColor();
    }
    static void Main()
    {
        //Tytuł programu w konsoli
        Console.Title = "System Obsługi Zleceń Serwisowych Firmy M&R Tech Services"; 

        //BazaZlecen w której przechowujemy obiekty Zlecen
        BazaZlecen bazaZlecen = new BazaZlecen();
        
        //Pętla nawigacyjna Menu Tekstowego
        while(true)
        {
            Menu();
            int wyborUzytkownika = WybierzOpcje();

            if (wyborUzytkownika == 1)
            {Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("Podaj nazwę zlecenia: ");
                Console.ResetColor();
                string nazwa = Console.ReadLine();
                Console.WriteLine("\n");

                Console.ResetColor();

                //Dodanie zlecenia do bazy zlecen
                bazaZlecen.DodajZlecenie(nazwa);

                System.Threading.Thread.Sleep(1500);

            }
            else if (wyborUzytkownika == 2)
            {
                Console.WriteLine("Aktualne zlecenia serwisowe:\n");

                //Pobranie listy zlecen z bazyZlecen 
                foreach (Zlecenie zlecenie in bazaZlecen.PobierzZlecenia())
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"ID: {zlecenie.Id}\n NAZWA: {zlecenie.Klient}\n DATA UTWORZENIA: {zlecenie.DataUtworzenia}\n STATUS: {zlecenie.Status}\n SERWISANT: {zlecenie.Serwisant}\n KOSZT ZLECENIA: {zlecenie.KosztZlecenia} zł ");

                    Console.WriteLine("---------------------------------------");
                    Console.ResetColor();
                }
            }
            else if (wyborUzytkownika == 3)
            {
                //Zamykanie zlecenia
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zamknij zlecenie!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj ID zlecenia: ");
                Console.ResetColor();
                string podaneId = Console.ReadLine();
                int.TryParse(podaneId,out int idZlecenia);

                //Walidacja danych wprowadzonych przez użytkownika
                if(idZlecenia > 0)
                {
                    
                    bazaZlecen.ZamknijZlecenie(idZlecenia);

                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Wprowadzone dane są nieprawidłowe!");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }

                System.Threading.Thread.Sleep(1500);
            }
            else if (wyborUzytkownika == 4)
            {
                //Usuwanie zlecenia
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Usuń zlecenie!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj ID zlecenia: ");
                Console.ResetColor();
                string podaneId = Console.ReadLine();
                int.TryParse(podaneId,out int idZlecenia);

                //Walidacja danych wprowadzonych przez użytkownika
                if(idZlecenia > 0)
                {
                    
                    bazaZlecen.UsunZlecenie(idZlecenia);

                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Wprowadzone dane są nieprawidłowe!");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }

                System.Threading.Thread.Sleep(1500);
            }
            else if (wyborUzytkownika == 5)
            {
                //Obliczanie kosztu zlecenia
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Dodaj koszty do zlecenia!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj ID zlecenia: ");
                Console.ResetColor();
                string podaneId = Console.ReadLine();
                int.TryParse(podaneId,out int idZlecenia);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj godziny przepracowane na zleceniu: ");
                Console.ResetColor();
                string podaneGodziny = Console.ReadLine();
                double.TryParse(podaneGodziny,out double przepracowaneGodziny);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj kilometry dojazdu do klienta: ");
                Console.ResetColor();
                string podaneKilometry = Console.ReadLine();
                double.TryParse(podaneKilometry,out double przejechaneKilometry);



                //Walidacja danych wprowadzonych przez użytkownika
                if(idZlecenia > 0)
                {
                    
                    bazaZlecen.KosztZlecenia(idZlecenia,przepracowaneGodziny,przejechaneKilometry);

                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Wprowadzone dane są nieprawidłowe!");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }

                System.Threading.Thread.Sleep(1500);
            }
            else if (wyborUzytkownika == 6)
            {
                //Przypisywanie zlecenia do serwisanta
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Przypisz serwisanta do zlecenia!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj ID zlecenia: ");
                Console.ResetColor();
                string podaneId = Console.ReadLine();
                int.TryParse(podaneId,out int idZlecenia);

                //Walidacja danych wprowadzonych przez użytkownika
                if(idZlecenia > 0)
                {
                    Console.Write("Podaj dane serwisanta: ");
                    string daneSerwisanta = Console.ReadLine();
                    bazaZlecen.PrzypiszSerwisanta(idZlecenia,daneSerwisanta);
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Wprowadzone dane są nieprawidłowe!");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }

                System.Threading.Thread.Sleep(1500);
            }
            else if (wyborUzytkownika == 7)
            {
                //Nadawanie nowego statusu zlecenia
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nadaj nowy status zlecenia!\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Podaj ID zlecenia: ");
                Console.ResetColor();
                string podaneId = Console.ReadLine();
                int.TryParse(podaneId,out int idZlecenia);

                //Walidacja danych wprowadzonych przez użytkownika
                if(idZlecenia > 0)
                {
                    Console.Write("Podaj nowy status zlecenia: ");
                    string nowyStatus = Console.ReadLine();
                    bazaZlecen.ZmienStatus(idZlecenia,nowyStatus);
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Wprowadzone dane są nieprawidłowe!");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                }
                

            }
            else if (wyborUzytkownika == 8)
            {
                Console.WriteLine("Generowanie raportu miesięcznego");

                System.Threading.Thread.Sleep(1500);
            }
            else if (wyborUzytkownika == 9)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Do zobaczenia!");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1500);
                break;
            }
        }
    }
};