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
    public partial class ChiTietPhieuDatTiecForm : Form
    {
        FormDanhSachTiecCanLapHoaDon f = new FormDanhSachTiecCanLapHoaDon();
        Hoadon hd = new Hoadon();
        hoadonBUS objHoaDon = new hoadonBUS();
        DataTable tbHoaDon1, tbHoaDon2;
        public static string MaCT_PDT = "";
        int TienBan_BanDau;
        int TienBan;
        int TongTienHoaDon;
        int TienConLai;
        int TienPhat;
        int TienCoc;
        int TienDichVu;
        int DonGiaBan;

        public ChiTietPhieuDatTiecForm(FormDanhSachTiecCanLapHoaDon f1,string a)
        {
            InitializeComponent();
            MaCT_PDT = a;
            f = f1;
        }


        private void ChiTietHoaDonForm_Load(object sender, EventArgs e)
        {
            int SoBanDuTru = int.Parse(objHoaDon.GetThongTinCaSanh(MaCT_PDT).SoBanDuTru);
            string[] obj = new string[SoBanDuTru + 1];
            for (int i = 0; i <= SoBanDuTru; i++)
            {
                obj[i] = i.ToString();
            }
            comboBoxSuDung.Items.AddRange(obj);
            comboBoxSuDung.SelectedIndex = 0;
            DonGiaBan = int.Parse(objHoaDon.GetThongTinBanAn(MaCT_PDT).DonGiaBan);
            TienBan_BanDau = DonGiaBan * (int.Parse(objHoaDon.GetThongTinBanAn(MaCT_PDT).SoLuongBan));
            TienDichVu = int.Parse(objHoaDon.GetTongTienDichVu(MaCT_PDT).TongTienDichVu);
            TongTienHoaDon = TienBan_BanDau + TienDichVu;
            TienCoc = int.Parse(objHoaDon.GetTienDatCoc(MaCT_PDT).TienDatCoc);
            TienConLai = TongTienHoaDon - TienCoc;

            DateTime NgayThanhToan = DateTime.Now;
            DateTime NgayToChuc = Convert.ToDateTime(objHoaDon.GetThongTinCaSanh(MaCT_PDT).NgayToChuc);
            int SoNgayTreHen = (int)NgayThanhToan.Subtract(NgayToChuc).TotalDays;
            if (SoNgayTreHen <= 0) SoNgayTreHen = 0;
            TienPhat = (int)TienConLai / 100 * SoNgayTreHen;

            TongTienHoaDon += TienPhat;
            TienConLai += TienPhat;

            lbTongTienHoaDon.Text = TongTienHoaDon.ToString();
            lbTongTienThanhToan.Text = TienConLai.ToString();

            this.lblMaCT_PDT.Text = MaCT_PDT;
            tbHoaDon1 = objHoaDon.GetDSDatDichVu(MaCT_PDT);
            tbHoaDon2 = objHoaDon.GetDSDatMonAn(MaCT_PDT);
            dgvGetDSdichvu.DataSource = tbHoaDon1;
            dgvGetDSDatMonAn.DataSource = tbHoaDon2;
            lbCa.Text = objHoaDon.GetThongTinCaSanh(MaCT_PDT).Ca;
            lbSanh.Text = objHoaDon.GetThongTinCaSanh(MaCT_PDT).TenSanh;
            lbSoDienThoai.Text = objHoaDon.GetThongTinCaSanh(MaCT_PDT).SoDienThoai;
            lbSoBanDuTru.Text = SoBanDuTru.ToString();
            lbNgayToChuc.Text = NgayToChuc.ToString("d");
            lbDonGia.Text = objHoaDon.GetThongTinBanAn(MaCT_PDT).DonGiaBan;
            lbSoLuongBan.Text = objHoaDon.GetThongTinBanAn(MaCT_PDT).SoLuongBan;
            lbTongTienBan.Text = TienBan_BanDau.ToString();
            lbTongTienDichVu.Text = objHoaDon.GetTongTienDichVu(MaCT_PDT).TongTienDichVu;
            lbTienDatCoc.Text = objHoaDon.GetTienDatCoc(MaCT_PDT).TienDatCoc;
            lbTenChuRe.Text = objHoaDon.GetTenCoDauChuRe(MaCT_PDT).TenChuRe;
            lbTenCoDau.Text = objHoaDon.GetTenCoDauChuRe(MaCT_PDT).TenCoDau;
            ckbTienPhat.Text = TienPhat.ToString() + " (Quá hạn " + SoNgayTreHen + " ngày)";

        }

        private void buttonThanhToan_Click(object sender, EventArgs e)
        {
            string ngaythanhtoan = DateTime.Now.ToString("d");
            string makhachhang = objHoaDon.GetTenCoDauChuRe(MaCT_PDT).MaKhachHang;
            string tongtienthanhtoan = lbTongTienThanhToan.Text;
            string tongtiendichvu = TienDichVu.ToString();
            string tongtienhoadon = TongTienHoaDon.ToString();
            string tongtienban = lbTongTienBan.Text;
            string maphieudattiec = MaCT_PDT;
            //string mahoadon = objHoaDon.GetMaHoaDon(MaCT_PDT).MaHoaDon;
            Hoadon hd = new Hoadon(makhachhang, ngaythanhtoan, tongtienthanhtoan, maphieudattiec, tongtiendichvu, tongtienhoadon, tongtienban);
            //Hoadon hd1 = new Hoadon(mahoadon,maphieudattiec,tongtiendichvu, tongtienhoadon, tongtienban);
            if (objHoaDon.AddHoaDon(hd))
            {
                //xoá luôn chi tiết phiếu đặt tiệc , giữ lại ct_hd để hoá đơn sau khi xoá không quay trở lại danh sách tiệc cưới =))
                MessageBox.Show("Lập Hoá Đơn Thành Công");
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Thất bại");
            }
            f.updateDgvDSLapHoaDon();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void comboBoxSuDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ckbTienPhat.Checked)
            {
                TienBan = TienBan_BanDau + int.Parse(comboBoxSuDung.SelectedItem.ToString()) * DonGiaBan;
                TongTienHoaDon = TienBan + int.Parse(objHoaDon.GetTongTienDichVu(MaCT_PDT).TongTienDichVu);
                TienConLai = TongTienHoaDon - TienCoc;
            }
            else
            {
                TienBan = TienBan_BanDau + int.Parse(comboBoxSuDung.SelectedItem.ToString()) * DonGiaBan;
                TongTienHoaDon = TienBan + int.Parse(objHoaDon.GetTongTienDichVu(MaCT_PDT).TongTienDichVu) + TienPhat;
                TienConLai = TongTienHoaDon - TienCoc;
            }

            lbTongTienBan.Text = TienBan.ToString();
            lbTongTienHoaDon.Text = TongTienHoaDon.ToString();
            lbTongTienThanhToan.Text = TienConLai.ToString();
        }

        private void ckbTienPhat_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbTienPhat.Checked)
            {
                TongTienHoaDon -= TienPhat;
                TienConLai -= TienPhat;

                lbTongTienHoaDon.Text = TongTienHoaDon.ToString();
                lbTongTienThanhToan.Text = TienConLai.ToString();
            }
            else
            {
                TongTienHoaDon += TienPhat;
                TienConLai += TienPhat;

                lbTongTienHoaDon.Text = TongTienHoaDon.ToString();
                lbTongTienThanhToan.Text = TienConLai.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
