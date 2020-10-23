using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using steganographyProj.CryptographyLogic;

namespace steganographyProj.Controllers
{
    public class MorseController: Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/morse/encode")]
        public IActionResult encode(string plaintext)
        {
            string ciphertext = MorseHelper.encode(plaintext);

            ViewData["text"] = ciphertext;

            // fix this
            return View("Encode");
        }

        [HttpPost("/morse/decode")]
        public IActionResult decode(string ciphertext)
        {
            string plaintext = MorseHelper.decode(ciphertext);
            ViewData["text"] = plaintext;
            return View();
        }
    }
}
