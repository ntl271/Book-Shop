using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookShopTuto
{
    public partial class User : Form
    {
        private DataProvider dataProvider = new DataProvider(); // Khởi tạo DataProvider
        private string connectionString = @"Data Source=KHANHNAM36;Initial Catalog=db_quan_ly_ban_sach;Integrated Security=True;Encrypt=False";

        public User()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            // Câu truy vấn để lấy dữ liệu từ bảng tbl_users
            string query = @"SELECT 
                            user_id AS [Mã Người Dùng], 
                            username AS [Tên Người Dùng], 
                            password AS [Mật Khẩu] 
                         FROM tbl_users";

            try
            {
                // Thực thi truy vấn và lấy dữ liệu từ CSDL
                DataTable dataTable = dataProvider.execQuery(query);

                // Gán dữ liệu vào DataGridView
                dgDangNhap.DataSource = dataTable;

                // Thiết lập chế độ tự động điều chỉnh chiều rộng các cột
                dgDangNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Căn giữa tiêu đề các cột
                foreach (DataGridViewColumn column in dgDangNhap.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                // Tải mã người dùng tiếp theo vào TextBox
                UpdateNextUserID();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateNextUserID()
        {
            try
            {
                // Câu truy vấn để lấy mã user_id lớn nhất
                string maxQuery = "SELECT MAX(user_id) FROM tbl_users";
                DataTable maxTable = dataProvider.execQuery(maxQuery);

                // Kiểm tra kết quả và thiết lập mã kế tiếp
                if (maxTable.Rows.Count > 0 && maxTable.Rows[0][0] != DBNull.Value)
                {
                    int nextUserID = Convert.ToInt32(maxTable.Rows[0][0]) + 1;
                    txtMaTK.Text = nextUserID.ToString(); // Gán mã kế tiếp vào TextBox
                }
                else
                {
                    txtMaTK.Text = "1"; // Nếu bảng rỗng, khởi tạo mã đầu tiên là 1
                }
                // Đặt TextBox ở chế độ chỉ đọc
                txtMaTK.ReadOnly = true;
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có vấn đề khi truy vấn
                MessageBox.Show("Có lỗi xảy ra khi lấy mã người dùng: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUserThoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            TrangChu trangChu = new TrangChu();
            trangChu.ShowDialog();
            this.Close();
        }

        private void btnUserRefresh_Click(object sender, EventArgs e)
        {
            // Xóa nội dung các TextBox
            txtMaTK.Clear();
            txtTenTK.Clear();
            txtMatKhau.Clear();

            // Bỏ chọn bất kỳ hàng nào trong DataGridView
            dgDangNhap.ClearSelection();

            // Tải lại dữ liệu vào DataGridView
            LoadUsers(); // Hàm này sẽ tải lại dữ liệu người dùng
        }

        private void dgDangNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng có bấm vào hàng hợp lệ không
            if (e.RowIndex >= 0) // e.RowIndex < 0 nghĩa là tiêu đề cột được click
            {
                // Lấy dữ liệu từ hàng đã click
                DataGridViewRow row = dgDangNhap.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                // Lưu ý: Các tên cột phải trùng với tên alias trong SQL
                txtMaTK.Text = row.Cells["Mã Người Dùng"].Value?.ToString() ?? string.Empty;
                txtTenTK.Text = row.Cells["Tên Người Dùng"].Value?.ToString() ?? string.Empty;
                txtMatKhau.Text = row.Cells["Mật Khẩu"].Value?.ToString() ?? string.Empty;
            }
        }

        private void btnUserXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu không có tài khoản nào được chọn
                if (string.IsNullOrWhiteSpace(txtMaTK.Text))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản cần xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy mã người dùng từ ô txtMaTK
                if (!int.TryParse(txtMaTK.Text, out int userID))
                {
                    MessageBox.Show("Mã người dùng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận xóa tài khoản
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    // Câu lệnh xóa tài khoản
                    string query = "DELETE FROM tbl_users WHERE user_id = @userID";

                    // Thêm tham số cho câu lệnh truy vấn
                    var parameters = new Dictionary<string, object>
                {
                    { "@userID", userID }
                };

                    // Gọi hàm thực hiện truy vấn
                    int rowsAffected = dataProvider.execNonQuery(query, parameters);

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers(); // Tải lại dữ liệu trong DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để xóa. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUserSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra nếu các trường nhập liệu để trống
                if (string.IsNullOrWhiteSpace(txtTenTK.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy dữ liệu từ các trường nhập liệu
                string username = txtTenTK.Text;
                string password = txtMatKhau.Text;

                // Lấy mã người dùng từ ô txtMaTK
                int userID = Convert.ToInt32(txtMaTK.Text); // Giả sử bạn đang sử dụng txtMaTK để lưu mã người dùng

                // Câu lệnh cập nhật thông tin người dùng
                string query = "UPDATE tbl_users SET username = @username, password = @password WHERE user_id = @userID";

                // Thêm các tham số cho câu lệnh truy vấn
                var parameters = new Dictionary<string, object>
                {
                    { "@username", username },
                    { "Password", password },
                       { "@userID", userID }
                };
                // Gọi hàm thực hiện truy vấn
                int rowsAffected = dataProvider.execNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers(); // Tải lại dữ liệu trong DataGridView
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
