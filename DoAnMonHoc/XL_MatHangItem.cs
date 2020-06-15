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

            string maMatHang = NhapInputString("Nhập mã mặt hàng");
            string tenMatHang = NhapInputString("Nhập tên mặt hàng: ");
            DateTime hanDung = NhapNgayHetHan();
            string congTySanXuat = NhapInputString("Nhập công ty sản xuất");
            int namSanXuat = NhapInputInt("Nhập năm sản xuất");
            string loaiHang = NhapInputString("Nhập mã loại hàng");
            Console.WriteLine();
            
            return TaoMatHang(maMatHang, tenMatHang, hanDung, congTySanXuat, namSanXuat, loaiHang);
        }
        
        private static string NhapInputString(string message)
        {
            string result = null;

            while (result == null)
            {
                Console.Write($"{message}: ");
                result = Console.ReadLine();
            }

            return result;
        }
        
        private static int NhapInputInt(string message)
        {
            int result = new int();
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    Console.Write($"{message}: ");
                    result = int.Parse(Console.ReadLine());
                    isValidInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input không hợp lệ, vui lòng nhập lại");
                }
            }
            return result;
        }
        
        private static DateTime NhapNgayHetHan()
        {
            bool isValidDate = false;
            DateTime result = new DateTime();
            
            Console.WriteLine("Nhập Ngày Hết Hạn");

            while (!isValidDate)
            {
                try
                {
                    int nam = NhapInputInt("Nhập năm");
                    int thang = NhapInputInt("Nhập tháng");
                    int ngay = NhapInputInt("Nhập ngày");

                    result = new DateTime(nam, thang, ngay);

                    isValidDate = true;
                }
                catch (Exception e)
                {
                    // Console.WriteLine("{0} Exception caught.", e);
                    Console.WriteLine("Ngày tháng vừa nhập không hợp lệ, vui lòng nhập lại");
                }
            }

            return result;
        }
        public static void XuatMatHang(MAT_HANG a)
        {
            Console.WriteLine();
            Console.WriteLine($"Mã mặt hàng {a.Ma}");
            Console.WriteLine($"Tên mặt hàng {a.TenHang}");
            Console.WriteLine($"Hạn sử dụng: {a.HanDung.ToString(CultureInfo.InvariantCulture)}");
            Console.WriteLine($"Công ty sản xuất: {a.CongTySanXuat}");
            Console.WriteLine($"Năm sản xuất: {a.NamSanXuat}");
            Console.WriteLine($"Mã loại hàng: {a.LoaiHang}");
            Console.WriteLine();
        }
    }
}