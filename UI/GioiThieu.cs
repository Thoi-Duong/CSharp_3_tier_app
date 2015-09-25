using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class GioiThieu : Form
    {
        public GioiThieu()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GioiThieu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("gioithieu.png");
        }
    }
}
