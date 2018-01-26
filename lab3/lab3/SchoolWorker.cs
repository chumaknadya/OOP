using System;
using System.ComponentModel;

namespace lab3
{


    public class SchoolWorker: Human
    {
        private string education;
        private string position;
        private int salary;
        private const int maxSalary = 10000000;
        enum Racion {salat,milk,fruit,potato,pizza};
      
        //constructors
        public SchoolWorker() : base()
        {
        }
        public SchoolWorker(string firstName, string lastName, string sex, int age,
            string education,string position,int salary) : base(
            firstName, lastName, sex, age)
        {
            this.education = education;
            this.position = position;
            this.salary = salary;
        }
      
        //properties
        public string Education
        {
            get => education;
            set => education = value;
        }

        public string Position
        {
            get => position;
            set => position = value;
        }
        public int Salary
        {
            set
            {
                if (salary > 0 || salary < maxSalary)
                {
                    salary = value;

                }
                else
                {
                    Console.WriteLine("Incorrect salary");
                }
            }
            get { return salary; }
        }
        
        public void IntroduceSelf()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              education + " "+position + " "+salary);
        }

        public void Responsibility()
        {
            Console.WriteLine("Responsibility for the knowledge of children");
        }
        private  FoodCollection<string> Food()
        {
            FoodCollection<string>  ration = new   FoodCollection<string>();
            ration.Add(Racion.fruit.ToString());
            ration.Add((Racion.milk.ToString()));
            ration.Add(Racion.pizza.ToString());
            return ration;

        }
        public void Ration()
        {
            FoodCollection < string > ration= Food();
            for (int i = 0; i < ration.FoodAmount(); i++)
            {
                Console.WriteLine(ration.Meals[i]);
            }
        }
        public override void Training(Practiser f, PracticEventArgs fargs)
        {
            if (base.Age > 25)
            {
                IntroduceSelf();
                Console.WriteLine("Teacher training by " + f.name);
                try
                {
                    Exceptions.ProcessPractise(fargs.specialization, fargs.experience_years);
                    Exceptions.ProcessSchoolWorkerPractise(fargs.specialization);
                    
                }
                catch (Exceptions ex)
                {
                    Console.WriteLine("Incorrect work expierence year  " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("You are too young");
            }
        } 
        } 
    }