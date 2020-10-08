using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCFrontendOfTh6.Models
{
    public partial class SanPham
    {
        public string Ma { get; set; }
        public string Ten { get; set; }
        public Nullable<int> DonGia { get; set; }
        public Nullable<int> MaDanhMuc { get; set; }
    }
}