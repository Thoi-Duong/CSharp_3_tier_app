using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DataAcessTier
{
    public class DattiecDAO : DBConnection
    {
        public DattiecDAO() : base() { }
        string MaPDT = null;
        public bool Kiemtra(string ngaydattiec, string ca, string sanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT PHIEUDATTIEC.MaPhieuDatTiec FROM SANH INNER JOIN (LOAICA INNER JOIN PHIEUDATTIEC ON LOAICA.MaLoaiCa = PHIEUDATTIEC.MaLoaiCa) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((LOAICA.TenLoaiCa)=@ca) AND ((SANH.TenSanh)=@sanh) AND ((PHIEUDATTIEC.NgayToChuc)=#" + ngaydattiec + "#))", conn);
                cmd.Parameters.Add("@ca", OleDbType.BSTR).Value = ca;
                cmd.Parameters.Add("@sanh", OleDbType.BSTR).Value = sanh;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    return false;
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return true;
        }

        public Dattiec Getloaidattiec(string ca, string sanh)
        {
            Dattiec dt = new Dattiec();
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT LOAICA.MaLoaiCa, SANH.MaSanh FROM LOAICA, SANH WHERE (((LOAICA.TenLoaiCa)=@ca) AND ((SANH.TenSanh)=@sanh))", conn);
                cmd.Parameters.Add("@ca", OleDbType.BSTR).Value = ca;
                cmd.Parameters.Add("@sanh", OleDbType.BSTR).Value = sanh;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    dt.Ca = rd["MaLoaiCa"].ToString();
                    dt.Sanh = rd["MaSanh"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return dt;
        }

        public Dattiec GetloaiMa(string tenchure, string tencodau, int dienthoai, string ngaydattiec, string ca, string sanh)
        {
            Dattiec dt = new Dattiec();
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT KHACHHANG.MaKhachHang, PHIEUDATTIEC.MaPhieuDatTiec FROM KHACHHANG, PHIEUDATTIEC WHERE (((KHACHHANG.TenChuRe)=@tenchure) AND ((KHACHHANG.TenCoDau)=@tencodau) AND ((KHACHHANG.DienThoai)=@dienthoai) AND ((PHIEUDATTIEC.NgayToChuc)=#" + ngaydattiec + "#) AND ((PHIEUDATTIEC.MaLoaiCa)=@ca) AND ((PHIEUDATTIEC.MaSanh)=@sanh))", conn);
                cmd.Parameters.Add("@tenchure", OleDbType.BSTR).Value = tenchure;
                cmd.Parameters.Add("@tencodau", OleDbType.BSTR).Value = tencodau;
                cmd.Parameters.Add("@dienthoai", OleDbType.Numeric).Value = dienthoai;
                cmd.Parameters.Add("@ca", OleDbType.BSTR).Value = ca;
                cmd.Parameters.Add("@sanh", OleDbType.BSTR).Value = sanh;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    dt.Ca = rd["MaPhieuDatTiec"].ToString();
                    dt.Sanh = rd["MaKhachHang"].ToString();
                    MaPDT = dt.Ca;
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return dt;
        }


        public bool Dattiec(Dattiec dattiec)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO KHACHHANG(TenChuRe,TenCoDau,DienThoai) VALUES (@tenchure,@tencodau,@dienthoai)", conn);
                cmd.Parameters.Add("@tenchure", OleDbType.BSTR).Value = dattiec.TenChuRe;
                cmd.Parameters.Add("@tencodau", OleDbType.BSTR).Value = dattiec.TenCoDau;                
                cmd.Parameters.Add("@dienthoai", OleDbType.Numeric).Value = dattiec.DienThoai;
                cmd.ExecuteNonQuery();

                Dattiec dt = Getloaidattiec(dattiec.Ca, dattiec.Sanh);
                OleDbCommand cmd2 = new OleDbCommand("INSERT INTO PHIEUDATTIEC(NgayToChuc,MaLoaiCa,MaSanh) VALUES (#" + dattiec.NgayDatTiec + "#," + dt.Ca + "," + dt.Sanh + ")", conn);
                cmd2.ExecuteNonQuery();

                dt = GetloaiMa(dattiec.TenChuRe, dattiec.TenCoDau, dattiec.DienThoai, dattiec.NgayDatTiec, dt.Ca, dt.Sanh);
                OleDbCommand cmd1 = new OleDbCommand("INSERT INTO CT_PDT([MaPhieuDatTiec],[MaKhachHang],[TienDatCoc],[SoLuongBan],[SoBanDuTru]) VALUES (" + dt.Ca + "," + dt.Sanh + ",@tiendatcoc,@soluongban,@sobandutru)", conn);
                cmd1.Parameters.Add("@tiendatcoc", OleDbType.Numeric).Value = dattiec.TienDatCoc;
                cmd1.Parameters.Add("@soluongban", OleDbType.Numeric).Value = dattiec.SoLuongBan;
                cmd1.Parameters.Add("@sobandutru", OleDbType.Numeric).Value = dattiec.SoBanDuTru;
                cmd1.ExecuteNonQuery();

                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }

        public DataTable GetMonAn()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM MONAN", conn);
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

        public bool DatMonAn(Dattiec monan)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO DATMONAN VALUES (@mapdt,@mamonan)", conn);
                cmd.Parameters.Add("@mapdt", OleDbType.BSTR).Value = MaPDT;
                cmd.Parameters.Add("@mamonan", OleDbType.BSTR).Value = monan.MaMonAn;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }

        public DataTable GetDichVu()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM DICHVU", conn);
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

        public bool DatDichVu(Dattiec dichvu)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO DATDICHVU VALUES (@mapdt,@madichvu,@sldichvu)", conn);
                cmd.Parameters.Add("@mapdt", OleDbType.BSTR).Value = MaPDT;
                cmd.Parameters.Add("@madichvu", OleDbType.BSTR).Value = dichvu.MaDichVu;
                cmd.Parameters.Add("@sldichvu", OleDbType.BSTR).Value = dichvu.SoLuongDV;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }

        public DataTable GetLoaiCa()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TenLoaiCa FROM LOAICA", conn);
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

        public DataTable GetSanh()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT TenSanh FROM SANH", conn);
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

        public DataTable GetDSMonAn()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MONAN.TenMonAn, MONAN.DonGiaMonAn, MONAN.GhiChu FROM (MONAN INNER JOIN DATMONAN ON MONAN.MaMonAn = DATMONAN.MaMonAn) INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec WHERE (((DATMONAN.MaPhieuDatTiec)=" + MaPDT + "))", conn);
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

        public DataTable GetDSDichVu()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT DICHVU.TenDichVu, DATDICHVU.SoLuong, DICHVU.DonGiaDichVu FROM DICHVU INNER JOIN (DATDICHVU INNER JOIN CT_PDT ON DATDICHVU.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON DICHVU.MaDichVu = DATDICHVU.MaDichVu WHERE (((DATDICHVU.MaPhieuDatTiec)=" + MaPDT + "))", conn);
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

        public bool KiemTraDonGiaBan()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Sum(MONAN.DonGiaMonAn) AS DonGiaBan FROM (LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh) INNER JOIN (PHIEUDATTIEC INNER JOIN (MONAN INNER JOIN (DATMONAN INNER JOIN CT_PDT ON DATMONAN.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON MONAN.MaMonAn = DATMONAN.MaMonAn) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON SANH.MaSanh = PHIEUDATTIEC.MaSanh WHERE (((PHIEUDATTIEC.MaPhieuDatTiec)=" + MaPDT + ")) GROUP BY CT_PDT.MaPhieuDatTiec, LOAISANH.DonGiaBanToiThieu HAVING (((Sum(MONAN.DonGiaMonAn))>=([LOAISANH].[DonGiaBanToiThieu])))", conn);
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            OleDbCommand cmd1 = new OleDbCommand("DELETE FROM DATMONAN WHERE DATMONAN.MaPhieuDatTiec=" + MaPDT + "", conn);
            cmd1.ExecuteReader();
            conn.Close();
            return false;
        }

        public bool KiemTraBan(string loaisanh, int ban)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT SANH.MaSanh FROM LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh WHERE (((SANH.TenSanh)=@loaisanh) AND ((" + ban + ")<=[SANH].[SoLuongBanToiDa]))", conn);
                cmd.Parameters.Add("@loaisanh", OleDbType.BSTR).Value = loaisanh;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    rd.Close();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            conn.Close();
            return false;
        }
    }
}