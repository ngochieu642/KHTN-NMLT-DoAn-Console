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
            // var foundItem = CuaHang.TatCaLoaiHang.Where(st => st.Ma == newItem.Ma);
            XL_LoaiHangItem.XuatLoaiHang(newItem);
            cuaHang.TatCaLoaiHang.Add(newItem);
            
            Console.WriteLine(cuaHang.TatCaLoaiHang);
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