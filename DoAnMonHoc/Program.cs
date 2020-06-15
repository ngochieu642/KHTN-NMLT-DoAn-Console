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
                // Tạo loại hàng
                var test = XL_LoaiHangItem.ConsoleTaoLoaiHang();
                XL_CuaHang.ConsoleThemLoaiHang(test, ref cuaHang);

                // Tìm kiếm loại hàng by ID
                // Console.Write("Nhập Id cần tìm: ");
                // string findId = Console.ReadLine();
                // XL_CuaHang.ConsoleGetLoaiHangById(findId, cuaHang);
                
                // Update loại hàng ID
                // Console.Write("Nhập ID cần cập nhật: ");
                // string oldId = Console.ReadLine();
                // Console.Write("Nhập ID thay thế: ");
                // string newId = Console.ReadLine();
                // XL_CuaHang.ConsoleUpdateLoaiHangId(ref cuaHang, oldId, newId);
                
                // Update loại hàng tên
                Console.Write("Nhập Id cần cập nhật: ");
                string id = Console.ReadLine();
                Console.Write("Nhập tên thay thế: ");
                string newName = Console.ReadLine();
                XL_CuaHang.ConsoleUpdateLoaiHangTen(ref cuaHang, id, newName);
                
                XL_CuaHang.ShowAllLoaiHang(cuaHang);
            }
        }
    }
}