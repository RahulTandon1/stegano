using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; } // db pk stuff
        public string Title { get; set; }

        // ALERT!!!
        // I have now clue what this line below does
        [DataType(DataType.Date)] // makes stuff only date, no time stuff
        public DateTime ReleaseData { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
