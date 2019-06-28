using System;
using System.Text;

namespace GenericsHomework
{
    public class GenericList<T> where T:class
    {
        private T[] elemente;
        private int count = 0;
        private int capacity;

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int Capacity
        {
            set
            {
                if (value==null)
                {
                    throw new ArgumentNullException("Capacity cannot be null!");
                }
                if (value.GetType()!=12.GetType())
                {
                    throw new FormatException("Capacity should be Integer");
                }
                this.capacity = value;
            }
            get { return this.capacity; }
        }
        //constructor 
        public GenericList(int Capacity)
        {
            this.elemente = new T[Capacity];
            this.capacity = Capacity;
        }
        //Access element by index
        public T this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException(String.Format(
                        "Invalid index: {0}.", index));
                }
                T result = elemente[index];
                return result;
            }
        }

        //Accessing element by index - v2
        public T GiveElementByIndex(int index)
        {
            if (index > count)
            {
                throw new IndexOutOfRangeException($"Introduced index is out of range. We have only {this.count} elements");
            }
            else
                return elemente[index];
        }
        //inserting element at given position
        public void InsertElement(T element, int position)
        {
            if (position > elemente.Length)
            {
                throw new IndexOutOfRangeException($"We cannot insert a value on position {position} because the capacity is {elemente.Length}");
            }
            else
            {
                if (elemente[position] == null)
                {
                    elemente[position] = element;
                }
                else
                {
                    var x = elemente[position];
                    elemente[position] = element;
                    if (count >= elemente.Length)
                    {
                        throw new IndexOutOfRangeException($"The element {x} that was on position {position} couldn't be saved because we exceeded the capacity (max capacity:{elemente.Length}");
                    }
                    else
                    {
                        this.elemente[count] = element;
                        count++;
                    }
                }
            }
        }

        //Adding element
        public void Add(T element)
        {
            if (count >= elemente.Length)
            {
                Resize(this.capacity);
                throw new IndexOutOfRangeException($"The list capacity of {elemente.Length} was exceeded. Try again because we are trying to resize it.");
            }
            this.elemente[count] = element;
            count++;
        }
        //Remove At given index
        public void RemoveAt(int index)
        {
            //verific daca elemente nu e gol
            if (elemente.Length == 0 || index > this.count || index<0)
            {
                throw new IndexOutOfRangeException("The specified index is not valid, because the Generic List is empty");
            }
            else
            {
                while (elemente[index + 1] != null)
                    elemente[index] = elemente[index + 1];
                Console.WriteLine($"Element from index {index} has been removed");
            }
        }
        
        //finding element by its value
        public int? FindElementsPosition(T value)
        {
            for (var v=0; v<elemente.Length; v++)
            {
                if (elemente[v] == value)
                    return v;
            }
            return null;
        }

        //clearing the list
        public void ClearList()
        {
            for (var a=0;a<elemente.Length;a++)
            {
                elemente[a] = null;
            }
            this.count = 0;
        }
        //ToString()
        public override string ToString()
        {
            StringBuilder c = new StringBuilder();
            foreach (var v in elemente)
            {
                if (v!=null)
                    c.Append($"Elementul {v}\n");
            }
            return Convert.ToString(c);
        }
        //PROBLEM 2
        private void Resize(int capacity)
        {
            if (capacity > this.Capacity)
            {
                this.capacity *= 2;
                Array.Resize(ref this.elemente, this.Capacity);
            }
        }
        //PROBLEM 3 - TO BE DONE HOME 




    }
}
