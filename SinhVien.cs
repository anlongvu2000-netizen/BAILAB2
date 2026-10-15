using System;

// === MỤC 1: KHAI BÁO LỚP SINH VIÊN ===
public class SinhVien 
{ 
    // Các thuộc tính cơ bản của Mục 1
    public string MaSV { get; set; } = string.Empty; 
    public DateTime NgaySinh { get; set; } 

    // === MỤC 3: ĐÓNG GÓI VÀ KIỂM TRA DỮ LIỆU ===
    // Dùng trường private làm backing field
    private string _hoTen = string.Empty; 
    private double _diemTB; 
    
    // Kiểm tra không cho phép Họ tên rỗng
    public string HoTen 
    { 
        get { return _hoTen; } 
        set 
        { 
            if (string.IsNullOrWhiteSpace(value)) 
                throw new ArgumentException("Họ tên không được rỗng."); 
            _hoTen = value.Trim(); 
        } 
    } 
    
    // Kiểm tra không cho phép Điểm TB ngoài khoảng [0,10]
    public double DiemTB 
    { 
        get { return _diemTB; } 
        set 
        { 
            if (value < 0 || value > 10) 
                throw new ArgumentOutOfRangeException("DiemTB", "Điểm TB phải nằm trong khoảng từ 0 đến 10."); 
            _diemTB = value; 
        } 
    }

    // === MỤC 2: CONSTRUCTOR VÀ NẠP CHỒNG ===
    // Constructor không tham số
    public SinhVien() 
    { 
        MaSV = "Chưa có"; 
        HoTen = "Chưa có"; 
        NgaySinh = DateTime.Today; 
        DiemTB = 0; 
    } 
    
    // Constructor đầy đủ tham số
    public SinhVien(string maSV, string hoTen, DateTime ngaySinh, double diemTB) 
    { 
        MaSV = maSV; 
        HoTen = hoTen; 
        NgaySinh = ngaySinh; 
        DiemTB = diemTB; 
    } 

    // === MỤC 4: PHƯƠNG THỨC NGHIỆP VỤ ===
    // Trả về tuổi của sinh viên
    public int TinhTuoi() 
    { 
        int tuoi = DateTime.Today.Year - NgaySinh.Year; 
        if (NgaySinh.Date > DateTime.Today.AddYears(-tuoi)) tuoi--; 
        return tuoi; 
    }

    // Trả về kết quả xếp loại
    public string XepLoai() 
    { 
        if (DiemTB >= 9) return "Xuất sắc";
        if (DiemTB >= 8) return "Giỏi"; 
        if (DiemTB >= 6.5) return "Khá"; 
        if (DiemTB >= 5) return "Trung bình"; 
        return "Yếu"; 
    } 

    // Phương thức của Mục 1 (được cập nhật để in thêm Tuổi và Xếp loại của Mục 4)
    public void HienThi() 
    { 
        Console.WriteLine("Mã: {0} | Tên: {1} | NS: {2:dd/MM/yyyy} | Điểm: {3:N2} | Tuổi: {4} | Xếp loại: {5}", 
            MaSV, HoTen, NgaySinh, DiemTB, TinhTuoi(), XepLoai()); 
    } 
}