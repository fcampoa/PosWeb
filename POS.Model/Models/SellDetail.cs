using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class SellDetail
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? SellId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Date { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }

        public virtual Product Product { get; set; }
        public virtual Sell Sell { get; set; }
    }
}
