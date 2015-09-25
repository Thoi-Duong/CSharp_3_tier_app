using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessTier;
using System.Data;

namespace BusinessLogicTier
{
    public class DoanhThuBUS
    {
        DoanhThuDAO objDoanhThu = new DoanhThuDAO();
        public DataTable getDoanhThu(string thang, string nam)
        {
            return objDoanhThu.getDoanhThu(thang, nam);
        }

        public DataTable getCTDoanhThu(string thang, string nam, string doanhthu)
        {
            return objDoanhThu.getCTDoanhThu(thang, nam, doanhthu);
        }
    }
}
