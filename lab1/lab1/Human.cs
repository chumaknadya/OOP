﻿using System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;

namespace lab1
{
    public class Human
    {
        
        private string firstName;
        private string lastName;
        private string sex;
        private int age;
        private const int MAX_HUMAN_AGE = 200;
        private static int _humanCounter;
        //constructors
        public Human()
        {
            _humanCounter++;
            firstName = "Name №" + _humanCounter;
            lastName = "Surname №" + _humanCounter;
            sex = "sex";
            age = 0;
           
        }
        public Human(string firstName,string lastName,string sex,int age)
        {
            _humanCounter++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.sex = sex;
            this.age = age;
          
        }
        static Human()
        {
            _humanCounter = 0;
        }
        //properties
        public string Name
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Incorrect value of name");
                }
                else { firstName = value; }
            }
            get { return firstName; }
        }
        public string Surname
        {
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Incorrect value of surname");
                }
                else { lastName = value; }
            }
            get { return lastName; }
        }
        public int Age
        {
            set
            {
                if (age > 0 || age < MAX_HUMAN_AGE)
                {
                    age = value;

                }
                else
                {
                    Console.WriteLine("Incorrect age");
                }
            }
            get { return age; }
        }

        public string Sex
        {
            set { sex = value; }
            get { return sex; }
        }
        public void humanAmount()
        {
            Console.WriteLine("{0} 'Human' objects is created", _humanCounter);
        }
        public void IntroduceSelf()
        {
           Console.WriteLine("I am " + firstName +" " +lastName);
        }

        public void GreetHappyBirthday()
        {
            
                Console.WriteLine("Happy birthday " + firstName );
           
        }

        public void InformationAbout()
        {
            Print();
            
        }
        virtual protected  void Print()
        {
            Console.WriteLine(firstName +" "+ lastName + " " + sex + " " + age);
            
        }
      
        
    }
}