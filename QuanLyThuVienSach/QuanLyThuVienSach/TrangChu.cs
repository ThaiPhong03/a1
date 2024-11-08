using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienSach
{
    public partial class TrangChu : Form
    {
        private string chucvu;
        private DataTable dt;
        public TrangChu(string chucVu)
        {
            InitializeComponent();
            this.chucvu = chucvu;
            Vohieutextbox();
        }
        private void Vohieutextbox()
        {
            txtMaSach.Enabled = false;
            txtTenSach.Enabled = false;
            txtMaLoaiSach.Enabled = false;
            txtMaTG.Enabled = false;
            txtSL.Enabled = false;
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            lvLoaiSach.View = View.List;
            lvLoaiSach.Items.Add("Sách giáo khoa").Tag = "SGK";
            lvLoaiSach.Items.Add("Truyện tranh").Tag = "TT";
            lvLoaiSach.Items.Add("Lịch sử").Tag = "LS";
            lvLoaiSach.Items.Add("Khoa học").Tag = "KH";
            lvLoaiSach.Items.Add("Kinh tế").Tag = "KT";
            lvLoaiSach.Items.Add("Chính Trị").Tag = "CT";
            Vohieutextbox();

            if (chucvu == "Giám đốc" || chucvu == "Chủ tịch")
            {
                btnTaiKhoan.Enabled = true;
            }
            else
            {
                btnTaiKhoan.Enabled = false;
            }

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
                txtMaTG.Text = dtgvDanhSach.CurrentRow.Cells[4].Value.ToString();

            }
            
        }

        private void lvLoaiSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLoaiSach.SelectedItems.Count > 0)
            {
                // Lấy Tag của mục được chọn làm MaLoaiSach
                string maLoaiSach = lvLoaiSach.SelectedItems[0].Tag.ToString();

                // Lọc dữ liệu dựa trên MaLoaiSach và cập nhật DataGridView
                dtgvDanhSach.DataSource = KetNoiDangNhap.GetTable($"SELECT * FROM QLSach WHERE MaLoaiSach = N'{maLoaiSach}'");
                if (dtgvDanhSach.Rows.Count == 1)
                {
                    MessageBox.Show("Thông tin sách chưa có .", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
