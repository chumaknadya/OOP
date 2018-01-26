using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.ComponentModel;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Practiser practiser1 = new Practiser("Nadinka",19,"female");
            Practiser practiser2 = new Practiser("Yehor",18,"male");
            TeacherStaff teacherStaff = new  TeacherStaff(practiser1);
            SchoolWorkerStaff schoolWorker = new SchoolWorkerStaff(practiser2);
            practiser1.Practice();
            practiser2.Practice();
            Student [] students = new Student[5];
            students[0] = new Student("Olya","Resop","female",14,"I I/M", 8);
            students[1] = new Student("Kolya","Resop","female",14,"I I/M", 12); 
            students[2] = new Student("Nadia","Resop","female",14,"I I/M", 2); 
            students[3] = new Student("Yehor","Resop","female",14,"I I/M", 1); 
            Console.WriteLine("\nStudent ration: \n");
            students[0].Ration();
            Array.Sort(students);
           
              
              FoodCollection<string>  foodCollection = new   FoodCollection<string>();
              foodCollection.Add("lobster");
              foodCollection.Add("varenuki");
              foodCollection.Add("fish");
              foodCollection.Remove(0);
              
              foodCollection.Menu();
              Console.WriteLine(foodCollection["fish"]);
              foreach ( string s in foodCollection )
                   Console.WriteLine( "Value: {0}", s );
               IEnumerator<string> iEnumeratorOfString = foodCollection.GetEnumerator(); 
               while(iEnumeratorOfString.MoveNext())
               {  
                    Console.WriteLine(iEnumeratorOfString.Current);  
               }     
            
            Serialization.XmlSerialization(students);
            Serialization.XmlDeserialization(students);
            Serialization.JsonSerialization(practiser1,"data.json");
            Serialization.JsonDeserialization(practiser1,"data.json");
        }
    }
}