using System;
namespace lab1
{
    public class SchoolWorker: Human
    {
      
        private string education;
        private string position;
        private int salary;
        private const int maxSalary = 10000000;
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
        
        protected override void Print()
        {
            Console.WriteLine( base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+education + " "+position + " "+salary);
        }

        public void Obligation()
        {
            Responsibility();
        }
        virtual protected  void  Responsibility()
        {
            Console.WriteLine("Responsibility for the safety of children");
        }
    }
}