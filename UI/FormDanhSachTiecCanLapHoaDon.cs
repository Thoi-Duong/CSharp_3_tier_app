using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BusinessLogicTier;

namespace UI
{
    public partial class FormDanhSachTiecCanLapHoaDon : Form
    {
        Hoadon hd = new Hoadon();
        hoadonBUS objHoaDon = new hoadonBUS();
        DataTable tbHoaDon;
        public FormDanhSachTiecCanLapHoaDon()
        {
            InitializeComponent();
        }

        private void butttonLapHoaDon_Click(object sender, EventArgs e)
        {
            string mact_pdt;
            int Curr = dgvDSLapHoaDon.CurrentCell.RowIndex;
            mact_pdt = dgvDSLapHoaDon.Rows[Curr].Cells[0].Value.ToString();
            ChiTietPhieuDatTiecForm f = new ChiTietPhieuDatTiecForm(this,mact_pdt);
            f.ShowDialog();
        }

        public void HoaDonForm_Load(object sender, EventArgs e)
        {
            tbHoaDon = objHoaDon.GetDSLapHoaDon();
            dgvDSLapHoaDon.DataSource = tbHoaDon;
           
            //tbHoaDon = objHoaDon.GetDSLapHoaDon();
            //tbHoaDon.Columns.Add(new DataColumn("TongTienThanhToan")); //thêm tổng tiền thanh toán vào cột cuối của getDSLapHoaDon
            //dgvDSLapHoaDon.DataSource = tbHoaDon;
            //for (int i = 0; i < dgvDSLapHoaDon.RowCount - 1; i++)
            //{
            //    //int Curr = dgvDSLapHoaDon.CurrentCell.RowIndex;
            //    string mact_pdt = dgvDSLapHoaDon.Rows[i].Cells[0].Value.ToString();
            //    dgvDSLapHoaDon.Rows[i].Cells[dgvDSLapHoaDon.ColumnCount - 1].Value = int.Parse(objHoaDon.GetThongTinBanAn(mact_pdt).TongTienBan) + int.Parse(objHoaDon.GetTongTienDichVu(mact_pdt).TongTienDichVu) - int.Parse(objHoaDon.GetTienDatCoc(mact_pdt).TienDatCoc) + "";
            //}

        }

        private void btnThoat_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void updateDgvDSLapHoaDon()
        {
            tbHoaDon = objHoaDon.GetDSLapHoaDon();
            dgvDSLapHoaDon.DataSource = tbHoaDon;
        }
    }
}
