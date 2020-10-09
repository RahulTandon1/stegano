using System;
using System.Linq;
namespace c_sharp_intro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
			int[] source = { 0, 1, 2, 3, 4, 5 };
			
			Console.WriteLine(source.GetType());
			var query = from item in source
            			where item <= 3 
            			select item;
			Console.WriteLine(query.GetType());
        }
    }
}
