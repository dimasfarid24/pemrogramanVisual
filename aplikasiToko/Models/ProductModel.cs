using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string kodeBarang { get; set; }
        public string nama { get; set; }
        public string kategori { get; set; }
        public string satuan { get; set; }
        public int stok { get; set; }
        public int hargaPokok { get; set; }
        public int hargaJual { get; set; }
    }
}
