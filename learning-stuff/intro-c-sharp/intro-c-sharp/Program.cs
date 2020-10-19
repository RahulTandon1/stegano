using System;
using System.IO;
using System.Drawing;
//using runtime
using System.Drawing.Common;
namespace App
{
    public class fileStuff
    {
        public static void Main()
        {
            string filePath = @"/Users/rahultandon/documents/internship/learning-stuff/intro-c-sharp/intro-c-sharp/imgs/chem-ail.png";
            string filePath2 = @"/Users/rahultandon/documents/internship/learning-stuff/intro-c-sharp/intro-c-sharp/imgs/0.png";
            var writer = new FileStream(filePath2, FileMode.Create);

            // read stuff
            FileStream stream = File.Open(filePath, FileMode.Open);
            Bitmap btmp2 = new Bitmap(stream);


        }
    }
}

