using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyThuVienSach
{
    internal class KetNoiDangNhap
    {
        private static string duongdan = "Data Source=NờTêPê\\THAIPHONG;Initial Catalog=QLTVS;Integrated Security=True;Encrypt=False";

        public static SqlConnection KetNoi()
        {
            return new SqlConnection(duongdan);
        }

        public static bool CheckDangNhap(string taikhoan, string matkhau)
        {
            bool ketQua = false;
            using (SqlConnection connection = KetNoi())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM QLTaiKhoan WHERE Taikhoan = @taikhoan AND Matkhau = @matkhau", connection);
                    cmd.Parameters.AddWithValue("@taikhoan", taikhoan);
                    cmd.Parameters.AddWithValue("@matkhau", matkhau);

                    int count = (int)cmd.ExecuteScalar();
                    ketQua = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return ketQua;
        }

        public static string GetChucVu(string taikhoan)
        {
            string chucVu = "";
            using (SqlConnection connection = KetNoi())
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT Chucvu FROM QLTaiKhoan WHERE Taikhoan = @taikhoan", connection);
                    cmd.Parameters.AddWithValue("@taikhoan", taikhoan);

                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        chucVu = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối đến cơ sở dữ liệu: " + ex.Message);
                }
            }
            return chucVu;
        }
        public static DataTable GetTable(string sql)
        {
            using (SqlConnection con = KetNoi())
            {
                con.Open();
                SqlDataAdapter ad = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                return dt;
            }
        }
        public static bool TSX(string sql)
        {
            try
            {
                using (SqlConnection con = KetNoi())
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi", ex.Message);
                return false;
            }
        }
        public static SqlDataReader LDL(string sql)
        {
            SqlConnection con = KetNoi();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
    }
}
