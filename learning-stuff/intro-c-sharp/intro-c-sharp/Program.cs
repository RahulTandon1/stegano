﻿using System;
using System.IO;
//using System.Drawing;
//using runtime
//using System.Drawing.Common;
namespace App
{
    public class fileStuff
    {
        public static void Main()
        {
            //encodeXOR(int plaintext, int key);
            //encryptCaesar("rahul tandon", 3);
            encryptCaesar("udkxo wdqgrq", -3);

        }

        

        
        public static void encryptCaesar(string plaintext, int shift)
        {
            // alphabet -> abcdefghijik....z loop to a

            // example
            // rahul, 2
            // tcjwm

            // +26 -> back to same letter i.e. we'll need mod 26.
            // That's not a really logical way to come to mod 26 though
            int increment = shift % 26;
            string ciphertext = "";
            foreach (char c in plaintext)
            {

                if (c == ' ') {
                    ciphertext += (char)c;
                    continue;
                }
                

                // c# does the type casting to integer itself
                ciphertext += (char)(c + increment);
            }
            Console.WriteLine(ciphertext);

        }
    }
}

