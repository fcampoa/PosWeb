using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Configuration
    {
        public int Id { get; set; }
        public string Printer { get; set; }
        public string CompanyName { get; set; }
        public int? InputMode { get; set; }
        public byte? PrintOnSale { get; set; }
    }
}
