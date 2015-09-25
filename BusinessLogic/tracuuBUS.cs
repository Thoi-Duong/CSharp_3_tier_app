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
    public class tracuuBUS
    {
        TraCuuDAO tracuu = new TraCuuDAO();
        public DataTable Gettracuu(string mapdt, string chure, string codau)
        {
            return tracuu.getTraCuu(mapdt, chure, codau);
        }

        public DataTable GetDSMA(string mapdt)
        {
            return tracuu.GetDSMonAn(mapdt);
        }

        public DataTable GetDSDV(string mapdt)
        {
            return tracuu.GetDSDichVu(mapdt);
        }

        public DataTable GetLoaiCa()
        {
            return tracuu.GetLoaiCa();
        }
    }
}
