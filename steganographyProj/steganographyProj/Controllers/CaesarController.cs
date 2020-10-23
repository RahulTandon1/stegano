using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using steganographyProj.CryptographyLogic;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace steganographyProj.Controllers
{
    public class CaesarController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/caesar/encode")]
        public IActionResult encode(string plaintext, int shift)
        {
            string ciphertext = CaesarHelper.encode(plaintext, shift);
            ViewData["text"] = ciphertext;
            ViewData["Shift"] = shift;
            // fix this
            return View("oopsie");
        }

        [HttpPost("/caesar/decode")]
        public IActionResult decode(string ciphertext, int shift)
        {
            string plaintext = CaesarHelper.decode(ciphertext, shift);
            ViewData["ciphername"] = "Caesar Shift Cipher";
            ViewData["text"] = plaintext;
            return View();
        }
    }
}
