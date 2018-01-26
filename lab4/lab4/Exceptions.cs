using System;
namespace lab4
{
    public class Exceptions : Exception
    {
       
        // Using "Clean code" rule 
        // Замена "волшебных чисел" именоваными константами
        public const string SCHOOL_WORKER_SPECIALIZATION = "math";
        private const int MAX_TEACHER_EXPIERENCE_VALUE = 20;

        public Exceptions(string message) : base(message){ }

        public static void CheckIfCanTrain(string specialization, int exp_year)
        {
            if (exp_year < 0 || String.IsNullOrEmpty(specialization))
            {
                throw new ArgumentException();
            }
        }
        public static void CheckAppropriativeSpecialization(string specialization)
        {
            if (specialization != SCHOOL_WORKER_SPECIALIZATION)
            {
                throw new ArgumentException();
            }
        }

        public static void CheckAppropriativeExpierence(int amount)
        {
            if (amount >  MAX_TEACHER_EXPIERENCE_VALUE)
            {
                throw new ArgumentException();
            }
        }
    }
}