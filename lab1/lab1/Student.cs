using System;
using System.Threading.Tasks.Dataflow;

namespace lab1
{
    public class Student : Human
    {

        private string group;
        private int GPA;
        private const int maxScore = 12;
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

        public void determineLevel()
        {
            if (GPA > 9)  Console.WriteLine("High Level");
            if (GPA < 9 || GPA > 6)  Console.WriteLine("Middle Level");
            else Console.WriteLine("Low Level");
        }
        protected override void Print()
        {
            Console.WriteLine( base.Name + " "+ base.Surname +" "+ base.Age +" "+ base.Sex+ " "+ group +" "+ GPA);
        }
    }
}