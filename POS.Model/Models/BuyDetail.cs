using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class BuyDetail
    {
        public int Id { get; set; }
        public int? BuyId { get; set; }
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Date { get; set; }

        public virtual Buy Buy { get; set; }
        public virtual Product Product { get; set; }
    }
}
