using System;
namespace Cwiczenie_2;

    class Student
    {
        //Wyciszenie warningów na początku programu
        #pragma warning disable
        private string imie;
        public string Imie
        {
            get { return imie ; }
            set { imie = value ;}
        }
        private int wiek;
        public int Wiek
        {
            get { return wiek ; }
            set { wiek = value ;}
        }
        private string kierunek;
        public string Kierunek
        {
            get { return kierunek ; }
            set { kierunek = value ;}
        }
        private bool urlop = false;
        public bool Urlop
        {
            get { return urlop ; }
            set { urlop = value ;}
        }

        //Konstruktory
        public Student (string imie, int wiek, string kierunek)
        {
            this.imie = imie;
            this.wiek = wiek;
            this.kierunek = kierunek;
            urlop = false;
        }

        public Student(string imie, int wiek, string kierunek,bool urlop)
        {
            this.imie = imie;
            this.wiek = wiek;
            this.kierunek = kierunek;
            this.urlop = urlop;
        }

        public Student()
        {
            
        }

        //Metody
        public void WezUrlop()
        {
            urlop = true;
        }

        public string Statut()
        {
            if(urlop == true)
            {
                return "Student przebywa na urlopie dziekańskim";
                
                
            }
            else
            {
                return "Student studiuje";
                
            }
        }

    //Override bo nadpisujemy klase bazowa
    public override string ToString()
    {
        return $"Imię: {imie}, Wiek: {wiek}, Kierunek: {kierunek}, Statut: {Statut()}";
    }

        
        
    }
    class Program
    {
        static void Main()
        {
            //Tworzenie obiektu
            Student student = new Student("Mateusz",31,"Informatyka");

            Console.WriteLine(student);

            //Wziecie urlopu przez studenta
            student.WezUrlop();

            Console.WriteLine(student);
        }
    }

