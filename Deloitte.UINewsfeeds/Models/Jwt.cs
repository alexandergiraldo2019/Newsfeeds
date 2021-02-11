using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deloitte.UINewsfeeds.Models
{
    public class JWT
    {
        public string ClaveSecreta { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
