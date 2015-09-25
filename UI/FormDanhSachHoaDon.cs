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
    public partial class FormDanhSachHoaDon : Form
    {
        Hoadon hd = new Hoadon();
        hoadonBUS objHoaDon = new hoadonBUS();
        DataTable tbHoaDon;
        public FormDanhSachHoaDon()
        {
            InitializeComponent();
            tbHoaDon = objHoaDon.GetDSHoaDonThanhToan();
            dgvDanhSachHoaDon.DataSource = objHoaDon.GetDSHoaDonThanhToan();
            if(dgvDanhSachHoaDon.Rows.Count == 0)
            {
                this.button1.Enabled = false;
                this.buttonChiTietHoaDon.Enabled = false;
            }

        }

        private void buttonChiTietHoaDon_Click(object sender, EventArgs e)
        {
            string mahoadon;
            int Curr = dgvDanhSachHoaDon.CurrentCell.RowIndex;
            mahoadon = dgvDanhSachHoaDon.Rows[Curr].Cells[0].Value.ToString();
            ChiTietHoaDonDaThanhToan f = new ChiTietHoaDonDaThanhToan(mahoadon);
            f.ShowDialog();
        }


        private void buttonTraCuu_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                DataGridViewRow row = new DataGridViewRow();
                dgvDanhSachHoaDon.DataSource = objHoaDon.GetTraCuuHoaDon(textBox1.Text, textBox2.Text, textBox3.Text);
                for (int i = 0; i < dgvDanhSachHoaDon.Rows.Count; i++)
                {
                    dgvDanhSachHoaDon.Rows[i].Cells[0].ReadOnly = true;
                    dgvDanhSachHoaDon.Rows[i].Cells[1].ReadOnly = true;
                    dgvDanhSachHoaDon.Rows[i].Cells[2].ReadOnly = true;
                    dgvDanhSachHoaDon.Rows[i].Cells[3].ReadOnly = true;
                    dgvDanhSachHoaDon.Rows[i].Cells[4].ReadOnly = true;

                }
                if (dgvDanhSachHoaDon.Rows.Count == 0)
                {
                    MessageBox.Show("Không Tìm Thấy Hoá Đơn");
                    buttonChiTietHoaDon.Enabled = false;
                    button1.Enabled = false; //btn xoá

                }
                else
                {
                    buttonChiTietHoaDon.Enabled = true;
                    button1.Enabled = true; // btn xoá
                }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin Tra Cứu Hóa Đơn");
            }

        }


        //chekbox hiển thị tất cả ds hoá đơn
        private void checkBoxHTTC_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBoxHTTC.Checked)
            {
                textBox1.Enabled = false; //mact_pdt
                textBox2.Enabled = false; //tenchure
                textBox3.Enabled = false; //tencodau
                dgvDanhSachHoaDon.DataSource = objHoaDon.GetDSHoaDonThanhToan();
                if (dgvDanhSachHoaDon.Rows.Count == 0)
                {
                    button1.Enabled = false; //btn xoa
                    buttonChiTietHoaDon.Enabled = false;
                    //textBox1.Enabled = false; //mact_pdt
                    //textBox2.Enabled = false; //tenchure
                    //textBox3.Enabled = false; //tencodau
                }
                else
                {
                    button1.Enabled = true; //btn xoa
                    buttonChiTietHoaDon.Enabled = true;
                }
                
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        //tekbox mãct_pdt
        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //tekbox tên chú rể
        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //tekbox tên cô dâu
        private void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && !Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //btn xoá click
        private void button1_Click(object sender, EventArgs e)
        {
            string mahoadon;
            int Curr = dgvDanhSachHoaDon.CurrentCell.RowIndex;
            mahoadon = dgvDanhSachHoaDon.Rows[Curr].Cells[0].Value.ToString();
            Hoadon hd = new Hoadon(mahoadon);
            if (objHoaDon.XoaHoaDon(hd) == true)
            {   
                string maphieudattiec = objHoaDon.GetMaPDT(mahoadon);
                objHoaDon.XoaCTPDT(new Hoadon(mahoadon, maphieudattiec));
                dgvDanhSachHoaDon.DataSource = objHoaDon.GetDSHoaDonThanhToan();
                if (dgvDanhSachHoaDon.Rows.Count == 0)
                {
                    button1.Enabled = false; //btn xoa
                    buttonChiTietHoaDon.Enabled = false;
                }
                MessageBox.Show("Xoá Hoá Đơn Thành Công!");
            }
            else
            {
                MessageBox.Show("Xoá Hoá Đơn Thất Bại!");
            }
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
