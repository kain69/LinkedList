using System;
using System.Collections;

namespace LinkedList
{
    class LinkedList<T> : IEnumerable
    {
        // Начало списка
        public Item<T> Head { get; private set; }
        // Конец списка
        public Item<T> Tail { get; private set; }
        // Количество элементов в списке
        public int Count { get; private set; }

        // Конструктор без элементов
        public LinkedList()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Конструктор с первоначальным элементом
        public LinkedList(T data)
        {
            Item<T> item = new Item<T>(data);
            SetHeadTail(item);
        }

        // Конструктор с первоначальным элементом
        public LinkedList(params T[] items)
        {
            foreach (T item in items)
            {
                this.AddLast(item);
            }
        }

        // Чтобы не дублировать, установка когда список пустой
        private void SetHeadTail(Item<T> item)
        {
            Head = item;
            Tail = item;
            Count = 1;
        }

        // Добавление в начало
        public void AddLast(T data)
        {
            Item<T> item = new Item<T>(data);
            if (Head != null)
            {
                Tail.Next = item;
                Tail = item;
                Count++;
            }
            else
            {
                SetHeadTail(item);
            }

        }

        // Добавление в конец
        public void AddFirst(T data)
        {
            Item<T> item = new Item<T>(data);

            if (Head != null)
            {
                item.Next = Head;
                Head = item;
                Count++;
            }
            else
            {
                SetHeadTail(item);
            }
        }

        // Добавление после цели
        public void AddAfterTarget(T data, Item<T> target)
        {
            if (target != Tail) {
                // Создать новый элемент
                Item<T> item = new Item<T>(data);
                // Запомнить указатель next у цели
                Item<T> Onext = target.Next;
                // Вставить новый итем после таргета
                item.Next = Onext;
                target.Next = item;
                Count++;
            }
            else
            {
                this.AddLast(data);
            }
        }

        // Добавление до цели
        public void AddBeforeTarget(T data, Item<T> target)
        {
            if (target == Head)
                this.AddFirst(data);
            else
            {
                // Создать новый элемент
                Item<T> item = Head;
                while(item.Next != target)
                {
                    item = item.Next;   
                }
                Item<T> insert = new Item<T>(data);
                insert.Next = target;
                item.Next = insert;
                Count++;
            }
            
        }

        // Удаление первого 
        public void RemoveFirst()
        {
            Head = Head.Next;
            Count--;
            // Я так понял, что не надо удалять элемент
            // Он же очистится Сборщиком мусора
            // Или нет?
        }

        // Удаление последнего
        public void RemoveLast()
        {
            Item<T> item = Head;
            while(item.Next != Tail)
            {
                item = item.Next;
            }
            Tail = item;
            Count--;
            // Я так понял, что не надо удалять элемент
            // Он же очистится Сборщиком мусора
            // Или нет?
        }

        // Удаление самой цели
        public void RemoveTarget(Item<T> target)
        {
            Item<T> item = Head;
            if(item == target)
            {
                this.RemoveFirst();
            }
            else
            {
                while (item.Next != target)
                {
                    item = item.Next;
                }
                item.Next = target.Next;
                Count--;
            }
            
            // А тут надо, вроде, таргет же должен ссылаться на объект все еще
            // Но вижуалка сказала, можно не удалять
            // Не понял, видимо из-за того, что на на таргет нет указателя в списке и он не нужен больше
            // target = null       
        }

        // Проверка на пустой
        public bool isEmpty()
        {
            if (Count == 0)
                return true;
            return false;
        }

        // Очистка
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Вывод
        public void Show()
        {
            Item<T> item = Head;
            while (item != null)
            while (item != null)
            {
                Console.Write(item.Data + " ");
                item = item.Next;
            }
            Console.WriteLine();
        }

        // Реализация для работы foreach
        public IEnumerator GetEnumerator()
        {
            var item = Head;
            while (item != null)
            {
                yield return item;
                item = item.Next;
            }
        }
    }
}
