using System;
using System.Collections.Generic;

namespace lab4
{
    //Рефакторинг
    //1.В вашей программе нет очень длинных методов/функций код занимает не  больше 2-3 десятков стро. 
    //2.Нет дублирования кода
    //3.Генерализация типов
    //4.Инкапсуляция полей классов
    //5.Выделение интерфейса 
    internal class Program
    {
        public static WeakReference WR()
        {
            return new WeakReference(new Student("Olya","Resop","female",14,"I I/M", 8));
        }
        public static void Main(string[] args)
        {
            Student st1 = new Student("Olya","Resop","female",14,"I I/M", 8);
            Student st2 = new Student("Kolya","Resop","female",14,"I I/M", 12); 
            Student st3 = new Student("Nadia","Resop","female",14,"I I/M", 2); 
            Student st4 = new Student("Yehor","Resop","female",14,"I I/M", 1); 
            
            StudentList<Student> studentList = new StudentList<Student>();

            studentList.AddToWeakRefList(st1);
            studentList.AddToWeakRefList(st2);
            studentList.AddToWeakRefList(st3);
            studentList.AddToWeakRefList(st4);
         

            GC.Collect();
            GC.WaitForPendingFinalizers();

            WeakReference wr = WR();
            Console.WriteLine("Is first object alive : " + wr.IsAlive.ToString()); 
                                                                                                                    
            GC.Collect(2, GCCollectionMode.Forced);

            Console.WriteLine("Is first object alive : " + wr.IsAlive.ToString());
           
            studentList.Dispose();
            Console.WriteLine("List does not exist: " + (studentList.wrList == null));// Ccилка  на список null 
            Console.WriteLine(studentList.ToString());
            Console.ReadKey();
        }
    }
}
