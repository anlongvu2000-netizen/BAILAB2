======================================================
BÁO CÁO THỰC HÀNH LAB 2 - LẬP TRÌNH C# HƯỚNG ĐỐI TƯỢNG
======================================================

1. CẤU TRÚC THƯ MỤC MÃ NGUỒN
- Program.cs: Chứa hàm Main, cấu trúc Menu điều khiển toàn bộ chương trình.
- SinhVien.cs: Class chứa nghiệp vụ quản lý sinh viên (Bài 1, 2, 3, 4, 5, 10).
- SanPham.cs: Class quản lý sản phẩm (Bài 6).
- TaiKhoanNganHang.cs: Class quản lý giao dịch ngân hàng (Bài 7).
- NhanVien.cs: Class tính lương nhân viên (Bài 8).
- HinhChuNhat.cs: Class tính chu vi, diện tích (Bài 9).

2. CÁCH BUILD VÀ CHẠY CHƯƠNG TRÌNH
- Yêu cầu môi trường: Cài đặt .NET SDK.
- Bước 1: Mở Terminal / Command Prompt tại thư mục Lab2.
- Bước 2: Chạy lệnh `dotnet build` để biên dịch dự án.
- Bước 3: Chạy lệnh `dotnet run` để khởi động chương trình.
- Bước 4: Tương tác với chương trình thông qua Menu Console (Nhập phím từ 0-9).

3. DỮ LIỆU THỬ (TEST DATA) ĐƯỢC TÍCH HỢP SẴN
- Bài 1-5, 10 (Sinh Viên): Đã nạp sẵn 4 sinh viên với các mức điểm khác nhau để test chức năng Sắp xếp và Thống kê (Nguyễn An - 8.2, Trần Bình - 6.8, Lê Cường - 9.5, Phạm Diệp - 4.5).
- Bài 6 (Sản phẩm): Laptop (Mã SP01), Đơn giá 15.000.000, Số lượng 2.
- Bài 7 (Ngân hàng): Khởi tạo TK Nguyễn Văn A (500k), TK Trần Thị B (0k). Chuyển 300k từ A sang B.
- Bài 8 (Nhân viên): NV Lê C, LCB 5.000.000, Hệ số 2.5, Phụ cấp 1.000.000.
- Bài 9 (Hình chữ nhật): Cạnh 5 và 10.
* Lưu ý: Các class đã được áp dụng Encapsulation (Đóng gói) để ném ra ngoại lệ (Exception) nếu nhập dữ liệu sai (vd: điểm < 0, đơn giá âm, chuỗi rỗng...).

4. PHẦN ĐÃ HOÀN THÀNH
- Hoàn thành 100% các yêu cầu từ Bài 1 đến Bài 10.
- Cấu trúc code áp dụng tốt tính Đóng gói (Encapsulation), Constructor nạp chồng, và biểu thức Lambda.
- Đã tích hợp thành một ứng dụng Console có Menu tổng hợp dễ dàng thao tác.