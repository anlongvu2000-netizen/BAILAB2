using System;

public class NhanVien
{
    public string MaNV { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public double LuongCoBan { get; set; }
    public double HeSo { get; set; }
    public double PhuCap { get; set; }

    public double TinhLuong()
    {
        return (LuongCoBan * HeSo) + PhuCap;
    }

    public void InBangLuong()
    {
        Console.WriteLine($"NV: {HoTen} | LCB: {LuongCoBan} | Hệ số: {HeSo} | Phụ cấp: {PhuCap} | TỔNG LƯƠNG: {TinhLuong()}");
    }
}