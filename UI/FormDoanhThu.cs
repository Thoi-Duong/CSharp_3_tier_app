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
using DTO;
namespace UI
{
    public partial class FormDoanhThu : Form
    {
        DoanhThuBUS objDoanhThu = new DoanhThuBUS();
        DataTable tbDoanhThu;
        public static string thang;
        public static string nam;
        public static string doanhthu;
        
        public FormDoanhThu()
        {
            InitializeComponent();
        }

        private void DoanhThuForm_Load(object sender, EventArgs e)
        {
            cbbThang.SelectedIndex = 0;
            string thang = "";
            string nam = "";
            tbDoanhThu = objDoanhThu.getDoanhThu(thang,nam);
            dgvDoanhThu.DataSource = tbDoanhThu;
            if (dgvDoanhThu.Rows.Count == 0)
            {
                chitietBtn.Enabled = false;
                dgvDoanhThu.Enabled = false;
            }
            else
            {
                chitietBtn.Enabled = true;
                dgvDoanhThu.Enabled = true;
            }

        }

        private void chitietBtn_Click(object sender, EventArgs e)
        {
            dgvDoanhThu.DataSource = tbDoanhThu;
            if (dgvDoanhThu.Rows.Count == 0)
            {
                chitietBtn.Enabled = false;
                dgvDoanhThu.Enabled = false;
            }
            string[] thangnam = dgvDoanhThu.CurrentRow.Cells[0].Value.ToString().Split('/');
            thang = thangnam[0];
            nam = thangnam[1];
            doanhthu = dgvDoanhThu.CurrentRow.Cells[1].Value.ToString();
            FormChiTietDoanhThu f = new FormChiTietDoanhThu();
            f.ShowDialog();
        }

        private void btnTim_Click_1(object sender, EventArgs e)
        {
            string thang = cbbThang.Text;
            string nam = txbNam.Text;
            if (thang == "Tất cả")
                thang = "";
            tbDoanhThu = objDoanhThu.getDoanhThu(thang, nam);
            dgvDoanhThu.DataSource = tbDoanhThu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
