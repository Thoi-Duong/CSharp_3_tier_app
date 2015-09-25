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
using System.Data;

namespace UI
{
    public partial class SanPhamForm : Form
    {
        sanhBUS objDM=new sanhBUS();
        sanphamBUS objSP = new sanphamBUS();
        DataTable tbsp = new System.Data.DataTable();
        string masp_selected = "";
        public SanPhamForm()
        {
            InitializeComponent();
        }

        private void SanPhamForm_Load(object sender, EventArgs e)
        {
            string strMaDM = SanhForm.strSanh_chon;
            tbsp = objSP.GetSanPhamByMADM(strMaDM);
            dataGridView1.DataSource = tbsp;
            comboDanhmuc.DataSource = objDM.GetDanhMuc();
            comboDanhmuc.DisplayMember = "TenDM";
            comboDanhmuc.ValueMember = "MaDM";
            comboDanhmuc.SelectedIndex = -1;
            dataGridView1.ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string strMasp = "";
            if((strMasp=dataGridView1.CurrentRow.Cells[0].Value.ToString())!="")
            {
                Sanpham sp = objSP.GetSanPhamByMASP(strMasp);
                txtMasp.Text = sp.Masanpham;
                txtTensp.Text = sp.Tensanpham;
                txtSoluong.Text = sp.Soluong.ToString();
                txtDongia.Text = sp.DonGia.ToString();
                txtXuatxu.Text = sp.XuatXu;
                comboDanhmuc.SelectedValue = sp.MaDanhMuc;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int sl = Convert.ToInt32(txtSoluong.Text);
            int dg = Convert.ToInt32(txtDongia.Text);
            Sanpham sp = new Sanpham(txtMasp.Text, txtTensp.Text, sl, dg, txtXuatxu.Text, comboDanhmuc.SelectedValue.ToString());
            if(objSP.AddSanPham(sp))
            {
                MessageBox.Show("Thêm thành công");
                dataGridView1.DataSource = objSP.GetSanPhamByMADM(SanhForm.strSanh_chon);
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            int sl = Convert.ToInt32(txtSoluong.Text);
            int dg = Convert.ToInt32(txtDongia.Text);
            Sanpham sp = new Sanpham(txtMasp.Text, txtTensp.Text, sl, dg, txtXuatxu.Text, comboDanhmuc.SelectedValue.ToString());
            if (objSP.UpdateSanPham(sp))
            {
                MessageBox.Show("Cập nhật thành công");
                dataGridView1.DataSource = objSP.GetSanPhamByMADM(SanhForm.strSanh_chon);
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtDongia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int sl = Convert.ToInt32(txtSoluong.Text);
            int dg = Convert.ToInt32(txtDongia.Text);
            Sanpham sp = new Sanpham(txtMasp.Text, txtTensp.Text, sl, dg, txtXuatxu.Text, comboDanhmuc.SelectedValue.ToString());
            if (objSP.XoaSanPham(sp))
            {
                MessageBox.Show("Xóa sản phẩm thành công");
                dataGridView1.DataSource = objSP.GetSanPhamByMADM(SanhForm.strSanh_chon);
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại");
            }
        }
    }
}
