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

        public static LOAI_HANG? GetLoaiHangByID(string id, CUA_HANG cuaHang)
        {
            var foundItemList = cuaHang.TatCaLoaiHang.Where(st => st.Ma == id).ToList();
            if (!foundItemList.Any())
            {
                return null;
            }
            else
            {
                return foundItemList[0];
            }
        }

        public static void ConsoleGetLoaiHangById(string id, CUA_HANG cuaHang)
        {
            Console.WriteLine();
            Console.WriteLine($"Tìm kiếm trong cơ sở dữ liệu loại hàng với id: {id}");
            var foundItem = GetLoaiHangByID(id, cuaHang);

            if (foundItem != null)
            {
                XL_LoaiHangItem.XuatLoaiHang((LOAI_HANG)foundItem);
            }
            else
            {
                Console.WriteLine($"Không tồn tại loại hàng với id: {id}");
            }
        }

        public static bool UpdateLoaiHangId(ref CUA_HANG cuaHang, string oldId, string newId)
        {
            bool isSuccess = false;
            
            var foundItemOldId = GetLoaiHangByID(oldId, cuaHang);
            var foundItemNewId = GetLoaiHangByID(newId, cuaHang);
            
            if (foundItemOldId != null && foundItemNewId == null)
            {
                // check xem mã cũ có tồn tại và mã mới ồn tại chưa
                // Chỉ update khi mã cũ đã tồn tại và mã mới chưa tồn tại
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == oldId);
                if(index != -1)
                {
                    LOAI_HANG oldLoaiHang = cuaHang.TatCaLoaiHang[index];
                    cuaHang.TatCaLoaiHang[index] = new LOAI_HANG(newId, oldLoaiHang.TenLoaiHang);
                }
                
                // TODO: Và update tất cả mặt hàng với oldId

                isSuccess = true;

            }

            return isSuccess;
        }

        public static bool UpdateLoaiHangTen(ref CUA_HANG cuaHang, string id, string newName)
        {
            bool isSuccess = false;

            var foundItem = GetLoaiHangByID(id, cuaHang);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == id);
                cuaHang.TatCaLoaiHang[index] = new LOAI_HANG(id, newName);
            }

            return isSuccess;
        }
        public static void ConsoleUpdateLoaiHangId(ref CUA_HANG cuaHang, string oldId, string newId)
        {
            bool updateSuccess = UpdateLoaiHangId(ref cuaHang, oldId, newId);
            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật ID cho loại hàng với ID: {oldId}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID hoặc new ID không hợp lệ");
            }
        }

        public static void ConsoleUpdateLoaiHangTen(ref CUA_HANG cuaHang, string id, string newName)
        {
            bool updateSuccess = UpdateLoaiHangTen(ref cuaHang, id, newName);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật tên cho loại hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }
        public static bool DeleteLoaiHangByID(ref CUA_HANG cuaHang, string id)
        {
            // Chỉ delete khi tôn tại loại hàng với id đó
            // Và không có mặt hàng nào có loại hàng như thế
            bool isSuccess = false;
            
            var foundItem = GetLoaiHangByID(id, cuaHang);
            
            // TODO: Check nếu có bất kì mặt hàng nào thuộc loại hàng với ID = id
            
            if (foundItem != null)
            {
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == id);
                cuaHang.TatCaLoaiHang.RemoveAt(index);
            }

            return isSuccess;
        }

        public static void TimKiemLoaiHang(string options, string needToFindString)
        {
            
        }
    }
}