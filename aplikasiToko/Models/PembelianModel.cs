using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Models
{
    public class PembelianModel
    {
        public int id { get; set; }
        public string faktur { get; set; }
        public int idSupplier { get; set; }
        public DateTime tglBeli { get; set; }
        public string kodeBarang { get; set; }
        public int hargaBeli { get; set; }
        public int jumlah { get; set; }
        public int totalBayar { get; set; }
    }
}
