using NewsPaper2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewsPaper2.Services
{
    public class NewsServices:INewsServices
    {
        public string WriteToPath { get; set; }
        public List<Page> JsonDeserialize()
        {
            string filePath = "C:/Users/spava/source/repos/AdvancedNewsPaper/AdvancedNewsPaper/Models/JSONData.txt";
            if (!File.Exists(filePath))
            {
                throw new Exception(new FileNotFoundException().Message);
            }
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Page>>(json);
        }
        public void WriteToFile(List<Page> pages)
        {
            WriteToPath = @"C:\Users\spava\Desktop\Up_News.txt";
            int i = 0;
            var sb = new StringBuilder();
            using (StreamWriter wr = new StreamWriter(WriteToPath))
            {
                foreach (var pv in pages)
                {
                    ++i;
                    for (int k = 0; k < pv.pli[0].cli.Count; ++k)
                    {
                        for (int j = 0; j < pv.pli.Count; ++j)
                        {
                            sb.Append(pv.pli[j].cli[k].row + "   ");
                        }
                        wr.WriteLine(sb);
                        sb.Clear();
                    }
                    wr.WriteLine();
                    wr.WriteLine("Page " + i);
                    wr.WriteLine();
                    wr.WriteLine();
                }
            }
        }
        public Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
