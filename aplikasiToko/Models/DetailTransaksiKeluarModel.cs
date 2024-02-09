using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Models
{
    class DetailTransaksiKeluarModel
    {
        //public int id { get; set; }
        public string nota { get; set; }
        public string idPelanggan { get; set; }
        public string kodeBarang { get; set; }
        public string namaBarang { get; set; }
        public int jumlah { get; set; }
        public int stok { get; set; }
        public int hargaSatuan { get; set; }
        public int hargaAkhir { get; set; }
        public int subTotal { get; set; }        
    }
}
