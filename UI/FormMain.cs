using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDanhSachSanh f = new FormDanhSachSanh();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDatTiec f = new FormDatTiec();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormTraCuuTiecCuoi f = new FormTraCuuTiecCuoi();
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormDanhSachMonAnDichVu f = new FormDanhSachMonAnDichVu();
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormDanhSachHoaDon f = new FormDanhSachHoaDon();
            f.ShowDialog();
            //FormDanhSachTiecCanLapHoaDon f = new FormDanhSachTiecCanLapHoaDon();
            //f.ShowDialog();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            FormDoanhThu f = new FormDoanhThu();
            f.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormDanhSachTiecCanLapHoaDon f = new FormDanhSachTiecCanLapHoaDon();
            f.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FormCa f = new FormCa();
            f.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GioiThieu f = new GioiThieu();
            f.ShowDialog();
            
        }      
    }
}
