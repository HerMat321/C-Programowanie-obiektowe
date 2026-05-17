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

    //Menu
    static void Menu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n");
        Console.WriteLine("\t\t\t\t\t\t Witamy w S-O-S-Z M&R Tech Services!");
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
        Console.WriteLine("5. Dodaj koszty danego zlecenia");
        Console.WriteLine("6. Przypisz zlecenie do serwisanta");
        Console.WriteLine("7. Nadaj status zlecenia");
        Console.WriteLine("8. Generuj raport kosztów z danego miesiąca");
        Console.WriteLine("9. Wyjdź z aplikacji");
        Console.WriteLine("-------------------------------");

        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Wybierz opcję: ");
        Console.ResetColor();
    }
    static void Main()
    {
        //Tytuł programu w konsoli
        Console.Title = "System Obsługi Serwisowych Zleceń Firmy M&R Tech Services"; 

        //BazaZlecen w której przechowujemy obiekty Zlecen
        IBazaZlecen bazaZlecen = new BazaZlecen();

        //System Logowania
        Uzytkownik aktualnyUzytkownik = null;
        
        //Na sztywno przypisane loginy i hasła (w miarę rozwoju programu przeniesione do bazy danych i zahaszowane)
        string loginAdministratora = "admin";
        string loginPracownika = "user";

        string hasloAdministratora = "admin";
        string hasloPracownika = "user";
    
        while(aktualnyUzytkownik == null)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Login: ");
            Console.ResetColor();
            string login = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Hasło: ");
            Console.ResetColor();
            string haslo = Console.ReadLine();

            if(login == loginAdministratora && haslo == hasloAdministratora)
            {
                aktualnyUzytkownik = new Administrator(login,haslo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zalogowano jako Administrator!");
                Console.ResetColor();

            }
            else if (login == loginPracownika && haslo == hasloPracownika)
            {
                aktualnyUzytkownik = new Pracownik(login,haslo);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Zalogowano jako Pracownik!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Nieprawidłowy login lub hasło!");
                Console.ResetColor();
            }
        }
        
        //Pętla nawigacyjna Menu Tekstowego
        while(true)
        {
            Menu();
            int wyborUzytkownika = WybierzOpcje();

            //Dodawanie zlecenia
            if (wyborUzytkownika == 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("Podaj nazwę zlecenia: ");
                Console.ResetColor();
                string nazwa = Console.ReadLine();
                Console.WriteLine("\n");
                

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write("Podaj opis zlecenia: ");
                Console.ResetColor();
                string opis = Console.ReadLine();
                

                Console.ResetColor();

                //Dodanie zlecenia do bazy zlecen
                bazaZlecen.DodajZlecenie(nazwa,opis);

                System.Threading.Thread.Sleep(1500);

            }
            else if (wyborUzytkownika == 2)
            {
                Console.WriteLine("Aktualne zlecenia serwisowe:\n");

                //Pobranie listy zlecen z bazyZlecen 
                foreach (Zlecenie zlecenie in bazaZlecen.PobierzZlecenia())
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("ID: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.Id}\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("NAZWA: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.Klient}\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("DATA UTWORZENIA: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.DataUtworzenia}\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("STATUS: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.Status}\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("SERWISANT: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.Serwisant}\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("KOSZT ZLECENIA: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.KosztZlecenia} zł\n");

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("OPIS: ");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{zlecenie.Opis}\n");

                    Console.ResetColor();

                    Console.WriteLine("---------------------------------------");
                   
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
                    
                    if (aktualnyUzytkownik.CzyMozeUsunacZlecenie() == true)
                    {
                        bazaZlecen.UsunZlecenie(idZlecenia);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Brak uprawnień do usuwania zleceń!");
                        Console.ResetColor();
                    }

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
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Podaj dane serwisanta: ");
                    Console.ResetColor();
                    string daneSerwisanta = Console.ReadLine();
                    bazaZlecen.PrzypiszSerwisanta(idZlecenia,daneSerwisanta);

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
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Podaj nowy status zlecenia: ");
                    Console.ResetColor();
                    string nowyStatus = Console.ReadLine();
                    bazaZlecen.ZmienStatus(idZlecenia,nowyStatus);

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
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("Generowanie raportu miesięcznego");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Podaj numer miesiąca, dla którego chcesz wygenerować raport: ");
                Console.ResetColor();
                string podanyMiesiac = Console.ReadLine();
                int.TryParse(podanyMiesiac,out int miesiac);

                bazaZlecen.RaporMiesieczny(miesiac);

                
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