using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Lab07_ADONET_Connection.BUS;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.Models;

namespace Lab07_ADONET_Connection.GUI
{
    public partial class frmMain : Form
    {
        private readonly SinhVienBUS _bus = new SinhVienBUS();
        private BindingList<SinhVien> _dsSinhVien = new BindingList<SinhVien>();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            cboConfigName.Items.Clear();
            cboConfigName.Items.Add("QLSinhVien ((localdb)\\MSSQLLocalDB - Mặc định)");
            cboConfigName.Items.Add("QLSinhVien_DefaultInstance (Data Source=.)");
            cboConfigName.Items.Add("QLSinhVien_SqlExpress (.\\SQLEXPRESS)");
            cboConfigName.Items.Add("QLSinhVien_SqlAuth (SQL Authentication - Câu 7)");
            cboConfigName.SelectedIndex = 0;

            txtDuongDanBak.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "QLSinhVien_Backup.bak");

            CauHinhDataGridView();
            NapDuLieuSinhVienVaKhoa();
        }

        private string LayTenKeyConfig()
        {
            switch (cboConfigName.SelectedIndex)
            {
                case 1: return "QLSinhVien_DefaultInstance";
                case 2: return "QLSinhVien_SqlExpress";
                case 3: return "QLSinhVien_SqlAuth";
                default: return "QLSinhVien";
            }
        }

        // Câu 8: Đọc chuỗi kết nối từ App.config bằng ConfigurationManager khi chọn cấu hình
        private void cboConfigName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key = LayTenKeyConfig();
            string connStr = DbConnectionFactory.GetConnectionStringFromConfig(key);
            txtConnectionString.Text = connStr;
            DbConnectionFactory.ActiveConnectionString = connStr;

            try
            {
                SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(connStr);
                txtDataSource.Text = b.DataSource;
                txtDatabase.Text = b.InitialCatalog;
                radWinAuth.Checked = b.IntegratedSecurity;
                radSqlAuth.Checked = !b.IntegratedSecurity;
                if (!b.IntegratedSecurity)
                {
                    txtUserId.Text = b.UserID;
                    txtPassword.Text = b.Password;
                }
            }
            catch { }
        }

        private void radAuth_CheckedChanged(object sender, EventArgs e)
        {
            bool sqlAuth = radSqlAuth.Checked;
            txtUserId.Enabled = sqlAuth;
            txtPassword.Enabled = sqlAuth;
            CapNhatChuoiKetNoiTuControl();
        }

        private void InputConn_TextChanged(object sender, EventArgs e)
        {
            CapNhatChuoiKetNoiTuControl();
        }

        private void CapNhatChuoiKetNoiTuControl()
        {
            string built = DbConnectionFactory.BuildConnectionString(
                txtDataSource.Text,
                txtDatabase.Text,
                radSqlAuth.Checked,
                txtUserId.Text,
                txtPassword.Text);
            txtConnectionString.Text = built;
        }

        // Bài 5 & Câu 9: Kiểm tra kết nối SQL Server và hiển thị lên Trang trạng thái kết nối
        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string connStr = txtConnectionString.Text.Trim();
                ConnectionStatusInfo info = DbConnectionFactory.TestConnection(connStr);
                HienThiTrangThaiKetNoi(info);

                if (info.IsSuccess)
                {
                    NapDuLieuSinhVienVaKhoa();
                    MessageBox.Show(
                        string.Format(
                            "Kết nối thành công: {0}\n" +
                            "- DataSource: {1}\n" +
                            "- ServerVersion: {2}\n" +
                            "- State: {3}\n" +
                            "- Thời gian kết nối: {4} ms",
                            info.Database, info.DataSource, info.ServerVersion, info.State, info.ElapsedMilliseconds),
                        "Kết quả kiểm tra kết nối (Bài 5 & Câu 9)",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                        info.Message + "\n\nGợi ý: Nếu CSDL QLSinhVien chưa được tạo trên máy chủ này, hãy nhấn nút 'Tạo CSDL & Dữ liệu mẫu (Lab07.sql)' bên cạnh!",
                        "Thông báo kết nối",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Câu 9: Cập nhật Trang trạng thái kết nối (DataSource, Database, ServerVersion, State, Thời gian)
        private void HienThiTrangThaiKetNoi(ConnectionStatusInfo info)
        {
            if (info == null) return;
            lblValDataSource.Text = info.DataSource;
            lblValDatabase.Text = info.Database;
            lblValServerVersion.Text = info.ServerVersion;
            lblValState.Text = info.State;
            lblValState.ForeColor = info.IsSuccess ? Color.FromArgb(46, 125, 50) : Color.FromArgb(211, 47, 47);
            lblValThoiGian.Text = string.Format("{0} ms (Lúc {1:HH:mm:ss dd/MM/yyyy})", info.ElapsedMilliseconds, info.CheckedAt);
            lblValThongBao.Text = info.Message;
            lblValThongBao.ForeColor = info.IsSuccess ? Color.FromArgb(13, 71, 161) : Color.FromArgb(198, 40, 40);
        }

        // Tự động chạy kịch bản Lab07_QLSinhVien.sql để tạo CSDL và nạp dữ liệu mẫu
        private void btnTaoCSDL_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string connStr = txtConnectionString.Text.Trim();
                DbConnectionFactory.InitializeDatabaseFromScript(connStr);

                ConnectionStatusInfo info = DbConnectionFactory.TestConnection(connStr);
                HienThiTrangThaiKetNoi(info);
                NapDuLieuSinhVienVaKhoa();

                MessageBox.Show(
                    "Đã thực thi kịch bản Lab07_QLSinhVien.sql thành công!\n" +
                    "- Đã tạo CSDL QLSinhVien\n" +
                    "- Đã tạo các bảng Khoa, SinhVien, HocPhan, DangKy và ràng buộc\n" +
                    "- Đã thêm 3 Khoa, 10 Sinh viên, 5 Học phần và dữ liệu Đăng ký!",
                    "Khởi tạo CSDL thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Không thể tự động khởi tạo CSDL trên Data Source '" + txtDataSource.Text + "':\n" + ex.Message +
                    "\n\nGợi ý: Hãy thử chọn cấu hình 'QLSinhVien_LocalDB ((localdb)\\MSSQLLocalDB)' hoặc mở SSMS chạy tệp Lab07_QLSinhVien.sql.",
                    "Lỗi khởi tạo CSDL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        // Câu 10: Sao lưu (Backup) và Phục hồi (Restore) CSDL QLSinhVien
        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnectionFactory.BackupDatabase(txtDuongDanBak.Text.Trim());
                MessageBox.Show("Đã sao lưu (Backup) CSDL QLSinhVien thành công ra tệp:\n" + txtDuongDanBak.Text,
                    "Sao lưu CSDL (Câu 10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao lưu CSDL: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DbConnectionFactory.RestoreDatabase(txtDuongDanBak.Text.Trim());
                NapDuLieuSinhVienVaKhoa();
                MessageBox.Show("Đã phục hồi (Restore) CSDL QLSinhVien thành công từ tệp:\n" + txtDuongDanBak.Text,
                    "Phục hồi CSDL (Câu 10)", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi CSDL: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tab 2: Quản lý dữ liệu QLSinhVien & Kiểm thử ràng buộc (Bài 2, 3, 4 & Câu 6)
        private void CauHinhDataGridView()
        {
            dgvSinhVien.AutoGenerateColumns = false;
            dgvSinhVien.Columns.Clear();

            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaSV", HeaderText = "Mã SV", Width = 80 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "HoTen", HeaderText = "Họ và tên", Width = 165 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NgaySinh",
                HeaderText = "Ngày sinh",
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "GioiTinhText", HeaderText = "Giới tính", Width = 70 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaKhoa", HeaderText = "Mã Khoa", Width = 75 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "TenKhoa", HeaderText = "Tên Khoa", Width = 165 });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DiemTB",
                HeaderText = "Điểm TB",
                Width = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
            });
            dgvSinhVien.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email (UNIQUE)", Width = 160 });

            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.AllowUserToAddRows = false;
        }

        private void NapDuLieuSinhVienVaKhoa()
        {
            List<Khoa> dsKhoa = _bus.GetAllKhoa();
            cboKhoa.DataSource = dsKhoa;
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";

            List<SinhVien> dsSV = _bus.GetAllSinhVien();
            _dsSinhVien = new BindingList<SinhVien>(dsSV);
            dgvSinhVien.DataSource = _dsSinhVien;

            string nguon = _bus.IsUsingSqlDatabase
                ? "Nguồn dữ liệu: SQL Server (QLSinhVien) - Đã kết nối trực tiếp"
                : "Nguồn dữ liệu: Bản sao mẫu từ Lab07_QLSinhVien.sql (3 Khoa, 10 Sinh viên)";
            lblNguonDuLieu.Text = string.Format("{0} | Tổng số: {1} sinh viên", nguon, dsSV.Count);
        }

        private void btnThemSV_Click(object sender, EventArgs e)
        {
            string rawDiem = (txtDiemTB.Text ?? "").Trim().Replace(',', '.');
            if (!decimal.TryParse(rawDiem, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal diem))
            {
                MessageBox.Show("Điểm trung bình không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maKhoa = cboKhoa.SelectedValue != null ? cboKhoa.SelectedValue.ToString() : "CNTT";
            SinhVien sv = new SinhVien(
                txtMaSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                dtpNgaySinh.Value,
                radNam.Checked,
                maKhoa,
                diem,
                txtEmail.Text.Trim(),
                cboKhoa.Text);

            try
            {
                _bus.Add(sv);
                NapDuLieuSinhVienVaKhoa();
                MessageBox.Show("Đã thêm sinh viên vào CSDL QLSinhVien thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ràng buộc CSDL từ chối dữ liệu:\n" + ex.Message,
                    "Kiểm tra Ràng buộc CSDL (Câu 6)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaSV_Click(object sender, EventArgs e)
        {
            SinhVien sv = dgvSinhVien.CurrentRow == null ? null : dgvSinhVien.CurrentRow.DataBoundItem as SinhVien;
            if (sv == null) return;

            if (MessageBox.Show("Bạn có chắc muốn xóa sinh viên " + sv.MaSV + " - " + sv.HoTen + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _bus.Delete(sv.MaSV);
                    NapDuLieuSinhVienVaKhoa();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Câu 6: Nút thử nhanh dữ liệu vi phạm UNIQUE Email và CHECK Điểm TB
        private void btnThuViPhamEmail_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "SV999";
            txtHoTen.Text = "Sinh Viên Trùng Email";
            txtDiemTB.Text = "7.5";
            txtEmail.Text = "an@eaut.edu.vn"; // Trùng với SV001
            btnThemSV_Click(sender, e);
        }

        private void btnThuViPhamDiem_Click(object sender, EventArgs e)
        {
            txtMaSV.Text = "SV998";
            txtHoTen.Text = "Sinh Viên Điểm Ngoài Miền";
            txtDiemTB.Text = "12.5"; // Vi phạm CHECK (DiemTB BETWEEN 0 AND 10)
            txtEmail.Text = "sv998@eaut.edu.vn";
            btnThemSV_Click(sender, e);
        }
    }
}
