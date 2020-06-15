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
        public static void ThemLoaiHang(LOAI_HANG newItem, ref CUA_HANG cuaHang)
        {
            // Check nếu loại hàng với id đã tồn tại
            var foundItemList = cuaHang.TatCaLoaiHang.Where(st => st.Ma == newItem.Ma).ToList();

            if (!foundItemList.Any())
            {
                Console.WriteLine("Loại hàng với ID phù hợp");
                Console.WriteLine("Thêm loại hàng vào Cơ sở dữ liêu...");
                cuaHang.TatCaLoaiHang.Add(newItem);
                Console.WriteLine("Loại hàng thêm vào cơ sở dữ liệu thành công");
            }
            else
            {
                Console.WriteLine("Loại hàng với ID này đã tồn tại");
                Console.WriteLine("Loại hàng không được thêm vào cơ sở dữ liệu");
            }
        }
        public static void GetAllLoaiHang()
        {
            
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