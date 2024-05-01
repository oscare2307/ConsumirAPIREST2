using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileStore.Models
{
    public class IdProduct : Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }


    }
}
