namespace QuanLyThuVienSach
{
    partial class DangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            btnĐN = new Button();
            txtTK = new TextBox();
            label2 = new Label();
            txtMK = new TextBox();
            label3 = new Label();
            btnThoat = new Button();
            ckHTMK = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(102, 103);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Tài Khoản :";
            // 
            // btnĐN
            // 
            btnĐN.Location = new Point(102, 189);
            btnĐN.Name = "btnĐN";
            btnĐN.Size = new Size(75, 23);
            btnĐN.TabIndex = 2;
            btnĐN.Text = "Đăng Nhập";
            btnĐN.UseVisualStyleBackColor = true;
            btnĐN.Click += btnĐN_Click;
            // 
            // txtTK
            // 
            txtTK.Location = new Point(201, 95);
            txtTK.Name = "txtTK";
            txtTK.Size = new Size(154, 23);
            txtTK.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(102, 147);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 4;
            label2.Text = "Mật Khẩu :";
            // 
            // txtMK
            // 
            txtMK.Location = new Point(201, 139);
            txtMK.Name = "txtMK";
            txtMK.Size = new Size(154, 23);
            txtMK.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 43);
            label3.Name = "label3";
            label3.Size = new Size(245, 30);
            label3.TabIndex = 6;
            label3.Text = "ĐĂNG NHẬP HỆ THỐNG";
            // 
            // btnThoat
            // 
            btnThoat.Location = new Point(280, 189);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(75, 23);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // ckHTMK
            // 
            ckHTMK.AutoSize = true;
            ckHTMK.Location = new Point(361, 147);
            ckHTMK.Name = "ckHTMK";
            ckHTMK.Size = new Size(71, 19);
            ckHTMK.TabIndex = 8;
            ckHTMK.Text = "Hiển thị ";
            ckHTMK.UseVisualStyleBackColor = true;
            ckHTMK.CheckedChanged += ckHTMK_CheckedChanged_1;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(491, 270);
            Controls.Add(ckHTMK);
            Controls.Add(btnThoat);
            Controls.Add(label3);
            Controls.Add(txtMK);
            Controls.Add(label2);
            Controls.Add(txtTK);
            Controls.Add(btnĐN);
            Controls.Add(label1);
            Name = "DangNhap";
            Text = "Form1";
            FormClosed += DangNhap_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnĐN;
        private TextBox txtTK;
        private Label label2;
        private TextBox txtMK;
        private Label label3;
        private Button btnThoat;
        private CheckBox ckHTMK;
    }
}
