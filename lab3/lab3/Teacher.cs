using System;
using System.ComponentModel;

namespace lab3
{

 
    public class Teacher:SchoolWorker,IAbout,IRation
    {
        private string сategory;
        private string specialization;
        enum Racion {lobster, wine, meat,beef,suchi,varenuki};
       
        //constructors
        public Teacher() : base()
        {
        }
        public Teacher(string firstName, string lastName, string sex, int age,
            string education,string position,int salary, string сategory,string specialization) : base(
            firstName, lastName, sex, age, education,position,salary)
        {
            this.сategory = сategory;
            this.specialization = specialization;
        }
        //properties
        public string Category
        {
            get => сategory;
            set => сategory = value;
        }

        public string Specialization
        {
            get => specialization;
            set => specialization = value;
        }
        public void IntroduceSelf()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              base.Education + " "+base.Position + " "+base.Salary+" "+сategory+" "+specialization);
        }

        public void Responsibility()
        {
            Console.WriteLine("Responsibility for the knowledge of children");
        }
        private  FoodCollection<string> Food()
        {
            FoodCollection<string>  ration = new   FoodCollection<string>();
            ration.Add(Racion.lobster.ToString());
            ration.Add((Racion.wine.ToString()));
            ration.Add(Racion.meat.ToString());
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
                    Exceptions.ProcessTeacherPractise(fargs.experience_years);
                    
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