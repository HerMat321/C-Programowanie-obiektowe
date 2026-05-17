using System;
using System.Collections.Generic;
namespace SoszApp;

//Interfejs Bazy Zlecen (czyli taka "umowa" co ma byc w kazdej Bazie Zlecen)
interface IBazaZlecen
{
    void DodajZlecenie(string klient, string opis);
    void ZmienStatus(int id,string status);
    void ZamknijZlecenie(int id);
    void UsunZlecenie(int id);
    void PrzypiszSerwisanta(int id,string serwisant);
    void KosztZlecenia(int id, double godziny, double kilometry);
    void RaporMiesieczny(int miesiac);
    List<Zlecenie> PobierzZlecenia();
}