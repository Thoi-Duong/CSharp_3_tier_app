using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Danhsach
    {
        public int MaMonAn { get; set; }
        public string TenMonAn { get; set; }
        public int DonGiaMonAn { get; set; }
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public int DonGiaDichVu { get; set; }
        public string GhiChu { get; set; }

        public Danhsach(int mamonan, string tenmonan, int dongiamonan, string ghichu)
        {
            TenMonAn = tenmonan;
            DonGiaMonAn = dongiamonan;
            GhiChu = ghichu;
            MaMonAn = mamonan;
        }

        public Danhsach(string tendichvu, int dongiadichvu, string ghichu, int madichvu)
        {
            TenDichVu = tendichvu;
            DonGiaDichVu = dongiadichvu;
            GhiChu = ghichu;
            MaDichVu = madichvu;
        }

        public Danhsach(int mamonan, int madichvu)
        {
            MaMonAn = mamonan;
            MaDichVu = madichvu;
        }
    }
}
