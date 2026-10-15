using System;

public class SanPham
{
    public string MaSP { get; set; } = string.Empty;
    public string TenSP { get; set; } = string.Empty;

    private double _donGia;
    public double DonGia
    {
        get { return _donGia; }
        set { _donGia = value > 0 ? value : throw new ArgumentException("Đơn giá phải > 0"); }
    }

    private int _soLuong;
    public int SoLuong
    {
        get { return _soLuong; }
        set { _soLuong = value >= 0 ? value : throw new ArgumentException("Số lượng không được âm"); }
    }

    public double TinhThanhTien()
    {
        return DonGia * SoLuong;
    }

    public void HienThi()
    {
        Console.WriteLine($"Mã: {MaSP} | Tên: {TenSP} | Đơn giá: {DonGia} | SL: {SoLuong} | Thành tiền: {TinhThanhTien()}");
    }
}