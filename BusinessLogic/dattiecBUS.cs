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
    public class dattiecBUS
    {
        DattiecDAO objDT = new DattiecDAO();
        public bool Kiemtra(string n, string c, string s)
        {
            return objDT.Kiemtra(n, c, s);
        }

        public bool Dattiec(Dattiec dt)
        {
            return objDT.Dattiec(dt);
        }

        public DataTable GetLoaiCa()
        {
            return objDT.GetLoaiCa();
        }

        public DataTable GetSanh()
        {
            return objDT.GetSanh();
        }

        public DataTable GetMonAn()
        {
            return objDT.GetMonAn();
        }

        public bool DatMonAn(Dattiec monan)
        {
            return objDT.DatMonAn(monan);
        }

        public DataTable GetDichVu()
        {
            return objDT.GetDichVu();
        }

        public bool DatDichVu(Dattiec dichvu)
        {
            return objDT.DatDichVu(dichvu);
        }

        public DataTable GetDSMonAn()
        {
            return objDT.GetDSMonAn();
        }

        public DataTable GetDSDichVu()
        {
            return objDT.GetDSDichVu();
        }

        public bool KiemTraDonGiaBan()
        {
            return objDT.KiemTraDonGiaBan();
        }

        public bool KiemTraBan(string ls, int ban)
        {
            return objDT.KiemTraBan(ls, ban);
        }
    }
}
