using System;

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
            while (true)
            {
                MAT_HANG a;
                a = XL_MatHangItem.ConsoleTaoMatHang();
                XL_MatHangItem.XuatMatHang(a);
            }
        }
    }
}