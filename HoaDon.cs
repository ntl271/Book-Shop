using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopTuto
{
    public partial class HoaDon : Form
    {
        private DataProvider dataProvider = new DataProvider();
        private string connectionString = @"Data Source=LAPTOP-4RJFPRS4\NTL;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;";
        private int selectedHoaDonId; // Thêm biến để lưu ID hóa đơn được chọn

        public HoaDon()
        {
            InitializeComponent();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            loadDgHoaDon(); // Gọi hàm để nạp dữ liệu khi form được tải
            loadDgChonSach();
            loadDgSachDaChon();

            //// Gán sự kiện CellClick cho dgChonSach
            //dgChonSach.CellClick += dgChonSach_CellClick;

            // Khi khởi tạo form, kiểm tra và tránh gắn trùng
            dgChonSach.CellClick -= dgChonSach_CellClick; // Xóa gắn kết trước đó nếu có
            dgChonSach.CellClick += dgChonSach_CellClick; // Gắn sự kiện một lần

            //loadTenSach();
        }

        private void loadDgHoaDon()
        {
            // Tạo câu truy vấn SQL để lấy dữ liệu từ bảng tbl_hoa_don và tbl_sach
            StringBuilder query = new StringBuilder("SELECT hd.ma_hoa_don AS [Mã Hóa Đơn], " +
                                                    "hd.ten_khach_hang AS [Tên Khách Hàng], " +
                                                    "hd.sdt_khach_hang AS [SĐT Khách Hàng], " +
                                                    "hd.ngay_lap_hoa_don AS [Ngày Lập Hóa Đơn], " +
                                                    "hd.ma_sach AS [Mã Sách], " +
                                                    "s.ten_sach AS [Tên Sách], " +
                                                    "hd.so_luong AS [Số Lượng], " +
                                                    "hd.thanh_tien AS [Thành Tiền] " +
                                                    "FROM tbl_hoa_don hd " +
                                                    "JOIN tbl_sach s ON hd.ma_sach = s.ma_sach;");

            // Thực hiện truy vấn và lưu kết quả vào DataTable
            DataTable dt = dataProvider.execQuery(query.ToString());

            // Gán DataTable vào DataGridView
            dgHoaDon.DataSource = dt;

            // Thiết lập chế độ tự động điều chỉnh chiều rộng cột
            dgHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Kiểm tra và ẩn cột "Mã Hóa Đơn" nếu tồn tại
            if (dgHoaDon.Columns.Contains("Mã Hóa Đơn"))
            {
                dgHoaDon.Columns["Mã Hóa Đơn"].Visible = false;
            }

            // Căn giữa tên đầu bảng
            foreach (DataGridViewColumn column in dgHoaDon.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void loadDgChonSach()
        {
            // Tạo câu truy vấn để lấy dữ liệu từ bảng tbl_sach
            StringBuilder query = new StringBuilder("SELECT ma_sach AS [Mã Sách], ten_sach AS [Tên Sách] FROM tbl_sach");

            // Thực hiện truy vấn và lưu kết quả vào DataTable
            DataTable dt = dataProvider.execQuery(query.ToString());

            // Gán DataTable vào DataGridView
            dgChonSach.DataSource = dt;

            // Thiết lập chế độ tự động điều chỉnh chiều rộng cột
            dgChonSach.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Căn giữa tên đầu bảng
            foreach (DataGridViewColumn column in dgChonSach.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Căn giữa nội dung các cột
            foreach (DataGridViewRow row in dgChonSach.Rows)
            {
                row.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void loadDgSachDaChon()
        {
            // Tạo DataTable để hiển thị trong DataGridView
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã Sách", typeof(int));
            dt.Columns.Add("Tên Sách", typeof(string));
            dt.Columns.Add("Số Lượng", typeof(int));

            // Thêm dữ liệu từ danh sách đã chọn vào DataTable
            foreach (var sach in danhSachDaChon)
            {
                dt.Rows.Add(sach.MaSach, sach.TenSach, sach.SoLuong);
            }

            // Gán DataTable vào DataGridView
            dgSachDaChon.DataSource = dt;

            // Tự động điều chỉnh độ rộng cột
            dgSachDaChon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            PhieuNhap phieu_nhap = new PhieuNhap();
            phieu_nhap.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trang_chu = new TrangChu();
            trang_chu.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            KhoHang kho_hang = new KhoHang();
            kho_hang.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhaPhanPhoi nha_phan_phoi = new NhaPhanPhoi();
            nha_phan_phoi.ShowDialog();
            this.Close();
        }



        // Hàm giả định để lấy giá bán của sách dựa vào tên sách
        private float GetGiaBanSach(string tenSach)
        {
            // Câu truy vấn để lấy giá bán từ bảng sách (tbl_sach)
            string query = "SELECT gia_ban FROM tbl_sach WHERE ma_sach = @ma_sach";
            var parameters = new Dictionary<string, object> { { "@ma_sach", tenSach } };
            DataTable dt = dataProvider.execQuery(query, parameters);

            // Kiểm tra và trả về giá trị giá bán
            if (dt.Rows.Count > 0)
            {
                return Convert.ToSingle(dt.Rows[0]["gia_ban"]);
            }
            else
            {
                throw new Exception("Không tìm thấy giá bán cho sách này.");
            }
        }

        private void txtHoaDonSearch_TextChanged(object sender, EventArgs e)
        {
            // Lấy giá trị tìm kiếm từ TextBox
            string searchValue = txtHoaDonSearch.Text.Trim();

            // Câu truy vấn SQL để tìm kiếm
            string query = "SELECT hd.ma_hoa_don AS [Mã Hóa Đơn], " +
                           "hd.ten_khach_hang AS [Tên Khách Hàng], " +
                           "hd.sdt_khach_hang AS [Số Điện Thoại], " +
                           "hd.ngay_lap_hoa_don AS [Ngày Lập Hóa Đơn], " +
                           "hd.ma_sach AS [Mã Sách], " +
                           "s.ten_sach AS [Tên Sách Mua], " +
                           "hd.so_luong AS [Số Lượng], " +
                           "hd.thanh_tien AS [Thành Tiền] " +
                           "FROM tbl_hoa_don hd " +
                           "JOIN tbl_sach s ON hd.ma_sach = s.ma_sach " +
                           "WHERE hd.ten_khach_hang LIKE @searchValue " +
                           "OR hd.sdt_khach_hang LIKE @searchValue " +
                           "OR s.ten_sach LIKE @searchValue";

            // Tạo tham số cho câu lệnh truy vấn
            var parameters = new Dictionary<string, object>
    {
        { "@searchValue", "%" + searchValue + "%" }
    };

            // Thực hiện truy vấn và cập nhật DataGridView
            DataTable result = dataProvider.execQuery(query, parameters);
            dgHoaDon.DataSource = result;

            // Kiểm tra và ẩn cột "Mã Hóa Đơn" nếu tồn tại
            if (dgHoaDon.Columns.Contains("Mã Hóa Đơn"))
            {
                dgHoaDon.Columns["Mã Hóa Đơn"].Visible = false; // Ẩn cột Mã Hóa Đơn
            }

            // Thiết lập chế độ tự động điều chỉnh chiều rộng cột
            dgHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Căn giữa tên đầu bảng
            foreach (DataGridViewColumn column in dgHoaDon.Columns)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private List<SachDaChon> danhSachDaChon = new List<SachDaChon>();

        // Tạo class SachDaChon để lưu trữ thông tin sách đã chọn
        public class SachDaChon
        {
            public int MaSach { get; set; }
            public string TenSach { get; set; }
            public int SoLuong { get; set; }
        }


        private void dgChonSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy mã sách và tên sách từ dòng được chọn
                int maSach = Convert.ToInt32(dgChonSach.Rows[e.RowIndex].Cells["Mã Sách"].Value);
                string tenSach = dgChonSach.Rows[e.RowIndex].Cells["Tên Sách"].Value.ToString();

                // Kiểm tra xem mã sách đã tồn tại trong danh sách đã chọn chưa
                var sachDaChon = danhSachDaChon.FirstOrDefault(s => s.MaSach == maSach);
                if (sachDaChon != null)
                {
                    // Nếu đã tồn tại, tăng số lượng lên 1
                    sachDaChon.SoLuong++;
                }
                else
                {
                    // Nếu chưa tồn tại, thêm sách mới với số lượng = 1
                    danhSachDaChon.Add(new SachDaChon
                    {
                        MaSach = maSach,
                        TenSach = tenSach,
                        SoLuong = 1
                    });
                }

                // Cập nhật lại DataGridView
                loadDgSachDaChon();
            }
        }

        private void btnHoaDonThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các trường nhập liệu
                string tenKhachHang = txtHoaDonTenKH.Text.Trim();
                string sdtKhachHang = txtHoaDonSDTKH.Text.Trim();
                DateTime ngayLapHoaDon = dateNgayLapHoaDon.Value;

                // Kiểm tra nếu tên khách hàng hoặc SĐT để trống
                if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdtKhachHang))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Duyệt qua danh sách các sách đã chọn
                foreach (var sach in danhSachDaChon)
                {
                    // Lấy giá bán của sách từ cơ sở dữ liệu
                    float giaBan = GetGiaBanSach(sach.MaSach.ToString());
                    int soLuong = sach.SoLuong;

                    // Tính thành tiền
                    float thanhTien = giaBan * soLuong;

                    // Tạo câu lệnh SQL để thêm hóa đơn vào bảng tbl_hoa_don
                    string query = "INSERT INTO tbl_hoa_don (ten_khach_hang, sdt_khach_hang, ngay_lap_hoa_don, ma_sach, so_luong, thanh_tien) " +
                                   "VALUES (@ten_khach_hang, @sdt_khach_hang, @ngay_lap_hoa_don, @ma_sach, @so_luong, @thanh_tien)";

                    // Tạo danh sách tham số cho câu lệnh SQL
                    var parameters = new Dictionary<string, object>
                    {
                        { "@ten_khach_hang", tenKhachHang },
                        { "@sdt_khach_hang", sdtKhachHang },
                        { "@ngay_lap_hoa_don", ngayLapHoaDon },
                        { "@ma_sach", sach.MaSach },
                        { "@so_luong", soLuong },
                        { "@thanh_tien", thanhTien }
                    };

                    // Thực thi câu lệnh SQL
                    dataProvider.execNonQuery(query, parameters);
                }

                // Hiển thị thông báo thành công
                MessageBox.Show("Thêm hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Làm mới danh sách hóa đơn
                loadDgHoaDon();

                // Xóa danh sách sách đã chọn và làm mới DataGridView
                danhSachDaChon.Clear();
                loadDgSachDaChon();

                // Xóa các trường nhập liệu
                txtHoaDonTenKH.Clear();
                txtHoaDonSDTKH.Clear();
                dateNgayLapHoaDon.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy thông tin từ dòng được chọn trong dgHoaDon
                string tenKH = dgHoaDon.Rows[e.RowIndex].Cells["Tên Khách Hàng"].Value.ToString();
                string sdtKH = dgHoaDon.Rows[e.RowIndex].Cells["SĐT Khách Hàng"].Value.ToString();
                DateTime ngayLap = Convert.ToDateTime(dgHoaDon.Rows[e.RowIndex].Cells["Ngày Lập Hóa Đơn"].Value);

                // Hiển thị thông tin lên các trường TextBox và DateTimePicker
                txtHoaDonTenKH.Text = tenKH;
                txtHoaDonSDTKH.Text = sdtKH;
                dateNgayLapHoaDon.Value = ngayLap;

                // Lấy mã sách, tên sách và số lượng từ bảng dgHoaDon (giả sử là cột "Mã Sách", "Tên Sách", "Số Lượng")
                int maSach = Convert.ToInt32(dgHoaDon.Rows[e.RowIndex].Cells["Mã Sách"].Value);
                string tenSach = dgHoaDon.Rows[e.RowIndex].Cells["Tên Sách"].Value.ToString();
                int soLuong = Convert.ToInt32(dgHoaDon.Rows[e.RowIndex].Cells["Số Lượng"].Value);

                // Cập nhật lại DataGridView dgSachDaChon
                // Lấy DataTable hiện tại từ dgSachDaChon
                DataTable dtSachDaChon = (DataTable)dgSachDaChon.DataSource;

                // Nếu DataTable chưa được khởi tạo, tạo mới
                if (dtSachDaChon == null)
                {
                    dtSachDaChon = new DataTable();
                    dtSachDaChon.Columns.Add("Mã Sách", typeof(int));
                    dtSachDaChon.Columns.Add("Tên Sách", typeof(string));
                    dtSachDaChon.Columns.Add("Số Lượng", typeof(int));
                }

                // Kiểm tra xem mã sách đã có trong dgSachDaChon chưa
                var existingRow = dtSachDaChon.AsEnumerable().FirstOrDefault(row => row.Field<int>("Mã Sách") == maSach);

                if (existingRow != null)
                {
                    // Nếu mã sách đã có, chỉ cập nhật số lượng
                    existingRow["Số Lượng"] = soLuong;
                }
                else
                {
                    // Nếu mã sách chưa có, thêm dòng mới vào DataTable
                    dtSachDaChon.Rows.Add(maSach, tenSach, soLuong);
                }

                // Cập nhật lại DataGridView dgSachDaChon
                dgSachDaChon.DataSource = dtSachDaChon;

                // Tự động điều chỉnh độ rộng cột
                dgSachDaChon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnHoaDonRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                // Xóa dữ liệu trong các trường nhập liệu
                txtHoaDonTenKH.Text = string.Empty;
                txtHoaDonSDTKH.Text = string.Empty;
                dateNgayLapHoaDon.Value = DateTime.Now;

                // Làm trống danh sách các sách đã chọn
                danhSachDaChon.Clear();

                // Làm mới DataGridView hiển thị danh sách sách đã chọn
                loadDgSachDaChon();

                // Làm mới danh sách hóa đơn
                loadDgHoaDon();

                // Làm mới danh sách sách để chọn
                loadDgChonSach();

                MessageBox.Show("Dữ liệu đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi làm mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Biến để theo dõi số lần click vào dòng
        private int clickCount = 0;

        private void btnHoaDonSua_Click(object sender, EventArgs e)
        {
            var tenKH = txtHoaDonTenKH.Text;
            var sdtKH = txtHoaDonSDTKH.Text;
            var ngayLap = dateNgayLapHoaDon.Value;

            if (dgHoaDon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để chỉnh sửa.");
                return;
            }

            int maHoaDon = Convert.ToInt32(dgHoaDon.SelectedRows[0].Cells["Mã Hóa Đơn"].Value);

            // Cập nhật thông tin hóa đơn
            UpdateHoaDon(maHoaDon, tenKH, sdtKH, ngayLap);

            // Cập nhật thông tin sách trong bảng tbl_hoa_don
            UpdateSachChoHoaDon(maHoaDon);
        }

        private void UpdateSachChoHoaDon(int maHoaDon)
        {
            string connectionString = @"Data Source=LAPTOP-4RJFPRS4\NTL;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;";

            DateTime ngayLap = dateNgayLapHoaDon.Value;
            string tenKhachHang = txtHoaDonTenKH.Text;
            string sdtKhachHang = txtHoaDonSDTKH.Text;

            if (string.IsNullOrEmpty(tenKhachHang) || string.IsNullOrEmpty(sdtKhachHang))
            {
                MessageBox.Show("Tên khách hàng và số điện thoại không thể để trống.");
                return;
            }

            // Lấy danh sách sách và số lượng từ DataGridView
            List<Tuple<int, int>> sachDaChon = new List<Tuple<int, int>>(); // Lưu trữ mã sách và số lượng
            foreach (DataGridViewRow row in dgSachDaChon.Rows)
            {
                if (row.Cells["Mã Sách"].Value != null && row.Cells["Số Lượng"].Value != null)
                {
                    int maSach = Convert.ToInt32(row.Cells["Mã Sách"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["Số Lượng"].Value);
                    sachDaChon.Add(new Tuple<int, int>(maSach, soLuong));
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Lặp qua các sách đã chọn và cập nhật thông tin vào tbl_hoa_don
                    foreach (var sach in sachDaChon)
                    {
                        int maSach = sach.Item1;
                        int soLuong = sach.Item2;

                        // Tính thành tiền (giả sử bạn đã có logic tính giá sách ở đâu đó, ví dụ lấy từ bảng sách)
                        float thanhTien = 0;

                        // Ví dụ: Truy vấn giá sách từ bảng sách (giả sử bảng 'tbl_sach' có cột 'gia_ban')
                        string getGiaSachQuery = "SELECT gia_ban FROM tbl_sach WHERE ma_sach = @maSach";
                        SqlCommand getGiaSachCmd = new SqlCommand(getGiaSachQuery, connection);
                        getGiaSachCmd.Parameters.AddWithValue("@maSach", maSach);

                        object result = getGiaSachCmd.ExecuteScalar();
                        if (result != null)
                        {
                            float giaSach = Convert.ToSingle(result);
                            thanhTien = giaSach * soLuong;
                        }

                        // Cập nhật thông tin vào tbl_hoa_don
                        string updateQuery = "UPDATE tbl_hoa_don SET " +
                                             "ngay_lap_hoa_don = @ngayLap, " +
                                             "ten_khach_hang = @tenKhachHang, " +
                                             "sdt_khach_hang = @sdtKhachHang, " +
                                             "so_luong = @soLuong, " +
                                             "thanh_tien = @thanhTien " +
                                             "WHERE ma_hoa_don = @maHoaDon AND ma_sach = @maSach";

                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@ngayLap", ngayLap);
                        updateCommand.Parameters.AddWithValue("@tenKhachHang", tenKhachHang);
                        updateCommand.Parameters.AddWithValue("@sdtKhachHang", sdtKhachHang);
                        updateCommand.Parameters.AddWithValue("@soLuong", soLuong);
                        updateCommand.Parameters.AddWithValue("@thanhTien", thanhTien);
                        updateCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);
                        updateCommand.Parameters.AddWithValue("@maSach", maSach);

                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Kiểm tra xem có cập nhật được bản ghi nào không
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn hoặc sách tương ứng để cập nhật.");
                        }
                    }

                    MessageBox.Show("Cập nhật hóa đơn thành công.");
                    loadDgHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật sách cho hóa đơn: " + ex.Message);
                }
            }
        }

        private void UpdateHoaDon(int maHoaDon, string tenKH, string sdtKH, DateTime ngayLap)
        {
            string connectionString = @"Data Source=LAPTOP-4RJFPRS4\NTL;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE tbl_hoa_don SET ten_khach_hang = @tenKH, sdt_khach_hang = @sdtKH, ngay_lap_hoa_don = @ngayLap WHERE ma_hoa_don = @maHoaDon";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tenKH", tenKH);
                command.Parameters.AddWithValue("@sdtKH", sdtKH);
                command.Parameters.AddWithValue("@ngayLap", ngayLap);
                command.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        private void dgSachDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnHoaDonXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng có chọn dòng trong DataGridView hay không
            if (dgHoaDon.SelectedRows.Count > 0)
            {
                // Lấy mã hóa đơn từ cột ẩn trong DataGridView (cột "Mã Hóa Đơn")
                int maHoaDon = Convert.ToInt32(dgHoaDon.SelectedRows[0].Cells["Mã Hóa Đơn"].Value);

                // Xác nhận người dùng muốn xóa hóa đơn
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?",
                                                            "Xác nhận xóa",
                                                            MessageBoxButtons.YesNo,
                                                            MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    // Câu lệnh SQL xóa hóa đơn từ bảng tbl_hoa_don
                    string connectionString = @"Data Source=LAPTOP-4RJFPRS4\NTL;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            // Câu lệnh SQL để xóa hóa đơn theo mã hóa đơn
                            string deleteQuery = "DELETE FROM tbl_hoa_don WHERE ma_hoa_don = @maHoaDon";

                            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@maHoaDon", maHoaDon);

                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Hóa đơn đã được xóa thành công.");
                                loadDgHoaDon(); // Tải lại DataGridView sau khi xóa
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hóa đơn với mã này.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn để xóa.");
            }
        }
    }
}
