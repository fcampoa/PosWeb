using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Sell
    {
        public Sell()
        {
            SellDetails = new HashSet<SellDetail>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Total { get; set; }
        public string Serie { get; set; }
        public string Folio { get; set; }
        public bool Canceled { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<SellDetail> SellDetails { get; set; }
    }
}
