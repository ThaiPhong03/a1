using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienSach
{
    public partial class CapNhat : Form
    {
        private DataTable dt;
        private string chuyennut = "";
        public CapNhat()
        {
            InitializeComponent();
            Vohieutextbox();
            LoadKhoa();
        }
        public void LoadKhoa()
        {
            string sql = "select distinct MaTG from QLSach";
            using (SqlDataReader rd = KetNoiDangNhap.LDL(sql))
            {
                while (rd.Read())
                {
                    cbMaTG.Items.Add(rd["MaTG"].ToString());
                }
            }
        }
        private void Xoatextbox()
        {
            txtMaSach.Clear();
            txtTenSach.Clear();
            txtMaLoaiSach.Clear();
            txtSL.Clear();
            //cbMaTG.Items.Clear();
        }
        private void Kichhoattextbox()
        {
            txtMaSach.Enabled = true;
            txtTenSach.Enabled = true;
            txtMaLoaiSach.Enabled = true;
            txtSL.Enabled = true;
            cbMaTG.Enabled = true;
        }
        private void Vohieutextbox()
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtMaLoaiSach.Enabled = false;
            txtSL.Enabled = false;
            cbMaTG.Enabled = false;
        }
        private void CapNhat_Load(object sender, EventArgs e)
        {
            dt = KetNoiDangNhap.GetTable("select * from QLSach");
            dtgvDanhSach.DataSource = KetNoiDangNhap.GetTable("select * from QLSach");
            dtgvDanhSach.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhSach.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhSach.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhSach.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgvDanhSach.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dtgvDanhSach.Columns[0].HeaderText = "Mã Sách";
            dtgvDanhSach.Columns[1].HeaderText = "Tên Sách";
            dtgvDanhSach.Columns[2].HeaderText = "Mã Loại Sách";
            dtgvDanhSach.Columns[3].HeaderText = "Số Lượng";
            dtgvDanhSach.Columns[4].HeaderText = "Tác Giả";
        }
        private void dtgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDanhSach.CurrentRow != null)
            {
                txtMaSach.Text = dtgvDanhSach.CurrentRow.Cells[0].Value.ToString();
                txtTenSach.Text = dtgvDanhSach.CurrentRow.Cells[1].Value.ToString();
                txtMaLoaiSach.Text = dtgvDanhSach.CurrentRow.Cells[2].Value.ToString();
                txtSL.Text = dtgvDanhSach.CurrentRow.Cells[3].Value.ToString();
                cbMaTG.Text = dtgvDanhSach.CurrentRow.Cells[4].Value.ToString();

            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            chuyennut = "Them";
            Kichhoattextbox();
            Xoatextbox();
           
            MessageBox.Show("Bạn đã chọn chức năng Thêm Thông Tin Sách. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQL.Visible = btnLuu.Visible = true;
        }
        private void luu_them()
        {
            
            if (string.IsNullOrEmpty(txtMaSach.Text) || string.IsNullOrEmpty(txtTenSach.Text) ||
                string.IsNullOrEmpty(txtMaLoaiSach.Text) || string.IsNullOrEmpty(txtSL.Text) ||
                string.IsNullOrEmpty(cbMaTG.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = $"INSERT INTO QLSach VALUES (N'{txtMaSach.Text}', N'{txtTenSach.Text}', N'{txtMaLoaiSach.Text}', N'{txtSL.Text}', N'{cbMaTG.Text}')";

            bool kt = KetNoiDangNhap.TSX(sql);

            if (kt)
            {
                MessageBox.Show("Đã Thêm thành công.");
                dtgvDanhSach.DataSource = KetNoiDangNhap.GetTable("SELECT * FROM QLSach");
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void luu_sua()
        {         
            string sql = $"UPDATE QLSach SET TenSach = N'{txtTenSach.Text}', MaLoaiSach = N'{txtMaLoaiSach.Text}', SoLuong = {txtSL.Text}, MaTG = N'{cbMaTG.Text}' WHERE MaSach = N'{txtMaSach.Text}'";
            bool kt = KetNoiDangNhap.TSX(sql);
            if (kt)
            {
                MessageBox.Show("Đã Sửa thành công.");
                dtgvDanhSach.DataSource = KetNoiDangNhap.GetTable("SELECT * FROM QLSach");
            }
            else
            {
                MessageBox.Show("Sửa thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            chuyennut = "Sua";
            Kichhoattextbox();
            Xoatextbox();
            MessageBox.Show("Bạn đã chọn chức năng Sửa Thông Tin Sách. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQL.Visible = btnLuu.Visible = true;
        }
        private void luu_xoa()
        {
            string sql = $"DELETE FROM QLSach WHERE MaSach = N'{txtMaSach.Text}'";

            bool kt = KetNoiDangNhap.TSX(sql);
            if (kt)
            {
                MessageBox.Show("Đã Xóa thành công.");
                dtgvDanhSach.DataSource = KetNoiDangNhap.GetTable("SELECT * FROM QLSach");
            }
            else
            {
                MessageBox.Show("Xóa thất bại. Vui lòng kiểm tra lại dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            chuyennut = "Xoa";
            Kichhoattextbox();
            Xoatextbox();
            MessageBox.Show("Bạn đã chọn chức năng Xoá Thông Tin Sách. Vui lòng nhập thông tin và nhấn 'Lưu' để hoàn thành.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = false;
            btnQL.Visible = btnLuu.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chuyennut == "Them")
            {
                luu_them();
            }
            else if (chuyennut == "Sua")
            {
                luu_sua();
            }
            else if (chuyennut == "Xoa")
            {
                luu_xoa();
            }
        }

        private void btnQL_Click(object sender, EventArgs e)
        {
            Xoatextbox();
            Vohieutextbox();
            btnLuu.Visible = btnQL.Visible = false;
            btnThem.Visible = btnSua.Visible = btnXoa.Visible = btnThoat.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát khỏi chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        
    }
}
