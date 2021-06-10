using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Buy
    {
        public Buy()
        {
            BuyDetails = new HashSet<BuyDetail>();
        }

        public int Id { get; set; }
        public int? ProviderId { get; set; }
        public string ProviderName { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public bool? Active { get; set; }

        public virtual Provider Provider { get; set; }
        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
    }
}
