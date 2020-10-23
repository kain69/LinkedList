namespace LinkedList
{
    // Класс элемента списка
    public class Item<T>
    {
        // Значение элемента
        public T Data { get; } = default;
        // Ссылка на следующий элемент
        public Item<T> Next { get; set; }

        public Item(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
