using System.Collections.Generic;

namespace AdvancedNewsPaper.Services
{
    public interface INewsServices
    {
        List<string> CreateNewsLines(string str, int width);
        void JsonSerialize(object obj);
    }
}
