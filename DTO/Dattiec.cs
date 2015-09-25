using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Dattiec
    {
        public string NgayDatTiec { get; set; }
        public string TenChuRe { get; set; }
        public string TenCoDau { get; set; }
        public int DienThoai { get; set; }
        public int TienDatCoc { get; set; }
        public int SoLuongBan { get; set; }
        public int SoBanDuTru { get; set; }
        public string Ca { get; set; }
        public string Sanh { get; set; }
        public string MaMonAn { get; set; }
        public string MaDichVu { get; set; }
        public string MaPDT { get; set; }
        public int SoLuongDV { get; set; }
        public Dattiec(string ngaydattiec, string tenchure, string tencodau, int dienthoai, int tiendatcoc, int soluongban, int sobandutru, string ca, string sanh)
        {
            NgayDatTiec = ngaydattiec;
            TenChuRe = tenchure;
            TenCoDau = tencodau;
            DienThoai = dienthoai;
            TienDatCoc = tiendatcoc;
            SoLuongBan = soluongban;
            SoBanDuTru = sobandutru;
            Ca = ca;
            Sanh = sanh;
        }

        public Dattiec(string mamonan)
        {
            MaMonAn = mamonan;
        }

        public Dattiec(string madichvu, int soluongdv)
        {
            MaDichVu = madichvu;
            SoLuongDV = soluongdv;
        }

        public Dattiec()
        {
        }
    }
}
