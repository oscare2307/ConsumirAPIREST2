using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FileStore.Models
{
    public class ErrorResponse : Product
    {
      public string Error {  get; set; }


    }
}
