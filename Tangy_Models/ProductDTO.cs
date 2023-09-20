﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tangy_Models
{
    public class ProductDTO
    {
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public bool ShopFavourite { get; set; }
        public bool CustomerFavourite { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        [Range(1,int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryDTO Category { get; set; }

        public ICollection<ProductPriceDTO> Prices { get; set; }
    }
}
