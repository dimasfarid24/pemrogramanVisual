using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string telp { get; set; }
        public string alamat { get; set; }
    }
}
