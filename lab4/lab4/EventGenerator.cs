﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;


namespace lab4
{
    public delegate void PractiseHandle(Practiser f, PracticEventArgs fargs);
    public class PracticEventArgs : EventArgs
    {
        public string specialization;
        public int experience_years;

        public PracticEventArgs ( string specialization, int experience_years)
        {
            this.specialization = specialization;
            this.experience_years = experience_years;
        }

        public PracticEventArgs() : this (null, 0) { }

    }
    [DataContract]
    public class Practiser
    {
        [DataMember]
        public string name;
        [DataMember]
        public int age;
        [DataMember]
        public string sex;

        public Practiser(string name)
        {
            this.name = name;
        }

        public  Practiser(string name, int age, string sex)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }
        public event PractiseHandle PracticeEvent;
     
        public void Practice()
        {
            string specialization;
            int experience_years;
            PracticEventArgs fargs;
            try
            {
                Console.WriteLine("Enter specialization: ");
                specialization = Console.ReadLine();

                Console.WriteLine("Enter work experience year: ");
                experience_years = Int32.Parse(Console.ReadLine());

                fargs = new  PracticEventArgs(specialization,experience_years);
            }
            catch 
            {
                fargs = new  PracticEventArgs();
            }
            Console.WriteLine("Practiser {0} is training staff...\n", name);
            if (PracticeEvent != null)
            {
                PracticeEvent((Practiser)this, fargs);
            }
            
        }
        
    }

    class TeacherStaff
    {
        public const int HUMAN_AMOUNT = 2;
        Human[] teacherStaff = new Human[HUMAN_AMOUNT];

        public TeacherStaff(Practiser practiser)
        {
             teacherStaff[0] = new Teacher("Danya", "Karpenko", "female", 56, "Secondary Education", "teacher", 20000,
                "higher", "mathematic");
             teacherStaff[1] = new Teacher("Lena", "Karpenko", "female", 56, "Secondary Education", "teacher", 20000,
                "higher", "mathematic");
                practiser.PracticeEvent += delegate(Practiser f, PracticEventArgs fargs)
                {
                        for (int i = 0; i < HUMAN_AMOUNT; i++)
                        {
                            teacherStaff[i].CertificationTrainingSchoolStaff(f, fargs);
                        }

                };
        }
    }

    class SchoolWorkerStaff
     {

            List<Human> schoolWorkerStaff = new List<Human>();

            public SchoolWorkerStaff(Practiser practiser)
            {
                schoolWorkerStaff.Add(new SchoolWorker("Ehor", "Muronyik", "male", 27, "Secondary Education",
                    "librarian", 10000));
                schoolWorkerStaff.Add(new SchoolWorker("Vadim", "Masiyk", "male", 27, "Secondary Education",
                    "librarian", 10000));
                foreach (Human human in schoolWorkerStaff)
                    practiser.PracticeEvent += (f, fargs) => { human.CertificationTrainingSchoolStaff(f, fargs); };

            }
        }
    }
    
    