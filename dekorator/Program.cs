using System;

namespace dekorator
{
    abstract public class MainBohater
    {
        public abstract void Staty(int a, int b, int c, int d, string s);       
    }

    public class Bohater : MainBohater
    {

        int hp;
        int atak;
        int obrona;

        bool[] eqtab = new bool[5];

        public Bohater()
        {
            hp = 100;
            atak = 10;
            obrona = 10;
        


            string a = String.Format("Bohater został utworzony {0}/{1}/{2} (HP/atak/obrona)", hp, atak, obrona);

            Console.WriteLine(a);

        }      

        public override void Staty(int a, int b, int c,int d,string s)
        {
            if (eqtab[d]==false)
            {
                hp += a;
                atak += b;
                obrona += c;
                eqtab[d] = true;
                Console.WriteLine("Dodano " + s);
            }
            else
            {
                hp -= a;
                atak -= b;
                obrona -= c;
                eqtab[d] = false;
                Console.WriteLine("Usunięto " + s);
            }
        

            string text = String.Format("Statystyki bohatera zostały zaktualizowane i wynoszą {0}/{1}/{2} (HP/atak/obrona)", hp, atak, obrona);

            Console.WriteLine(text);
        }

    }



    public abstract class Dekorator : MainBohater
    {
        public abstract override void Staty(int a, int b, int c,int d,string s);
    }

    public class Rekawice : Dekorator
    {
        MainBohater hero;
        int hp = 10;
        int atak = 3;
        int obrona = 4;
        int numer = 0;
        string nazwa = "Rękawice";

        public Rekawice(MainBohater bohater)
        {
            hero = bohater;           
            Staty(hp, atak, obrona, numer,nazwa);
        }

        public override void Staty(int a, int b, int c, int d,String s)
        {
            hero.Staty(a, b, c,d,s);
        }
    }

    public class Buty : Dekorator
    {
        MainBohater hero;
        int hp = 3;
        int atak = 1;
        int obrona = 2;
        int numer = 1;
        string nazwa = "Buty";

        public Buty(MainBohater bohater)
        {
            hero = bohater;
            Staty(hp, atak, obrona, numer, nazwa);
        }

        public override void Staty(int a, int b, int c, int d, String s)
        {
            hero.Staty(a, b, c, d, s);
        }
    }

    public class Spodnie : Dekorator
    {
        MainBohater hero;
        int hp = 5;
        int atak = 3;
        int obrona = 2;
        int numer = 2;
        string nazwa = "Spodnie";

        public Spodnie(MainBohater bohater)
        {
            hero = bohater;
            Staty(hp, atak, obrona, numer, nazwa);
        }

        public override void Staty(int a, int b, int c, int d, String s)
        {
            hero.Staty(a, b, c, d, s);
        }
    }

    public class Helm : Dekorator
    {
        MainBohater hero;
        int hp = 15;
        int atak = 5;
        int obrona = 5;
        int numer = 3;
        string nazwa = "Hełm";

        public Helm(MainBohater bohater)
        {
            hero = bohater;
            Staty(hp, atak, obrona, numer, nazwa);
        }

        public override void Staty(int a, int b, int c, int d, String s)
        {
            hero.Staty(a, b, c, d, s);
        }
    }

    public class Miecz : Dekorator
    {
        MainBohater hero;
        int hp = 25;
        int atak = 10;
        int obrona = 10;
        int numer = 4;
        string nazwa = "Miecz";

        public Miecz(MainBohater bohater)
        {
            hero = bohater;
            Staty(hp, atak, obrona, numer, nazwa);
        }

        public override void Staty(int a, int b, int c, int d, String s)
        {
            hero.Staty(a, b, c, d, s);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Aby stworzyć nowego bohatera naciśnij " + 1 + ".");
            Console.WriteLine("2. W celu dodania/usunięcia rękawic do/z aktualnego bohatera naciśnij " + 2 + ".");
            Console.WriteLine("3. W celu dodania/usunięcia butów do/z aktualnego bohatera naciśnij " + 3 + ".");
            Console.WriteLine("4. W celu dodania/usunięcia spodni do/z aktualnego bohatera naciśnij " + 4 + ".");
            Console.WriteLine("5. W celu dodania/usunięcia hełmu do/z aktualnego bohatera naciśnij " + 5 + ".");
            Console.WriteLine("6. W celu dodania/usunięcia miecza do/z aktualnego bohatera naciśnij " + 6 + ".");
            Console.WriteLine("7. Aby zatrzymać działanie programu naciśnij " + 0 + ".");

            bool work = true;
            while (work)
            {
                

                int option = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        MainBohater bohater = new Bohater();                      
                        
                        int option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();

                        bool work2 = true;

                        while (work2)
                        {
                            switch (option2)
                            {
                                case 1:
                                    Console.WriteLine("Bohater już utworzony");
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 2:                                  
                                    bohater = new Rekawice(bohater);
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 3:
                                    bohater = new Buty(bohater);
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 4:
                                    bohater = new Spodnie(bohater);
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 5:
                                    bohater = new Helm(bohater);
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 6:
                                    bohater = new Miecz(bohater);
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;

                                case 0:
                                    work = false;
                                    work2 = false;
                                    break;

                                default:
                                    Console.WriteLine("Nie ma takiej opcji, spróbuj jeszcze raz");
                                    option2 = int.Parse(Console.ReadKey().KeyChar.ToString());
                                    Console.WriteLine();
                                    break;
                            }
                        }
                        break;

                    case int n when (n > 1 && n < 7):
                        Console.WriteLine("Nie został utworzony bohater");                    
                        break;

                    case 0:                       
                        work = false;
                        break;

                    default:
                        Console.WriteLine("Nie ma takiej opcji, spróbuj jeszcze raz");
                        option = int.Parse(Console.ReadKey().KeyChar.ToString());
                        Console.WriteLine();
                        break;
                }

            }
        }
    }
}
