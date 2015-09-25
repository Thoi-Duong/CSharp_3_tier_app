using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Ca
    {
        public string TenLoaiCa { get; set; }
        public string GhiChu { get; set; }
        public int MaLoaiCa { get; set; }
        public Ca()
        {

        }

        public Ca(int maloaica,string tenloaica, string ghichu)
        {
            MaLoaiCa = maloaica;
            TenLoaiCa = tenloaica;
            GhiChu = ghichu;
        }
    }
}
