DynamicArray a = new DynamicArray();
Console.Write("Введите сколько значений хотите ввести n = ");
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    Console.Write($"Введите {i+1}-й element = ");
    a.Append(Convert.ToInt32(Console.ReadLine()));
}
a.Output();

Console.Write("\nЧтение элемента по индексу: \n" +
    "Введите index = ");
int index = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Элемент под индексом {index}: {a.GetElem(index)}");

Console.Write("Запись элемента по индексу: \n" +
    "Введите index = ");
index = Convert.ToInt32(Console.ReadLine());
Console.Write($"Введите element = ");
int element = Convert.ToInt32(Console.ReadLine());
a.SetElem(index, element);
a.Output();

Console.Write("\nДобавление элемента в конце массива: \n" +
    "Введите element = ");
element = Convert.ToInt32(Console.ReadLine());
a.Append(element);
a.Output();

Console.WriteLine("\nУдаление последнего элемента: ");
a.Pop();
a.Output();

Console.Write("\nВставка элемента по индексу: \n" +
    "Введите index = ");
index = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите element = ");
element = Convert.ToInt32(Console.ReadLine());
a.Insert(index, element);
a.Output();

Console.Write("\nУдаление элемента по индексу: \n" +
    "Введите index = ");
index = Convert.ToInt32(Console.ReadLine());
a.RemoveAt(index);
a.Output();

Console.Write("\nУдаление элемента по значению: \n" +
    "Введите element = ");
element = Convert.ToInt32(Console.ReadLine());
a.Remove(element);
a.Output();

Console.WriteLine($"\nВозврат индекса максимального значения: {a.Max()}");

Console.WriteLine($"Проверка на переполнение: {a.IsFull()}");

Console.WriteLine($"Возврат количества элементов: {a.Size()}");
public class DynamicArray
{
    private int[] array;
    private int size;
    private int capacity;

    public DynamicArray(int capacity = 4)
    {
        this.capacity = capacity;
        array = new int[capacity];
        size = 0;
    }

    private void Resize()
    {
        capacity *= 2;
        int[] newArray = new int[capacity];
        Array.Copy(array, newArray, size);
        array = newArray;
    }

    public void Output()
    {
        for (int i = 0; i < size; i++)
        {
            Console.Write($"{array[i]} ");
        }
    }

    public int GetElem(int index)
    {
        return array[index];
    }

    public void SetElem(int index, int value)
    {
        if (index >= 0 && index < capacity) array[index] = value;
    }

    public void Append(int value)
    {
        if (IsFull())
        {
            Resize();
        }
        array[size] = value;
        size++;
    }
    public void Pop()
    {
        array[size - 1] = 0;
        size--;
    }

    public void Insert(int index, int value)
    {
        if (index >= 0 && index < size)
        {
            if (IsFull()) Resize();
            for (int i = size; i > index; i--)
            {
                array[i] = array[i - 1];
            }
            array[index] = value;
            size++;
        }
    }
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < size)
        {
            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
        }
    }
    public void Remove(int value)
    {
        for (int i = 0; i < size; i++)
        {
            if (array[i] == value)
            {
                RemoveAt(i);
                i--;
            }
        }
    }

    public int Max()
    {
        int maxIndex = 0;
        for (int i = 1; i < this.size; i++)
        {
            if (array[i] > array[maxIndex])
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }

    public bool IsFull()
    {
        return size == capacity;
    }

    public int Size()
    {
        return size;
    }
}