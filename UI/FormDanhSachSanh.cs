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
    public partial class FormDanhSachSanh : Form
    {
        sanhBUS objsanh = new sanhBUS();
        public FormDanhSachSanh()
        {
            InitializeComponent();
        }

        private void SanhForm_Load(object sender, EventArgs e)
        {
            listSanh.DataSource = objsanh.GetDanhMuc();
            listSanh.ReadOnly = true;
            dataLoaiSanh.DataSource = objsanh.GetLoaiSanh();
            for (int i = 0; i < dataLoaiSanh.Rows.Count; i++)
            {
                dataLoaiSanh.Rows[i].Cells[0].ReadOnly = true;
            }
        }


        private void btn_thoat_Click(object sender, EventArgs e)
        {
            int Curr = dataLoaiSanh.CurrentCell.RowIndex;
            int maloaisanh = (int)dataLoaiSanh.Rows[Curr].Cells[0].Value;
            string loaisanh = Convert.ToString(dataLoaiSanh.Rows[Curr].Cells[1].Value.ToString());
            int dongiamonan = (int)dataLoaiSanh.Rows[Curr].Cells[2].Value;
            Sanh s = new Sanh(maloaisanh, loaisanh, dongiamonan);
            if (objsanh.UpdateSanh(s))
            {
                MessageBox.Show("Cập nhật thành công");
                listSanh.DataSource = objsanh.GetDanhMuc();
                dataLoaiSanh.DataSource = objsanh.GetLoaiSanh();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }
        
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            int Curr = dataLoaiSanh.CurrentCell.RowIndex;
            int masanh = (int)dataLoaiSanh.Rows[Curr].Cells[0].Value;
            if (masanh == 1 || masanh == 2 || masanh == 3 || masanh == 4 || masanh == 5)
            {
                MessageBox.Show("Không được xóa");
            }
            else
            {
                if (objsanh.XoaSanh(masanh) == true)
                {
                    MessageBox.Show("Xóa sảnh thành công");
                    listSanh.DataSource = objsanh.GetDanhMuc();
                    dataLoaiSanh.DataSource = objsanh.GetLoaiSanh();
                }
                else
                {
                    MessageBox.Show("Xóa sảnh thất bại");
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            int Curr = dataLoaiSanh.CurrentCell.RowIndex;
            if (Curr + 2 >= dataLoaiSanh.Rows.Count)
            {
                try
                {
                    string loaisanh = Convert.ToString(dataLoaiSanh.Rows[Curr].Cells[1].Value.ToString());
                    int dongiamonan = (int)(dataLoaiSanh.Rows[Curr].Cells[2].Value);
                    Sanh s = new Sanh(0, loaisanh, dongiamonan);
                    if (objsanh.Themsanh(s))
                    {
                        MessageBox.Show("Thêm thành công");
                        listSanh.DataSource = objsanh.GetDanhMuc();
                        dataLoaiSanh.DataSource = objsanh.GetLoaiSanh();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
                catch
                {
                    MessageBox.Show("Nhập Đầy Đủ Thông Tin");
                }
            }            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThoat_Click_2(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataLoaiSanh_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataLoaiSanh.CurrentCellAddress.X == dataLoaiSanh.Columns[2].DisplayIndex)
            {
                TextBox txt = e.Control as TextBox;
                txt.Name = "SoChuyenThu";
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
            }

            if (this.dataLoaiSanh.CurrentCellAddress.X == dataLoaiSanh.Columns[1].DisplayIndex)
            {
                TextBox txtsotui = e.Control as TextBox;
                txtsotui.Name = "SoTui";
                if (txtsotui != null)
                {
                    txtsotui.KeyPress -= new KeyPressEventHandler(txtsotui_KeyPress);
                    txtsotui.KeyPress += new KeyPressEventHandler(txtsotui_KeyPress);

                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kim tra cot
            TextBox txt = (TextBox)sender;
            if (txt.Name == "SoChuyenThu")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtsotui_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kim tra cot
            TextBox txt = (TextBox)sender;
            if (txt.Name == "SoTui")
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
        private void listSanh_SelectionChanged(object sender, EventArgs e)
        {
            dataLoaiSanh.ClearSelection();
        }

        private void dataLoaiSanh_SelectionChanged(object sender, EventArgs e)
        {
            listSanh.ClearSelection();
        }
    }
}
