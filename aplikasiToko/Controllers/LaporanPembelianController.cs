using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aplikasiToko.Controllers
{
    public class LaporanPembelianController: BaseController
    {
        public LaporanPembelianController()
        {
            this.table = "transactionbuy";
        }
    }
}
