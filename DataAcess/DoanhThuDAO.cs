using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace DataAcessTier
{
    public class DoanhThuDAO : DBConnection
    {
        public DoanhThuDAO() : base() { }

        public DataTable getDoanhThu(string thang, string nam)
        {
            try
            {
                OleDbCommand cmd = new OleDbCommand();
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                if (thang == "" && nam == "")
                {
                    cmd = new OleDbCommand("SELECT Str(Month([NgayToChuc]))+'/'+Str(Year([NgayToChuc])) AS Tháng, Sum(CT_HD.TongTienHoaDon) AS [Doanh thu] FROM PHIEUDATTIEC INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY Month([NgayToChuc]), Year([NgayToChuc]);", conn);
                }
                else if (thang != "" && nam != "")
                {
                    cmd = new OleDbCommand("SELECT Str(Month([NgayToChuc]))+'/'+Str(Year([NgayToChuc])) AS Tháng, Sum(CT_HD.TongTienHoaDon) AS [Doanh thu] FROM PHIEUDATTIEC INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY Month([NgayToChuc]), Year([NgayToChuc]) HAVING (((Month([NgayToChuc]))=@thang) AND ((Year([NgayToChuc]))=@nam));", conn);
                    cmd.Parameters.Add("@thang", OleDbType.BSTR).Value = thang;
                    cmd.Parameters.Add("@nam", OleDbType.BSTR).Value = nam;
                }
                else if (thang == "" && nam != "")
                {
                    cmd = new OleDbCommand("SELECT Str(Month([NgayToChuc]))+'/'+Str(Year([NgayToChuc])) AS Tháng, Sum(CT_HD.TongTienHoaDon) AS [Doanh thu] FROM PHIEUDATTIEC INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY Month([NgayToChuc]), Year([NgayToChuc]) HAVING (((Year([NgayToChuc]))=@nam));", conn);
                    cmd.Parameters.Add("@nam", OleDbType.BSTR).Value = nam;
                }
                else
                {
                    cmd = new OleDbCommand("SELECT Str(Month([NgayToChuc]))+'/'+Str(Year([NgayToChuc])) AS Tháng, Sum(CT_HD.TongTienHoaDon) AS [Doanh thu] FROM PHIEUDATTIEC INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY Month([NgayToChuc]), Year([NgayToChuc]) HAVING (((Month([NgayToChuc]))=@thang));", conn);
                    cmd.Parameters.Add("@thang", OleDbType.BSTR).Value = thang;
                }

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (Exception)
            {
                conn.Close();
            }
            return null;
        }

        public DataTable getCTDoanhThu(string thang, string nam, string doanhthu)
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                OleDbCommand cmd = new OleDbCommand("SELECT PHIEUDATTIEC.NgayToChuc AS [Ngày tổ chức], Count(PHIEUDATTIEC.NgayToChuc) AS [Số lượng tiệc], Sum(CT_HD.TongTienHoaDon) AS [Doanh thu], Sum([TongTienHoaDon]/" + int.Parse(doanhthu) + "*100) AS [Tỉ lệ] FROM PHIEUDATTIEC INNER JOIN (CT_HD INNER JOIN CT_PDT ON CT_HD.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec) ON PHIEUDATTIEC.MaPhieuDatTiec = CT_PDT.MaPhieuDatTiec GROUP BY PHIEUDATTIEC.NgayToChuc, Month([PHIEUDATTIEC].[NgayToChuc]), Year([PHIEUDATTIEC].[NgayToChuc]) HAVING (((Month([PHIEUDATTIEC].[NgayToChuc]))=@thang) AND ((Year([PHIEUDATTIEC].[NgayToChuc]))=@nam));", conn);
                cmd.Parameters.Add("@thang", OleDbType.BSTR).Value = int.Parse(thang);
                cmd.Parameters.Add("@nam", OleDbType.BSTR).Value = int.Parse(nam);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                conn.Close();
            }
            return null;
        }
    }
}
