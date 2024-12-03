using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace BookShopTuto
{
    public partial class KhoHang : Form
    {
        private string connectionString = @"Data Source=LAPTOP-4RJFPRS4\NTL;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;";
        private DataProvider dataProvider = new DataProvider();

        public KhoHang()
        {
            InitializeComponent();
            LoadDgKhoHang();
            //LoadMaSach();
        }

        private void LoadDgKhoHang()
        {
            try
            {
                // Tạo câu truy vấn SQL để lấy dữ liệu về tổng số lượng nhập, bán và số lượng còn lại
                StringBuilder query = new StringBuilder(@"
            SELECT 
                s.ma_sach AS [Mã Sách], 
                s.ten_sach AS [Tên Sách],
                ISNULL(SUM(csn.so_luong), 0) AS [Tổng Số Lượng Nhập], 
                ISNULL(SUM(hd.so_luong), 0) AS [Tổng Số Lượng Bán], 
                (ISNULL(SUM(csn.so_luong), 0) - ISNULL(SUM(hd.so_luong), 0)) AS [Số Lượng Còn Lại] 
            FROM tbl_sach s
            LEFT JOIN tbl_chi_tiet_phieu_nhap csn ON s.ma_sach = csn.ma_sach
            LEFT JOIN tbl_hoa_don hd ON s.ma_sach = hd.ma_sach
            GROUP BY s.ma_sach, s.ten_sach");

                // Thực hiện truy vấn và lưu kết quả vào DataTable
                DataTable dt = dataProvider.execQuery(query.ToString());

                // Gán DataTable vào DataGridView
                dgKhoHang.DataSource = dt;

                // Thiết lập chế độ tự động điều chỉnh chiều rộng cột
                dgKhoHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Căn giữa tên đầu bảng
                foreach (DataGridViewColumn column in dgKhoHang.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                // In ra lỗi nếu có
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books sach = new Books();
            sach.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoaiSach loai_sach = new LoaiSach();
            loai_sach.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            HoaDon hoa_don = new HoaDon();
            hoa_don.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            PhieuNhap phieu_nhap = new PhieuNhap();
            phieu_nhap.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaPhanPhoi nha_phan_phoi = new NhaPhanPhoi();
            nha_phan_phoi.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trang_chu = new TrangChu();
            trang_chu.ShowDialog();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Gọi hàm tìm kiếm khi giá trị trong TextBox thay đổi
            SearchData(txtSearch.Text);
        }

        private void SearchData(string searchValue)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Câu truy vấn tìm kiếm theo Mã Sách và Tên Sách
                    string query = @"
            SELECT 
                s.ma_sach AS [Mã Sách], 
                s.ten_sach AS [Tên Sách],
                ISNULL(SUM(csn.so_luong), 0) AS [Tổng Số Lượng Nhập], 
                ISNULL(SUM(hd.so_luong), 0) AS [Tổng Số Lượng Bán], 
                (ISNULL(SUM(csn.so_luong), 0) - ISNULL(SUM(hd.so_luong), 0)) AS [Số Lượng Còn Lại] 
            FROM tbl_sach s
            LEFT JOIN tbl_chi_tiet_phieu_nhap csn ON s.ma_sach = csn.ma_sach
            LEFT JOIN tbl_hoa_don hd ON s.ma_sach = hd.ma_sach
            WHERE s.ma_sach LIKE @SearchValue OR s.ten_sach LIKE @SearchValue
            GROUP BY s.ma_sach, s.ten_sach";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số tìm kiếm với ký tự wildcard
                        command.Parameters.AddWithValue("@SearchValue", "%" + searchValue + "%");

                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // Gán dữ liệu tìm kiếm cho DataGridView
                        dgKhoHang.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

    }
}
