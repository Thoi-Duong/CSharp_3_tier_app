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
    public class SanPhamDAO:DBConnection
    {
        public SanPhamDAO() : base() { }
        public DataTable GetsanphamByMADM(string strdm)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from tbSanPham where madm=@madm order by MaSP ASC", conn);
                cmd.Parameters.Add("@madm", OleDbType.BSTR).Value = strdm;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public Sanpham GetsanphamByMASP(string strSP)
        {
            Sanpham sp = null;
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from tbSanPham where masp=@masp order by MaSP ASC", conn);
                cmd.Parameters.Add("@masp", OleDbType.BSTR).Value = strSP;
                OleDbDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    sp = new Sanpham();
                    sp.Masanpham = rd["MaSP"].ToString();
                    sp.Tensanpham = rd["TenSP"].ToString();
                    sp.Soluong = (int)rd["SoLuong"];
                    sp.DonGia = (int)rd["DonGia"];
                    sp.XuatXu = rd["XuatXu"].ToString();
                    sp.MaDanhMuc = rd["MaDM"].ToString();
                    rd.Close();
                }
            }
            catch (Exception e)
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return sp;
        }

        public string GetTendanhmuc(string strMaDM)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("select * from tbDanhMuc where madm=@madm order by MaSP ASC", conn);
                cmd.Parameters.Add("@madm", OleDbType.BSTR).Value = strMaDM;
                OleDbDataReader rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    return rd["TenDM"].ToString();
                }
                rd.Close();
            }
            catch (Exception e )
            {
                conn.Close();
                Console.WriteLine(e.ToString());
            }
            return null;
        }

        public bool Addsanpham(Sanpham sp)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                OleDbCommand cmd = new OleDbCommand("INSERT INTO tbSANPHAM([MASP],[TENSP],[SOLUONG],[DONGIA],[XUATXU],[MADM]) VALUES(@masp, @tensp, @soluong, @dongia, @xuatxu, @madm)", conn);
                cmd.Parameters.Add("@masp", OleDbType.BSTR).Value = sp.Masanpham;
                cmd.Parameters.Add("@tensp", OleDbType.BSTR).Value = sp.Tensanpham;
                cmd.Parameters.Add("@soluong", OleDbType.Numeric).Value = sp.Soluong;
                cmd.Parameters.Add("@dongia", OleDbType.Numeric).Value = sp.DonGia;
                cmd.Parameters.Add("@xuatxu", OleDbType.BSTR).Value = sp.XuatXu;
                cmd.Parameters.Add("@madm", OleDbType.BSTR).Value = sp.MaDanhMuc;
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

        public bool Updatesanpham(Sanpham sp)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "UPDATE tbSANPHAM SET TENSP='" + sp.Tensanpham + "', SOLUONG='" + sp.Soluong.ToString() + "', DONGIA='" + sp.DonGia.ToString() + "', XUATXU='" + sp.XuatXu + "',MADM='" + sp.MaDanhMuc + "' where MASP='" + sp.Masanpham + "'";
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

        public bool Xoasanpham(Sanpham sp)
        {
            try
            {
                if (conn.State != ConnectionState.Open) conn.Open();
                string strcmd = "DELETE FROM tbSANPHAM where MASP='" + sp.Masanpham + "'";
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
