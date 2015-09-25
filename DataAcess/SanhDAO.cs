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
    public class SanhDAO : DBConnection
    {
        public SanhDAO() : base() { }
        public bool Deletedanhmuc(string tenloaisanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                OleDbCommand cmd = new OleDbCommand("DELETE LOAISANH.TenLoaiSanh FROM LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh WHERE LOAISANH.TenLoaiSanh=@tenloaisanh", conn);
                cmd.Parameters.Add("@tenloaisanh", OleDbType.BSTR).Value = tenloaisanh;
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

        public DataTable getAlldanhmuc()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT LOAISANH.MaLoaiSanh,SANH.TenSanh, LOAISANH.TenLoaiSanh, SANH.SoLuongBanToiDa, LOAISANH.DonGiaBanToiThieu, SANH.GhiChu FROM LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh", conn);
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

        public DataTable getLoaiSanh()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM LOAISANH", conn);
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

        public Sanh GetloaisanhByMALS(string strLS)
        {
            Sanh s = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT LOAISANH.MaLoaiSanh,SANH.TenSanh, LOAISANH.TenLoaiSanh, SANH.SoLuongBanToiDa, LOAISANH.DonGiaBanToiThieu, SANH.GhiChu FROM LOAISANH INNER JOIN SANH ON LOAISANH.MaLoaiSanh = SANH.MaLoaiSanh where LOAISANH.MaLoaiSanh=@mals", conn);
                cmd.Parameters.Add("@mals", OleDbType.BSTR).Value = strLS;
                OleDbDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    s = new Sanh();
                    s.TenSanh = rd["TenSanh"].ToString();
                    s.TenLoaiSanh = rd["TenLoaiSanh"].ToString();
                    s.SLBanToiDa = (int)rd["SoLuongBanToiDa"];
                    s.DGBanToiThieu = (int)rd["DonGiaBanToiThieu"];
                    s.GhiChu = rd["GhiChu"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
            }
            return s;
        }

        public bool UpdateSanh(Sanh sanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "UPDATE LOAISANH SET TenLoaiSanh='" + sanh.TenLoaiSanh + "', DonGiaBanToiThieu='" + sanh.DGBanToiThieu.ToString() + "' where MaLoaiSanh=" + sanh.MaLoaiSanh;
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

        public bool ThemSanh(Sanh sanh)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO LOAISANH([TenLoaiSanh],[DonGiaBanToiThieu]) VALUES (@tenloaisanh,@dongia)", conn);
                cmd.Parameters.Add("@tenloaisanh", OleDbType.BSTR).Value = sanh.TenLoaiSanh;
                cmd.Parameters.Add("@dongia", OleDbType.BSTR).Value = sanh.DGBanToiThieu;
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

        public bool XoaSanh(int ls)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM LOAISANH WHERE MaLoaiSanh =" + ls + "", conn);
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
