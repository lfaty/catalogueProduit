using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace projetCatalogueProduit.Models
{
    public partial class CatProduit
    {
        public int CodeProduit { get; set; }
        public int? CodeCategorie { get; set; }
        public string? LibelleProduit { get; set; }
        public string? DescriptionProduit { get; set; }
        public string? ImageProduit { get; set; }
        public string? UrlImageProduit { get; set; }
        public DateTime? DateSaisie { get; set; }
    }
}
