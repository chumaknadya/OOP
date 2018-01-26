using System;

namespace lab3
{
    public class Exceptions : Exception
    {
       

        public const string SCHOOL_WORKER_SPECIALIZATION = "math";
        private const int MAX_TEACHER_EXPIERENCE_VALUE = 20;

        public Exceptions(string message) : base(message){ }

        public static void ProcessPractise(string specialization, int exp_year)
        {
            if (exp_year < 0 || String.IsNullOrEmpty(specialization))
            {
                throw new ArgumentException();
            }
        }
        public static void ProcessSchoolWorkerPractise(string specialization)
        {
            if (specialization != SCHOOL_WORKER_SPECIALIZATION)
            {
                throw new ArgumentException();
            }
        }

        public static void ProcessTeacherPractise(int amount)
        {
            if (amount >  MAX_TEACHER_EXPIERENCE_VALUE)
            {
                throw new ArgumentException();
            }
        }
    }
}