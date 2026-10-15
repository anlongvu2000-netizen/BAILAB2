using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<SinhVien> ds = new List<SinhVien>();

        // Dữ liệu mẫu 
        ds.Add(new SinhVien("SV01", "Nguyễn An", new DateTime(2005, 5, 12), 8.2)); 
        ds.Add(new SinhVien("SV02", "Trần Bình", new DateTime(2005, 9, 3), 6.8));  
        ds.Add(new SinhVien("SV03", "Lê Cường", new DateTime(2004, 2, 20), 9.5)); 
        ds.Add(new SinhVien("SV04", "Phạm Diệp", new DateTime(2006, 11, 8), 4.5)); 

        while (true)
        {
            Console.WriteLine("\n========== MENU TỔNG HỢP BÀI TẬP ==========");
            Console.WriteLine("1. Thêm sinh viên mới");
            Console.WriteLine("2. Hiển thị danh sách");
            Console.WriteLine("3. Tìm kiếm theo mã");
            Console.WriteLine("4. Sắp xếp theo Điểm TB (Giảm dần)");
            Console.WriteLine("5. Thống kê số lượng SV Giỏi/Xuất sắc");
            Console.WriteLine("6. Lớp Sản Phẩm");
            Console.WriteLine("7. Lớp Tài Khoản Ngân Hàng");
            Console.WriteLine("8. Lớp Nhân Viên");
            Console.WriteLine("9. Lớp Hình Chữ Nhật");
            Console.WriteLine("0. Thoát chương trình");
            Console.Write("Chọn chức năng (0-9): ");
            
            string chon = Console.ReadLine() ?? "";
            Console.WriteLine("-------------------------------------------");

            switch (chon)
            {
                case "1":
                    try 
                    {
                        Console.Write("Nhập mã SV: "); string ma = Console.ReadLine() ?? "";
                        Console.Write("Nhập họ tên: "); string ten = Console.ReadLine() ?? "";
                        Console.Write("Nhập năm sinh (yyyy): "); int nam = int.Parse(Console.ReadLine() ?? "2000");
                        Console.Write("Nhập tháng sinh (mm): "); int thang = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Nhập ngày sinh (dd): "); int ngay = int.Parse(Console.ReadLine() ?? "1");
                        Console.Write("Nhập điểm TB (0-10): "); double diem = double.Parse(Console.ReadLine() ?? "0");
                        
                        ds.Add(new SinhVien(ma, ten, new DateTime(nam, thang, ngay), diem)); 
                        Console.WriteLine(">> Thêm sinh viên thành công!");
                    }
                    catch (Exception ex) { Console.WriteLine(">> LỖI: " + ex.Message); }
                    break;
                case "2":
                    if (ds.Count == 0) Console.WriteLine(">> Danh sách trống!");
                    else foreach (var sv in ds) sv.HienThi();
                    break;
                case "3":
                    Console.Write("Nhập mã cần tìm: "); string maTim = Console.ReadLine() ?? "";
                    var ketQua = ds.Find(x => x.MaSV.Equals(maTim, StringComparison.OrdinalIgnoreCase));
                    if (ketQua != null) ketQua.HienThi();
                    else Console.WriteLine(">> Không tìm thấy!");
                    break;
                case "4":
                    ds.Sort((sv1, sv2) => sv2.DiemTB.CompareTo(sv1.DiemTB));
                    Console.WriteLine(">> Đã sắp xếp! (Bấm phím 2 để xem)");
                    break;
                case "5":
                    int gioi = ds.Count(x => x.XepLoai() == "Giỏi" || x.XepLoai() == "Xuất sắc");
                    Console.WriteLine($">> Có {gioi} sinh viên đạt loại Giỏi/Xuất sắc.");
                    break;

                // ==========================================
                // CODE TEST BÀI 6, 7, 8, 9
                // ==========================================
                case "6":
                    Console.WriteLine(">> TEST BÀI 6: SẢN PHẨM");
                    SanPham sp = new SanPham { MaSP = "SP01", TenSP = "Laptop", DonGia = 15000000, SoLuong = 2 };
                    sp.HienThi(); 
                    break;
                
                case "7":
                    Console.WriteLine(">> TEST BÀI 7: NGÂN HÀNG");
                    TaiKhoanNganHang tkA = new TaiKhoanNganHang("001", "Nguyễn Văn A", 500000);
                    TaiKhoanNganHang tkB = new TaiKhoanNganHang("002", "Trần Thị B", 0);
                    Console.WriteLine($"Số dư A: {tkA.SoDu}");
                    tkA.ChuyenTien(tkB, 300000); // A chuyển cho B 300k
                    Console.WriteLine($"Sau khi chuyển -> Số dư A: {tkA.SoDu} | Số dư B: {tkB.SoDu}");
                    break;
                
                case "8":
                    Console.WriteLine(">> TEST BÀI 8: NHÂN VIÊN");
                    NhanVien nv = new NhanVien { MaNV = "NV1", HoTen = "Lê C", LuongCoBan = 5000000, HeSo = 2.5, PhuCap = 1000000 };
                    nv.InBangLuong();
                    break;
                
                case "9":
                    Console.WriteLine(">> TEST BÀI 9: HÌNH CHỮ NHẬT");
                    HinhChuNhat hcn = new HinhChuNhat(5, 10);
                    Console.WriteLine($"Hình chữ nhật (Dài: {hcn.ChieuDai}, Rộng: {hcn.ChieuRong}) -> Chu vi: {hcn.TinhChuVi()}, Diện tích: {hcn.TinhDienTich()}");
                    break;

                case "0":
                    Console.WriteLine("Đang thoát chương trình... Tạm biệt!");
                    return;
                
                default:
                    Console.WriteLine(">> Chức năng không hợp lệ!");
                    break;
            }
        }
    }
}