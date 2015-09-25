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
    public partial class FormDanhSachMonAnDichVu : Form
    {
        danhsachBUS objds = new danhsachBUS();
        public FormDanhSachMonAnDichVu()
        {
            InitializeComponent();
        }

        private void DanhSachForm_Load(object sender, EventArgs e)
        {
            dataMonan.DataSource = objds.GetMA();
            dataDV.DataSource = objds.GetDV();
            dataMonan.Columns[1].Width = 220;
            dataDV.Columns[1].Width = 220;
            dataMonan.Columns[0].ReadOnly = true;
            dataDV.Columns[0].ReadOnly = true;
        }

        private void buttsua_Click(object sender, EventArgs e)
        {
            int Curr = dataMonan.CurrentCell.RowIndex;
            int mamonan = (int)dataMonan.Rows[Curr].Cells[0].Value;
            string tenmonan = Convert.ToString(dataMonan.Rows[Curr].Cells[1].Value.ToString());
            int dongiamonan = (int)dataMonan.Rows[Curr].Cells[2].Value;
            string ghichu = Convert.ToString(dataMonan.Rows[Curr].Cells[3].Value.ToString());

            Danhsach ds = new Danhsach(mamonan,tenmonan, dongiamonan, ghichu);
            if (objds.UpdateMonAn(ds) == true)
            {
                dataMonan.DataSource = objds.GetMA();
                MessageBox.Show("Cập Nhật Thành Công");
            }
            else
            {
                MessageBox.Show("Cập Nhật Thất Bại");
            }
        }

        private void buttthem_Click(object sender, EventArgs e)
        {
            try
            {
                int Curr = dataMonan.CurrentCell.RowIndex;
                if (Curr + 2 >= dataMonan.Rows.Count)
                {
                    string tenmonan = Convert.ToString(dataMonan.Rows[Curr].Cells[1].Value.ToString());
                    int dongiamonan = (int)dataMonan.Rows[Curr].Cells[2].Value;
                    string ghichu = Convert.ToString(dataMonan.Rows[Curr].Cells[3].Value.ToString());

                    Danhsach ds = new Danhsach(0, tenmonan, dongiamonan, ghichu);
                    if (tenmonan != "")
                    {
                        if (dongiamonan != 0)
                        {
                            if (objds.ThemMonAn(ds) == true)
                            {
                                dataMonan.DataSource = objds.GetMA();
                                MessageBox.Show("Thêm Món Ăn Thành Công");
                            }
                            else
                            {
                                MessageBox.Show("Thêm Món Ăn Thất Bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Nhập Đơn Giá Món Ăn");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Tên Món Ăn");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm Món Ăn Thất Bại");
                }
            }
            catch
            {
                MessageBox.Show("Vui Lòng Nhập đầy đủ thông tin");
            }
        }

        private void buttxoa_Click(object sender, EventArgs e)
        {
            int Curr = dataMonan.CurrentCell.RowIndex;
            int mamonan = (int)dataMonan.Rows[Curr].Cells[0].Value;
            Danhsach ds = new Danhsach(mamonan,0);
            if (objds.XoaMonAn(ds) == true)
            {
                dataMonan.DataSource = objds.GetMA();
                MessageBox.Show("Xóa Món Ăn Thành Công");
            }
            else
            {
                MessageBox.Show("Xóa Món Ăn Thất Bại");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int Curr = dataDV.CurrentCell.RowIndex;
                if (Curr + 2 >= dataDV.Rows.Count)
                {
                    string tendichvu = Convert.ToString(dataDV.Rows[Curr].Cells[1].Value.ToString());
                    int dongiadichvu = (int)dataDV.Rows[Curr].Cells[2].Value;
                    string ghichu = Convert.ToString(dataDV.Rows[Curr].Cells[3].Value.ToString());

                    Danhsach ds = new Danhsach(tendichvu, dongiadichvu, ghichu, 0);
                    if (tendichvu != "")
                    {
                        if (dongiadichvu != 0)
                        {
                            if (objds.ThemDV(ds) == true)
                            {
                                dataDV.DataSource = objds.GetDV();
                                MessageBox.Show("Thêm Dịch Vụ Thành Công");
                            }
                            else
                            {
                                MessageBox.Show("Thêm Dịch Vụ Thất Bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vui Lòng Nhập Đơn Giá Dịch Vụ");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Tên Dịch Vụ");
                    }
                }
                else
                {
                    MessageBox.Show("Thêm Dịch Vụ Thất Bại");
                }
            }
            catch
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Curr = dataDV.CurrentCell.RowIndex;
            int madichvu = (int)dataDV.Rows[Curr].Cells[0].Value;
            Danhsach ds = new Danhsach(0,madichvu);
            if (objds.XoaDV(ds) == true)
            {
                dataDV.DataSource = objds.GetDV();
                MessageBox.Show("Xóa Dịch Vụ Thành Công");
            }
            else
            {
                MessageBox.Show("Xóa Dịch Vụ Thất Bại");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Curr = dataDV.CurrentCell.RowIndex;
            int madichvu = (int)dataDV.Rows[Curr].Cells[0].Value;
            string tendichvu = Convert.ToString(dataDV.Rows[Curr].Cells[1].Value.ToString());
            int dongiadichvu = (int)dataDV.Rows[Curr].Cells[2].Value;
            string ghichu = Convert.ToString(dataDV.Rows[Curr].Cells[3].Value.ToString());

            Danhsach ds = new Danhsach(tendichvu, dongiadichvu, ghichu, madichvu);
            if (objds.UpdateDV(ds) == true)
            {
                dataDV.DataSource = objds.GetDV();
                MessageBox.Show("Cập Nhật Dịch Vụ Thành Công");
            }
            else
            {
                MessageBox.Show("Cập Nhật Dịch Vụ Thất Bại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void dataMonan_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataMonan.CurrentCellAddress.X == dataMonan.Columns[2].DisplayIndex)
            {
                TextBox txt = e.Control as TextBox;
                txt.Name = "DonGia";
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
            }

            if (this.dataMonan.CurrentCellAddress.X == dataMonan.Columns[1].DisplayIndex)
            {
                TextBox txtmonan = e.Control as TextBox;
                txtmonan.Name = "TenMonAn";
                if (txtmonan != null)
                {
                    txtmonan.KeyPress -= new KeyPressEventHandler(txtmonan_KeyPress);
                    txtmonan.KeyPress += new KeyPressEventHandler(txtmonan_KeyPress);

                }
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kim tra cot
            TextBox txt = (TextBox)sender;
            if (txt.Name == "DonGia")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void txtmonan_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kim tra cot
            TextBox txt = (TextBox)sender;
            if (txt.Name == "TenMonAn")
            {
                if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void dataDV_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataDV.CurrentCellAddress.X == dataMonan.Columns[2].DisplayIndex)
            {
                TextBox txt = e.Control as TextBox;
                txt.Name = "DonGia";
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
            }

            if (this.dataDV.CurrentCellAddress.X == dataMonan.Columns[1].DisplayIndex)
            {
                TextBox txtmonan = e.Control as TextBox;
                txtmonan.Name = "TenMonAn";
                if (txtmonan != null)
                {
                    txtmonan.KeyPress -= new KeyPressEventHandler(txtmonan_KeyPress);
                    txtmonan.KeyPress += new KeyPressEventHandler(txtmonan_KeyPress);

                }
            }
        }

        private void dataMonan_SelectionChanged(object sender, EventArgs e)
        {
            dataMonan.ClearSelection();
        }

        private void dataDV_SelectionChanged(object sender, EventArgs e)
        {
            dataDV.ClearSelection();
        }

    }
}
