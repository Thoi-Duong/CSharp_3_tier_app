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
    public class DanhSachDAO : DBConnection
    {
        public DanhSachDAO() : base() { }

        public DataTable GetDSMonAn()
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

        public DataTable GetDSDichVu()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT MaDichVu,TenDichVu,DonGiaDichVu,GhiChu FROM DICHVU", conn);
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

        public bool UpdateMonAn(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "UPDATE MONAN SET TenMonAn='" + ds.TenMonAn + "', DonGiaMonAn=" + ds.DonGiaMonAn + ",GhiChu='" + ds.GhiChu + "' where MaMonAn=" + ds.MaMonAn;
                OleDbCommand cmd = new OleDbCommand(strcmd, conn);
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

        public bool ThemMonAn(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO MONAN(TenMonAn,DonGiaMonAn,GhiChu) VALUES ('" + ds.TenMonAn + "'," + ds.DonGiaMonAn + ",'" + ds.GhiChu + "')", conn);
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

        public bool XoaMonAn(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM MONAN WHERE MaMonAn =" + ds.MaMonAn + "", conn);
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

        public bool ThemDichVu(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO DICHVU(TenDichVu,DonGiaDichVu,GhiChu) VALUES ('" + ds.TenDichVu + "'," + ds.DonGiaDichVu + ",'" + ds.GhiChu + "')", conn);
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

        public bool XoaDichVu(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM DICHVU WHERE MaDichVu =" + ds.MaDichVu + "", conn);
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

        public bool UpdateDichVu(Danhsach ds)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "UPDATE DICHVU SET TenDichVu='" + ds.TenDichVu + "', DonGiaDichVu=" + ds.DonGiaDichVu + ",GhiChu='" + ds.GhiChu + "' where MaDichVu=" + ds.MaDichVu;
                OleDbCommand cmd = new OleDbCommand(strcmd, conn);
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
    }
}
