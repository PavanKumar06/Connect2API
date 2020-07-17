using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace AdvancedNewsPaper.Services
{
    public class NewsServices:INewsServices
    {
        List<string> li = new List<string>();
        public List<string> CreateNewsLines(string str, int width)
        {
            List<string> li = new List<string>();
            for (int j = 0; j < str.Length; j += width)
            {
                if (str.Substring(j, 1) == " ")
                    ++j;
                if (width + j > str.Length)
                    li.Add(str.Substring(j).PadRight(width));
                else
                    li.Add(str.Substring(j, width));
            }
            return li;
        }
        public void JsonSerialize(object obj)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            string filePath = "C:/Users/spava/source/repos/AdvancedNewsPaper/AdvancedNewsPaper/Models/JSONData.txt";
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            File.WriteAllText(filePath, json);
        }
    }
}
