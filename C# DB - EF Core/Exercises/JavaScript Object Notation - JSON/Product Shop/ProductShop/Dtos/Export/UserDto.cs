using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductShop.Dtos.Export
{
    public class UserDto
    {
        [JsonProperty(PropertyName ="firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "age")]

        public int? Age { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]

        public SoldProductDataDto SoldProducts { get; set; }

        
    }
}
