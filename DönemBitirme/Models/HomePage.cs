using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DönemBitirme.Models
{
    public class HomePage
    {
        public IEnumerable<Book> getBooks{ get; set; }
        public IEnumerable<AboutU> aboutUs{ get; set; }
    }
}