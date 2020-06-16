using System;
using System.Collections.Generic;

namespace DoAnMonHoc
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLyCuaHang();
        }

        static void QuanLyCuaHang()
        {
            CUA_HANG cuaHang = new CUA_HANG
            {
                TatCaLoaiHang = new List<LOAI_HANG>(), TatCaMatHang = new List<MAT_HANG>()
            };

            bool wantToExit = false;
            
            while (!wantToExit)
            {
                // -------------XỦ LÝ LOẠI HÀNG-------------------
                // Tạo loại hàng
                // var test = XL_LoaiHang.ConsoleTaoLoaiHang();
                // XL_CuaHang.ConsoleThemLoaiHang(test, ref cuaHang);

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
                
                // // Delete loại hàng by ID
                // Console.Write("Nhập ID cần xóa: ");
                // id = Console.ReadLine();
                // XL_CuaHang.ConsoleDeleteLoaiHangById(ref cuaHang, id);
                
                // Tìm kiếm loại hàng
                // Console.Write("Nhập tên cần tìm: ");
                // string toFind = Console.ReadLine();
                // XL_CuaHang.ConsoleTimKiemLoaiHang(cuaHang, "regex", toFind);
                //
                // XL_CuaHang.ShowAllLoaiHang(cuaHang);
                
                // --------------XỬ LÝ MẶT HÀNG-----------------
                
                // Tạo mặt hàng
                // var testMatHang = XL_MatHang.ConsoleTaoMatHang();
                // XL_CuaHang.ConsoleThemMatHang(ref cuaHang, testMatHang);
                
                // Tìm kiếm mặt hàng by ID
                // Console.Write("Nhập Id cần tìm: ");
                // findId = Console.ReadLine();
                // XL_CuaHang.ConsoleGetLoaiHangById(findId, cuaHang);
                
                // Update mặt hàng ID
                // Console.Write("Nhập ID cần cập nhật: ");
                // oldId = Console.ReadLine();
                // Console.Write("Nhập ID thay thế: ");
                // newId = Console.ReadLine();
                // XL_CuaHang.ConsoleUpdateMatHangId(ref cuaHang, oldId, newId);
                
                // Show menu
                ShowMenuCuaHang();
                    
                // Lua chon loai Menu
                int menuOption = new int();
                bool isValidMenuOption = false;
                string invalidInputMsg = "Không hợp lệ, vui lòng nhập lại";

                while (!isValidMenuOption)
                {
                    try
                    {
                        Console.WriteLine();
                        Console.Write("Vui lòng chọn loại menu: ");
                        menuOption = int.Parse(Console.ReadLine());

                        if (menuOption == 1 || menuOption ==2)
                        {
                            isValidMenuOption = true;
                        } else if (menuOption == 0)
                        {
                            // Exit
                            isValidMenuOption = true;
                            wantToExit = true;
                        }
                        else
                        {
                            Console.WriteLine(invalidInputMsg);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(invalidInputMsg);
                    }   
                }

                if (wantToExit)
                {
                    break;
                }
                
                // Based on menuOption, show menu
                switch (menuOption)
                {
                    case 1:
                        Console.WriteLine("Bạn đã lựa chọn menu mặt hàng");
                        ShowMenuMatHang();
                        break;
                    case 2:
                        Console.WriteLine("Bạn đã lựa chọn menu loại hàng");
                        ChonMenuLoaiHang();
                        break;
                    default:
                        Console.WriteLine("Bạn không nên nhìn thấy dòng này!");
                        break;
                }
            }
            
            Console.WriteLine("GoodBye and have a nice day!");
        }

        private static int ChonMenuLoaiHang()
        {
            int menuOption  = new int();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-----MENU LOẠI HÀNG-----");
                Console.WriteLine("1. Tạo loại hàng");
                Console.WriteLine("2. Hiển thị tất cả loại hàng");
                Console.WriteLine("3. Tìm kiếm loại hàng");
                Console.WriteLine("4. Cập nhật loại hàng");

                menuOption = XL_Console.NhapInputInt("Menu lựa chọn");

                if (menuOption == 1 || menuOption == 2 || menuOption == 3 || menuOption == 4)
                {
                    break;
                }
                
                Console.WriteLine("Lựa chọn không khả dụng, vui lòng nhập lại");
            }

            return menuOption;
        }

        private static void ShowMenuMatHang()
        {
            Console.WriteLine();
            Console.WriteLine("-----MENU MẶT HÀNG-----");
            Console.WriteLine("1. Tạo mặt hàng");
            Console.WriteLine("2. Hiển thị tất cả mặt hàng");
            Console.WriteLine("3. Tìm kiếm mặt hàng");
            Console.WriteLine("4. Cập nhật mặt hàng");
            Console.WriteLine("5. Xóa mặt hàng");
        }

        static void ShowMenuCuaHang()
        {
            Console.WriteLine();
            Console.WriteLine("HỆ THỐNG QUẢN LÝ CỬA HÀNG");
            Console.WriteLine("---------MENU-----------");
            Console.WriteLine("1. Mặt hàng MENU");
            Console.WriteLine("2. Loại hàng MENU");
            Console.WriteLine("0. Exit");
        }
    }
}