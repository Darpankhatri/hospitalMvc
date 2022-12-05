using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace hospitalMvc.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public object image { get; set; }
        public object gender { get; set; }
        public object address { get; set; }
        public object dob { get; set; }
        public int role_id { get; set; }
        public object email_verified_at { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}