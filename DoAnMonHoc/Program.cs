using System;
using System.Collections.Generic;
using System.Linq;

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
                int menuOption = ChonMenuGeneral();
                wantToExit = menuOption == 0;

                if (wantToExit)
                {
                    break;
                }
                
                // Based on menuOption, show menu
                switch (menuOption)
                {
                    case 1:
                        while (true)
                        {
                            Console.WriteLine("Menu mặt hàng");
                            int menuMatHang = ChonMenuMatHang();

                            switch (menuMatHang)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                default:
                                    break;
                            }

                            if (menuMatHang == 0)
                            {
                                break;
                            }
                        }
                        break;
                    case 2:
                        while (true)
                        {
                            Console.WriteLine("Menu loại hàng");
                            int menuLoaiHang = ChonMenuLoaiHang();

                            switch (menuLoaiHang)
                            {
                                case 1:
                                    // Tạo loại hàng
                                    var newLoaiHang = XL_LoaiHang.ConsoleTaoLoaiHang();
                                    XL_CuaHang.ConsoleThemLoaiHang(ref cuaHang, newLoaiHang);
                                    break;
                                case 2:
                                    //  Hiển thị tất cả loại hàng
                                    XL_CuaHang.ShowAllLoaiHang(cuaHang);
                                    break;
                                case 3:
                                    // Tìm kiếm loại hàng
                                    Console.Write("Nhập từ khóa cần tìm: ");
                                    string toFind = Console.ReadLine();
                                    XL_CuaHang.ConsoleTimKiemLoaiHang(cuaHang, "regex", toFind);
                                    break;
                                case 4:
                                    // TODO: Chọn lựa thuộc tính muốn update

                                    // Update loại hàng ID
                                    Console.Write("Nhập ID cần cập nhật: ");
                                    string oldId = Console.ReadLine();
                                    Console.Write("Nhập ID thay thế: ");
                                    string newId = Console.ReadLine();
                                    XL_CuaHang.ConsoleUpdateLoaiHangId(ref cuaHang, oldId, newId);

                                    // Update loại hàng tên
                                    Console.Write("Nhập Id cần cập nhật: ");
                                    string id = Console.ReadLine();
                                    Console.Write("Nhập tên thay thế: ");
                                    string newName = Console.ReadLine();
                                    XL_CuaHang.ConsoleUpdateLoaiHangTen(ref cuaHang, id, newName);
                                    break;
                                case 5:
                                    // // Delete loại hàng by ID
                                    Console.Write("Nhập ID cần xóa: ");
                                    id = Console.ReadLine();
                                    XL_CuaHang.ConsoleDeleteLoaiHangById(ref cuaHang, id);
                                    break;
                                default:
                                    break;
                            }

                            if (menuLoaiHang == 0)
                            {
                                break;
                            }
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Bạn không nên nhìn thấy dòng này!");
                        break;
                }
            }
            
            Console.WriteLine("GoodBye and have a nice day!");
        }

        private static int ChonMenuGeneral()
        {
            int menuOption = new int();

            while (true)
            {
                Console.WriteLine();
                menuOption = XL_Console.NhapInputInt("Vui lòng chọn loại menu");

                if (menuOption == 1 || menuOption == 2 || menuOption == 0)
                {
                    break;
                }
            }

            return menuOption;
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
                Console.WriteLine("5. Xóa loại hàng");
                Console.WriteLine("0. Back");

                menuOption = XL_Console.NhapInputInt("Menu lựa chọn");

                int[] validOptions = {0, 1, 2, 3, 4, 5};
                if (validOptions.Contains(menuOption))
                {
                    break;
                }
                
                Console.WriteLine("Lựa chọn không khả dụng, vui lòng nhập lại");
            }

            return menuOption;
        }

        private static int ChonMenuMatHang()
        {
            int menuOption = new int();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("-----MENU MẶT HÀNG-----");
                Console.WriteLine("1. Tạo mặt hàng");
                Console.WriteLine("2. Hiển thị tất cả mặt hàng");
                Console.WriteLine("3. Tìm kiếm mặt hàng");
                Console.WriteLine("4. Cập nhật mặt hàng");
                Console.WriteLine("5. Xóa mặt hàng");
                Console.WriteLine("0. Back");

                menuOption = XL_Console.NhapInputInt("Menu lựa chọn");

                int[] validOptions = {0, 1, 2, 3, 4, 5};
                if (validOptions.Contains(menuOption))
                {
                    break;
                }
                Console.WriteLine("Lựa chọn không khả dụng, vui lòng nhập lại");
            }

            return menuOption;
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