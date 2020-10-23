using System;
using System.Net.Mime;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Drawing;
using steganographyProj.CryptographyLogic;
using Microsoft.Extensions.Logging;

namespace steganographyProj.Controllers
{
    public class SteganographyController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public SteganographyController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet()]
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost("/steganography/encode")]
        public IActionResult encode(IFormFile file, string plaintext)
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


            // hide message in bitmap
            img = SteganographyHelper.embedText(plaintext, img);


            // new memory stream for bitmap to png converion
            var stream = new MemoryStream();
            //  
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            //string format = MediaTypeNames.Application.Octet.ToString(); -> doing this leads to direct download
            string format = "image/png";
            stream.Seek(0, SeekOrigin.Begin);
            FileStreamResult res= base.File(stream, format); ;

            // For later
            // adding png here does the trick. But maybe there's also a way of making it do the file extension
            // stuff itself
            res.FileDownloadName = "steganodecode.png"; 
            return res;

        }
        [HttpPost("/steganography/decode")]
        public IActionResult decode(IFormFile file)
        {
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


            // hide message in bitmap
            string plaintext = SteganographyHelper.extractText(img);

            ViewData["text"] = plaintext;
            return View();

        }
    }
}
