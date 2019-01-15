using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicDatabaseApi.Models
{
    public class Deck
    {
        public String AuthorId { get; set; }

        public List<object> Cards { get; set; }
    }
}
