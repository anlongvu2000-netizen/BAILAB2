================================================================================
BÁO CÁO & HƯỚNG DẪN SỬ DỤNG - LAB 07: CƠ SỞ DỮ LIỆU QLSINHVIEN & ADO.NET
Học phần: Lập trình .NET (IT3212) - Khoa CNTT - Trường Đại học Công nghệ Đông Á
Project : Lab07_ADONET_Connection (.NET Framework 4.8)
================================================================================

1. TÊN INSTANCE SQL SERVER VÀ CÁCH THAY CHUỖI KẾT NỐI
--------------------------------------------------------------------------------
- Các tên Instance SQL Server phổ biến đã cấu hình sẵn trong tệp App.config:
  1) Instance mặc định (Default Instance):
     Data Source=.;Initial Catalog=QLSinhVien;Integrated Security=True
  2) SQL Server LocalDB (Đã cài sẵn trên máy cùng Visual Studio 2022):
     Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QLSinhVien;Integrated Security=True
  3) SQL Server Express:
     Data Source=.\SQLEXPRESS;Initial Catalog=QLSinhVien;Integrated Security=True
  4) SQL Server Authentication (Câu 7 - Tài khoản riêng cho ứng dụng):
     Data Source=.;Initial Catalog=QLSinhVien;User ID=app_qlsinhvien;Password=Eaut@2026!

- Cách thay đổi chuỗi kết nối:
  + Cách 1 (Sửa trong tệp App.config - Câu 8):
    Mở tệp Lab07_ADONET_Connection\App.config, tìm thẻ <connectionStrings>, sửa giá trị
    thuộc tính Data Source=... thành tên Server/Instance trong SSMS của bạn.
  + Cách 2 (Chỉnh trực tiếp trên giao diện ứng dụng):
    Tại Tab 1 của frmMain, chọn cấu hình trong ComboBox "Chọn từ App.config" hoặc
    nhập trực tiếp tên Server/Instance vào ô "Server / Instance".

2. CÁCH CHẠY KỊCH BẢN SQL VÀ CHẠY ỨNG DỤNG
--------------------------------------------------------------------------------
- Bước 1: Tạo CSDL QLSinhVien
  + Cách A (Trên SSMS): Mở tệp Lab07_QLSinhVien.sql trong SQL Server Management Studio
    và nhấn F5 (Execute) để tạo CSDL QLSinhVien, 4 bảng (Khoa, SinhVien, HocPhan, DangKy),
    các ràng buộc (PK, FK, CHECK, UNIQUE, DEFAULT), tài khoản app_qlsinhvien và dữ liệu mẫu.
  + Cách B (Tự động ngay trên ứng dụng WinForms): Chạy ứng dụng Lab07_ADONET_Connection,
    chọn Instance (ví dụ "(localdb)\MSSQLLocalDB" hoặc ".") rồi nhấn nút màu xanh lá:
    "Tạo CSDL & Dữ liệu mẫu (Lab07.sql)".

- Bước 2: Kiểm tra kết nối & Xem trạng thái SqlConnection (Bài 5 & Câu 9)
  + Nhấn nút "Kiểm tra kết nối (Bài 5)".
  + Xem đầy đủ các thông số trên khung "Trang Trạng thái Kết nối SqlConnection":
    * DataSource (Tên máy chủ)
    * Database (QLSinhVien)
    * ServerVersion (Phiên bản SQL Server)
    * State (Open / Closed)
    * Thời gian mở kết nối (đo bằng Stopwatch theo đơn vị ms).

- Bước 3: Kiểm thử Ràng buộc (Câu 6) & Sao lưu/Phục hồi (Câu 10)
  + Chuyển sang Tab 2 để xem danh sách 10 Sinh viên thuộc 3 Khoa từ CSDL QLSinhVien,
    thử nhấn nút "Thử Vi phạm UNIQUE Email" hoặc "Thử Vi phạm CHECK Điểm > 10".
  + Tại cuối Tab 1, nhấn "Backup (.bak)" để sao lưu CSDL và "Restore (.bak)" để phục hồi.
================================================================================
