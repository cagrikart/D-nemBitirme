using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DönemBitirme.Models
{
    public class BookListArg
    {
        public IEnumerable<GETBOOKS_Result> getBook{ get; set; }
        public IEnumerable<GetCategory_Result> getCategory { get; set; }
    }
}