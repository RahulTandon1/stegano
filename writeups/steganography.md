# Steganography

Hi! This doc covers the Steganography logic of the project.

Declaration: The steganography logic used in the project is not original has been taken from https://www.codeproject.com/Tips/635715/Steganography-Simple-Implementation-in-Csharp.

It took me time to understand the logic properly. This intent of this document is to simplify that process for you and hopefully save some time :-)

## Wait a sec! What even is this \_Stegano_stuff?

Steganography refers to the science of hiding information in multimedia. It started with a chill guy Johannes Trithemius who wrote a book on Cryptography but made it seem like it's a book about magic. Such magic much wow!

In this project the "main" tool was the steganography tool though I implemented some other ciphers as welll (those incidently were written totally by me).

The tool simply allows you to upload an image, give a secret message and then enoce it.

## Alright! What's the logic?

In binary numbers say "11100011" if one changes the rightmost bit it won't make much of a difference to the value of the decimal version of the number e.g. 227 becomes 226. This rightmost bit is called the Least Significant Bit.

Now image this: We have say 100 binary numbers and we purposely change the LSB of each of these binary numbers to represent a "secret" binary number which represents say a text using `character -> ascii value (decimal) -> binary`. And we mark the end of "secret" binary numbers by a byte(8 bits) full of zeroes since ascii number 0 is NULL.

I'd mentioned earlier that the project involves images. Well images have pixels. And each pixel has a particular RGB value (Red Green Blue) and each of these values must lie in \[0, 255\] (inclusive).

So we can make minor changes to the RGB value by decreasing them by 1 if need be...to represent our required binary.

Later we can decode this by getting the binary, converting it to decimal and then to text. Simple.

## How does this reflect in the code?

So we have a number of concerns to address which I explain below.

### 8 bits for each character

While for some character we can represent them using say just 7 or 6 bits, we NEED to convert that into 8 bits for uniformity. So when we're decoding when know that we can pick up 8 bits convert to a character and then go to next 8 bits and so on.

### 3 pixels only

C# allows us to set pixel in an image (Bitmap rather) using R, G, B values.
So when were encoding binary in the Bitmap we need to take keep in mind that we can only do it 3 at a time.

Lastly, while "setting a pixel" we need to provide the X and Y coordinates of said pixel. So we need to take care of that bit as well.

## Stuff to keep in mind before going through the code

- The code's main aim is to get everything done in a single iteration through the necessary pixels. So it looks at each pixel just once.

- The code generates the binary of each character on the fly.

- Keep in mind the "concerns" mentioned aboved and you should be good to go.
