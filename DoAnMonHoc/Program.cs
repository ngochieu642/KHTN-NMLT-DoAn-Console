using System;
using System.Collections.Generic;

namespace DoAnMonHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            QuanLyCuaHang();
        }

        static void QuanLyCuaHang()
        {
            CUA_HANG cuaHang = new CUA_HANG
            {
                TatCaLoaiHang = new List<LOAI_HANG>(), TatCaMatHang = new List<MAT_HANG>()
            };
            
            while (true)
            {
                var test = XL_LoaiHangItem.ConsoleTaoLoaiHang();
                

                XL_CuaHang.ThemLoaiHang(test, ref cuaHang);
            }
        }
    }
}