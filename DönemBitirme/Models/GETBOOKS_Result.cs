//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DönemBitirme.Models
{
    using System;
    
    public partial class GETBOOKS_Result
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<int> Author { get; set; }
        public string BookYear { get; set; }
        public Nullable<int> Publisher { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
    }
}
