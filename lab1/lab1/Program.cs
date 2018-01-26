using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
         Human human = new Human();
         human.Name = "Nadinka";
         human.Surname = "Chumack";
         human.Age = 19;
         human.Sex = "female";
         human.GreetHappyBirthday();
         human.IntroduceSelf();
         human.InformationAbout();
         Console.WriteLine("\n");
          
            
         Student student = new Student("Olya","Resop","female",14,"I I/M", 8);
         student.Age = 15;
         student.determineLevel();
         student.GreetHappyBirthday();
         student.IntroduceSelf();
         student.InformationAbout();
         Console.WriteLine("\n");
            
            
          SchoolWorker worker = new SchoolWorker("Ehor","Muronyik","male",17,"Secondary Education","librarian",10000);
          worker.Education = "Higher Education";
          worker.Obligation();
          worker.GreetHappyBirthday();
          worker.IntroduceSelf();
          worker.InformationAbout();
          Console.WriteLine("\n");  
            
            
          Administrator admin = new Administrator();
          admin.Position = "administrator";
          admin.Obligation();
          admin.GreetHappyBirthday();
          admin.IntroduceSelf();
          admin.InformationAbout();
          Console.WriteLine("\n");  
            
          HeadTeacher headteacher = new HeadTeacher("Lena","Karpenko","female",16,"Secondary Education","headteacher",20000);
          headteacher.Obligation();
          headteacher.GreetHappyBirthday();
          headteacher.IntroduceSelf();
          headteacher.InformationAbout();
          Console.WriteLine("\n");   
            
            
          Director.createDirector("Roma","Rex","male",30,"Higher Education","director",200000);
            
          human.humanAmount();
         
            
        }
    }
}