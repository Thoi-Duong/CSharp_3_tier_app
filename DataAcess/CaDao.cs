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
    public class CaDAO : DBConnection
    {
        public CaDAO() : base() { }

        public DataTable GetCa()
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM LOAICA", conn);
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

        public bool UpdateCa(Ca ca)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "UPDATE LOAICA SET TenLoaiCa='" + ca.TenLoaiCa.ToString() + "', GhiChu='" + ca.GhiChu.ToString() + "' where MaLoaiCa=" + ca.MaLoaiCa;
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


        public bool XoaSanh(int ca)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM LOAICA WHERE MaLoaiCa =" + ca + "", conn);
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

        public bool ThemCa(Ca ca)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO LOAICA([TenLoaiCa],[GhiChu]) VALUES (@tenloaica,@ghichu)", conn);
                cmd.Parameters.Add("@tenloaica", OleDbType.BSTR).Value = ca.TenLoaiCa;
                cmd.Parameters.Add("@ghichu", OleDbType.BSTR).Value = ca.GhiChu;
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
