using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using evoQuiz.Model;

namespace evoQuiz
{
    public class MapSerializer
    {
        private string MainPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\Maps\\"));
        public void SerializeMap(string path, Map data)
        {
            File.WriteAllText(MainPath + path,"");

            var serializer = new XmlSerializer(typeof(Map));
            using (var sw = new StreamWriter(MainPath + path))
            {                
                serializer.Serialize(sw, data);
            }
        }

        public Map DeserializeMap(string path)
        {
            Map data;
            string xmlInputData = File.ReadAllText(MainPath + path);
            XmlSerializer serializer = new XmlSerializer(typeof(Map));
            using (StringReader reader = new StringReader(xmlInputData))
            {
                data = (Map)serializer.Deserialize(reader);
            }

            return data;
        }
    }
}
