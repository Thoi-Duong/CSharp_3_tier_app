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
    public partial class FormCa : Form
    {
        caBUS objca = new caBUS();
        public FormCa()
        {
            InitializeComponent();
        }

        private void buttThem_Click(object sender, EventArgs e)
        {
            int Curr = dataCa.CurrentCell.RowIndex;
            if (Curr + 2 >= dataCa.Rows.Count)
            {
                string loaisanh = Convert.ToString(dataCa.Rows[Curr].Cells[1].Value.ToString());
                string dongiamonan = Convert.ToString(dataCa.Rows[Curr].Cells[2].Value.ToString());
                Ca s = new Ca(0,loaisanh, dongiamonan);
                if (objca.ThemCa(s))
                {
                    MessageBox.Show("Thêm thành công");
                    dataCa.DataSource = objca.GetCa();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
        }

        private void buttXoa_Click(object sender, EventArgs e)
        {
            int Curr = dataCa.CurrentCell.RowIndex;
            int maca = (int)dataCa.Rows[Curr].Cells[0].Value;
            if (maca == 1 || maca == 2)
            {
                MessageBox.Show("Không Được Xóa");
            }
            else
            {
                if (objca.XoaCa(maca) == true)
                {
                    MessageBox.Show("Xóa thành công");
                    dataCa.DataSource = objca.GetCa();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        //lỗi không thể sửa loại ca hiện tại
        private void buttSua_Click(object sender, EventArgs e)
        {
            int Curr = dataCa.CurrentCell.RowIndex;
            int maloaica = (int)dataCa.Rows[Curr].Cells[0].Value;
            string loaisanh = Convert.ToString(dataCa.Rows[Curr].Cells[1].Value.ToString());
            string dongiamonan = Convert.ToString(dataCa.Rows[Curr].Cells[2].Value.ToString());
            Ca s = new Ca(maloaica,loaisanh, dongiamonan);
            if (objca.UpdateCa(s) == true)
            {
                MessageBox.Show("Sửa thành công");
                dataCa.DataSource = objca.GetCa();

            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void CaForm_Load(object sender, EventArgs e)
        {
            dataCa.DataSource = objca.GetCa();
            for (int i = 0; i < dataCa.Rows.Count; i++)
            {
                dataCa.Rows[i].Cells[0].ReadOnly = true;
            }
        }

        private void dataCa_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataCa.CurrentCellAddress.X == dataCa.Columns[1].DisplayIndex)
            {
                TextBox txttenca = e.Control as TextBox;
                txttenca.Name = "TenCa";
                if (txttenca != null)
                {
                    txttenca.KeyPress -= new KeyPressEventHandler(txttenca_KeyPress);
                    txttenca.KeyPress += new KeyPressEventHandler(txttenca_KeyPress);
                }
            }
            if (this.dataCa.CurrentCellAddress.X == dataCa.Columns[2].DisplayIndex)
            {
                TextBox txttenca = e.Control as TextBox;
                txttenca.Name = "Ten";
            }
        }

        private void txttenca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kim tra cot
            TextBox txt = (TextBox)sender;
            if (txt.Name == "TenCa")
            {
                if (!Char.IsLetter(e.KeyChar)&&!Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
