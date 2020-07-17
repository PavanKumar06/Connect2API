using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPaper2.Model;
using NewsPaper2.Services;

namespace NewsPaper2.Controllers
{
    [Route("v1")]
    [ApiController]
    public class News2Controller : ControllerBase
    {
        private readonly INewsServices _services;
        List<Page> NewsPages;
        public News2Controller(INewsServices services)
        {
            _services = services;
        }
        [HttpGet]
        [Route("GetNewsItems")]
        public async Task<IActionResult> GetNewsItems()//localhost:44397
        {
            NewsPages = _services.JsonDeserialize();
            _services.WriteToFile(NewsPages);
            var path = _services.WriteToPath;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return File(memory, _services.GetMimeTypes()[ext], Path.GetFileName(path));
        }
    }
}