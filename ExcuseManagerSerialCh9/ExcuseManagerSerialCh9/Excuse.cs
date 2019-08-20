using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExcuseManagerCh9
{
    [Serializable]
    class Excuse
    {

        public Excuse()
        {
            ExcusePath = "";
        }

        public Excuse(string fileName)
        {
            Open(fileName);
        }

        public Excuse(Random random, string selectedFolder)
        {
            string[] fileNames = Directory.GetFiles(selectedFolder, "*.txt");
            Open(fileNames[random.Next(fileNames.Length)]);
        }

        public string Description { get; set; }
        public string Results { get; set; }
        public DateTime LastUsed { get; set; }
        public string ExcusePath { get; set; }

        public void Save(string filePath)
        {
            using (Stream output = File.Create(filePath))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, this);
            }
            ExcusePath = filePath;
        }

        public void Open(string fileName)
        {
            this.ExcusePath = fileName;
            using(Stream input = File.OpenRead(fileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Excuse temp = (Excuse)bf.Deserialize(input);
                Description = temp.Description;
                Results = temp.Results;
                LastUsed = temp.LastUsed;
            }
        }
    }
}
