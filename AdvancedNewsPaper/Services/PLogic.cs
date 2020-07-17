using AdvancedNewsPaper.Models;
using System;
using System.Collections.Generic;

namespace AdvancedNewsPaper.Services
{
    public class PLogic:ILogic
    {
        public Object Logic(List<string> li, int col, int row)
        {
            List<Page> pages = new List<Page>();
            int y = (int)Math.Ceiling((decimal)(li.Count / (col * row)));
            var cl = new CLogic();
            int k = 0;
            for (int i = 0; i < y; ++i)
            {
                Page p = new Page();
                for (int j = 0; j < col; ++j)
                {
                    var c = (Column)cl.Logic(li, row, k * row);
                    p.pli.Add(c);
                    ++k;
                }
                pages.Add(p);
            }
            return pages;
        }
    }
}
