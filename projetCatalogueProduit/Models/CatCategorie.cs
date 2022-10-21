using System;
using System.Collections.Generic;

namespace projetCatalogueProduit.Models
{
    public partial class CatCategorie
    {
        public int CodeCategorie { get; set; }
        public string? LibelleCategorie { get; set; }
        public DateTime? DateSaisie { get; set; }
    }
}
