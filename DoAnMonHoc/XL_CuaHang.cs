using System;
using System.Collections.Generic;
using System.Linq;

namespace DoAnMonHoc
{
    public struct CUA_HANG
    {
        public List<MAT_HANG> TatCaMatHang;
        public List<LOAI_HANG> TatCaLoaiHang;
    }
    public class XL_CuaHang
    {
        // Apply CRUD Mặt hàng
        public static void ThemMatHang(MAT_HANG newItem)
        {
            
        }

        public static void GetAllMatHang()
        {
            
        }

        public static void GetMatHangByID(string id)
        {
            
        }

        public static void TimKiemMatHang(string options, string needToFindString)
        {
            
        }

        public static void UpdateMatHang(string id)
        {
            
        }

        public static void DeleteMatHangByID(string id)
        {
            
        }
        
        // Apply CRUD Loai hàng
        public static bool ThemLoaiHang(LOAI_HANG newItem, ref CUA_HANG cuaHang)
        {
            var foundItemList = cuaHang.TatCaLoaiHang.Where(st => st.Ma == newItem.Ma).ToList();
            if (!foundItemList.Any())
            {
                cuaHang.TatCaLoaiHang.Add(newItem);
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ConsoleThemLoaiHang(LOAI_HANG newItem, ref CUA_HANG cuaHang)
        {
            // Check nếu loại hàng với id đã tồn tại
            bool themThanhCong = ThemLoaiHang(newItem, ref cuaHang);

            if (themThanhCong)
            {
                Console.WriteLine("Loại hàng với ID phù hợp");
                Console.WriteLine("Loại hàng thêm vào cơ sở dữ liệu thành công");
            }
            else
            {
                Console.WriteLine("Loại hàng với ID này đã tồn tại");
                Console.WriteLine("Loại hàng không được thêm vào cơ sở dữ liệu");
            }
            
            ShowAllLoaiHang(cuaHang);
        }
        public static void ShowAllLoaiHang(CUA_HANG cuaHang)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Các loại hàng tồn tại trong cửa hàng");
            foreach (var loaiHang in cuaHang.TatCaLoaiHang)
            {
                XL_LoaiHangItem.XuatLoaiHang(loaiHang);
            }
        }

        public static void GetLoaiHangByID(string id)
        {
            
        }

        public static void TimKiemLoaiHang(string options, string needToFindString)
        {
            
        }

        public static void UpdateLoaiHang(string id)
        {
            
        }

        public static void DeleteLoaiHangByID(string id)
        {
            
        }
    }
}