using System;
using System.ComponentModel;
namespace lab4
{
    public class Teacher:SchoolWorker,IAbout,IRation
    {
        private string сategory;
        private string specialization;
        private const int MINIMUM_NUMBER_OF_YEARS_FOR_TRAINING = 25;
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
        // Using "Clean code" rule 
        // Изменение названия метода по правилу "метод - глагол"
        public void IntroduceSelf()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              base.Education + " "+base.Position + " "+base.Salary+" "+сategory+" "+specialization);
        }

        public void Responsibility()
        {
            Console.WriteLine("Responsibility for the knowledge of children");
        }
        // Using "Clean code" rule 
        // Исполнение лишь одной операции в функции
        private  FoodCollection<string> addFoodToRation()
        {
            FoodCollection<string>  ration = new   FoodCollection<string>();
            ration.AddDish(Racion.lobster.ToString());
            ration.AddDish((Racion.wine.ToString()));
            ration.AddDish(Racion.meat.ToString());
            return ration;

        }
        public void Ration()
        {
            FoodCollection < string > ration= addFoodToRation();
            for (int i = 0; i < ration.FoodAmount(); i++)
            {
                Console.WriteLine(ration.Meals[i]);
            }
        }
        // Using "Clean code" rule 
        // Инкапсуляция условных конструкций
        private bool checkPosibilityToCertificationTrain(int minimum_numbers_of_year)
        {
            if (base.Age > minimum_numbers_of_year) return true;
            return false;
        }
        // Using "Clean code" rule 
        // Недвусмысленые имена функции
        public override void CertificationTrainingSchoolStaff(Practiser f, PracticEventArgs fargs)
        {
            if (checkPosibilityToCertificationTrain(MINIMUM_NUMBER_OF_YEARS_FOR_TRAINING))
            {
                IntroduceSelf();
                Console.WriteLine("Teacher training by " + f.name);
                try
                {
                    Exceptions.CheckIfCanTrain(fargs.specialization, fargs.experience_years);
                    Exceptions.CheckAppropriativeExpierence(fargs.experience_years);
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