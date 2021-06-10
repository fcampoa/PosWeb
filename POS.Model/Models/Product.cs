using System;
using System.Collections.Generic;

#nullable disable

namespace POS.Model.Models
{
    public partial class Product
    {
        public Product()
        {
            BuyDetails = new HashSet<BuyDetail>();
            SellDetails = new HashSet<SellDetail>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string CodigoBarras { get; set; }
        public decimal Precio { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Ieps { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set; }
        public int? UnidadMedida { get; set; }

        public virtual ICollection<BuyDetail> BuyDetails { get; set; }
        public virtual ICollection<SellDetail> SellDetails { get; set; }
    }
}
