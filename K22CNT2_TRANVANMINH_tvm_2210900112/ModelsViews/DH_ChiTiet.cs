using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K22CNT2_TRANVANMINH_tvm_2210900112.ModelsViews
{
    public class DH_ChiTiet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public double? Price { get; set; }
        public double? Total { get; set; }

    }
}