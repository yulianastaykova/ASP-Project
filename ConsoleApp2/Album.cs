//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public int ID { get; set; }
        public string CoverImage { get; set; }
        public int SongID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
    
        public virtual Song Song { get; set; }
    }
}
