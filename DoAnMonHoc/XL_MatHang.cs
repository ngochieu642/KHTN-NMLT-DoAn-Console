using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace DoAnMonHoc
{
    public struct MAT_HANG
    {
        public string Ma;
        public string TenHang;
        public DateTime HanDung;
        public string CongTySanXuat;
        public int NamSanXuat;
        public string LoaiHang;
    }
    public class XL_MatHang
    {
        public static MAT_HANG TaoMatHang(string maMatHang, string tenMatHang, DateTime hanDung, string congTySanXuat,
            int namSanXuat, string maLoaiHang)
        {
            MAT_HANG result = new MAT_HANG();
            result.Ma = maMatHang;
            result.TenHang = tenMatHang;
            result.HanDung = hanDung;
            result.CongTySanXuat = congTySanXuat;
            result.NamSanXuat = namSanXuat;
            result.LoaiHang = maLoaiHang;

            return result;
        }
        public static MAT_HANG ConsoleTaoMatHang()
        {
            Console.WriteLine();
            Console.WriteLine("TẠO MẶT HÀNG");

            string maMatHang = XL_Console.NhapInputString("Nhập mã mặt hàng");
            string tenMatHang = XL_Console.NhapInputString("Nhập tên mặt hàng: ");
            DateTime hanDung = XL_Console.NhapNgayHetHan();
            string congTySanXuat = XL_Console.NhapInputString("Nhập công ty sản xuất");
            int namSanXuat = XL_Console.NhapInputInt("Nhập năm sản xuất");
            string loaiHang = XL_Console.NhapInputString("Nhập mã loại hàng");
            Console.WriteLine();
            
            return TaoMatHang(maMatHang, tenMatHang, hanDung, congTySanXuat, namSanXuat, loaiHang);
        }
        
        public static void XuatMatHang(MAT_HANG a)
        {
            Console.WriteLine();
            Console.WriteLine($"Mã mặt hàng: {a.Ma}");
            Console.WriteLine($"Tên mặt hàng: {a.TenHang}");
            Console.WriteLine($"Hạn sử dụng: {a.HanDung.ToString(CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Công ty sản xuất: {a.CongTySanXuat}");
            Console.WriteLine($"Năm sản xuất: {a.NamSanXuat}");
            Console.WriteLine($"Mã loại hàng: {a.LoaiHang}");
            Console.WriteLine();
        }
    }
}