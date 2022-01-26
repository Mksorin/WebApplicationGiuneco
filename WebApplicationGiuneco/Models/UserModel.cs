using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAndAuth.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
