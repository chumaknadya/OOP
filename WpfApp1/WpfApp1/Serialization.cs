using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;

using System.IO;
namespace WpfApp1
{
    public class Serialization
    {
        public List<T> ReadFromFileToListOfObjects<T>(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var obj = (List<T>)ser.ReadObject(stream);
            return obj;
        }
        public void WriteToFileFromClass<T>(List<Human> t, string path)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<T>));
            MemoryStream msObj = new MemoryStream();
            js.WriteObject(msObj, t);
            msObj.Position = 0;
            StreamReader sr = new StreamReader(msObj);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            Console.WriteLine(json);
            File.WriteAllText(path, json);

        }
    }
}
