using System;
namespace lab1
{
    public class Director:Administrator
    {
        //constructor
        private Director(string firstName, string lastName, string sex, int age,
            string education,string position,int salary) : base(
            firstName, lastName,sex, age,education, position,salary)
        {
            
        }
        public static void createDirector(string firstName, string lastName, string sex, int age,
                                          string education,string position,int salary)
        {

            if (education == "Higher Education" && age > 20)
            {
                Director director = new Director(firstName,lastName,sex,age,education,position,salary);
            }
        }
        protected override void Print()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              base.Education + " "+base.Position + " "+base.Salary);
        }

        protected override void Responsibility()
        {
            Console.WriteLine("Responsibility for issues orders");
        }
       
    }
}