using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.OleDb;

namespace DataAcessTier
{
    public class TraCuuDAO : DBConnection
    {
        public TraCuuDAO() : base() { }
        string MaPDT = null;
        public DataTable getTraCuu(string mapdt, string chure, string codau)
        {
            try
            {
                if (mapdt == "")
                {
                    mapdt = "0";
                }
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = 
                    new OleDbCommand("SELECT  CT_PDT.MaPhieuDatTiec,KHACHHANG.TenChuRe, KHACHHANG.TenCoDau, SANH.TenSanh, PHIEUDATTIEC.NgayToChuc, LOAICA.TenLoaiCa, CT_PDT.SoLuongBan FROM (LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN (LOAICA INNER JOIN (PHIEUDATTIEC INNER JOIN (KHACHHANG INNER JOIN CT_PDT ON KHACHHANG.MaKhachHang = CT_PDT.MaKhachHang) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON LOAICA.MaLoaiCa = PHIEUDATTIEC.MaLoaiCa) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((KHACHHANG.TenChuRe)=@tenchure)) OR ((KHACHHANG.TenCoDau)=@tencodau) OR (((CT_PDT.MaPhieuDatTiec)=" + mapdt + "))", conn);
                cmd.Parameters.Add("@tenchure", OleDbType.BSTR).Value = chure;
                cmd.Parameters.Add("@tencodau", OleDbType.BSTR).Value = codau;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmd.ExecuteReader();
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }

        public DataTable GetDSMonAn(string mapdt)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MONAN.TenMonAn, MONAN.DonGiaMonAn, MONAN.GhiChu FROM (MONAN INNER JOIN DATMONAN ON MONAN.MaMonAn = DATMONAN.MaMonAn) INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec WHERE (((DATMONAN.MaPhieuDatTiec)=" + mapdt + "))", conn);
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

        public DataTable GetDSDichVu(string mapdt)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT DICHVU.TenDichVu, DATDICHVU.SoLuong, DICHVU.DonGiaDichVu FROM DICHVU INNER JOIN (DATDICHVU INNER JOIN CT_PDT ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu WHERE (((DATDICHVU.MaPhieuDatTiec)=" + mapdt + "))", conn);
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

        public DataTable GetLoaiCa()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM LOAICA", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt, "LOAICA");
                conn.Close();
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return null;
        }
    }
}
