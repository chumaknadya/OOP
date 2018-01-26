using System;
using System.ComponentModel;
namespace lab4
{
    public class SchoolWorker: Human
    {
        private string education;
        private string position;
        private int salary;
        // Using "Clean code" rule 
        // Замена "волшебных чисел" именоваными константами
        private const int MINIMUM_NUMBER_OF_YEARS_FOR_TRAINING = 25;
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
        // Using "Clean code" rule 
        // Изменение названия метода по правилу "метод - глагол"
        public void IntroduceSelf()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              education + " "+position + " "+salary);
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
            ration.AddDish(Racion.fruit.ToString());
            ration.AddDish((Racion.milk.ToString()));
            ration.AddDish(Racion.pizza.ToString());
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
                    Exceptions.CheckAppropriativeSpecialization(fargs.specialization);
                    
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