using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hospitalMvc.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }

        public Token()
        {
            access_token = "0";
            token_type = "Bearer";
        }
    }
}