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
    public class sanhBUS
    {
        SanhDAO objDM = new SanhDAO();
        public DataTable GetDanhMuc()
        {
            return objDM.getAlldanhmuc();
        }

        public DataTable GetLoaiSanh()
        {
            return objDM.getLoaiSanh();
        }

        public bool DeleteDanhMuc(string madm)
        {
            return objDM.Deletedanhmuc(madm);
        }

        public Sanh GetSanhByMaLS(string strLS)
        {
            return objDM.GetloaisanhByMALS(strLS);
        }

        public bool UpdateSanh(Sanh s)
        {
            return objDM.UpdateSanh(s);
        }

        public bool Themsanh(Sanh s)
        {
            return objDM.ThemSanh(s);
        }

        public bool XoaSanh(int ls)
        {
            return objDM.XoaSanh(ls);
        }
    }
}
