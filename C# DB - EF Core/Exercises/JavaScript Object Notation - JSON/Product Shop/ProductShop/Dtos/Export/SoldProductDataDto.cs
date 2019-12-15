using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    public class SoldProductDataDto
    {
        [JsonProperty(PropertyName ="count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "products")]
        public ICollection<ProductOfUserDto> Products { get; set; }
    }
}
