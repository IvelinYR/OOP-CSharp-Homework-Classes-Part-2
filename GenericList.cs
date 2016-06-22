namespace GenericClass
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GenericList<T> where T : IComparable<T>
    {
        private T[] data;
        private int nextPosition;

        public GenericList(int initialCapacity)
        {
            this.data = new T[initialCapacity];
        }

        public void Add(T elemnt)
        {
            if (this.data.Length == this.nextPosition)
            {
                this.AutoGrow();
            }

            this.data[nextPosition] = elemnt;
            this.nextPosition++;
        }

        public T this[int index]
        {
            get
            {
                if (index > this.nextPosition - 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.data[index];
            }
            private set
            {
                this.data[index] = value;
            }
        }

        public void Remuve(int index)
        {
            for (int i = index; i < nextPosition && i < (this.data.Length - 1); i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.nextPosition--;
            this.data[nextPosition] = default(T);
        }

        public void Insert(int index, T element)
        {
            if (this.data.Length == this.nextPosition)
            {
                this.AutoGrow();
            }

            for (int i = this.nextPosition; i >= index && i > 0; i--)
            {
                this.data[i] = this.data[i - 1];
            }
            this.data[index] = element;
            this.nextPosition++;
        }

        public void Clear()
        {
            this.data = new T[this.data.Length];
        }

        public T Min()
        {
            if (this.nextPosition == 0)
            {
                throw new ArgumentException("There ara no element!");
            }

            T min = this.data[0];
            foreach (T item in data)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.nextPosition == 0)
            {
                throw new ArgumentException("There ara no element!");
            }

            T max = this.data[0];
            foreach (T item in data)
            {
                if (max.CompareTo(item) < 0)
                {
                    max = item;
                }
            }

            return max;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.nextPosition; i++)
            {
                sb.Append(this.data[i]);
                if (i < this.nextPosition - 1)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString();
        }

        private void AutoGrow()
        {
            var newData = new T[this.data.Length * 2];

            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;
        }
    }
}
