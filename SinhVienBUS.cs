using System;
using System.Collections.Generic;
using Lab07_ADONET_Connection.DAL;
using Lab07_ADONET_Connection.Models;

namespace Lab07_ADONET_Connection.BUS
{
    public class SinhVienBUS
    {
        private readonly SinhVienDAL _dal = new SinhVienDAL();

        public bool IsUsingSqlDatabase => _dal.IsUsingSqlDatabase;

        public List<Khoa> GetAllKhoa()
        {
            return _dal.GetAllKhoa();
        }

        public List<SinhVien> GetAllSinhVien()
        {
            return _dal.GetAllSinhVien();
        }

        public void Add(SinhVien sv)
        {
            if (sv == null)
                throw new ArgumentNullException(nameof(sv));
            if (string.IsNullOrWhiteSpace(sv.MaSV))
                throw new ArgumentException("Mã sinh viên không được để trống.");
            if (string.IsNullOrWhiteSpace(sv.HoTen))
                throw new ArgumentException("Họ tên sinh viên không được để trống.");

            _dal.Add(sv);
        }

        public void Delete(string maSV)
        {
            if (string.IsNullOrWhiteSpace(maSV))
                throw new ArgumentException("Vui lòng chọn mã sinh viên cần xóa.");
            _dal.Delete(maSV);
        }
    }
}
