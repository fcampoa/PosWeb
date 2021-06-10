using POS.Model.Mappings;
using POS.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.DTO
{
    public class ProviderDTO: IMapFrom<Provider>
    {
        public ProviderDTO()
        {
            Buys = new HashSet<BuyDTO>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Rfc { get; set; }
        public string BusinessName { get; set; }

        public virtual ICollection<BuyDTO> Buys { get; set; }
    }
}
