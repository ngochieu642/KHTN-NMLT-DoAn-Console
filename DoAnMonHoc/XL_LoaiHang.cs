using System;
using System.Collections.Generic;

namespace DoAnMonHoc
{
    public struct LOAI_HANG
    {
        public string Ma;
        public string TenLoaiHang;

        public LOAI_HANG(string maLoaiHang, string tenLoaiHang)
        {
            Ma = maLoaiHang;
            TenLoaiHang = tenLoaiHang;
        }
    }
    
    public class XL_LoaiHang
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

            string maLoaiHang = XL_Console.NhapInputString("Nhập mã loại hàng");
            string tenLoaiHang = XL_Console.NhapInputString("Nhập tên loại hàng");
            
            Console.WriteLine();

            return TaoLoaiHang(maLoaiHang, tenLoaiHang);
        }

        public static void XuatLoaiHang(LOAI_HANG a)
        {
            Console.WriteLine();
            Console.WriteLine($"Mã loại hàng: {a.Ma}");
            Console.WriteLine($"Tên loại hàng: {a.TenLoaiHang}");
        }

        public static void XuatLoaiHangList(List<LOAI_HANG> a)
        {
            foreach (var loaiHang in a)
            {
                XL_LoaiHang.XuatLoaiHang(loaiHang);
            }
        }
    }
}