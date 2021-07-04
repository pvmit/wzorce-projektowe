using System;
using System.Collections.Generic;
using System.Timers;
/*using System.Threading;
using System.Threading.Tasks;*/

namespace obserwator
{
    public interface IObserver
    {
        public void Update(string t);
    }

    public interface ISubject
    {
        public void GetTime(Watch watch);
        public void Remove(Watch watch);
        public void Notify();

    }

    public class Watch : IObserver
    {
        string place;

        

        public Watch(string name)
        {
            place = name;          
        }

        public void Update(string t)
        {
            Console.WriteLine("W " + place + " jest godzina " + t);
        }
    }

    public class Systemw : ISubject
    {
        private List<Watch> watches = new List<Watch>();

        string time = DateTime.Now.ToString("HH:mm:ss");

       

    public void GetTime(Watch observer)
        {
            bool isExist = watches.Contains(observer);
            if (!isExist)
                watches.Add(observer);
            else
                Remove(observer);
        }

        public void Remove(Watch observer)
        {
            watches.Remove(observer);
        }

        public void Notify()
        {
            time = DateTime.Now.ToString("HH:mm:ss");
            foreach (Watch watch in watches)
                watch.Update(time);

        }


    }



    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("1. Aby uruchomić zegar centralny naciśnij " + 1 + ".");
            Console.WriteLine("2. W celu dodania/usunięcia wyświetlacza pokojowego naciśnij " + 2 + ".");
            Console.WriteLine("3. W celu dodania/usunięcia wyświetlacza kuchennego naciśnij " + 3 + ".");
            Console.WriteLine("4. W celu dodania/usunięcia wyświetlacza ogrodowego naciśnij " + 4 + ".");
            Console.WriteLine("5. Aby zatrzymać działanie programu naciśnij " + 0 + ".");
            Watch pok = new Watch("pokoju");
            Watch kuch = new Watch("kuchni");
            Watch ogr = new Watch("ogrodzie");

            bool work = true;

            Systemw systemw = new Systemw();

            


            while (work)
            {
                int option = int.Parse(Console.ReadKey().KeyChar.ToString());
                Console.WriteLine();
                switch (option)
                {
                    case 1:       
                        Console.WriteLine("\nZegar centralny uruchomiony");
                        
                        Timer aTimer = new System.Timers.Timer(10000);    
                        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                        
                        aTimer.Interval = 2000;
                        aTimer.Enabled = true;
                        void OnTimedEvent(object source, ElapsedEventArgs e)
                        {
                            systemw.Notify();
                        }
                        break;

                    case 2:                          
                        systemw.GetTime(pok);
                        break;

                    case 3:                       
                        systemw.GetTime(kuch);
                        break;
                    case 4:                      
                        systemw.GetTime(ogr);
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

