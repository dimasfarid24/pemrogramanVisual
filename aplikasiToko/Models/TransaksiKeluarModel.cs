using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Models
{
    public class TransaksiKeluarModel
    {
        public int id { get; set; }
        public string nota { get; set; }
        public int idUser { get; set; }
        public string kodePelanggan { get; set; }        
        public int totalHarga { get; set; }
        public int totalTagihan { get; set; }
        public int diskon { get; set; }
        public int bayar { get; set; }
        public int kembali { get; set; }
    }
}
