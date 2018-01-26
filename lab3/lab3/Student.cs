using System;
using System.Collections;
using System.Threading.Tasks.Dataflow;

namespace lab3
{
    
    [Serializable]
    public class Student : Human, IRation,IComparable
    {

        private string group;
        private int GPA;
        private const int maxScore = 12;
       
        enum Racion { bread , water, salt};
        
        
        //constructors
        public Student() : base()
        {
        }

        /*
         * Add new param for this class
         */
        public Student(string firstName, string lastName, string sex, int age, string group, int GPA) : base(
            firstName, lastName, sex, age)
        {
            this.group = group;
            this.GPA = GPA;
        }
        //properties
        public string Group
        { get; set; }

        public int AvarageScore
        {
            set
            {
                if (GPA > 0 || GPA < maxScore)
                {
                    GPA = value;

                }
                else
                {
                    Console.WriteLine("Incorrect GPA");
                }
            }
            get { return GPA; }
        }

        private  FoodCollection<string> Food()
        {
            FoodCollection<string>  ration = new   FoodCollection<string>();
            ration.Add(Racion.bread.ToString());
            ration.Add((Racion.salt.ToString()));
            ration.Add(Racion.water.ToString());
            return ration;

        }
        public void Ration()
        {
            FoodCollection < string > ration= Food();
            Action <int,string[]> action = delegate(int foodAmount,string [] meals)
            {
                for (int i = 0; i < foodAmount; i++)
                {
                    Console.WriteLine(meals[i]);
                }
                
            };
            action(ration.FoodAmount(),ration.Meals);
          
        }

        public override void Training(Practiser f, PracticEventArgs fargs)
        {
            Console.WriteLine("Student can not train ");
        }
        public IEnumerator GetEnumerator() { return (IEnumerator)this; }
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Student))
                throw new ArgumentException();

            Student student = (Student) obj;

            if (this.GPA > student.GPA) return 1;
            if (this.GPA < student.GPA) return -1;
            else return 0;
        }
         

      }
       


      
    }
