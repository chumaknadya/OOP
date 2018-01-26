using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    public class FoodCollection <T> : IEnumerable<T>,IEnumerator<T> where T : IComparable 
    {
        T[] meal = null;
        int pos = -1;
        private int foodAmount = 0;
        
       
        public FoodCollection()
        {
            meal = new T[100];
        }
        public void Add(T item)
        {
            // Let us only worry about adding the item 
            meal[foodAmount] = item;
            foodAmount++;
        }

        public void Remove(int item)
        {
            if (item == 0) return;
           
            for (int i = item - 1; i < foodAmount; i++)
            {
                meal[i] = meal[i + 1];
            }
            foodAmount--;
        }
        public int FoodAmount()
        {
            Func<int> amount = delegate {return foodAmount; };
            return amount();
            
        }
     
        private int GetFood(T testFood)
        {
            for (int j = 0; j < foodAmount; j++)
            {
                if (meal[j].CompareTo(testFood) == 0)
                {
                    Console.WriteLine("In menu this meal has a number: " + (j + 1));
                }
            }
            return 0;
        }
       
        public T[] Meals { get { return meal.ToArray(); } }

        public int this[T food]
        {
            get
            {
                return (GetFood(food));
            }
        }
         public IEnumerator<T> GetEnumerator()
        {
            int i = 0;
            foreach ( T s in meal )
            {
                if (i < foodAmount)
                {
                    yield return s;
                }
                i++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool MoveNext()
        {
            return (++ pos < foodAmount);
        }

        public void Reset()
        {
            pos = -1;
        }

        public T Current
        {
            get { return meal[pos]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }


        public void Dispose()
        {
        }
    }
    
}