using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Sanh
    {

        public int MaSanh { get; set; }
        public string TenSanh { get; set; }
        public int MaLoaiSanh { get; set; }
        public string TenLoaiSanh { get; set; }
        public int SLBanToiDa { get; set; }
        public int DGBanToiThieu { get; set; }
        public string GhiChu { get; set; }

        public Sanh(string tensanh, int maloaisanh, string tenloaisanh, int slbantoida, int dgbantoithieu, string ghichu)
        {
            TenSanh = tensanh;
            SLBanToiDa = slbantoida;
            TenLoaiSanh = tenloaisanh;
            DGBanToiThieu = dgbantoithieu;
            MaLoaiSanh = maloaisanh;
            GhiChu = ghichu;
        }

        public Sanh(int maloaisanh, string tenloaisanh, int dgbantoithieu)
        {
            MaLoaiSanh = maloaisanh;
            TenLoaiSanh = tenloaisanh;
            DGBanToiThieu = dgbantoithieu;
        }

        public Sanh()
        {
        }
    }
}
