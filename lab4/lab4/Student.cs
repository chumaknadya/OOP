using System;
using System.Collections;

namespace lab4
{
    [Serializable]
    public class Student:Human, IRation,IComparable
    {
        private string group;
        private int GPA;
        // Using "Clean code" rule 
        // Замена "волшебных чисел" именоваными константами
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
        // Using "Clean code" rule 
        // Инкапсуляция условных конструкций
        private bool checkCorrectGPA(int avaragescore)
        {
            if (avaragescore > 0 || avaragescore < maxScore) return true;
            return false;
        }

        public int AvarageScore
        {
            set
            {
                if (checkCorrectGPA(GPA))
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
        // Using "Clean code" rule 
        // Исполнение лишь одной операции в функции
        private  FoodCollection<string> addFoodToRation()
        {
            FoodCollection<string>  ration = new   FoodCollection<string>();
            ration.AddDish(Racion.bread.ToString());
            ration.AddDish((Racion.salt.ToString()));
            ration.AddDish(Racion.water.ToString());
            return ration;

        }
        public void Ration()
        {
            FoodCollection < string > ration= addFoodToRation();
            Action <int,string[]> action = delegate(int foodAmount,string [] meals)
            {
                for (int i = 0; i < foodAmount; i++)
                    Console.WriteLine(meals[i]);
            };
            action(ration.FoodAmount(),ration.Meals);
        }
        // Using "Clean code" rule 
        // Недвусмысленые имена функции
        public override void CertificationTrainingSchoolStaff(Practiser f, PracticEventArgs fargs)
        {
            Console.WriteLine("Student can not train ");
        }
        public IEnumerator GetEnumerator() { return (IEnumerator)this; }
        
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Student)) throw new ArgumentException();
            Student student = (Student) obj;
            if (this.GPA > student.GPA) return 1;
            if (this.GPA < student.GPA) return -1;
            else return 0;
        }
        ~Student()
        {
            Console.WriteLine("Deleted " + base.Name);
        }
         

      }
   }
