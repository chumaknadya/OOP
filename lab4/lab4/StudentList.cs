using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab4
{
    // Using "Clean code" rule 
    //“Читание кода сверху вниз”, “Метод меньшего масштаба - ниже”
    // Форматирование отступов
    public class StudentList <T> : IDisposable where T : Student
    {
        public List<Student> wrList; // список слабких посилань
        bool disposed = false;

        public StudentList()
        {
            wrList = new List<Student>();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                wrList.Clear();
                wrList = null;
            }
            Console.WriteLine("Student list disposed");
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void AddToWeakRefList(Student elem)
        {
            wrList.Add(elem);
        }
    }
}