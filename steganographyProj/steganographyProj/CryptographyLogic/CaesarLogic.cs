using System;
namespace steganographyProj.CryptographyLogic
{
    public class CaesarHelper
    {
        public static string encode(string plaintext, int shift)
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

                if (c == ' ')
                {
                    ciphertext += (char)c;
                    continue;
                }


                // c# does the type casting to integer itself
                ciphertext += (char)(c + increment);
            }

            return ciphertext;
        }

        public static string decode(string plaintext, int shift)
        {

            return encode(plaintext, -shift);
        }
    }
}
