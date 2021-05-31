using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;


namespace MP3PlayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> DownloadFile()
        {
            

            var stream = System.IO.File.OpenRead("Filepath");
            FileInfo fileInfo = new FileInfo("Filepath");
            
            return File(stream, "application/octet-stream", fileInfo.Name);

        }

    }
}
