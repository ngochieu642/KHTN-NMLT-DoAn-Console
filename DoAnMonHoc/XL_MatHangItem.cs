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
    public class XL_MatHangItem
    {
        public static MAT_HANG TaoMatHang()
        {
            MAT_HANG result = new MAT_HANG();
            Console.WriteLine("Nhập mặt hàng");
            
            // Nhập mã
            result.Ma = NhapMa();

            // Nhập tên mặt hàng
            result.TenHang = NhapTen();

            // Nhập hạn dùng
            Console.WriteLine("Nhập ngày hết hạn");
            result.HanDung= NhapDate();

            // Nhập công ty sản xuất
            result.CongTySanXuat = NhapCongty();
            
            // Nhập năm sản xuất
            result.NamSanXuat = NhapNamSanXuat();
            
            // Nhập loại hàng
            result.LoaiHang = NhapMaLoaiHang();
            
            // Mặt hàng
            return result;    
        }

        private static string NhapMaLoaiHang()
        {
            // ReSharper disable once InvalidXmlDocComment
            Console.Write("Nhập mã loại hàng: ");
            var result = Console.ReadLine();
            return result;
        }

        private static int NhapNamSanXuat()
        {
            bool isValidInt = false;
            int namSanXuat=0;
            
            while (!isValidInt)
            {
                try
                {
                    Console.Write("Nhập năm sản xuất: ");
                    namSanXuat = int.Parse(Console.ReadLine());
                    isValidInt = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }

            return namSanXuat;
        }

        private static string NhapCongty()
        {
            Console.Write("Nhập tên công ty: ");
            string result = Console.ReadLine();
            return result;
        }

        private static DateTime NhapDate()
        {
            bool isValidDate = false;
            DateTime result = new DateTime();

            while (!isValidDate)
            {
                try
                {
                    Console.Write("Nhập năm: ");
                    int nam = int.Parse(Console.ReadLine());

                    Console.Write("Nhập tháng: ");
                    int thang = int.Parse(Console.ReadLine());

                    Console.Write("Nhập ngày: ");
                    int ngay = int.Parse(Console.ReadLine());

                    result = new DateTime(nam, thang, ngay);

                    // Set cờ
                    isValidDate = true;
                    return result;
                }
                catch (Exception e)
                {
                    // Console.WriteLine("{0} Exception caught.", e);
                    Console.WriteLine("Ngày tháng vừa nhập không hợp lệ, vui lòng nhập lại");
                }
            }

            return result;
        }

        private static string NhapTen()
        {
            Console.Write("Nhập tên mặt hàng: ");
            string tenHang = Console.ReadLine();
            return tenHang;
        }

        private static string NhapMa()
        {
            Console.Write("Nhập mã mặt hàng: ");
            string maMatHang = Console.ReadLine();
            return maMatHang;
        }

        public static void XuatMatHang(MAT_HANG a)
        {
            Console.WriteLine($"Mã mặt hàng {a.Ma}");
            Console.WriteLine($"Tên mặt hàng {a.TenHang}");
            Console.WriteLine($"Hạn sử dụng: {a.HanDung.ToString(CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Công ty sản xuất: {a.CongTySanXuat}");
            Console.WriteLine($"Năm sản xuất: {a.NamSanXuat}");
            Console.WriteLine($"Mã loại hàng: {a.LoaiHang}");
        }
    }
}