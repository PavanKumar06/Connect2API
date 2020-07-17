using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AdvancedNewsPaper.Models;
using AdvancedNewsPaper.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedNewsPaper.Controllers
{
    [Route("v1")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IHostingEnvironment _environment;
        private readonly INewsServices _services;
        private readonly ILogic _logic;
        public NewsController(IHostingEnvironment environment, INewsServices services, ILogic logic)
        {
            _environment = environment;
            _services = services;
            _logic = logic;
        }
        [HttpPost]
        [Route("AddNewsItems")]
        public async Task<string> AddNewsItems(News_Properties items)//locahost:44355
        {
            if (items.News_Content.Length > 0)
            {
                try
                {
                    items.NoOfCol = (items.NoOfCol == 0) ? 4 : items.NoOfCol;
                    items.NoOfCol = (items.NoOfRow == 0) ? 6 : items.NoOfRow;
                    items.ColWidth = (items.ColWidth == 0) ? 9 : items.ColWidth;
                    var li = _services.CreateNewsLines(items.News_Content, items.ColWidth);
                    List<Page> pages = (List<Page>)_logic.Logic(li, items.NoOfCol, items.NoOfRow);
                    _services.JsonSerialize(pages);
                    HttpClient hc = new HttpClient();
                    hc.BaseAddress = new Uri("https://localhost:44397/v1/");
                    var apiempctrl = hc.GetAsync("GetNewsItems");
                    apiempctrl.Wait();
                    return "Successful";
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return "Unsuccessful";
            }
        }
    }
}
