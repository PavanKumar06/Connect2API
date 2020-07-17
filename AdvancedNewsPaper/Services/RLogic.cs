using AdvancedNewsPaper.Models;
using System;
using System.Collections.Generic;

namespace AdvancedNewsPaper.Services
{
    public class RLogic:ILogic
    {
        public Object Logic(List<string> li, int row, int col)
        {
            Row r = new Row();
            r.row = li[row + col];
            return r;
        }
    }
}
