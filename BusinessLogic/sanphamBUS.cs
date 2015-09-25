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
    public class sanphamBUS
    {
        SanPhamDAO objSP = new SanPhamDAO();
        public Sanpham GetSanPhamByMASP(string strmasp)
        {
            return objSP.GetsanphamByMASP(strmasp);
        }
        public DataTable GetSanPhamByMADM(string strmadm)
        {
            return objSP.GetsanphamByMADM(strmadm);
        }
        public string GetTenDanhMuc(string strmadm)
        {
            return objSP.GetTendanhmuc(strmadm);
        }

        public bool AddSanPham(Sanpham sp)
        {
            return objSP.Addsanpham(sp);
        }

        public bool UpdateSanPham(Sanpham sp)
        {
            return objSP.Updatesanpham(sp);
        }

        public bool XoaSanPham(Sanpham sp)
        {
            return objSP.Xoasanpham(sp);
        }
    }
}
