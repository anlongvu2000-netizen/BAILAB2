using System.Drawing;
using System.Windows.Forms;

namespace Lab07_ADONET_Connection.GUI
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTieuDe;
        private TabControl tabMain;
        private TabPage tabKetNoi;
        private GroupBox grpCauHinh;
        private Label lblChonConfig;
        private ComboBox cboConfigName;
        private Label lblDataSource;
        private TextBox txtDataSource;
        private Label lblDatabase;
        private TextBox txtDatabase;
        private RadioButton radWinAuth;
        private RadioButton radSqlAuth;
        private Label lblUserId;
        private TextBox txtUserId;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblConnStr;
        private TextBox txtConnectionString;
        private Button btnKiemTra;
        private Button btnTaoCSDL;
        private GroupBox grpTrangThai;
        private Label lblTitleDS;
        private Label lblValDataSource;
        private Label lblTitleDB;
        private Label lblValDatabase;
        private Label lblTitleVer;
        private Label lblValServerVersion;
        private Label lblTitleState;
        private Label lblValState;
        private Label lblTitleTime;
        private Label lblValThoiGian;
        private Label lblValThongBao;
        private GroupBox grpBackupRestore;
        private Label lblFileBak;
        private TextBox txtDuongDanBak;
        private Button btnBackup;
        private Button btnRestore;
        private TabPage tabDuLieuSQL;
        private GroupBox grpNhapSV;
        private Label lblMaSV;
        private TextBox txtMaSV;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private RadioButton radNam;
        private RadioButton radNu;
        private Label lblKhoa;
        private ComboBox cboKhoa;
        private Label lblDiemTB;
        private TextBox txtDiemTB;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnThemSV;
        private Button btnXoaSV;
        private Button btnThuViPhamEmail;
        private Button btnThuViPhamDiem;
        private DataGridView dgvSinhVien;
        private Label lblNguonDuLieu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTieuDe = new Label();
            this.tabMain = new TabControl();
            this.tabKetNoi = new TabPage();
            this.grpCauHinh = new GroupBox();
            this.lblChonConfig = new Label();
            this.cboConfigName = new ComboBox();
            this.lblDataSource = new Label();
            this.txtDataSource = new TextBox();
            this.lblDatabase = new Label();
            this.txtDatabase = new TextBox();
            this.radWinAuth = new RadioButton();
            this.radSqlAuth = new RadioButton();
            this.lblUserId = new Label();
            this.txtUserId = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.lblConnStr = new Label();
            this.txtConnectionString = new TextBox();
            this.btnKiemTra = new Button();
            this.btnTaoCSDL = new Button();
            this.grpTrangThai = new GroupBox();
            this.lblTitleDS = new Label();
            this.lblValDataSource = new Label();
            this.lblTitleDB = new Label();
            this.lblValDatabase = new Label();
            this.lblTitleVer = new Label();
            this.lblValServerVersion = new Label();
            this.lblTitleState = new Label();
            this.lblValState = new Label();
            this.lblTitleTime = new Label();
            this.lblValThoiGian = new Label();
            this.lblValThongBao = new Label();
            this.grpBackupRestore = new GroupBox();
            this.lblFileBak = new Label();
            this.txtDuongDanBak = new TextBox();
            this.btnBackup = new Button();
            this.btnRestore = new Button();
            this.tabDuLieuSQL = new TabPage();
            this.grpNhapSV = new GroupBox();
            this.lblMaSV = new Label();
            this.txtMaSV = new TextBox();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblNgaySinh = new Label();
            this.dtpNgaySinh = new DateTimePicker();
            this.radNam = new RadioButton();
            this.radNu = new RadioButton();
            this.lblKhoa = new Label();
            this.cboKhoa = new ComboBox();
            this.lblDiemTB = new Label();
            this.txtDiemTB = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.btnThemSV = new Button();
            this.btnXoaSV = new Button();
            this.btnThuViPhamEmail = new Button();
            this.btnThuViPhamDiem = new Button();
            this.dgvSinhVien = new DataGridView();
            this.lblNguonDuLieu = new Label();
            this.tabMain.SuspendLayout();
            this.tabKetNoi.SuspendLayout();
            this.grpCauHinh.SuspendLayout();
            this.grpTrangThai.SuspendLayout();
            this.grpBackupRestore.SuspendLayout();
            this.tabDuLieuSQL.SuspendLayout();
            this.grpNhapSV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).BeginInit();
            this.SuspendLayout();

            // lblTieuDe
            this.lblTieuDe.AutoSize = false;
            this.lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTieuDe.ForeColor = Color.FromArgb(13, 71, 161);
            this.lblTieuDe.Location = new Point(12, 8);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new Size(920, 30);
            this.lblTieuDe.Text = "LAB 07: CƠ SỞ DỮ LIỆU QLSINHVIEN & KẾT NỐI ADO.NET (SQL SERVER)";
            this.lblTieuDe.TextAlign = ContentAlignment.MiddleCenter;

            // tabMain
            this.tabMain.Controls.Add(this.tabKetNoi);
            this.tabMain.Controls.Add(this.tabDuLieuSQL);
            this.tabMain.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.tabMain.Location = new Point(12, 42);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new Size(920, 560);
            this.tabMain.TabIndex = 0;

            // tabKetNoi
            this.tabKetNoi.BackColor = Color.FromArgb(248, 249, 250);
            this.tabKetNoi.Controls.Add(this.grpBackupRestore);
            this.tabKetNoi.Controls.Add(this.grpTrangThai);
            this.tabKetNoi.Controls.Add(this.grpCauHinh);
            this.tabKetNoi.Location = new Point(4, 25);
            this.tabKetNoi.Name = "tabKetNoi";
            this.tabKetNoi.Padding = new Padding(8);
            this.tabKetNoi.Size = new Size(912, 531);
            this.tabKetNoi.TabIndex = 0;
            this.tabKetNoi.Text = "1. Cấu hình Kết nối, Trạng thái SqlConnection & Backup/Restore (Bài 5, Câu 7, 8, 9, 10)";

            // grpCauHinh
            this.grpCauHinh.Controls.Add(this.lblChonConfig);
            this.grpCauHinh.Controls.Add(this.cboConfigName);
            this.grpCauHinh.Controls.Add(this.lblDataSource);
            this.grpCauHinh.Controls.Add(this.txtDataSource);
            this.grpCauHinh.Controls.Add(this.lblDatabase);
            this.grpCauHinh.Controls.Add(this.txtDatabase);
            this.grpCauHinh.Controls.Add(this.radWinAuth);
            this.grpCauHinh.Controls.Add(this.radSqlAuth);
            this.grpCauHinh.Controls.Add(this.lblUserId);
            this.grpCauHinh.Controls.Add(this.txtUserId);
            this.grpCauHinh.Controls.Add(this.lblPassword);
            this.grpCauHinh.Controls.Add(this.txtPassword);
            this.grpCauHinh.Controls.Add(this.lblConnStr);
            this.grpCauHinh.Controls.Add(this.txtConnectionString);
            this.grpCauHinh.Controls.Add(this.btnKiemTra);
            this.grpCauHinh.Controls.Add(this.btnTaoCSDL);
            this.grpCauHinh.Location = new Point(15, 10);
            this.grpCauHinh.Name = "grpCauHinh";
            this.grpCauHinh.Size = new Size(880, 222);
            this.grpCauHinh.TabIndex = 0;
            this.grpCauHinh.TabStop = false;
            this.grpCauHinh.Text = "Cấu hình Chuỗi kết nối (Đọc từ App.config qua ConfigurationManager & SQL Authentication)";

            this.lblChonConfig.AutoSize = true;
            this.lblChonConfig.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblChonConfig.Location = new Point(18, 28);
            this.lblChonConfig.Text = "Chọn từ App.config (Câu 8):";

            this.cboConfigName.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboConfigName.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.cboConfigName.Location = new Point(190, 24);
            this.cboConfigName.Size = new Size(340, 23);
            this.cboConfigName.SelectedIndexChanged += new System.EventHandler(this.cboConfigName_SelectedIndexChanged);

            this.lblDataSource.AutoSize = true;
            this.lblDataSource.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblDataSource.Location = new Point(18, 60);
            this.lblDataSource.Text = "Server / Instance:";

            this.txtDataSource.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtDataSource.Location = new Point(190, 56);
            this.txtDataSource.Size = new Size(210, 23);
            this.txtDataSource.Text = ".";
            this.txtDataSource.TextChanged += new System.EventHandler(this.InputConn_TextChanged);

            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblDatabase.Location = new Point(420, 60);
            this.lblDatabase.Text = "Database:";

            this.txtDatabase.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtDatabase.Location = new Point(495, 56);
            this.txtDatabase.Size = new Size(165, 23);
            this.txtDatabase.Text = "QLSinhVien";
            this.txtDatabase.TextChanged += new System.EventHandler(this.InputConn_TextChanged);

            this.radWinAuth.AutoSize = true;
            this.radWinAuth.Checked = true;
            this.radWinAuth.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.radWinAuth.Location = new Point(18, 92);
            this.radWinAuth.Text = "Windows Authentication";
            this.radWinAuth.CheckedChanged += new System.EventHandler(this.radAuth_CheckedChanged);

            this.radSqlAuth.AutoSize = true;
            this.radSqlAuth.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.radSqlAuth.Location = new Point(190, 92);
            this.radSqlAuth.Text = "SQL Server Authentication (Câu 7)";
            this.radSqlAuth.CheckedChanged += new System.EventHandler(this.radAuth_CheckedChanged);

            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblUserId.Location = new Point(420, 94);
            this.lblUserId.Text = "User ID:";

            this.txtUserId.Enabled = false;
            this.txtUserId.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtUserId.Location = new Point(475, 90);
            this.txtUserId.Size = new Size(140, 23);
            this.txtUserId.Text = "app_qlsinhvien";
            this.txtUserId.TextChanged += new System.EventHandler(this.InputConn_TextChanged);

            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblPassword.Location = new Point(630, 94);
            this.lblPassword.Text = "Password:";

            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtPassword.Location = new Point(700, 90);
            this.txtPassword.Size = new Size(155, 23);
            this.txtPassword.Text = "Eaut@2026!";
            this.txtPassword.TextChanged += new System.EventHandler(this.InputConn_TextChanged);

            this.lblConnStr.AutoSize = true;
            this.lblConnStr.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblConnStr.Location = new Point(18, 128);
            this.lblConnStr.Text = "ConnectionString:";

            this.txtConnectionString.BackColor = Color.FromArgb(240, 244, 248);
            this.txtConnectionString.Font = new Font("Consolas", 9.5F, FontStyle.Regular);
            this.txtConnectionString.Location = new Point(190, 125);
            this.txtConnectionString.Size = new Size(665, 23);

            this.btnKiemTra.BackColor = Color.FromArgb(25, 118, 210);
            this.btnKiemTra.FlatStyle = FlatStyle.Flat;
            this.btnKiemTra.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnKiemTra.ForeColor = Color.White;
            this.btnKiemTra.Location = new Point(190, 162);
            this.btnKiemTra.Size = new Size(250, 42);
            this.btnKiemTra.Text = "Kiểm tra kết nối (Bài 5)";
            this.btnKiemTra.UseVisualStyleBackColor = false;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);

            this.btnTaoCSDL.BackColor = Color.FromArgb(46, 125, 50);
            this.btnTaoCSDL.FlatStyle = FlatStyle.Flat;
            this.btnTaoCSDL.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnTaoCSDL.ForeColor = Color.White;
            this.btnTaoCSDL.Location = new Point(460, 162);
            this.btnTaoCSDL.Size = new Size(320, 42);
            this.btnTaoCSDL.Text = "Tạo CSDL & Dữ liệu mẫu (Lab07.sql)";
            this.btnTaoCSDL.UseVisualStyleBackColor = false;
            this.btnTaoCSDL.Click += new System.EventHandler(this.btnTaoCSDL_Click);

            // grpTrangThai (Câu 9)
            this.grpTrangThai.Controls.Add(this.lblTitleDS);
            this.grpTrangThai.Controls.Add(this.lblValDataSource);
            this.grpTrangThai.Controls.Add(this.lblTitleDB);
            this.grpTrangThai.Controls.Add(this.lblValDatabase);
            this.grpTrangThai.Controls.Add(this.lblTitleVer);
            this.grpTrangThai.Controls.Add(this.lblValServerVersion);
            this.grpTrangThai.Controls.Add(this.lblTitleState);
            this.grpTrangThai.Controls.Add(this.lblValState);
            this.grpTrangThai.Controls.Add(this.lblTitleTime);
            this.grpTrangThai.Controls.Add(this.lblValThoiGian);
            this.grpTrangThai.Controls.Add(this.lblValThongBao);
            this.grpTrangThai.Location = new Point(15, 242);
            this.grpTrangThai.Size = new Size(880, 178);
            this.grpTrangThai.TabIndex = 1;
            this.grpTrangThai.TabStop = false;
            this.grpTrangThai.Text = "Trang Trạng thái Kết nối SqlConnection (Câu 9: DataSource, Database, ServerVersion, State, Thời gian)";

            this.lblTitleDS.AutoSize = true;
            this.lblTitleDS.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblTitleDS.Location = new Point(22, 32);
            this.lblTitleDS.Text = "• Máy chủ (DataSource):";

            this.lblValDataSource.AutoSize = true;
            this.lblValDataSource.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValDataSource.Location = new Point(215, 32);
            this.lblValDataSource.Text = "(Chưa kiểm tra)";

            this.lblTitleDB.AutoSize = true;
            this.lblTitleDB.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblTitleDB.Location = new Point(470, 32);
            this.lblTitleDB.Text = "• Cơ sở dữ liệu (Database):";

            this.lblValDatabase.AutoSize = true;
            this.lblValDatabase.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValDatabase.ForeColor = Color.FromArgb(13, 71, 161);
            this.lblValDatabase.Location = new Point(660, 32);
            this.lblValDatabase.Text = "QLSinhVien";

            this.lblTitleVer.AutoSize = true;
            this.lblTitleVer.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblTitleVer.Location = new Point(22, 66);
            this.lblTitleVer.Text = "• Phiên bản (ServerVersion):";

            this.lblValServerVersion.AutoSize = true;
            this.lblValServerVersion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValServerVersion.Location = new Point(215, 66);
            this.lblValServerVersion.Text = "(Chưa kiểm tra)";

            this.lblTitleState.AutoSize = true;
            this.lblTitleState.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblTitleState.Location = new Point(470, 66);
            this.lblTitleState.Text = "• Trạng thái (State):";

            this.lblValState.AutoSize = true;
            this.lblValState.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValState.Location = new Point(660, 66);
            this.lblValState.Text = "Closed";

            this.lblTitleTime.AutoSize = true;
            this.lblTitleTime.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblTitleTime.Location = new Point(22, 100);
            this.lblTitleTime.Text = "• Thời gian mở kết nối:";

            this.lblValThoiGian.AutoSize = true;
            this.lblValThoiGian.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValThoiGian.ForeColor = Color.FromArgb(0, 105, 92);
            this.lblValThoiGian.Location = new Point(215, 100);
            this.lblValThoiGian.Text = "0 ms";

            this.lblValThongBao.AutoSize = false;
            this.lblValThongBao.BackColor = Color.FromArgb(227, 242, 253);
            this.lblValThongBao.BorderStyle = BorderStyle.FixedSingle;
            this.lblValThongBao.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblValThongBao.ForeColor = Color.FromArgb(13, 71, 161);
            this.lblValThongBao.Location = new Point(22, 132);
            this.lblValThongBao.Padding = new Padding(8, 0, 0, 0);
            this.lblValThongBao.Size = new Size(835, 32);
            this.lblValThongBao.Text = "Nhấn nút 'Kiểm tra kết nối (Bài 5)' để đo thời gian và kiểm tra trạng thái SqlConnection.";
            this.lblValThongBao.TextAlign = ContentAlignment.MiddleLeft;

            // grpBackupRestore (Câu 10)
            this.grpBackupRestore.Controls.Add(this.lblFileBak);
            this.grpBackupRestore.Controls.Add(this.txtDuongDanBak);
            this.grpBackupRestore.Controls.Add(this.btnBackup);
            this.grpBackupRestore.Controls.Add(this.btnRestore);
            this.grpBackupRestore.Location = new Point(15, 430);
            this.grpBackupRestore.Size = new Size(880, 85);
            this.grpBackupRestore.TabIndex = 2;
            this.grpBackupRestore.TabStop = false;
            this.grpBackupRestore.Text = "Sao lưu (Backup) và Phục hồi (Restore) Cơ sở dữ liệu QLSinhVien (Câu 10)";

            this.lblFileBak.AutoSize = true;
            this.lblFileBak.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblFileBak.Location = new Point(22, 36);
            this.lblFileBak.Text = "Đường dẫn tệp .bak:";

            this.txtDuongDanBak.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtDuongDanBak.Location = new Point(155, 32);
            this.txtDuongDanBak.Size = new Size(410, 23);

            this.btnBackup.BackColor = Color.FromArgb(0, 105, 92);
            this.btnBackup.FlatStyle = FlatStyle.Flat;
            this.btnBackup.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnBackup.ForeColor = Color.White;
            this.btnBackup.Location = new Point(580, 28);
            this.btnBackup.Size = new Size(135, 32);
            this.btnBackup.Text = "Backup (.bak)";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);

            this.btnRestore.BackColor = Color.FromArgb(230, 81, 0);
            this.btnRestore.FlatStyle = FlatStyle.Flat;
            this.btnRestore.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnRestore.ForeColor = Color.White;
            this.btnRestore.Location = new Point(725, 28);
            this.btnRestore.Size = new Size(135, 32);
            this.btnRestore.Text = "Restore (.bak)";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);

            // tabDuLieuSQL
            this.tabDuLieuSQL.BackColor = Color.FromArgb(248, 249, 250);
            this.tabDuLieuSQL.Controls.Add(this.lblNguonDuLieu);
            this.tabDuLieuSQL.Controls.Add(this.dgvSinhVien);
            this.tabDuLieuSQL.Controls.Add(this.grpNhapSV);
            this.tabDuLieuSQL.Location = new Point(4, 25);
            this.tabDuLieuSQL.Name = "tabDuLieuSQL";
            this.tabDuLieuSQL.Padding = new Padding(8);
            this.tabDuLieuSQL.Size = new Size(912, 531);
            this.tabDuLieuSQL.TabIndex = 1;
            this.tabDuLieuSQL.Text = "2. Dữ liệu Bảng Khoa - SinhVien & Kiểm thử Ràng buộc PK, FK, CHECK, UNIQUE (Bài 2, 3, 4 & Câu 6)";

            // grpNhapSV
            this.grpNhapSV.Controls.Add(this.lblMaSV);
            this.grpNhapSV.Controls.Add(this.txtMaSV);
            this.grpNhapSV.Controls.Add(this.lblHoTen);
            this.grpNhapSV.Controls.Add(this.txtHoTen);
            this.grpNhapSV.Controls.Add(this.lblNgaySinh);
            this.grpNhapSV.Controls.Add(this.dtpNgaySinh);
            this.grpNhapSV.Controls.Add(this.radNam);
            this.grpNhapSV.Controls.Add(this.radNu);
            this.grpNhapSV.Controls.Add(this.lblKhoa);
            this.grpNhapSV.Controls.Add(this.cboKhoa);
            this.grpNhapSV.Controls.Add(this.lblDiemTB);
            this.grpNhapSV.Controls.Add(this.txtDiemTB);
            this.grpNhapSV.Controls.Add(this.lblEmail);
            this.grpNhapSV.Controls.Add(this.txtEmail);
            this.grpNhapSV.Controls.Add(this.btnThemSV);
            this.grpNhapSV.Controls.Add(this.btnXoaSV);
            this.grpNhapSV.Controls.Add(this.btnThuViPhamEmail);
            this.grpNhapSV.Controls.Add(this.btnThuViPhamDiem);
            this.grpNhapSV.Location = new Point(15, 10);
            this.grpNhapSV.Size = new Size(880, 130);
            this.grpNhapSV.TabIndex = 0;
            this.grpNhapSV.TabStop = false;
            this.grpNhapSV.Text = "Nhập Sinh viên & Thử nghiệm Ràng buộc Dữ liệu (Câu 6: UNIQUE Email, CHECK Điểm [0..10])";

            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblMaSV.Location = new Point(15, 28);
            this.lblMaSV.Text = "Mã SV:";

            this.txtMaSV.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtMaSV.Location = new Point(68, 24);
            this.txtMaSV.Size = new Size(85, 23);
            this.txtMaSV.Text = "SV011";

            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblHoTen.Location = new Point(165, 28);
            this.lblHoTen.Text = "Họ tên:";

            this.txtHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtHoTen.Location = new Point(218, 24);
            this.txtHoTen.Size = new Size(175, 23);
            this.txtHoTen.Text = "Trịnh Quốc Khánh";

            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblNgaySinh.Location = new Point(408, 28);
            this.lblNgaySinh.Text = "Ngày sinh:";

            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new Point(478, 24);
            this.dtpNgaySinh.Size = new Size(110, 23);

            this.radNam.AutoSize = true;
            this.radNam.Checked = true;
            this.radNam.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.radNam.Location = new Point(605, 26);
            this.radNam.Text = "Nam";

            this.radNu.AutoSize = true;
            this.radNu.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.radNu.Location = new Point(665, 26);
            this.radNu.Text = "Nữ";

            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblKhoa.Location = new Point(15, 60);
            this.lblKhoa.Text = "Khoa:";

            this.cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKhoa.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.cboKhoa.Location = new Point(68, 56);
            this.cboKhoa.Size = new Size(195, 23);

            this.lblDiemTB.AutoSize = true;
            this.lblDiemTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblDiemTB.Location = new Point(275, 60);
            this.lblDiemTB.Text = "Điểm TB:";

            this.txtDiemTB.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtDiemTB.Location = new Point(338, 56);
            this.txtDiemTB.Size = new Size(65, 23);
            this.txtDiemTB.Text = "8.0";

            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.lblEmail.Location = new Point(418, 60);
            this.lblEmail.Text = "Email:";

            this.txtEmail.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.txtEmail.Location = new Point(465, 56);
            this.txtEmail.Size = new Size(235, 23);
            this.txtEmail.Text = "khanh.tq@eaut.edu.vn";

            this.btnThemSV.BackColor = Color.FromArgb(46, 125, 50);
            this.btnThemSV.FlatStyle = FlatStyle.Flat;
            this.btnThemSV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnThemSV.ForeColor = Color.White;
            this.btnThemSV.Location = new Point(15, 90);
            this.btnThemSV.Size = new Size(130, 30);
            this.btnThemSV.Text = "+ Thêm Sinh Viên";
            this.btnThemSV.UseVisualStyleBackColor = false;
            this.btnThemSV.Click += new System.EventHandler(this.btnThemSV_Click);

            this.btnXoaSV.BackColor = Color.FromArgb(211, 47, 47);
            this.btnXoaSV.FlatStyle = FlatStyle.Flat;
            this.btnXoaSV.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnXoaSV.ForeColor = Color.White;
            this.btnXoaSV.Location = new Point(155, 90);
            this.btnXoaSV.Size = new Size(135, 30);
            this.btnXoaSV.Text = "Xóa SV đang chọn";
            this.btnXoaSV.UseVisualStyleBackColor = false;
            this.btnXoaSV.Click += new System.EventHandler(this.btnXoaSV_Click);

            this.btnThuViPhamEmail.BackColor = Color.FromArgb(230, 81, 0);
            this.btnThuViPhamEmail.FlatStyle = FlatStyle.Flat;
            this.btnThuViPhamEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnThuViPhamEmail.ForeColor = Color.White;
            this.btnThuViPhamEmail.Location = new Point(340, 90);
            this.btnThuViPhamEmail.Size = new Size(255, 30);
            this.btnThuViPhamEmail.Text = "Thử Vi phạm UNIQUE Email (Câu 6)";
            this.btnThuViPhamEmail.UseVisualStyleBackColor = false;
            this.btnThuViPhamEmail.Click += new System.EventHandler(this.btnThuViPhamEmail_Click);

            this.btnThuViPhamDiem.BackColor = Color.FromArgb(106, 27, 154);
            this.btnThuViPhamDiem.FlatStyle = FlatStyle.Flat;
            this.btnThuViPhamDiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnThuViPhamDiem.ForeColor = Color.White;
            this.btnThuViPhamDiem.Location = new Point(605, 90);
            this.btnThuViPhamDiem.Size = new Size(255, 30);
            this.btnThuViPhamDiem.Text = "Thử Vi phạm CHECK Điểm > 10 (Câu 6)";
            this.btnThuViPhamDiem.UseVisualStyleBackColor = false;
            this.btnThuViPhamDiem.Click += new System.EventHandler(this.btnThuViPhamDiem_Click);

            // dgvSinhVien
            this.dgvSinhVien.BackgroundColor = Color.White;
            this.dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSinhVien.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            this.dgvSinhVien.Location = new Point(15, 148);
            this.dgvSinhVien.Name = "dgvSinhVien";
            this.dgvSinhVien.RowHeadersVisible = false;
            this.dgvSinhVien.Size = new Size(880, 335);

            // lblNguonDuLieu
            this.lblNguonDuLieu.AutoSize = false;
            this.lblNguonDuLieu.BackColor = Color.FromArgb(227, 242, 253);
            this.lblNguonDuLieu.BorderStyle = BorderStyle.FixedSingle;
            this.lblNguonDuLieu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblNguonDuLieu.ForeColor = Color.FromArgb(13, 71, 161);
            this.lblNguonDuLieu.Location = new Point(15, 490);
            this.lblNguonDuLieu.Padding = new Padding(8, 0, 0, 0);
            this.lblNguonDuLieu.Size = new Size(880, 30);
            this.lblNguonDuLieu.TextAlign = ContentAlignment.MiddleLeft;

            // frmMain
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 247, 250);
            this.ClientSize = new Size(944, 614);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.lblTieuDe);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Lab07_ADONET_Connection - Thiết kế CSDL QLSinhVien & Kết nối SQL Server ADO.NET";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabMain.ResumeLayout(false);
            this.tabKetNoi.ResumeLayout(false);
            this.grpCauHinh.ResumeLayout(false);
            this.grpCauHinh.PerformLayout();
            this.grpTrangThai.ResumeLayout(false);
            this.grpTrangThai.PerformLayout();
            this.grpBackupRestore.ResumeLayout(false);
            this.grpBackupRestore.PerformLayout();
            this.tabDuLieuSQL.ResumeLayout(false);
            this.grpNhapSV.ResumeLayout(false);
            this.grpNhapSV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSinhVien)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
