using System;
using System.ComponentModel;

namespace lab1
{
    public class Teacher:SchoolWorker
    {
        private string сategory;
        private string specialization;
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
        protected override void Print()
        {
            Console.WriteLine(base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex + " "+
                              base.Education + " "+base.Position + " "+base.Salary+" "+сategory+" "+specialization);
        }

        protected override void Responsibility()
        {
            Console.WriteLine("Responsibility for the knowledge of children");
        }
    }
}