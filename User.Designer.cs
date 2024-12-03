namespace BookShopTuto
{
    partial class User
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
            panel2 = new Panel();
            label5 = new Label();
            panel3 = new Panel();
            txtMatKhau = new TextBox();
            label4 = new Label();
            txtTenTK = new TextBox();
            label3 = new Label();
            btnUserThoat = new Button();
            btnUserRefresh = new Button();
            txtMaTK = new TextBox();
            btnUserXoa = new Button();
            label2 = new Label();
            btnUserSua = new Button();
            dgDangNhap = new DataGridView();
            label1 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgDangNhap).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.WhiteSmoke;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(dgDangNhap);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(1, -1);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1900, 1100);
            panel2.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Coral;
            label5.Location = new Point(26, 320);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(178, 25);
            label5.TabIndex = 10;
            label5.Text = "Thông tin tài khoản";
            // 
            // panel3
            // 
            panel3.Controls.Add(txtMatKhau);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(txtTenTK);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(btnUserThoat);
            panel3.Controls.Add(btnUserRefresh);
            panel3.Controls.Add(txtMaTK);
            panel3.Controls.Add(btnUserXoa);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(btnUserSua);
            panel3.Location = new Point(26, 135);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1706, 156);
            panel3.TabIndex = 23;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMatKhau.Location = new Point(1379, 18);
            txtMatKhau.Margin = new Padding(4, 3, 4, 3);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(292, 34);
            txtMatKhau.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Coral;
            label4.Location = new Point(1198, 27);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 9;
            label4.Text = "Mật khẩu";
            // 
            // txtTenTK
            // 
            txtTenTK.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTenTK.Location = new Point(808, 18);
            txtTenTK.Margin = new Padding(4, 3, 4, 3);
            txtTenTK.Name = "txtTenTK";
            txtTenTK.Size = new Size(292, 34);
            txtTenTK.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Coral;
            label3.Location = new Point(627, 27);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(145, 25);
            label3.TabIndex = 7;
            label3.Text = "Tên đăng nhập";
            // 
            // btnUserThoat
            // 
            btnUserThoat.BackColor = Color.Orange;
            btnUserThoat.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnUserThoat.ForeColor = Color.White;
            btnUserThoat.Location = new Point(1410, 94);
            btnUserThoat.Margin = new Padding(4, 3, 4, 3);
            btnUserThoat.Name = "btnUserThoat";
            btnUserThoat.Size = new Size(175, 44);
            btnUserThoat.TabIndex = 4;
            btnUserThoat.Text = "Thoát";
            btnUserThoat.UseVisualStyleBackColor = false;
            btnUserThoat.Click += btnUserThoat_Click;
            // 
            // btnUserRefresh
            // 
            btnUserRefresh.BackColor = Color.Orange;
            btnUserRefresh.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnUserRefresh.ForeColor = Color.White;
            btnUserRefresh.Location = new Point(1010, 94);
            btnUserRefresh.Margin = new Padding(4, 3, 4, 3);
            btnUserRefresh.Name = "btnUserRefresh";
            btnUserRefresh.Size = new Size(175, 44);
            btnUserRefresh.TabIndex = 3;
            btnUserRefresh.Text = "Refresh";
            btnUserRefresh.UseVisualStyleBackColor = false;
            btnUserRefresh.Click += btnUserRefresh_Click;
            // 
            // txtMaTK
            // 
            txtMaTK.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMaTK.Location = new Point(209, 18);
            txtMaTK.Margin = new Padding(4, 3, 4, 3);
            txtMaTK.Name = "txtMaTK";
            txtMaTK.Size = new Size(292, 34);
            txtMaTK.TabIndex = 0;
            // 
            // btnUserXoa
            // 
            btnUserXoa.BackColor = Color.Orange;
            btnUserXoa.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnUserXoa.ForeColor = Color.White;
            btnUserXoa.Location = new Point(610, 94);
            btnUserXoa.Margin = new Padding(4, 3, 4, 3);
            btnUserXoa.Name = "btnUserXoa";
            btnUserXoa.Size = new Size(175, 44);
            btnUserXoa.TabIndex = 2;
            btnUserXoa.Text = "Xóa";
            btnUserXoa.UseVisualStyleBackColor = false;
            btnUserXoa.Click += btnUserXoa_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Coral;
            label2.Location = new Point(28, 27);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(124, 25);
            label2.TabIndex = 5;
            label2.Text = "Mã tài khoản";
            // 
            // btnUserSua
            // 
            btnUserSua.BackColor = Color.Orange;
            btnUserSua.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btnUserSua.ForeColor = Color.White;
            btnUserSua.Location = new Point(210, 94);
            btnUserSua.Margin = new Padding(4, 3, 4, 3);
            btnUserSua.Name = "btnUserSua";
            btnUserSua.Size = new Size(175, 44);
            btnUserSua.TabIndex = 1;
            btnUserSua.Text = "Sửa";
            btnUserSua.UseVisualStyleBackColor = false;
            btnUserSua.Click += btnUserSua_Click;
            // 
            // dgDangNhap
            // 
            dgDangNhap.BackgroundColor = Color.White;
            dgDangNhap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgDangNhap.Location = new Point(26, 350);
            dgDangNhap.Margin = new Padding(4, 5, 4, 5);
            dgDangNhap.Name = "dgDangNhap";
            dgDangNhap.RowHeadersWidth = 51;
            dgDangNhap.Size = new Size(1850, 681);
            dgDangNhap.TabIndex = 1;
            dgDangNhap.CellClick += dgDangNhap_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(801, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(410, 53);
            label1.TabIndex = 1;
            label1.Text = "Cửa hàng bán sách";
            // 
            // User
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1764, 1055);
            Controls.Add(panel2);
            Name = "User";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User";
            WindowState = FormWindowState.Maximized;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgDangNhap).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private Button btnUserThoat;
        private Button btnUserRefresh;
        private TextBox txtMaTK;
        private Button btnUserXoa;
        private Label label2;
        private Button btnUserSua;
        private DataGridView dgDangNhap;
        private Label label1;
        private Label label5;
        private TextBox txtMatKhau;
        private Label label4;
        private TextBox txtTenTK;
        private Label label3;
    }
}