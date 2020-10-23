using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list1 = new LinkedList<int>(1,2,3);
            list1.AddFirst(0);
            list1.AddLast(4);
            list1.Show();
            Console.WriteLine();

            LinkedList<string> list2 = new LinkedList<string>("б", "в", "г");
            list2.AddFirst("а");
            list2.AddLast("д");
            list2.Show();
            Console.WriteLine();

            LinkedList<double> list3 = new LinkedList<double>(1.5, 2.5, 3.5);
            list3.AddFirst(0.5);
            list3.AddLast(4.5);
            list3.Show();
            Console.WriteLine();

            LinkedList<char> list4 = new LinkedList<char>('1', '2', '3');
            list4.AddFirst('0');
            list4.AddLast('4');
            list4.Show();
            Console.WriteLine();

            //3.Даны упорядоченные списки L1 и L2.Вставить элементы списка L2 в список L1, не нарушая его упорядоченности.
            Console.WriteLine("Задание: ");
            LinkedList<int> L1 = new LinkedList<int>(1, 3, 5, 7, 9);
            LinkedList<int> L2 = new LinkedList<int>(2, 3, 4, 6, 8, 10);
            Console.Write("L1 : ");
            L1.Show();
            Console.WriteLine();
            Console.Write("L2 : ");
            L2.Show();
            Console.WriteLine();
            foreach (Item<int> item1 in L1)
            {
                foreach (Item<int> item2 in L2)
                {
                    if(item2.Data <= item1.Data)
                    {
                        L1.AddBeforeTarget(item2.Data, item1);
                        L2.RemoveTarget(item2);
                    }
                }
            }
            while (!L2.isEmpty())
            {
                foreach (Item<int> item in L2)
                {
                    L1.AddLast(item.Data);
                    L2.RemoveTarget(item);
                }
            }
            Console.Write("Ответ: ");
            L1.Show();
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
