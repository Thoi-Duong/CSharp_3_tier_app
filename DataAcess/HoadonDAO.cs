using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using DTO;

namespace DataAcessTier
{
    public class HoadonDAO : DBConnection
    {
        public HoadonDAO() : base() { }

        //lấy ds đặt dịch vụ theo mactpdt
        public DataTable GetDSDatDichVu(string mact_pdt)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT DATDICHVU.MaDichVu, DICHVU.TenDichVu, DATDICHVU.SoLuong, DICHVU.DonGiaDichVu, [DATDICHVU].[soluong]*[Dichvu].[dongiadichvu] AS ThanhTienDichVu FROM DICHVU INNER JOIN (DATDICHVU INNER JOIN (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu WHERE (((CT_PDT.MaPhieuDatTiec)=@MaCT_PDT));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        //lấy ds đặt món ăn theo mact_pdt
        public DataTable GetDSDatMonAn(string mact_pdt)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MONAN.MaMonAn, MONAN.TenMonAn, MONAN.DonGiaMonAn, MONAN.GhiChu FROM PHIEUDATTIEC INNER JOIN (MONAN INNER JOIN (DATMONAN INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON MONAN.MaMonAn = DATMONAN.MaMonAn) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY MONAN.MaMonAn, MONAN.TenMonAn, MONAN.DonGiaMonAn, MONAN.GhiChu, PHIEUDATTIEC.MaPhieuDatTiec HAVING (((PHIEUDATTIEC.MaPhieuDatTiec)=@MaCT_PDT));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        //lấy ds đặt dịch vụ theo mahoadon
        public DataTable GetDSDatDichVu_MaHD(string mahd)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT DATDICHVU.MaDichVu, DICHVU.TenDichVu, DATDICHVU.SoLuong, DICHVU.DonGiaDichVu, [DATDICHVU].[soluong]*[Dichvu].[dongiadichvu] AS ThanhTienDichVu FROM (DICHVU INNER JOIN (DATDICHVU INNER JOIN (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu) INNER JOIN HOADON ON KHACHHANG.MaKhachHang = HOADON.MaKhachHang WHERE (((HOADON.MaHoaDon)=@mahoadon));", conn);
                //OleDbCommand cmd = new OleDbCommand("SELECT Sum(MONAN.DonGiaMonAn) AS DonGiaBan, CT_PDT.SoLuongBan, [Ct_PDT].[soluongban]*[dongiaban] AS TongTienBan FROM (LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN (PHIEUDATTIEC INNER JOIN (MONAN INNER JOIN (DATMONAN INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON MONAN.MaMonAn = DATMONAN.MaMonAn) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((PHIEUDATTIEC.MaPhieuDatTiec)=@MaCT_PDT)) GROUP BY CT_PDT.MaPhieuDatTiec, LOAISANH.DonGiaBanToiThieu, CT_PDT.SoLuongBan, [Ct_PDT].[soluongban]*[dongiaban] HAVING (((Sum(MONAN.DonGiaMonAn))>=([LOAISANH].[DonGiaBanToiThieu])));", conn);
                cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        // lấy thông tin về ca, sảnh, ngày tổ chức, số lượng bàn, số lượng bàn dự trữ theo mact_pdt
        public Hoadon GetThongTinCaSanh(string mact_pdt)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, SANH.TenSanh, LOAICA.TenLoaiCa AS Ca, PHIEUDATTIEC.NgayToChuc, CT_PDT.SoLuongBan, CT_PDT.SoBanDuTru, KHACHHANG.DienThoai FROM (LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN ((LOAICA INNER JOIN PHIEUDATTIEC ON LOAICA.MaLoaiCa = PHIEUDATTIEC.MaLoaiCa) INNER JOIN (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((CT_PDT.MaPhieuDatTiec)=@MaCT_PDT));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TenChuRe = rd["TenChuRe"].ToString();
                    hd.TenCoDau = rd["TenCoDau"].ToString();
                    hd.TenSanh = rd["TenSanh"].ToString();
                    hd.Ca = rd["Ca"].ToString();
                    hd.NgayToChuc = rd["NgayToChuc"].ToString();
                    hd.SoLuongBan = rd["SoLuongBan"].ToString();
                    hd.SoBanDuTru = rd["SoBanDuTru"].ToString();
                    hd.SoDienThoai = rd["DienThoai"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //tính tổng tiền dịch vụ theo mactpdt
        public Hoadon GetTongTienDichVu(string mact_pdt)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.MaPhieuDatTiec, Sum([DICHVU].[DonGiaDichVu]*[DATDICHVU].[SoLuong]) AS [TongTienDichVu] FROM DICHVU INNER JOIN (DATDICHVU INNER JOIN CT_PDT ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu GROUP BY CT_PDT.MaPhieuDatTiec, CT_PDT.MaPhieuDatTiec HAVING (((CT_PDT.MaPhieuDatTiec)=@mactpdt));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TongTienDichVu = rd["TongTienDichVu"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //tính tổng tiền dịch vụ theo mahoadon
        public Hoadon GetTongTienDichVu_MaHD(string mahd)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(DICHVU.DonGiaDichVu*DATDICHVU.SoLuong) AS TongTienDichVu, HOADON.MaHoaDon FROM (DICHVU INNER JOIN (DATDICHVU INNER JOIN CT_PDT ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu) INNER JOIN HOADON ON CT_PDT.MaKhachHang = HOADON.MaKhachHang GROUP BY CT_PDT.MaPhieuDatTiec, HOADON.MaHoaDon HAVING (((HOADON.MaHoaDon)=@mahoadon));", conn);
                cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TongTienDichVu = rd["TongTienDichVu"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //lấy thông tin về số lượng bàn, đơn giá bàn, tổng tiền bàn theo mactpdt
        public Hoadon GetThongTinBanAn(string mact_pdt)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(MONAN.DonGiaMonAn) AS DonGiaBanAn, CT_PDT.SoLuongBan, [ct_PDT].[soLuongBan]*DonGiaBanAn AS TongTienBan FROM (LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN (PHIEUDATTIEC INNER JOIN (MONAN INNER JOIN (DATMONAN INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON MONAN.MaMonAn = DATMONAN.MaMonAn) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((PHIEUDATTIEC.MaPhieuDatTiec)=@mact_pdt)) GROUP BY CT_PDT.SoLuongBan, CT_PDT.MaPhieuDatTiec, LOAISANH.DonGiaBanToiThieu HAVING (((Sum(MONAN.DonGiaMonAn))>=([LOAISANH].[DonGiaBanToiThieu])));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();

                    hd.DonGiaBan = rd["DonGiaBanAn"].ToString();
                    hd.SoLuongBan = rd["SoLuongBan"].ToString();
                    hd.TongTienBan = int.Parse(hd.DonGiaBan) * int.Parse(hd.SoLuongBan) + "";
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }


        //lấy thông tin về số lượng bàn, đơn giá bàn, tổng tiền bàn theo mahd
        public Hoadon GetThongTinBanAn_MaHD(string mahd)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(MONAN.DonGiaMonAn) AS DonGiaBanAn, CT_PDT.SoLuongBan, [ct_PDT].[soLuongBan]*DonGiaBanAn AS TongTienBan FROM ((LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN (PHIEUDATTIEC INNER JOIN (MONAN INNER JOIN (DATMONAN INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON MONAN.MaMonAn = DATMONAN.MaMonAn) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh) INNER JOIN HOADON ON CT_PDT.MaKhachHang = HOADON.MaKhachHang GROUP BY CT_PDT.SoLuongBan, CT_PDT.MaPhieuDatTiec, LOAISANH.DonGiaBanToiThieu, HOADON.MaHoaDon HAVING (((Sum(MONAN.DonGiaMonAn))>=([LOAISANH].[DonGiaBanToiThieu])) AND ((HOADON.MaHoaDon)=@mahoadon)); ", conn);
                cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
                OleDbDataReader rd = cmd.ExecuteReader();
                rd.Read();
                    hd = new Hoadon();

                    hd.DonGiaBan = rd["DonGiaBanAn"].ToString();
                    hd.SoLuongBan = rd["SoLuongBan"].ToString();
                    hd.TongTienBan = int.Parse(hd.DonGiaBan) * int.Parse(hd.SoLuongBan) + "";
                    rd.Close();
                    return hd;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
            return hd;
        }

        //lấy thông tin tiền đặt cọc theo mapctdt
        public Hoadon GetTienDatCoc(string mact_pdt)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.TienDatCoc, CT_PDT.MaPhieuDatTiec FROM KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang WHERE (((CT_PDT.MaPhieuDatTiec)=@mact_pdt));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TienDatCoc = rd["TienDatCoc"].ToString();
                    rd.Close();
                }

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //lấy thông tin tiền đặt cọc theo mahd
        public Hoadon GetTienDatCoc_MaHD(string mahd)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.TienDatCoc, HOADON.MaHoaDon FROM (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) INNER JOIN HOADON ON KHACHHANG.MaKhachHang = HOADON.MaKhachHang WHERE (((HOADON.MaHoaDon)=@mahoadon));", conn);
                cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TienDatCoc = rd["TienDatCoc"].ToString();
                    rd.Close();
                }

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //lấy danh sách đặt tiệc trong trường hợp tiệc chưa nằm trong hoá đơn
        public DataTable GetDSThongTinDatTiec()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.MaPhieuDatTiec, KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, SANH.TenSanh, PHIEUDATTIEC.NgayToChuc, LOAICA.TenLoaiCa AS Ca FROM SANH INNER JOIN ((LOAICA INNER JOIN PHIEUDATTIEC ON LOAICA.MaLoaiCa = PHIEUDATTIEC.MaLoaiCa) INNER JOIN (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((CT_PDT.MaKhachHang) Not In (SELECT MaKhachHang FROM HOADON)));", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        //lấy thông tin tên cô dâu, chú rể và tổng tiền thanh toán thông qua mact_pdt 
        public Hoadon GetTenCoDauChuRe(string mact_pdt)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, KHACHHANG.MaKhachHang FROM KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang WHERE (((CT_PDT.MaPhieuDatTiec)=@MaCT_PDT));", conn);
                cmd.Parameters.Add("@MaCT_PDT", OleDbType.BSTR).Value = mact_pdt;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TenChuRe = rd["TenChuRe"].ToString();
                    hd.TenCoDau = rd["TenCoDau"].ToString();
                    hd.MaKhachHang = rd["MaKhachHang"].ToString();
                    rd.Close();
                }

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        //lấy thông tin tên cô dâu, chú rể và tổng tiền thanh toán theo mã hoá đơn
        public Hoadon GetTenCoDauChuRe_MaHD(string mahd)
        {
            Hoadon hd = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT KHACHHANG.TenChuRe, KHACHHANG.TenCoDau FROM (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) INNER JOIN HOADON ON KHACHHANG.MaKhachHang = HOADON.MaKhachHang WHERE (((HOADON.MaHoaDon)=@mahoadon));", conn);
                cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd = new Hoadon();
                    hd.TenChuRe = rd["TenChuRe"].ToString();
                    hd.TenCoDau = rd["TenCoDau"].ToString();
                    rd.Close();
                }

            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return hd;
        }

        // lấy thông tin về những hoá đơn chưa thanh toán
        public DataTable GetDSLapHoaDon()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.MaPhieuDatTiec, CT_PDT.MaKhachHang, KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, CT_PDT.TienDatCoc FROM KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang WHERE (((CT_PDT.MaKhachHang) Not In (SELECT MaKhachHang FROM HOADON)));", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        public DataTable GetDSHoaDonThanhToan() // lấy danh sách các hoá đơn đã thanh toán 
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT HOADON.MaHoaDon, HOADON.MaKhachHang, KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, HOADON.NgayThanhToan, HOADON.TongTienThanhToan FROM HOADON INNER JOIN KHACHHANG ON HOADON.MaKhachHang = KHACHHANG.MaKhachHang; ", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        public Hoadon GetMaHD(string makh, string ngaytt) //get mãhd từ mãkh , support cho hàm addhoadon
        {
            Hoadon hd = new Hoadon();
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT HOADON.MaHoaDon FROM HOADON WHERE (((HOADON.MaKhachHang)=" + makh + ") AND ((HOADON.NgayThanhToan)=#" + ngaytt + "#))", conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    hd.MaHoaDon = rd["MaHoaDon"].ToString();
                    rd.Close();
                }
                conn.Close();
                return hd;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex);
                return null;
            }
        }


        
        public string GetMaPDT(string mahoadon) //get mã ct_pdt từ bảng ct_hd (do bảng ct_hd k bị mất )
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_HD.MaPhieuDatTiec FROM CT_HD WHERE (((CT_HD.MaHoaDon)="+mahoadon+"));", conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return rd["MaPhieuDatTiec"].ToString();
                    rd.Close();
                }
                conn.Close();
                return "";
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex);
                return null;
            }
        }

        // add hoá đơn và chi tiết hoá đơn 
        public bool AddHoaDon(Hoadon hd)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open(); //add hoa don
                OleDbCommand cmd = new OleDbCommand("INSERT INTO HOADON([MaKhachHang],[NgayThanhToan],[TongTienThanhToan]) VALUES (" + hd.MaKhachHang + ",#" + hd.NgayThanhToan + "#," + hd.TongTienThanhToan + ")", conn);
                cmd.ExecuteNonQuery();

                Hoadon hd1 = GetMaHD(hd.MaKhachHang, hd.NgayThanhToan); // get mahd, add chi tiet hoa don
                OleDbCommand cmd1 = new OleDbCommand("INSERT INTO CT_HD([MaHoaDon],[MaPhieuDatTiec],[TongTienDichVu],[TongTienHoaDon],[TongTienBan]) VALUES (" + hd1.MaHoaDon + "," + hd.MaPhieuDatTiec + "," + hd.TongTienDichVu + "," + hd.TongTienHoaDon + "," + hd.TongTienBan + ")", conn);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                conn.Close();
                Console.WriteLine(ex);
                return false;
            }
        }

        //public Hoadon GetMaCTPDT(string mahd) // lấy mã ctpdt từ hoá đơn và chi tiết hoá đơn
        //{
        //    Hoadon hd = null;
        //    try
        //    {
        //        if (conn.State != ConnectionState.Open) conn.Open();
        //        OleDbCommand cmd = new OleDbCommand("SELECT CT_PDT.MaPhieuDatTiec, HOADON.MaHoaDon, CT_HD.TongTienDichVu, CT_HD.TongTienHoaDon, CT_HD.TongTienBan FROM HOADON INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON HOADON.MaHoaDon = CT_HD.MaHoaDon WHERE (((HOADON.MaHoaDon)=@mahoadon));", conn);
        //        cmd.Parameters.Add("@mahoadon", OleDbType.BSTR).Value = mahd;
        //        OleDbDataReader rd = cmd.ExecuteReader();
        //        if (rd.Read())
        //        {
        //            hd = new Hoadon();
        //            hd.MaChiTietPhieuDatTiec = rd["MaPhieuDatTiec"].ToString();
        //            rd.Close();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        conn.Close();
        //        Console.WriteLine(e.ToString());
        //    }
        //    return hd;
        //}


        //phan them vao tra cuu hoa don
        public DataTable GetTraCuuHoaDon(string mahoadon, string chure, string codau)
        {
            try
            {
                if (mahoadon == "")
                {
                    mahoadon = "0";
                }
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT HOADON.MaHoaDon, KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, HOADON.NgayThanhToan, HOADON.TongTienThanhToan FROM HOADON INNER JOIN KHACHHANG ON HOADON.MaKhachHang = KHACHHANG.MaKhachHang WHERE (((KHACHHANG.TenChuRe)=@TenChuRe)) OR (((KHACHHANG.TenCoDau)=@TenCoDau)) OR (((HOADON.MaHoaDon)=" + mahoadon + "));", conn);
                cmd.Parameters.Add("@TenChuRe", OleDbType.BSTR).Value = chure;
                cmd.Parameters.Add("@TenCoDau", OleDbType.BSTR).Value = codau;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteReader();
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                conn.Close();
            }
            return null;
        }


        //xoá hoá đơn bằng mã hoá đơn
        public bool XoaHoaDon(Hoadon hd)
        {
            {
                try
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM HOADON WHERE (((HOADON.[MaHoaDon])=" + hd.MaHoaDon + "));", conn);
                    cmd.ExecuteNonQuery();

                    //OleDbCommand cmd1 = new OleDbCommand("DELETE CT_HD.MaHoaDon FROM CT_HD WHERE (((CT_HD.MaHoaDon)=" + hd.MaHoaDon + "));", conn);
                    //cmd1.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    conn.Close();
                    Console.WriteLine();
                    return false;
                }
            }
        }

        //cập nhật lại thông tin số lượng bàn sử dụng, tiền thanh toán, tiền bàn, tiền phạt, sau khi đã tiến hành lập hoá đơn
        public Hoadon getChiTietHoaDon(string MaHD)
        {
            Hoadon cthd = new Hoadon();
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT CT_HD.TongTienDichVu, CT_HD.TongTienHoaDon, CT_HD.TongTienBan FROM CT_HD WHERE (((CT_HD.MaHoaDon)=" + MaHD + "));", conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    cthd.MaHoaDon = MaHD;
                    cthd.TongTienDichVu = rd["TongTienDichVu"].ToString();
                    cthd.TongTienBan = rd["TongTienBan"].ToString();
                    cthd.TongTienHoaDon = rd["TongTienHoaDon"].ToString();
                    rd.Close();
                }
                conn.Close();
                return cthd;
            }
            catch (Exception)
            {
                conn.Close();
                Console.WriteLine();
                return null;
            }
        }


        //xoa ct_pdt sau khi đã xoá hd thành công bằng mãct_PDT
        public bool XoaCT_PDT(Hoadon hd)
        {
            {
                try
                {
                    if (conn.State != ConnectionState.Open) conn.Open();
                    OleDbCommand cmd = new OleDbCommand("DELETE FROM CT_PDT WHERE (((CT_PDT.[MaPhieuDatTiec])="+hd.MaPhieuDatTiec+"));", conn);
                    cmd.ExecuteNonQuery();

                    //OleDbCommand cmd1 = new OleDbCommand("DELETE CT_HD.MaHoaDon FROM CT_HD WHERE (((CT_HD.MaHoaDon)=" + hd.MaHoaDon + "));", conn);
                    //cmd1.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
                catch (Exception)
                {
                    conn.Close();
                    Console.WriteLine();
                    return false;
                }
            }
        }


    }
}


