using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExcuseManagerCh9
{
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
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(Description);
                writer.WriteLine(Results);
                writer.WriteLine(LastUsed.ToString());
            }
            ExcusePath = filePath;
        }

        public void Open(string fileName)
        {
            this.ExcusePath = fileName;
            using (StreamReader reader = new StreamReader(fileName))
            {
                Description = reader.ReadLine();
                Results = reader.ReadLine();
                LastUsed = Convert.ToDateTime(reader.ReadLine());
            }
        }
    }
}
