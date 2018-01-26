using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;

namespace lab3
{
     public class Serialization
    {
        public static void XmlSerialization(Student[] students)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Student[]));
            using (Stream fs = new FileStream("xmlserializer.xml", FileMode.Create))
            {
                ser.Serialize(fs, students);
                Console.WriteLine("Objects are  serialized");
            }
        }

        public static void XmlDeserialization(Student[] cats)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Student[]));
            using (FileStream fs = new FileStream("xmlserializer.xml", FileMode.OpenOrCreate))
            {
                Student[] new_students = (Student[])ser.Deserialize(fs);
                Console.WriteLine("Objects are  deserialized");
            }

        }
        public static void JsonSerialization(Practiser practiser, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Practiser));
                ser.WriteObject(stream, practiser);
                stream.Position = 0;
                StreamReader streamReader = new StreamReader(stream);
                Console.WriteLine(streamReader.ReadToEnd());
                stream.Position = 0;
                Practiser result = (Practiser)ser.ReadObject(stream);
            }
        }

        public static void JsonDeserialization(Practiser practiser, string path)
        {
         

            using (Stream stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                // Deserialization from JSON  
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(Practiser));
                Practiser obj = (Practiser) deserializer.ReadObject(stream);
                Console.Write("Object is deserialized");
             
            }
        }

    }
}