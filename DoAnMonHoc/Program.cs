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
                                    // Tạo mặt hàng
                                    var testMatHang = XL_MatHang.ConsoleTaoMatHang();
                                    XL_CuaHang.ConsoleThemMatHang(ref cuaHang, testMatHang);
                                    break;
                                case 2:
                                    // Hiển thị tất cả mặt hàng
                                    XL_CuaHang.ShowAllMatHang(cuaHang);
                                    break;
                                case 3:
                                    // Tìm kiếm loại hàng
                                    Console.Write("Nhập từ khóa cần tìm: ");
                                    string toFind = Console.ReadLine();
                                    XL_CuaHang.ConsoleTimKiemMatHang(cuaHang, "regex", toFind);
                                    break;
                                case 4:
                                    // TODO: Lựa chọn thuộc tính muốn update
                                    // Update mặt hàng ID
                                    string oldId = XL_Console.NhapInputString("Nhập ID cần cập nhật");
                                    string newId = XL_Console.NhapInputString("Nhập ID thay thế");
                                    XL_CuaHang.ConsoleUpdateMatHangId(ref cuaHang, oldId, newId);
                                    break;
                                case 5:
                                    // // Delete mặt hàng by ID
                                    string toDeleteId = XL_Console.NhapInputString("Nhập ID cần xóa");
                                    XL_CuaHang.ConsoleDeleteLoaiHangById(ref cuaHang, toDeleteId);
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
                                    string oldId = XL_Console.NhapInputString("Nhập ID cần cập nhật");
                                    string newId = XL_Console.NhapInputString("Nhập ID thay thế");
                                    XL_CuaHang.ConsoleUpdateLoaiHangId(ref cuaHang, oldId, newId);

                                    // Update loại hàng tên
                                    string toUpdateId = XL_Console.NhapInputString("Nhập Id cần cập nhật");
                                    string newName = XL_Console.NhapInputString("Nhập tên thay thế");
                                    XL_CuaHang.ConsoleUpdateLoaiHangTen(ref cuaHang, toUpdateId, newName);
                                    break;
                                case 5:
                                    // // Delete loại hàng by ID
                                    string toDeleteId = XL_Console.NhapInputString("Nhập ID cần xóa");
                                    XL_CuaHang.ConsoleDeleteLoaiHangById(ref cuaHang, toDeleteId);
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