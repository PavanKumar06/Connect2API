using NewsPaper2.Model;
using System.Collections.Generic;

namespace NewsPaper2.Services
{
    public interface INewsServices
    {
        string WriteToPath { get; set; }
        List<Page> JsonDeserialize();
        void WriteToFile(List<Page> pv);
        Dictionary<string, string> GetMimeTypes();
    }
}
