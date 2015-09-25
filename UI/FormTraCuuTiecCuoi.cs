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
    public partial class FormTraCuuTiecCuoi : Form
    {
        tracuuBUS tracuu = new tracuuBUS();

        public FormTraCuuTiecCuoi()
        {
            InitializeComponent();
            button2.Enabled = false;
        }


        //btn tra cứu
        private void button1_Click(object sender, EventArgs e)
        {
         
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "")
            {
                DataGridViewRow row = new DataGridViewRow();
                dataTracuu.DataSource = tracuu.Gettracuu(textBox1.Text, textBox2.Text, textBox3.Text);
                    for (int i = 0; i < dataTracuu.Rows.Count; i++)
                    {
                        dataTracuu.Rows[i].Cells[0].ReadOnly = true;
                        dataTracuu.Rows[i].Cells[1].ReadOnly = true;
                        dataTracuu.Rows[i].Cells[2].ReadOnly = true;
                        dataTracuu.Rows[i].Cells[3].ReadOnly = true;
                        dataTracuu.Rows[i].Cells[4].ReadOnly = true;
                        dataTracuu.Rows[i].Cells[6].ReadOnly = true;
                    }
                     if (dataTracuu.Rows.Count == 0)
                     {
                        MessageBox.Show("Không Tìm Thấy Tiệc Cuoi ");
                        button2.Enabled = false;
                     }
                     else
                     {
                        button2.Enabled = true;
                     }
            }
            else
            {
                MessageBox.Show("Vui Lòng Nhập Thông Tin Tra Cứu");
            }            
        }
   
   

        //btn xem ds món ăn dịch vụ
        private void button2_Click(object sender, EventArgs e)
        {
            int Curr = dataTracuu.CurrentCell.RowIndex;
            string mapdt = dataTracuu.Rows[Curr].Cells[0].Value.ToString();
            dataMonan.DataSource = tracuu.GetDSMA(mapdt);
            dataDichvu.DataSource = tracuu.GetDSDV(mapdt);
        }


        //tekbox tencodau, tenchure
        private void KeyPress1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) &&!Char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        //tekbox mapdt
        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
