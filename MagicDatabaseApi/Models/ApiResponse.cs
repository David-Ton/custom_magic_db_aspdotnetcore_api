using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class ApiResponse
    {
        public bool Successful { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
