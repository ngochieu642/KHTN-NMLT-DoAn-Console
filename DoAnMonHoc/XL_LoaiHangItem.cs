using System;

namespace DoAnMonHoc
{
    public struct LOAI_HANG
    {
        public string Ma;
        public string TenLoaiHang;
    }
    
    public class XL_LoaiHangItem
    {
        public static LOAI_HANG TaoLoaiHang(string ma, string tenLoaiHang)
        {
            LOAI_HANG result = new LOAI_HANG();
            result.Ma = ma;
            result.TenLoaiHang = tenLoaiHang;

            return result;
        }

        public static LOAI_HANG ConsoleTaoLoaiHang()
        {
            Console.WriteLine();
            Console.WriteLine("TẠO LOẠI HÀNG");

            string maLoaiHang = NhapInputString("Nhập mã loại hàng");
            string tenLoaiHang = NhapInputString("Nhập tên loại hàng");
            
            Console.WriteLine();

            return TaoLoaiHang(maLoaiHang, tenLoaiHang);
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
    }
}