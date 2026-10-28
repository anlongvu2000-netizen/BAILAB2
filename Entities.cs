using System;

namespace Lab07_ADONET_Connection.Models
{
    public class Khoa
    {
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }

        public Khoa() { }

        public Khoa(string maKhoa, string tenKhoa)
        {
            MaKhoa = maKhoa;
            TenKhoa = tenKhoa;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1}", MaKhoa, TenKhoa);
        }
    }

    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; } // true (1): Nam, false (0): Nữ
        public string MaKhoa { get; set; }
        public string TenKhoa { get; set; }
        public decimal DiemTB { get; set; }
        public string Email { get; set; }

        public string GioiTinhText => GioiTinh ? "Nam" : "Nữ";

        public SinhVien()
        {
            NgaySinh = new DateTime(2005, 1, 1);
            GioiTinh = true;
            MaKhoa = "CNTT";
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string maKhoa, decimal diemTB, string email, string tenKhoa = "")
        {
            MaSV = maSV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            MaKhoa = maKhoa;
            DiemTB = diemTB;
            Email = email;
            TenKhoa = tenKhoa;
        }
    }

    public class HocPhan
    {
        public string MaHP { get; set; }
        public string TenHP { get; set; }
        public int SoTinChi { get; set; }

        public HocPhan() { }

        public HocPhan(string maHP, string tenHP, int soTinChi)
        {
            MaHP = maHP;
            TenHP = tenHP;
            SoTinChi = soTinChi;
        }
    }

    public class ConnectionStatusInfo
    {
        public bool IsSuccess { get; set; }
        public string DataSource { get; set; }
        public string Database { get; set; }
        public string ServerVersion { get; set; }
        public string State { get; set; }
        public long ElapsedMilliseconds { get; set; }
        public DateTime CheckedAt { get; set; }
        public string Message { get; set; }
    }
}
