using System;


class Program
{
   public class Punkt
    {
        public int x;
        public int y;

        public Punkt(int wspX, int wspY)
        {
            this.x = wspX;
            this.y = wspY;
        }

        public Punkt(int wspX):this(wspX,wspX){}
        public Punkt():this(0,0){}
    }

    static void Main()
    {
        Punkt punkt = new Punkt(10,20);
        Console.WriteLine("Współrzędne x: {0}",punkt.x);
        Console.WriteLine($"Współrzędne y: {punkt.y}");
        Punkt punkt2 = new Punkt(45);
        Console.WriteLine("Współrzędne x: {0},{1}",punkt2.x,punkt2.x);
        Punkt punkt3 = new Punkt();
        Console.WriteLine($"Współrzędne xy: {punkt3.x},{punkt3.y}");
        Console.Beep();
    }
}