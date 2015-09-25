using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicTier;

namespace UI
{
    public partial class FormChiTietDoanhThu : Form
    {      
        DoanhThuBUS objCTDoanhThu = new DoanhThuBUS();
        DataTable tbCTDoanhThu;

        public FormChiTietDoanhThu()
        {
            InitializeComponent();
        }
        
        private void thoatBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DoanhThuCTForm_Load(object sender, EventArgs e)
        {
            string thang = FormDoanhThu.thang;
            string nam = FormDoanhThu.nam;
            string tongdoanhthu = FormDoanhThu.doanhthu;
            label1.Text = "CHI TIẾT DOANH THU THÁNG " + thang + "/" + nam;
            label2.Text = "TỔNG DOANH THU: " + tongdoanhthu + "đ";
            tbCTDoanhThu = objCTDoanhThu.getCTDoanhThu(thang, nam, tongdoanhthu);
            dgvCTDoanhThu.DataSource = tbCTDoanhThu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
