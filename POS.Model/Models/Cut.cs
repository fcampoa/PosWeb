using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Cut
    {
        public int Id { get; set; }
        public double? Total { get; set; }
        public DateTime? Date { get; set; }
    }
}
