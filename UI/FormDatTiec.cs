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
    public partial class FormDatTiec : Form
    {
        dattiecBUS objdt = new dattiecBUS();
        public FormDatTiec()
        {
            InitializeComponent();
            txtChure.ReadOnly = true;
            txtdatcoc.ReadOnly = true;
            txtCodau.ReadOnly = true;
            txtslban.ReadOnly = true;
            txtdt.ReadOnly = true;
            txtbandutru.ReadOnly = true;
            dataMonan.Visible = false;
            dataDichvu.Visible = false;
            dataDSMA.Visible = false;
            dataDSDV.Visible = false;
            buttDT.Enabled = false;
            buttDMA.Enabled = false;
            buttDV.Enabled = false;
            label11.Visible = false;
            label12.Visible = false;
        }


        //btn kiểm tra điều kiện ngàytc, sảnh và ca có bị trùng hay không
        private void button1_Click(object sender, EventArgs e)
        {
            string c = comboBox1.Text;
            string s = comboBox2.Text;
            string n = dateTimePicker1.Value.Date.ToString("dd-MM-yyyy");
            if (objdt.Kiemtra(n, c, s) == true)
            {
                MessageBox.Show("Có Thể Đặt Tiệc");
                buttKT.Enabled = false;  //set lại false cho btn kiểm tra
                txtChure.ReadOnly = false;
                txtdatcoc.ReadOnly = false;
                txtCodau.ReadOnly = false;
                txtslban.ReadOnly = false;
                txtdt.ReadOnly = false;
                txtbandutru.ReadOnly = false;
                buttDT.Enabled = true;
                comboBox1.Enabled = false; // ca
                comboBox2.Enabled = false; // sảnh
                dateTimePicker1.Enabled = false;

            }
            else
            {
                MessageBox.Show("Bị Trùng");
            }
        }

        //btn đặt tiệc, hiện thị ds món ăn và dịch vụ sau khi đã kiểm tra đk ngàytc,sảnh, bàn và thông tin khách hàng thành công

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int dt = Convert.ToInt32(txtdt.Text);
                int dc = Convert.ToInt32(txtdatcoc.Text);
                int slban = Convert.ToInt32(txtslban.Text);
                int bandutru = Convert.ToInt32(txtbandutru.Text);
                Dattiec dattiec = new Dattiec(dateTimePicker1.Value.Date.ToString("dd-MM-yyyy"), txtChure.Text, txtCodau.Text, dt, dc, slban, bandutru, comboBox1.Text, comboBox2.Text);
                if (slban > 0)
                {
                    if(slban>bandutru)
                    {
                        if (objdt.KiemTraBan(comboBox2.Text, slban + bandutru) == true)
                        {
                            if (objdt.Dattiec(dattiec) == true)
                            {
                                MessageBox.Show("Đặt Tiệc Thành Công");
                                txtChure.ReadOnly = true;
                                txtdatcoc.ReadOnly = true;
                                txtCodau.ReadOnly = true;
                                txtslban.ReadOnly = true;
                                txtdt.ReadOnly = true;
                                txtbandutru.ReadOnly = true;
                                buttDT.Enabled = false;
                                dataMonan.Visible = true;
                                dataDichvu.Visible = true;
                                buttDMA.Enabled = true;
                                buttDV.Enabled = true;
                                dataMonan.DataSource = objdt.GetMonAn();
                                dataMonan.Columns[2].Width = 200;
                                dataMonan.Columns["MaMonAn"].ReadOnly = true;
                                dataMonan.Columns["TenMonAn"].ReadOnly = true;
                                dataMonan.Columns["DonGiaMonAn"].ReadOnly = true;
                                dataDichvu.DataSource = objdt.GetDichVu();
                                dataDichvu.Columns[2].Width = 200;
                                dataDichvu.Columns["DonGiaDichVu"].ReadOnly = true;
                                dataDichvu.Columns["MaDichVu"].ReadOnly = true;
                                dataDichvu.Columns["TenDichVu"].ReadOnly = true;
                            }
                            else
                            {
                                MessageBox.Show("Đặt Tiệc Thất Bại");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng bàn đã quá quy định");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số Bàn Dự Trữ Phải Nhỏ Hơn Số Bàn Đặt Tiệc");
                    }
                }
                else
                {
                    MessageBox.Show("Vui Lòng Nhập Số Lượng Bàn");
                }
            }
            catch
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin");
            }
        }


        // btn đặt món ăn , check điều kiện tổng tiền món ăn chọn >= đơn giá bàn tối thiểu
        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            bool kt = false;
            for (int i = 0; i < dataMonan.Rows.Count; i++)
            {
                dataMonan.Rows[i].Cells[3].ReadOnly = true;
                row = dataMonan.Rows[i];
                Dattiec monan = new Dattiec(row.Cells[1].Value.ToString());
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    if (objdt.DatMonAn(monan) == true)
                    {
                        kt = true;
                    }
                    else
                    {
                        kt = false;
                    }
                }
            }

            if (objdt.KiemTraDonGiaBan() == true)
            {
                if (kt)
                {
                    MessageBox.Show("Đặt Món Ăn Thành Công");
                    buttDMA.Enabled = false;
                }
                else MessageBox.Show("Đặt Món Ăn Thất Bại");
                dataMonan.Visible = false;
                dataDSMA.Visible = true;
                dataDSMA.DataSource = objdt.GetDSMonAn();
                dataDSMA.Columns[1].Width = 200;
                for (int i = 0; i < dataDSMA.Rows.Count - 1; i++)
                {
                    dataDSMA.Rows[i].Cells[0].Value = i + 1;
                }
            }
            else
            {
                MessageBox.Show("Đơn Giá Bàn Tối Thiểu Chưa Đủ, Vui Lòng Chọn Thêm Món Ăn");
            }
        }


        //btn đặt dịch vụ, còn lỗi (check nhiều dv, hiển thị 2 ms...) và éo sửa được :v
        private void button1_Click_1(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            Dattiec dichvu = new Dattiec();
            bool kt = false;
            try
            {
                for (int i = 0; i < dataDichvu.Rows.Count; i++)
                {
                    dataDichvu.Rows[i].Cells[4].ReadOnly = true;
                    row = dataDichvu.Rows[i];
                    if (row.Cells[3].Value.ToString() != "0")
                    {
                        if (row.Cells[3].Value == null)
                        {
                            row.Cells[3].Value = 1;
                        }
                        if (Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            dichvu = new Dattiec(row.Cells[1].Value.ToString(), Convert.ToInt32(row.Cells[3].Value.ToString()));
                            if (objdt.DatDichVu(dichvu) == true)
                            {
                                kt = true;
                            }
                            else
                            {
                                kt = false;
                            }
                            dataDichvu.Visible = false;
                            dataDSDV.Visible = true;
                            dataDSDV.DataSource = objdt.GetDSDichVu();
                            dataDSDV.Columns[1].Width = 200;
                            for (int j = 0; j < dataDSDV.Rows.Count - 1; j++)
                            {
                                dataDSDV.Rows[j].Cells[0].Value = j + 1;
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui Lòng Nhập Số Lượng Dịch Vụ");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui Lòng Nhập Số Lượng Dịch Vụ");
            }
            if (kt)
            {
                MessageBox.Show("Đặt Dịch Vụ Thành Công");
                buttDV.Enabled = false;
            }
            else
            { 
                MessageBox.Show("Đặt Dịch Vụ Thất Bại");
            }
        }

        private void DattiecForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = objdt.GetLoaiCa();
            comboBox1.DisplayMember = "TenLoaiCa";
            comboBox1.ValueMember = "TenLoaiCa";
            comboBox2.DataSource = objdt.GetSanh();
            comboBox2.DisplayMember = "TenSanh";
            comboBox2.ValueMember = "TenSanh";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //ràng buộc nhập chữ đối với tên cô dâu, chú rể
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) &&!Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        //ràng buộc nhập số đối với số điện thoại, tiền đặt cọc, số bàn, số bàn dự trữ
        private void KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra cột
            TextBox txt = (TextBox)sender;
            if (txt.Name == "SoLuong")
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }


        //Kiểm tra cột số lượng đặt dịch vụ
        private void dataDichvu_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataDichvu.CurrentCellAddress.X == dataDichvu.Columns[3].DisplayIndex)
            {
                TextBox txt = e.Control as TextBox;
                txt.Name = "SoLuong";
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(txt_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(txt_KeyPress);
                }
            }

            if (this.dataDichvu.CurrentCellAddress.X == dataDichvu.Columns[1].DisplayIndex)
            {
                TextBox txt1 = e.Control as TextBox;
                txt1.Name = "SoLuong";
                if (txt1 != null)
                {
                    txt1.KeyPress -= new KeyPressEventHandler(KeyPress);
                    txt1.KeyPress += new KeyPressEventHandler(KeyPress);
                }
            }
        }
    }
}
