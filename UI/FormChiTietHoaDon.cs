using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogicTier;

namespace UI
{
    public partial class ChiTietHoaDonDaThanhToan : Form
    {
        Hoadon hd = new Hoadon();
        hoadonBUS objHoaDon = new hoadonBUS();
        DataTable tbHoaDon;
        public static string MaHoaDon = "";
        public string tongtienhoadon = "";
        public string tongtienconlai = "";
        public string tongtiendichvu = "";
        public string tongtienban = "";

        public ChiTietHoaDonDaThanhToan(string a)
        {
            InitializeComponent();
            MaHoaDon = a;
        }


        private void TestForm_Load(object sender, EventArgs e)
        {
            Hoadon cthd = new Hoadon();
            this.lblMaHoaDon.Text = MaHoaDon;

            //label1.Text = objHoaDon.GetMaCTPDT(MaHoaDon).MaChiTietPhieuDatTiec;
            tbHoaDon = objHoaDon.GetDSDatDichVu_MaHD(MaHoaDon);
            dgvGetDSdichvu.DataSource = objHoaDon.GetDSDatDichVu_MaHD(MaHoaDon);
            lbDonGia.Text = objHoaDon.GetThongTinBanAn_MaHD(MaHoaDon).DonGiaBan;

            cthd = objHoaDon.getChiTietHoaDon(MaHoaDon);
            lbTongTienDichVu.Text = cthd.TongTienDichVu;
            lbTongTienHoaDon.Text = cthd.TongTienHoaDon;
            lbTongTienBan.Text = cthd.TongTienBan;

            lbSoLuongBan.Text = (int.Parse(cthd.TongTienBan) / int.Parse(objHoaDon.GetThongTinBanAn_MaHD(MaHoaDon).DonGiaBan)).ToString();

            lbTienDatCoc.Text = objHoaDon.GetTienDatCoc_MaHD(MaHoaDon).TienDatCoc;
            lbTenChuRe.Text = objHoaDon.GetTenCoDauChuRe_MaHD(MaHoaDon).TenChuRe;
            lbTenCoDau.Text = objHoaDon.GetTenCoDauChuRe_MaHD(MaHoaDon).TenCoDau;
            lbNgayThanhToan.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //lbTongTienHoaDon.Text = int.Parse(objHoaDon.GetThongTinBanAn_MaHD(MaHoaDon).TongTienBan) + int.Parse(objHoaDon.GetTongTienDichVu_MaHD(MaHoaDon).TongTienDichVu) + "";

            //lbTongTienThanhToan.Text = int.Parse(objHoaDon.GetThongTinBanAn_MaHD(MaHoaDon).TongTienBan) + int.Parse(objHoaDon.GetTongTienDichVu_MaHD(MaHoaDon).TongTienDichVu) - int.Parse(objHoaDon.GetTienDatCoc_MaHD(MaHoaDon).TienDatCoc) + "";
            lbTongTienThanhToan.Text = (int.Parse(cthd.TongTienHoaDon) - int.Parse(objHoaDon.GetTienDatCoc_MaHD(MaHoaDon).TienDatCoc)).ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
