using System;

public class TaiKhoanNganHang
{
    public string SoTK { get; set; } = string.Empty;
    public string ChuTK { get; set; } = string.Empty;
    public double SoDu { get; private set; } // Chỉ cho phép thay đổi số dư thông qua nạp/rút

    public TaiKhoanNganHang(string soTK, string chuTK, double soDuBanDau)
    {
        SoTK = soTK;
        ChuTK = chuTK;
        SoDu = soDuBanDau >= 0 ? soDuBanDau : 0;
    }

    public void NapTien(double soTien)
    {
        if (soTien > 0) SoDu += soTien;
    }

    public bool RutTien(double soTien)
    {
        if (soTien > 0 && soTien <= SoDu)
        {
            SoDu -= soTien;
            return true; // Rút thành công
        }
        return false; // Số dư không đủ hoặc số tiền không hợp lệ
    }

    public void ChuyenTien(TaiKhoanNganHang tkNhan, double soTien)
    {
        if (RutTien(soTien))
        {
            tkNhan.NapTien(soTien);
            Console.WriteLine($"Chuyển thành công {soTien} tới {tkNhan.ChuTK}");
        }
        else
        {
            Console.WriteLine("Chuyển tiền thất bại (Số dư không đủ).");
        }
    }
}