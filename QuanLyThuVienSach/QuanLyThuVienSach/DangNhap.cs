namespace QuanLyThuVienSach
{
    public partial class DangNhap : Form
    {
        public static string TenTaiKhoanDangNhap;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnĐN_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTK.Text;
            string matKhau = txtMK.Text;

            if (KetNoiDangNhap.CheckDangNhap(taiKhoan, matKhau))
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TenTaiKhoanDangNhap = taiKhoan;
                string chucVu = KetNoiDangNhap.GetChucVu(taiKhoan);

                if (!string.IsNullOrEmpty(chucVu))
                {
                    TrangChu f = new TrangChu(chucVu);
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin chức vụ cho tài khoản này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ckHTMK_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = !ckHTMK.Checked;
        }

        private void DangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
