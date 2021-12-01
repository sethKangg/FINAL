using System;
using System.Collections.Generic;

#nullable disable

namespace FINAL.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
