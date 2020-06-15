using System.Collections.Generic;

namespace DoAnMonHoc
{
    public struct CUA_HANG
    {
        public List<MAT_HANG> TatCaMatHang;
        public List<LOAI_HANG> TatCaLoaiHang;
    }
    public class XL_CuaHang
    {
        public CUA_HANG CuaHang;
        
        // Apply CRUD Mặt hàng
        public void ThemMatHang()
        {
            
        }

        public void GetAllMatHang()
        {
            
        }

        public void GetMatHangByID(string id)
        {
            
        }

        public void TimKiemMatHang(string options, string needToFindString)
        {
            
        }

        public void UpdateMatHang(string id)
        {
            
        }

        public void DeleteMatHangByID(string id)
        {
            
        }
        
        // Apply CRUD Loai hàng
        public void ThemLoaiHang(LOAI_HANG newItem)
        {
            
        }
        public void GetAllLoaiHang()
        {
            
        }

        public void GetLoaiHangByID(string id)
        {
            
        }

        public void TimKiemLoaiHang(string options, string needToFindString)
        {
            
        }

        public void UpdateLoaiHang(string id)
        {
            
        }

        public void DeleteLoaiHangByID(string id)
        {
            
        }
    }
}