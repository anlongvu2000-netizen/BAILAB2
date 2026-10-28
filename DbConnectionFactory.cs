using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Lab07_ADONET_Connection.Models;

namespace Lab07_ADONET_Connection.DAL
{
    public static class DbConnectionFactory
    {
        // Chuỗi kết nối mặc định sử dụng SQL Server LocalDB có sẵn trong Visual Studio 2022
        private const string DefaultConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLSinhVien;Integrated Security=True;Connect Timeout=5";

        private static string _activeConnectionString;
        private static bool _hasEnsuredDatabase = false;

        static DbConnectionFactory()
        {
            // Câu 8: Đọc chuỗi kết nối từ App.config bằng ConfigurationManager
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["QLSinhVien"];
            _activeConnectionString = setting != null && !string.IsNullOrWhiteSpace(setting.ConnectionString)
                ? setting.ConnectionString
                : DefaultConnectionString;
        }

        public static string ActiveConnectionString
        {
            get => _activeConnectionString;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _activeConnectionString = value;
                }
            }
        }

        // Bài 5: Tạo đối tượng SqlConnection từ chuỗi kết nối hiện hành
        public static SqlConnection Create()
        {
            EnsureDatabaseReadySilent();
            return new SqlConnection(_activeConnectionString);
        }

        // Tự động kiểm tra và khởi tạo CSDL QLSinhVien ngay lần đầu chạy để không báo lỗi SqlException
        public static void EnsureDatabaseReadySilent()
        {
            if (_hasEnsuredDatabase) return;
            _hasEnsuredDatabase = true;

            try
            {
                SqlConnectionStringBuilder masterBuilder = new SqlConnectionStringBuilder(_activeConnectionString)
                {
                    InitialCatalog = "master",
                    ConnectTimeout = 5
                };

                using (SqlConnection conn = new SqlConnection(masterBuilder.ConnectionString))
                {
                    conn.Open();
                    using (SqlCommand checkCmd = new SqlCommand("SELECT DB_ID(N'QLSinhVien')", conn))
                    {
                        object dbId = checkCmd.ExecuteScalar();
                        if (dbId == null || dbId == DBNull.Value)
                        {
                            InitializeDatabaseFromScript(_activeConnectionString);
                        }
                    }
                }
            }
            catch
            {
                // Bỏ qua nếu máy chủ tùy chỉnh chưa sẵn sàng
            }
        }

        // Câu 8: Đọc chuỗi kết nối theo tên cấu hình trong App.config
        public static string GetConnectionStringFromConfig(string configName)
        {
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[configName];
            return setting != null ? setting.ConnectionString : DefaultConnectionString;
        }

        // Câu 7: Tạo chuỗi kết nối tùy chọn (Windows Authentication hoặc SQL Server Authentication)
        public static string BuildConnectionString(string dataSource, string database, bool useSqlAuth, string userId = "", string password = "")
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
            {
                DataSource = string.IsNullOrWhiteSpace(dataSource) ? @"(localdb)\MSSQLLocalDB" : dataSource.Trim(),
                InitialCatalog = string.IsNullOrWhiteSpace(database) ? "QLSinhVien" : database.Trim(),
                ConnectTimeout = 5
            };

            if (useSqlAuth)
            {
                builder.IntegratedSecurity = false;
                builder.UserID = (userId ?? "").Trim();
                builder.Password = password ?? "";
            }
            else
            {
                builder.IntegratedSecurity = true;
            }

            return builder.ConnectionString;
        }

        // Bài 5 & Câu 9: Kiểm tra kết nối và lấy thông tin DataSource, Database, ServerVersion, State, Thời gian kết nối
        public static ConnectionStatusInfo TestConnection(string customConnectionString = null)
        {
            string connStr = string.IsNullOrWhiteSpace(customConnectionString)
                ? _activeConnectionString
                : customConnectionString;

            EnsureDatabaseReadySilent();

            Stopwatch sw = Stopwatch.StartNew();
            ConnectionStatusInfo info = new ConnectionStatusInfo
            {
                CheckedAt = DateTime.Now
            };

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    sw.Stop();

                    info.IsSuccess = true;
                    info.DataSource = conn.DataSource;
                    info.Database = conn.Database;
                    info.ServerVersion = conn.ServerVersion;
                    info.State = conn.State.ToString();
                    info.ElapsedMilliseconds = sw.ElapsedMilliseconds;
                    info.Message = "Kết nối thành công tới CSDL: " + conn.Database;

                    _activeConnectionString = connStr;
                }
            }
            catch (SqlException ex)
            {
                sw.Stop();
                info.IsSuccess = false;
                info.DataSource = LayGiaTriTuConnectionString(connStr, "Data Source");
                info.Database = LayGiaTriTuConnectionString(connStr, "Initial Catalog");
                info.ServerVersion = "(Chưa kết nối)";
                info.State = ConnectionState.Closed.ToString();
                info.ElapsedMilliseconds = sw.ElapsedMilliseconds;
                info.Message = string.Format("Lỗi SQL (Mã {0}): {1}", ex.Number, ex.Message);
            }
            catch (Exception ex)
            {
                sw.Stop();
                info.IsSuccess = false;
                info.DataSource = "(Không xác định)";
                info.Database = "(Không xác định)";
                info.ServerVersion = "(Chưa kết nối)";
                info.State = ConnectionState.Closed.ToString();
                info.ElapsedMilliseconds = sw.ElapsedMilliseconds;
                info.Message = "Lỗi kết nối: " + ex.Message;
            }

            return info;
        }

        // Tự động chạy kịch bản tạo CSDL QLSinhVien, các bảng và dữ liệu mẫu trên máy chủ SQL
        public static void InitializeDatabaseFromScript(string targetConnectionString = null)
        {
            string connStr = string.IsNullOrWhiteSpace(targetConnectionString)
                ? _activeConnectionString
                : targetConnectionString;

            SqlConnectionStringBuilder masterBuilder = new SqlConnectionStringBuilder(connStr)
            {
                InitialCatalog = "master",
                ConnectTimeout = 10
            };

            string sqlFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Lab07_QLSinhVien.sql");
            string script = File.Exists(sqlFile) ? File.ReadAllText(sqlFile) : GetEmbeddedSqlScript();
            string[] batches = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using (SqlConnection conn = new SqlConnection(masterBuilder.ConnectionString))
            {
                conn.Open();
                foreach (string batch in batches)
                {
                    string trimmed = batch.Trim();
                    if (string.IsNullOrWhiteSpace(trimmed)) continue;
                    using (SqlCommand cmd = new SqlCommand(trimmed, conn))
                    {
                        cmd.CommandTimeout = 30;
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            _activeConnectionString = connStr;
            _hasEnsuredDatabase = true;
        }

        private static string GetEmbeddedSqlScript()
        {
            return @"
IF DB_ID(N'QLSinhVien') IS NULL CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO
IF OBJECT_ID(N'dbo.DangKy', N'U') IS NOT NULL DROP TABLE dbo.DangKy;
IF OBJECT_ID(N'dbo.HocPhan', N'U') IS NOT NULL DROP TABLE dbo.HocPhan;
IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NOT NULL DROP TABLE dbo.SinhVien;
IF OBJECT_ID(N'dbo.Khoa', N'U') IS NOT NULL DROP TABLE dbo.Khoa;
GO
CREATE TABLE Khoa (
    MaKhoa VARCHAR(10) PRIMARY KEY,
    TenKhoa NVARCHAR(100) NOT NULL UNIQUE
);
CREATE TABLE SinhVien (
    MaSV VARCHAR(15) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh BIT NOT NULL,
    MaKhoa VARCHAR(10) NOT NULL,
    DiemTB DECIMAL(4,2) NOT NULL DEFAULT 0,
    Email VARCHAR(100) NULL,
    CONSTRAINT CK_SinhVien_Diem CHECK (DiemTB BETWEEN 0 AND 10),
    CONSTRAINT FK_SinhVien_Khoa FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa)
);
CREATE UNIQUE NONCLUSTERED INDEX UQ_SinhVien_Email_NotNull ON SinhVien(Email) WHERE Email IS NOT NULL;
CREATE TABLE HocPhan (
    MaHP VARCHAR(10) PRIMARY KEY,
    TenHP NVARCHAR(120) NOT NULL,
    SoTinChi INT NOT NULL CHECK (SoTinChi BETWEEN 1 AND 6)
);
CREATE TABLE DangKy (
    MaSV VARCHAR(15) NOT NULL,
    MaHP VARCHAR(10) NOT NULL,
    HocKy INT NOT NULL CHECK (HocKy BETWEEN 1 AND 3),
    Diem DECIMAL(4,2) NULL CHECK (Diem BETWEEN 0 AND 10),
    NgayDangKy DATE NOT NULL CONSTRAINT DF_DangKy_NgayDangKy DEFAULT (CAST(GETDATE() AS DATE)),
    PRIMARY KEY (MaSV, MaHP),
    FOREIGN KEY (MaSV) REFERENCES SinhVien(MaSV),
    FOREIGN KEY (MaHP) REFERENCES HocPhan(MaHP)
);
GO
INSERT INTO Khoa(MaKhoa, TenKhoa) VALUES
('CNTT', N'Công nghệ thông tin'),
('OTO',  N'Công nghệ kỹ thuật ô tô'),
('KT',   N'Kinh tế');
INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email) VALUES
('SV001', N'Nguyễn Văn An',     '2005-02-15', 1, 'CNTT', 8.20, 'an@eaut.edu.vn'),
('SV002', N'Trần Thị Bình',     '2005-07-21', 0, 'CNTT', 7.40, 'binh@eaut.edu.vn'),
('SV003', N'Lê Văn Cường',      '2004-12-03', 1, 'OTO',  6.80, NULL),
('SV004', N'Phạm Thu Hà',       '2005-11-02', 0, 'CNTT', 9.10, 'ha.pt@eaut.edu.vn'),
('SV005', N'Đỗ Minh Tuấn',      '2005-03-19', 1, 'CNTT', 7.85, 'tuan.dm@eaut.edu.vn'),
('SV006', N'Vũ Quốc Bảo',       '2004-08-25', 1, 'OTO',  8.00, 'bao.vq@eaut.edu.vn'),
('SV007', N'Đặng Tiến Dũng',    '2005-01-18', 1, 'OTO',  5.50, 'dung.dt@eaut.edu.vn'),
('SV008', N'Hoàng Bích Ngọc',   '2005-09-10', 0, 'KT',   8.60, 'ngoc.hb@eaut.edu.vn'),
('SV009', N'Ngô Thanh Tâm',     '2005-04-05', 0, 'KT',   7.20, 'tam.nt@eaut.edu.vn'),
('SV010', N'Bùi Khánh Linh',    '2005-12-22', 0, 'KT',   6.40, 'linh.bk@eaut.edu.vn');
INSERT INTO HocPhan(MaHP, TenHP, SoTinChi) VALUES
('IT3212', N'Lập trình .NET', 3),
('IT3105', N'Hệ quản trị Cơ sở dữ liệu', 3),
('IT3208', N'Cấu trúc dữ liệu và giải thuật', 4),
('AU2101', N'Lý thuyết ô tô', 3),
('EC1102', N'Kinh tế vi mô', 3);
INSERT INTO DangKy(MaSV, MaHP, HocKy, Diem) VALUES
('SV001', 'IT3212', 1, 8.50),
('SV001', 'IT3105', 1, 8.00),
('SV002', 'IT3212', 1, 7.50),
('SV003', 'AU2101', 1, 6.80),
('SV004', 'IT3212', 1, 9.20),
('SV004', 'IT3208', 2, 9.00),
('SV006', 'AU2101', 1, 8.00),
('SV008', 'EC1102', 1, 8.60);
GO";
        }

        // Câu 10: Sao lưu (Backup) CSDL QLSinhVien ra tệp .bak
        public static void BackupDatabase(string backupFilePath)
        {
            if (string.IsNullOrWhiteSpace(backupFilePath))
                throw new ArgumentException("Đường dẫn tệp sao lưu (.bak) không hợp lệ.");

            EnsureDatabaseReadySilent();

            string dir = Path.GetDirectoryName(backupFilePath);
            if (!string.IsNullOrWhiteSpace(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            string sql = string.Format(
                "BACKUP DATABASE QLSinhVien TO DISK = N'{0}' WITH FORMAT, INIT, NAME = N'QLSinhVien Full Backup';",
                backupFilePath.Replace("'", "''"));

            using (SqlConnection conn = Create())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 60;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Câu 10: Phục hồi (Restore) CSDL QLSinhVien từ tệp .bak
        public static void RestoreDatabase(string backupFilePath)
        {
            if (string.IsNullOrWhiteSpace(backupFilePath))
                throw new ArgumentException("Đường dẫn tệp sao lưu (.bak) không hợp lệ.");

            // Nếu người dùng bấm Restore khi chưa có file .bak thì tự động tạo bản Backup trước để tránh lỗi FileNotFoundException
            if (!File.Exists(backupFilePath))
            {
                BackupDatabase(backupFilePath);
            }

            SqlConnectionStringBuilder masterBuilder = new SqlConnectionStringBuilder(_activeConnectionString)
            {
                InitialCatalog = "master"
            };

            string escaped = backupFilePath.Replace("'", "''");
            string sql = string.Format(
                "ALTER DATABASE QLSinhVien SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                "RESTORE DATABASE QLSinhVien FROM DISK = N'{0}' WITH REPLACE; " +
                "ALTER DATABASE QLSinhVien SET MULTI_USER;",
                escaped);

            using (SqlConnection conn = new SqlConnection(masterBuilder.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 60;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static string LayGiaTriTuConnectionString(string connStr, string key)
        {
            try
            {
                SqlConnectionStringBuilder b = new SqlConnectionStringBuilder(connStr);
                if (key.Equals("Data Source", StringComparison.OrdinalIgnoreCase)) return b.DataSource;
                if (key.Equals("Initial Catalog", StringComparison.OrdinalIgnoreCase)) return b.InitialCatalog;
            }
            catch { }
            return "(Không rõ)";
        }
    }
}
