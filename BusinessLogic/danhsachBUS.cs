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
    public class danhsachBUS
    {
        DanhSachDAO objds = new DanhSachDAO();

        public DataTable GetMA()
        {
            return objds.GetDSMonAn();
        }

        public DataTable GetDV()
        {
            return objds.GetDSDichVu();
        }

        public bool UpdateMonAn(Danhsach ds)
        {
            return objds.UpdateMonAn(ds);
        }

        public bool ThemMonAn(Danhsach ds)
        {
            return objds.ThemMonAn(ds);
        }

        public bool XoaMonAn(Danhsach ds)
        {
            return objds.XoaMonAn(ds);
        }

        public bool UpdateDV(Danhsach ds)
        {
            return objds.UpdateDichVu(ds);
        }

        public bool ThemDV(Danhsach ds)
        {
            return objds.ThemDichVu(ds);
        }

        public bool XoaDV(Danhsach ds)
        {
            return objds.XoaDichVu(ds);
        }
    }
}
