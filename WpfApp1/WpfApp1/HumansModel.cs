using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
namespace WpfApp1
{
    [DataContract]
    public  class Human
    {

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public string Sex { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Id { get; set; }
        public Human(string Name, string Surname,string Sex, int Age,int Id)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Sex = Sex;
            this.Age = Age;
            this.Id = Id;
        }
    }
        public class HumansModel: ObservableCollection<Human>
    {
            private static object _threadLock = new Object();  
            private static HumansModel current = null;
            public static HumansModel Current
            {
                get
                {
                    lock (_threadLock)
                        if (current == null)
                            current = new HumansModel();
                    return current;
                }
            }
            private HumansModel()
            {
             Human aNewHuman = new Human("sdsda", "sdasd", "saddas", 12, new Random().Next(10, 100000));
             Human aNewHuman1 = new Human("sdsda", "sdasd", "saddas", 12, new Random().Next(10, 100000));
             Human aNewHuman2 = new Human("sdsda", "sdasd", "saddas", 12, new Random().Next(10, 100000));
             Human aNewHuman3 = new Human("sdsda", "sdasd", "saddas", 12, new Random().Next(10, 100000));
             Human aNewHuman4 = new Human("sdsda", "sdasd", "saddas", 12, new Random().Next(10, 100000));
             Add(aNewHuman);
             Add(aNewHuman1);
             Add(aNewHuman2);
             Add(aNewHuman3);
             Add(aNewHuman4);
                    //Serialization file = new Serialization();
                    //List<Human> list = file.ReadFromFileToListOfObjects<Human>(@"C:\Users\HomePC\human.json");      
                   // foreach (Human human in list)
                  //  {
                   //     Add(human);
                  //  }
        }
            public void AddHuman(string Name, string Surname, string Sex, int Age)
            {
                Human aNewHuman = new Human(Name, Surname, Sex, Age, new Random().Next(10, 100000));
                Add(aNewHuman);
            }
            public void RemoveHuman(Human obj)
            {
                Remove(obj);                
            }
            public int GetHumanIndex(Human h)
            {
                return IndexOf(h);
            }


    }
}
