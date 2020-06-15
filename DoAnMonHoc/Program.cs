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
                // -------------XỦ LÝ LOẠI HÀNG-------------------
                // Tạo loại hàng
                var test = XL_LoaiHang.ConsoleTaoLoaiHang();
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
                // Console.Write("Nhập Id cần cập nhật: ");
                // string id = Console.ReadLine();
                // Console.Write("Nhập tên thay thế: ");
                // string newName = Console.ReadLine();
                // XL_CuaHang.ConsoleUpdateLoaiHangTen(ref cuaHang, id, newName);
                
                // Delete loại hàng by ID
                // Console.Write("Nhập ID cần xóa: ");
                // string id = Console.ReadLine();
                // XL_CuaHang.ConsoleDeleteLoaiHangById(ref cuaHang, id);
                
                // Tìm kiếm loại hàng
                // Console.Write("Nhập tên cần tìm: ");
                // string toFind = Console.ReadLine();
                // XL_CuaHang.ConsoleTimKiemLoaiHang(cuaHang, "regex", toFind);
                
                XL_CuaHang.ShowAllLoaiHang(cuaHang);
                
                // --------------XỬ LÝ MẶT HÀNG-----------------
                
                // Tạo mặt hàng
                var testMatHang = XL_MatHang.ConsoleTaoMatHang();
                XL_CuaHang.ConsoleThemMatHang(ref cuaHang, testMatHang);
                
                // Tìm kiếm mặt hàng by ID
                Console.Write("Nhập Id cần tìm: ");
                string findId = Console.ReadLine();
                XL_CuaHang.ConsoleGetLoaiHangById(findId, cuaHang);
            }
        }
    }
}