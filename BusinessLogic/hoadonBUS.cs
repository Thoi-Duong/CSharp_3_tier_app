using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAcessTier;
using System.Data;
using System.Data.OleDb;

namespace BusinessLogicTier
{
    public class hoadonBUS
    {
        HoadonDAO objhd = new HoadonDAO();
        public DataTable GetDSDatDichVu(string mact_pdt)
        {
            return objhd.GetDSDatDichVu(mact_pdt);
        }

        public DataTable GetDSDatDichVu_MaHD(string mahd)
        {
            return objhd.GetDSDatDichVu_MaHD(mahd);
        }

        public Hoadon GetTienDatCoc(string mact_pdt)
        {
            return objhd.GetTienDatCoc(mact_pdt);
        }

        public Hoadon GetTienDatCoc_MaHD(string mahd)
        {
            return objhd.GetTienDatCoc_MaHD(mahd);
        }
        public Hoadon GetThongTinBanAn(string mact_pdt)
        {
            return objhd.GetThongTinBanAn(mact_pdt);
        }

        public Hoadon GetThongTinBanAn_MaHD(string mahd)
        {
            return objhd.GetThongTinBanAn_MaHD(mahd);
        }

        public Hoadon GetTongTienDichVu(string mact_pdt)
        {
            return objhd.GetTongTienDichVu(mact_pdt);
        }

        public Hoadon GetTongTienDichVu_MaHD(string mahd)
        {
            return objhd.GetTongTienDichVu_MaHD(mahd);
        }
        public Hoadon GetTenCoDauChuRe(string mact_ptd)
        {
            return objhd.GetTenCoDauChuRe(mact_ptd);
        }

        public Hoadon GetTenCoDauChuRe_MaHD(string mahd)
        {
            return objhd.GetTenCoDauChuRe_MaHD(mahd);
        }

        public DataTable GetDSLapHoaDon()
        {
            return objhd.GetDSLapHoaDon();
        }
        public DataTable GetDSHoaDonThanhToan()
        {
            return objhd.GetDSHoaDonThanhToan();
        }

        public bool AddHoaDon(Hoadon hd)
        {
            return objhd.AddHoaDon(hd);
        }

        public DataTable GetDSThongTinDatTiec()
        {
            return objhd.GetDSThongTinDatTiec();
        }

        public DataTable GetDSDatMonAn(string mact_pdt)
        {
            return objhd.GetDSDatMonAn(mact_pdt);
        }

        public Hoadon GetThongTinCaSanh(string mact_pdt)
        {
            return objhd.GetThongTinCaSanh(mact_pdt);
        }

        public DataTable GetTraCuuHoaDon(string mahd, string tenchure, string tencodau)
        {
            return objhd.GetTraCuuHoaDon(mahd, tenchure, tencodau);
        }

        public bool XoaHoaDon(Hoadon hd)
        {
            return objhd.XoaHoaDon(hd);
        }

        public bool XoaCTPDT(Hoadon hd)
        {
            return objhd.XoaCT_PDT(hd);
        }

        public Hoadon getChiTietHoaDon(string MaHD)
        {
            return objhd.getChiTietHoaDon(MaHD);
        }


        public string GetMaPDT(string mahoadon)
        {
            return objhd.GetMaPDT(mahoadon);
        }
    }
}
