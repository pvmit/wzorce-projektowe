using System;
using System.Collections.Generic;
using System.Linq;

namespace strategia
{

    abstract class SortStrategy
    {
        public abstract void Sort(List<int> lista);
        
    }

    class BublleSort : SortStrategy
    {
        public override void Sort(List<int> lista)
        {
            int size = lista.Count-1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < (size - i); j++)
                {
                    if (lista[j] > lista[j + 1])
                    {
                        int temp = lista[j];
                        lista[j] = lista[j + 1];
                        lista[j + 1] = temp;
                    }
                }
            }
        }
    }

    class InserSort : SortStrategy
    {
        public override void Sort(List<int> lista)
        {
            int n = lista.Count - 1;
            for (int i = 1; i < n; ++i)
            {
                int key = lista[i];
                int j = i - 1;

                while (j >= 0 && lista[j] > key)
                {
                    lista[j + 1] = lista[j];
                    j = j - 1;
                }
                lista[j + 1] = key;
            }
        }
    }

    class MergeSort : SortStrategy
    {
        public override void Sort(List<int> lista)
        {          
            MergeSort_Recursive(lista, 0, lista.Count - 1);
        }

        public void MergeSort_Recursive(List<int> lista, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(lista, left, mid);
                MergeSort_Recursive(lista, (mid + 1), right);

                DoMerge(lista, left, (mid + 1), right);
            }
        }

        public void DoMerge(List<int> lista, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (lista[left] <= lista[mid])
                    temp[tmp_pos++] = lista[left++];
                else
                    temp[tmp_pos++] = lista[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = lista[left++];

            while (mid <= right)
                temp[tmp_pos++] = lista[mid++];

            for (i = 0; i < num_elements; i++)
            {
                lista[right] = temp[right];
                right--;
            }
        }
    }

    class SortingMethod
    {
        private SortStrategy _sortStrategy;
        private List<int> list;

        public void SetSortStrategy(SortStrategy sortStrategy)
        {
            this._sortStrategy = sortStrategy;
        }

        private void SetList(List<int> lista)
        {
            list = lista;
        }

        public void Sort(List<int> list)
        {
            _sortStrategy.Sort(list);
        }
        public void Access(List<int> lista)
        {
            Console.WriteLine();
            for (int i = 0; i < lista.Count; i++)
                Console.WriteLine(lista[i]);
        }

    }


    class Program
    {
    
        static void Main(string[] args)
        {
            SortingMethod sortingMethod = new SortingMethod();
            
            List<int> liczby = new List<int>();
                    
            bool work = true;
            while (work)
            {
                Console.Clear();
                Console.WriteLine("Menu");
                int option = int.Parse(Console.ReadKey().KeyChar.ToString());

                switch (option)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Add number");
                        int number = int.Parse(Console.ReadLine());
                        liczby.Add(number);
                        break;

                    case 2:
                        Console.Clear();
                        sortingMethod.SetSortStrategy(new BublleSort());
                        sortingMethod.Sort(liczby);
                        sortingMethod.Access(liczby);
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        sortingMethod.SetSortStrategy(new InserSort());
                        sortingMethod.Sort(liczby);
                        sortingMethod.Access(liczby);
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Clear();
                        sortingMethod.SetSortStrategy(new MergeSort());
                        sortingMethod.Sort(liczby);
                        sortingMethod.Access(liczby);
                        Console.ReadKey();
                        break;

                    case 0:
                        work = false;
                        break;

                    default:
                        Console.WriteLine("incorrect option");                    
                        break;
                }
            }
        }
    }
}
