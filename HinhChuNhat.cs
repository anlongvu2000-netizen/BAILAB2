using System;

public class HinhChuNhat
{
    private double _chieuDai;
    private double _chieuRong;

    public double ChieuDai
    {
        get { return _chieuDai; }
        set { _chieuDai = value > 0 ? value : throw new ArgumentException("Chiều dài phải lớn hơn 0"); }
    }

    public double ChieuRong
    {
        get { return _chieuRong; }
        set { _chieuRong = value > 0 ? value : throw new ArgumentException("Chiều rộng phải lớn hơn 0"); }
    }

    public HinhChuNhat(double chieuDai, double chieuRong)
    {
        ChieuDai = chieuDai;
        ChieuRong = chieuRong;
    }

    public double TinhChuVi() => (ChieuDai + ChieuRong) * 2;
    public double TinhDienTich() => ChieuDai * ChieuRong;
}