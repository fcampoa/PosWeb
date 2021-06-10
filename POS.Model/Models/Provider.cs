using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Provider
    {
        public Provider()
        {
            Buys = new HashSet<Buy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Rfc { get; set; }
        public string BusinessName { get; set; }

        public virtual ICollection<Buy> Buys { get; set; }
    }
}
