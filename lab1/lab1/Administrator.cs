using System;
namespace lab1
{
    public class Administrator:SchoolWorker
    {
        public Administrator() : base()
        {
        }
        public Administrator(string firstName, string lastName, string sex, int age,
            string education,string position,int salary) : base(
            firstName, lastName, sex, age,education, position,salary)
        {
            
        }
        protected override void Print()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              base.Education + " "+base.Position + " "+base.Salary);
        }

        protected override void Responsibility()
        {
            Console.WriteLine("Responsibility for school control");
        }
    }
}