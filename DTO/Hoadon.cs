using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class Hoadon
    {

        public string MaHoaDon { get; set; }
        public string MaChiTietPhieuDatTiec { get; set; }
        public string MaKhachHang { get; set; }
        public string MaChiTietHoaDon { get; set; }
        public string MaPhieuDatTiec { get; set; }
        public string NgayToChuc { get; set; }
        public string TenSanh { get; set; }
        public string Ca { get; set; }
        public string NgayThanhToan { get; set; }
        public string TenCoDau { get; set; }
        public string TenChuRe { get; set; }
        public string TongTienDichVu { get; set; }
        public string TongTienThanhToan { get; set; }
        public string TongTienBan { get; set; }
        public string DonGiaBan { get; set; }
        public string TongTienHoaDon { get; set; }
        public string SoBanDuTru { get; set; }
        public string SoLuongBan { get; set; }
        public string TienDatCoc { get; set; }
        public string SoDienThoai { get; set; }
        public Hoadon() { }
        public Hoadon(string makhachhang, string ngaythanhtoan, string tongtienthanhtoan)
        {
            MaKhachHang = makhachhang;
            NgayThanhToan = ngaythanhtoan;
            TongTienThanhToan = tongtienthanhtoan;
        }
        public Hoadon(string mahoadon, string maphieudattiec, string tongtiendichvu, string tongtienhoadon, string tongtienban)
        {
            MaHoaDon = mahoadon;
            MaPhieuDatTiec = maphieudattiec;
            TongTienDichVu = tongtiendichvu;
            TongTienHoaDon = tongtienhoadon;
            TongTienBan = tongtienban;
        }

        public Hoadon(string makhachhang, string ngaythanhtoan, string tongtienthanhtoan, string maphieudattiec, string tongtiendichvu, string tongtienhoadon, string tongtienban)
        {
            MaKhachHang = makhachhang;
            NgayThanhToan = ngaythanhtoan;
            TongTienThanhToan = tongtienthanhtoan;
            MaPhieuDatTiec = maphieudattiec;
            TongTienDichVu = tongtiendichvu;
            TongTienHoaDon = tongtienhoadon;
            TongTienBan = tongtienban;
        }
        public Hoadon(string mahoadon)
        {
            MaHoaDon = mahoadon;
        }

        public Hoadon(string mahoadon,string maphieudattiec)
        {
            MaHoaDon = mahoadon;
            MaPhieuDatTiec = maphieudattiec;
        }

        public Hoadon(string mahoadon, string tongtiendichvu, string tongtienhoadon, string tongtienban)
        {
            MaHoaDon = mahoadon;
            TongTienDichVu = tongtiendichvu;
            TongTienHoaDon = tongtienhoadon;
            TongTienBan = TongTienBan;
        }
    }
}
