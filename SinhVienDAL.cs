using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Lab07_ADONET_Connection.Models;

namespace Lab07_ADONET_Connection.DAL
{
    public class SinhVienDAL
    {
        // Dữ liệu dự phòng khớp 100% với kịch bản Lab07_QLSinhVien.sql (3 Khoa, 10 Sinh viên, 5 Học phần)
        private readonly List<Khoa> _fallbackKhoa = new List<Khoa>
        {
            new Khoa("CNTT", "Công nghệ thông tin"),
            new Khoa("OTO", "Công nghệ kỹ thuật ô tô"),
            new Khoa("KT", "Kinh tế")
        };

        private readonly List<SinhVien> _fallbackSinhVien = new List<SinhVien>
        {
            new SinhVien("SV001", "Nguyễn Văn An",   new DateTime(2005, 2, 15), true,  "CNTT", 8.20m, "an@eaut.edu.vn",      "Công nghệ thông tin"),
            new SinhVien("SV002", "Trần Thị Bình",   new DateTime(2005, 7, 21), false, "CNTT", 7.40m, "binh@eaut.edu.vn",    "Công nghệ thông tin"),
            new SinhVien("SV003", "Lê Văn Cường",    new DateTime(2004, 12, 3), true,  "OTO",  6.80m, "",                    "Công nghệ kỹ thuật ô tô"),
            new SinhVien("SV004", "Phạm Thu Hà",     new DateTime(2005, 11, 2), false, "CNTT", 9.10m, "ha.pt@eaut.edu.vn",   "Công nghệ thông tin"),
            new SinhVien("SV005", "Đỗ Minh Tuấn",    new DateTime(2005, 3, 19), true,  "CNTT", 7.85m, "tuan.dm@eaut.edu.vn", "Công nghệ thông tin"),
            new SinhVien("SV006", "Vũ Quốc Bảo",     new DateTime(2004, 8, 25), true,  "OTO",  8.00m, "bao.vq@eaut.edu.vn",  "Công nghệ kỹ thuật ô tô"),
            new SinhVien("SV007", "Đặng Tiến Dũng",  new DateTime(2005, 1, 18), true,  "OTO",  5.50m, "dung.dt@eaut.edu.vn", "Công nghệ kỹ thuật ô tô"),
            new SinhVien("SV008", "Hoàng Bích Ngọc", new DateTime(2005, 9, 10), false, "KT",   8.60m, "ngoc.hb@eaut.edu.vn", "Kinh tế"),
            new SinhVien("SV009", "Ngô Thanh Tâm",   new DateTime(2005, 4, 5),  false, "KT",   7.20m, "tam.nt@eaut.edu.vn",  "Kinh tế"),
            new SinhVien("SV010", "Bùi Khánh Linh",  new DateTime(2005, 12, 22),false, "KT",   6.40m, "linh.bk@eaut.edu.vn", "Kinh tế")
        };

        public bool IsUsingSqlDatabase { get; private set; }

        public List<Khoa> GetAllKhoa()
        {
            try
            {
                List<Khoa> list = new List<Khoa>();
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    string sql = "SELECT MaKhoa, TenKhoa FROM Khoa ORDER BY MaKhoa";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Khoa(
                                reader["MaKhoa"].ToString(),
                                reader["TenKhoa"].ToString()));
                        }
                    }
                }
                IsUsingSqlDatabase = true;
                return list;
            }
            catch
            {
                IsUsingSqlDatabase = false;
                return new List<Khoa>(_fallbackKhoa);
            }
        }

        public List<SinhVien> GetAllSinhVien()
        {
            try
            {
                List<SinhVien> list = new List<SinhVien>();
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    string sql = @"
                        SELECT sv.MaSV, sv.HoTen, sv.NgaySinh, sv.GioiTinh, sv.MaKhoa, k.TenKhoa, sv.DiemTB, sv.Email
                        FROM SinhVien sv
                        INNER JOIN Khoa k ON sv.MaKhoa = k.MaKhoa
                        ORDER BY sv.MaSV";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString();
                            list.Add(new SinhVien(
                                reader["MaSV"].ToString(),
                                reader["HoTen"].ToString(),
                                Convert.ToDateTime(reader["NgaySinh"]),
                                Convert.ToBoolean(reader["GioiTinh"]),
                                reader["MaKhoa"].ToString(),
                                Convert.ToDecimal(reader["DiemTB"]),
                                email,
                                reader["TenKhoa"].ToString()));
                        }
                    }
                }
                IsUsingSqlDatabase = true;
                return list;
            }
            catch
            {
                IsUsingSqlDatabase = false;
                return new List<SinhVien>(_fallbackSinhVien);
            }
        }

        public void Add(SinhVien sv)
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    string sql = @"
                        INSERT INTO SinhVien(MaSV, HoTen, NgaySinh, GioiTinh, MaKhoa, DiemTB, Email)
                        VALUES (@MaSV, @HoTen, @NgaySinh, @GioiTinh, @MaKhoa, @DiemTB, @Email)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", sv.MaSV);
                        cmd.Parameters.AddWithValue("@HoTen", sv.HoTen);
                        cmd.Parameters.AddWithValue("@NgaySinh", sv.NgaySinh.Date);
                        cmd.Parameters.AddWithValue("@GioiTinh", sv.GioiTinh);
                        cmd.Parameters.AddWithValue("@MaKhoa", sv.MaKhoa);
                        cmd.Parameters.AddWithValue("@DiemTB", sv.DiemTB);
                        if (string.IsNullOrWhiteSpace(sv.Email))
                            cmd.Parameters.AddWithValue("@Email", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@Email", sv.Email.Trim());

                        cmd.ExecuteNonQuery();
                    }
                }
                IsUsingSqlDatabase = true;
            }
            catch (SqlException)
            {
                throw; // Ném lỗi ràng buộc SQL (PK, FK, CHECK, UNIQUE Email) lên tầng trên để hiển thị
            }
            catch
            {
                // Nếu chưa bật SQL Server thì lưu vào bộ nhớ tạm để người dùng vẫn thử nghiệm được
                if (_fallbackSinhVien.Any(x => string.Equals(x.MaSV, sv.MaSV, StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException("Vi phạm PRIMARY KEY: Mã sinh viên '" + sv.MaSV + "' đã tồn tại!");
                if (!string.IsNullOrWhiteSpace(sv.Email) &&
                    _fallbackSinhVien.Any(x => string.Equals(x.Email, sv.Email.Trim(), StringComparison.OrdinalIgnoreCase)))
                    throw new InvalidOperationException("Vi phạm UNIQUE Email (Câu 6): Email '" + sv.Email + "' đã được sử dụng!");
                if (sv.DiemTB < 0 || sv.DiemTB > 10)
                    throw new InvalidOperationException("Vi phạm CHECK CK_SinhVien_Diem: Điểm TB phải thuộc đoạn [0, 10]!");

                Khoa k = _fallbackKhoa.FirstOrDefault(x => x.MaKhoa == sv.MaKhoa);
                sv.TenKhoa = k != null ? k.TenKhoa : sv.MaKhoa;
                _fallbackSinhVien.Add(sv);
            }
        }

        public void Delete(string maSV)
        {
            try
            {
                using (SqlConnection conn = DbConnectionFactory.Create())
                {
                    conn.Open();
                    using (SqlCommand cmdDelDK = new SqlCommand("DELETE FROM DangKy WHERE MaSV = @MaSV", conn))
                    {
                        cmdDelDK.Parameters.AddWithValue("@MaSV", maSV);
                        cmdDelDK.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM SinhVien WHERE MaSV = @MaSV", conn))
                    {
                        cmd.Parameters.AddWithValue("@MaSV", maSV);
                        cmd.ExecuteNonQuery();
                    }
                }
                IsUsingSqlDatabase = true;
            }
            catch (SqlException)
            {
                throw;
            }
            catch
            {
                _fallbackSinhVien.RemoveAll(x => string.Equals(x.MaSV, maSV, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}
