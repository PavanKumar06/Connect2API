using AdvancedNewsPaper.Models;
using System;
using System.Collections.Generic;

namespace AdvancedNewsPaper.Services
{
    public class CLogic:ILogic
    {
        public Object Logic(List<string> li, int row, int j)
        {
            Column c = new Column();
            var rl = new RLogic();
            for (int i = 0; i < row; ++i)
            {
                var r = (Row)rl.Logic(li, i, j);
                c.cli.Add(r);
            }
            return c;
        }
    }
}
