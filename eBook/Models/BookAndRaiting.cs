using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eBook.Models
{
    public class BookAndRaiting
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        
        public string Image { get; set; }

        public double raiting { get; set; }
    }
}