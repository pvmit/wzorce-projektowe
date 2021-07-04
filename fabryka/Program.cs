using System;

namespace fabryka
{
    public enum Jednostki
    {
        Zolnierz, Czolg, Helikopter, Samolot, Statek, Lodz
    }

    public interface IJednostkaNaziemna
    {
        string stworzNaziemna();
    }

    public interface IJednostkaPowietrzna
    {
        public string stworzPowietrzna();
    }

    public interface IJednostkaWodna
    {
        public string stworzWodna();
    }

    public class Zolnierz : IJednostkaNaziemna
    {
        string nazwa;

        public Zolnierz()
        {
            nazwa = "Żołnierz";
        }

        public string stworzNaziemna()
        {
            return ("Stworzono " + nazwa);
        }
    }

    public class Czolg : IJednostkaNaziemna
    {
        string nazwa;

        public Czolg()
        {
            nazwa = "Czołg";
        }

        public string stworzNaziemna()
        {
            return ("Stworzono " + nazwa);
        }
    }
    public class Helikopter : IJednostkaPowietrzna
    {
        string nazwa;

        public Helikopter()
        {
            nazwa = "Helikopter";
        }

        public string stworzPowietrzna()
        {
            return ("Stworzono " + nazwa);
        }
    }

    public class Samolot : IJednostkaPowietrzna
    {
        string nazwa;

        public Samolot()
        {
            nazwa = "Samolot";
        }

        public string stworzPowietrzna()
        {
            return ("Stworzono " + nazwa);
        }
    }

    public class Statek : IJednostkaWodna
    {
        string nazwa;

        public Statek()
        {
            nazwa = "Statek";
        }

        public string stworzWodna()
        {
            return ("Stworzono " + nazwa);
        }
    }

    public class Lodz : IJednostkaWodna
    {
        string nazwa;

        public Lodz()
        {
            nazwa = "Łódź";
        }

        public string stworzWodna()
        {
            return ("Stworzono " + nazwa);
        }
    }
    
    public class Koszary 
    {               
        public IJednostkaNaziemna CreateMinion(Jednostki typ)
        { 
            switch(typ)
            {
                case Jednostki.Zolnierz:
                    return new Zolnierz();

                case Jednostki.Czolg:
                    return new Czolg();

                default:
                    throw new Exception() ;
            
            }
                
        }
       
    }
    public class Hangar 
    {
        public IJednostkaPowietrzna CreateMinion(Jednostki typ)
        {
            switch (typ)
            {
                case Jednostki.Helikopter:
                    return new Helikopter();

                case Jednostki.Samolot:
                    return new Samolot();

                default:
                    throw new Exception();

            }

        }
    }
    public class Port 
    {
        public IJednostkaWodna CreateMinion(Jednostki typ)
        {
            switch (typ)
            {
                case Jednostki.Statek:
                    return new Statek();

                case Jednostki.Lodz:
                    return new Lodz();

                default:
                    throw new Exception();

            }

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            /*Console.WriteLine("1. Aby stworzyć koszary naciśnij " + 1 + ".");
            Console.WriteLine("2. Aby stworzyć hangar naciśnij " + 2 + ".");
            Console.WriteLine("3. Aby stworzyć port naciśnij " + 3 + ".");
            Console.WriteLine("4. Aby wrócić do głównego menu naciśnij " + 9 + ".");
            Console.WriteLine("5. Aby zatrzymać działanie programu naciśnij " + 0 + ".");*/

            bool work = true;

            while (work)
            {
                Console.WriteLine("1. Aby stworzyć koszary naciśnij " + 1 + ".");
                Console.WriteLine("2. Aby stworzyć hangar naciśnij " + 2 + ".");
                Console.WriteLine("3. Aby stworzyć port naciśnij " + 3 + ".");
                Console.WriteLine("4. Aby wrócić do głównego menu naciśnij " + 9 + ".");
                Console.WriteLine("5. Aby zatrzymać działanie programu naciśnij " + 0 + ".");

                int option = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                
                switch (option)
                {
                    
                    case 1:
                        Koszary koszary = new Koszary();

                        int i = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();
                        bool go = true;
                        while (go)
                            switch (i)
                            {
                                case 1:
                                    IJednostkaNaziemna zolnierz = koszary.CreateMinion(Jednostki.Zolnierz);
                                    Console.WriteLine(zolnierz.stworzNaziemna());
                                    i = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    IJednostkaNaziemna czolg = koszary.CreateMinion(Jednostki.Czolg);
                                    Console.WriteLine(czolg.stworzNaziemna());
                                    i = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 9:
                                    go = false;
                                    break;
                                case 0:
                                    go = false;
                                    work = false;
                                    break;
                                default:
                                    Console.WriteLine("Nie ma takiej opcji, spróbuj jeszcze raz");
                                    i = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                            }
                        break;
                    case 2:
                        Hangar hangar = new Hangar();

                        int j = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();
                        bool go2 = true;
                        while (go2)
                            switch (j)
                            {
                                case 1:
                                    IJednostkaPowietrzna helikopter = hangar.CreateMinion(Jednostki.Helikopter);
                                    Console.WriteLine(helikopter.stworzPowietrzna());
                                    j = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    IJednostkaPowietrzna samolot = hangar.CreateMinion(Jednostki.Samolot);
                                    Console.WriteLine(samolot.stworzPowietrzna());
                                    j = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                                case 9:
                                    go2 = false;
                                    break;
                                case 0:
                                    go2 = false;
                                    work = false;
                                    break;
                                default:
                                    Console.WriteLine("Nie ma takiej opcji, spróbuj jeszcze raz");
                                    j = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                            }
                        break;                   
                    case 3:
                        Port port = new Port();

                        int a = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();
                        bool go3 = true;
                        while (go3)
                            switch (a)
                            {
                                case 1:
                                    IJednostkaWodna statek = port.CreateMinion(Jednostki.Statek);
                                    Console.WriteLine(statek.stworzWodna());
                                    a = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    IJednostkaWodna lodz = port.CreateMinion(Jednostki.Lodz);
                                    Console.WriteLine(lodz.stworzWodna());
                                    a = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                                case 9:
                                    go3 = false;
                                    break;
                                case 0:
                                    go3 = false;
                                    work = false;
                                    break;
                                default:
                                    Console.WriteLine("Nie ma takiej opcji, spróbuj jeszcze raz");
                                    a = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                            }
                        break;
                    case 9:

                        break;
                    case 0:
                        work = false;
                        break;
                    default:
                        Console.WriteLine("Nie ma takiej opcji");
                        break;
                }

            }

           
        }
    }
}
