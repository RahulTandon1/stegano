using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace steganographyProj.CryptographyLogic
{
    public class MorseHelper
    {
		private static Dictionary<char, string> morseAlphabetDictionary = new Dictionary<char, string>()
								   {
									   {'a', ".-"},
									   {'b', "-..."},
									   {'c', "-.-."},
									   {'d', "-.."},
									   {'e', "."},
									   {'f', "..-."},
									   {'g', "--."},
									   {'h', "...."},
									   {'i', ".."},
									   {'j', ".---"},
									   {'k', "-.-"},
									   {'l', ".-.."},
									   {'m', "--"},
									   {'n', "-."},
									   {'o', "---"},
									   {'p', ".--."},
									   {'q', "--.-"},
									   {'r', ".-."},
									   {'s', "..."},
									   {'t', "-"},
									   {'u', "..-"},
									   {'v', "...-"},
									   {'w', ".--"},
									   {'x', "-..-"},
									   {'y', "-.--"},
									   {'z', "--.."},
									   {'0', "-----"},
									   {'1', ".----"},
									   {'2', "..---"},
									   {'3', "...--"},
									   {'4', "....-"},
									   {'5', "....."},
									   {'6', "-...."},
									   {'7', "--..."},
									   {'8', "---.."},
									   {'9', "----."}
								   };
		public static string encode(string plaintext)
		{
			// lower case
			plaintext = plaintext.ToLower();

			// string builder for final result to be returned
			StringBuilder ciphertext = new StringBuilder();

			// sample text: rahul tandon is a mega noob
			// iterating over each character
			foreach (char c in plaintext)
			{

				// if the characters is in our dictionary add it to the string builder
				if (morseAlphabetDictionary.ContainsKey(c))
				{
					ciphertext.Append(morseAlphabetDictionary[c]);

					// "By convention, when writing, each character is separated
					// by a space and each word is separated by a slash /."
					// Src: https://www.dcode.fr/morse-code
					ciphertext.Append(" ");
				}
				else if (c == ' ')
				{
					ciphertext.Append('/');
				}
			}
			string ciphertTextStr = ciphertext.ToString();
			return ciphertTextStr;
		}

		public static string decode(string cipherTextStr)
		{
			/* Logic relies on this statement from https://www.dcode.fr/morse-code
			 * "By convention, when writing, each character is separated
			 * by a space and each word is separated by a slash /."
			 * 
			 * Sample
			 * Plaintext: rahul tandon is a mega noob
			 * Morse code:
			 * .-. .- .... ..- .-.. / - .- -. -.. --- -. / .. ... / .- / -- . --. .- / -. --- --- -...
			 */


			// array of words in morse code
			// example "word" in "words": .-. .- .... ..- .-..
			// notice the spaces in the morse code above 
			string[] words = cipherTextStr.Split('/');

			// array for character in morse code
			// example "char" in "chars" .-..
			string[] chars;

			// plaintextDecode will be the final result that we return
			StringBuilder plaintextDecode = new StringBuilder();


			// each new word
			// e.g. .-. .- .... ..- .-.. /- .- -. -.. --- -.
			foreach (string word in words)
			{
				chars = word.ToLower().Trim().Split(' ');

				foreach (string c in chars)
				{

					// LINQ Syntax credit:
					// https://stackoverflow.com/questions/2444033/get-dictionary-key-by-value
					var key = morseAlphabetDictionary.Where(x => x.Value == c);
					plaintextDecode.Append((key.ElementAt(0).Key));
				}

				// adding a space at after adding each word in the
				// nested for loop above
				plaintextDecode.Append(' ');
			}

			return plaintextDecode.ToString();

		}
	}
}
