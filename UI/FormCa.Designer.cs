namespace UI
{
    partial class FormCa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCa));
            this.dataCa = new System.Windows.Forms.DataGridView();
            this.buttThem = new System.Windows.Forms.Button();
            this.buttXoa = new System.Windows.Forms.Button();
            this.buttSua = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataCa)).BeginInit();
            this.SuspendLayout();
            // 
            // dataCa
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dataCa.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataCa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataCa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dataCa.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataCa.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataCa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataCa.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataCa.Location = new System.Drawing.Point(12, 12);
            this.dataCa.Name = "dataCa";
            this.dataCa.Size = new System.Drawing.Size(693, 406);
            this.dataCa.TabIndex = 0;
            this.dataCa.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataCa_EditingControlShowing);
            // 
            // buttThem
            // 
            this.buttThem.BackColor = System.Drawing.Color.Green;
            this.buttThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttThem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttThem.ForeColor = System.Drawing.Color.White;
            this.buttThem.Image = global::UI.Properties.Resources.plus_math_261;
            this.buttThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttThem.Location = new System.Drawing.Point(12, 423);
            this.buttThem.Name = "buttThem";
            this.buttThem.Size = new System.Drawing.Size(77, 40);
            this.buttThem.TabIndex = 1;
            this.buttThem.Text = "THÊM";
            this.buttThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttThem.UseVisualStyleBackColor = false;
            this.buttThem.Click += new System.EventHandler(this.buttThem_Click);
            // 
            // buttXoa
            // 
            this.buttXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttXoa.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttXoa.ForeColor = System.Drawing.Color.White;
            this.buttXoa.Image = global::UI.Properties.Resources.erase_26;
            this.buttXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttXoa.Location = new System.Drawing.Point(95, 423);
            this.buttXoa.Name = "buttXoa";
            this.buttXoa.Size = new System.Drawing.Size(77, 40);
            this.buttXoa.TabIndex = 2;
            this.buttXoa.Text = "XÓA";
            this.buttXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttXoa.UseVisualStyleBackColor = false;
            this.buttXoa.Click += new System.EventHandler(this.buttXoa_Click);
            // 
            // buttSua
            // 
            this.buttSua.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttSua.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttSua.ForeColor = System.Drawing.Color.White;
            this.buttSua.Image = global::UI.Properties.Resources.edit_26;
            this.buttSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttSua.Location = new System.Drawing.Point(178, 423);
            this.buttSua.Name = "buttSua";
            this.buttSua.Size = new System.Drawing.Size(77, 40);
            this.buttSua.TabIndex = 3;
            this.buttSua.Text = "SỬA";
            this.buttSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttSua.UseVisualStyleBackColor = false;
            this.buttSua.Click += new System.EventHandler(this.buttSua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Transparent;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.Color.Transparent;
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Location = new System.Drawing.Point(665, 424);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(40, 40);
            this.btnThoat.TabIndex = 34;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FormCa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UI.Properties.Resources.restaurant_261;
            this.ClientSize = new System.Drawing.Size(717, 475);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.buttSua);
            this.Controls.Add(this.buttXoa);
            this.Controls.Add(this.buttThem);
            this.Controls.Add(this.dataCa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormCa";
            this.Text = "QUẢN LÝ CA";
            this.Load += new System.EventHandler(this.CaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataCa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataCa;
        private System.Windows.Forms.Button buttThem;
        private System.Windows.Forms.Button buttXoa;
        private System.Windows.Forms.Button buttSua;
        private System.Windows.Forms.Button btnThoat;
    }
}