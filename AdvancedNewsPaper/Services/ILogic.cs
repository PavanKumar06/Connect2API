using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvancedNewsPaper.Services
{
    public interface ILogic
    {
        Object Logic(List<string> li, int col, int row);
    }
}
