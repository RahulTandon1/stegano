using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using steganographyProj.Models;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using steganographyProj.CryptographyLogic;

namespace steganographyProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpPost("FileUpload")]
        public IActionResult upload(IFormFile file)
        {
            //IFormFile file = files[0];
            if (file == null || file.Length == 0)
            {
                return BadRequest();
            }

            // empty image to populate later
            Bitmap img;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // making a new bitmap from uploaded image
                Image tempImg = Image.FromStream(memoryStream);
                img = (Bitmap)tempImg;
            }

            // std message
            // !!! Change to taking from user input.
            string stdMsg = "aur ji pranam";

            // process uploaded files
            img = SteganographyHelper.embedText(stdMsg, img);

            var stream = new MemoryStream();
                        
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    var res = stream.ToArray();

                    return base.File(res, "result.png");

        }
    }
}
