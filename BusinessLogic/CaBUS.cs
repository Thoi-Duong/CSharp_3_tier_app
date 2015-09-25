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
    public class caBUS
    {
        CaDAO objCa = new CaDAO();

        public DataTable GetCa()
        {
            return objCa.GetCa();
        }

        public bool UpdateCa(Ca ca)
        {
            return objCa.UpdateCa(ca);
        }

        public bool XoaCa(int ca)
        {
            return objCa.XoaSanh(ca);
        }

        public bool ThemCa(Ca ca)
        {
            return objCa.ThemCa(ca);
        }
    }
}
