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
        // Apply CRUD Loai hàng
        
        // Hàm xử lý logic
        public static bool ThemLoaiHang(LOAI_HANG newItem, ref CUA_HANG cuaHang)
        {
            bool isSuccess = false;
            var foundItemList = cuaHang.TatCaLoaiHang.Where(st => st.Ma == newItem.Ma).ToList();
            if (!foundItemList.Any())
            {
                cuaHang.TatCaLoaiHang.Add(newItem);
                isSuccess = true;
            }

            return isSuccess;
        }
        public static LOAI_HANG? GetLoaiHangById(string id, CUA_HANG cuaHang)
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

        public static bool UpdateLoaiHangId(ref CUA_HANG cuaHang, string oldId, string newId)
        {
            bool isSuccess = false;
            
            var foundItemOldId = GetLoaiHangById(oldId, cuaHang);
            var foundItemNewId = GetLoaiHangById(newId, cuaHang);
            
            if (foundItemOldId != null && foundItemNewId == null)
            {
                // check xem mã cũ có tồn tại và mã mới ồn tại chưa
                // Chỉ update khi mã cũ đã tồn tại và mã mới chưa tồn tại
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == oldId);
                if(index != -1)
                {
                    LOAI_HANG oldLoaiHang = cuaHang.TatCaLoaiHang[index];
                    cuaHang.TatCaLoaiHang[index] = new LOAI_HANG(newId, oldLoaiHang.TenLoaiHang);
                    
                    // Và update tất cả mặt hàng với oldId
                    foreach (var matHang in cuaHang.TatCaMatHang)
                    {
                        UpdateMatHangLoaiHang(ref cuaHang, matHang.Ma, newId);
                    }
                    
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        public static bool UpdateLoaiHangTen(ref CUA_HANG cuaHang, string id, string newName)
        {
            bool isSuccess = false;

            var foundItem = GetLoaiHangById(id, cuaHang);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    cuaHang.TatCaLoaiHang[index] = new LOAI_HANG(id, newName);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
        
        public static bool DeleteLoaiHangById(ref CUA_HANG cuaHang, string id)
        {
            // Chỉ delete khi tôn tại loại hàng với id đó
            // Và không có mặt hàng nào có loại hàng như thế
            bool isSuccess = false;
            
            var foundLoaiHang = GetLoaiHangById(id, cuaHang);
            var relatedMatHang = cuaHang.TatCaMatHang.Where(st => st.LoaiHang == id).ToList().Any();
            
            // TODO: Check nếu có bất kì mặt hàng nào thuộc loại hàng với ID = id
            if (foundLoaiHang != null && !relatedMatHang)
            {
                int index = cuaHang.TatCaLoaiHang.FindLastIndex(c => c.Ma == id);
                cuaHang.TatCaLoaiHang.RemoveAt(index);
                isSuccess = true;
            }

            return isSuccess;
        }
        
        public static List <LOAI_HANG> TimKiemLoaiHang(CUA_HANG cuaHang, string options, string toFindObject)
        {
            List<LOAI_HANG> result = new List<LOAI_HANG>();
            
            if (options == "id")
            {
                LOAI_HANG? foundItem = GetLoaiHangById(toFindObject, cuaHang);

                if (foundItem != null)
                {
                    result.Add((LOAI_HANG) foundItem);   
                }
            }
            else if (options == "regex")
            {
                var foundItemList = cuaHang.TatCaLoaiHang.Where(st => st.TenLoaiHang.Contains(toFindObject, StringComparison.CurrentCultureIgnoreCase)).ToList();
                foreach (var item in foundItemList)
                {
                    result.Add(item);
                }
            }

            return result;
        }
        
        // Hàm log console
        public static void ShowAllLoaiHang(CUA_HANG cuaHang)
        {
            Console.WriteLine();
            Console.WriteLine("------------------------------");
            Console.WriteLine("Các loại hàng tồn tại trong cửa hàng");
            foreach (var loaiHang in cuaHang.TatCaLoaiHang)
            {
                XL_LoaiHang.XuatLoaiHang(loaiHang);
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

        public static void ConsoleGetLoaiHangById(string id, CUA_HANG cuaHang)
        {
            Console.WriteLine();
            Console.WriteLine($"Tìm kiếm trong cơ sở dữ liệu loại hàng với id: {id}");
            var foundItem = GetLoaiHangById(id, cuaHang);

            if (foundItem != null)
            {
                XL_LoaiHang.XuatLoaiHang((LOAI_HANG)foundItem);
            }
            else
            {
                Console.WriteLine($"Không tồn tại loại hàng với id: {id}");
            }
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

        public static void ConsoleDeleteLoaiHangById(ref CUA_HANG cuaHang, string id)
        {
            bool deleteSuccess = DeleteLoaiHangById(ref cuaHang, id);

            if (deleteSuccess)
            {
                Console.WriteLine($"Loại hàng với ID: {id} đã được xóa khỏi cơ sở dữ liệu");
            }
            else
            {
                Console.WriteLine($"Loại hàng với ID: {id} không thể xóa khỏi cơ sở dữ liêụ");
            }
        }

        public static void ConsoleTimKiemLoaiHang(CUA_HANG cuaHang, string options, string toFindObject)
        {
            List<LOAI_HANG> foundItems = TimKiemLoaiHang(cuaHang, options, toFindObject);

            if (foundItems.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Kết quả tìm kiếm: ");
                XL_LoaiHang.XuatLoaiHangList(foundItems);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Không có loại hàng thỏa điều kiện tìm kiếm");
            }
        }
        
        // Apply CRUD mặt hàng
        
        // Hàm xử lý logic
        public static bool ThemMatHang(ref CUA_HANG cuaHang, MAT_HANG newItem)
        {
            bool isSuccess = false;
            
            // Unique ID
            var foundItemList = cuaHang.TatCaMatHang.Where(c => c.Ma == newItem.Ma).ToList();
            
            // Loại hàng phải tồn tại
            var foundLoaiHang = cuaHang.TatCaLoaiHang.Where(c => c.Ma == newItem.LoaiHang).ToList();

            if (!foundItemList.Any() && foundLoaiHang.Any())
            {
                cuaHang.TatCaMatHang.Add(newItem);
                isSuccess = true;
            }

            return isSuccess;
        }

        public static MAT_HANG? GetMatHangById(CUA_HANG cuaHang, string id)
        {
            var foundItemList = cuaHang.TatCaMatHang.Where(c => c.Ma == id).ToList();
            if (!foundItemList.Any())
            {
                return null;
            }
            else
            {
                return foundItemList[0];
            }
        }

        public static bool UpdateMatHangId(ref CUA_HANG cuaHang, string oldId, string newId)
        {
            bool isSuccess = false;

            var foundItemOldId = GetMatHangById(cuaHang, oldId);
            var foundItemNewId = GetMatHangById(cuaHang, newId);

            if (foundItemOldId != null && foundItemNewId == null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == oldId);

                MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                cuaHang.TatCaMatHang[index] = new MAT_HANG(newId, oldMatHang.TenHang, oldMatHang.HanDung, oldMatHang.CongTySanXuat, oldMatHang.NamSanXuat, oldMatHang.LoaiHang);

                isSuccess = true;
            }

            return isSuccess;
        }

        public static bool UpdateMatHangTen(ref CUA_HANG cuaHang, string id, string newName)
        {
            bool isSuccess = false;

            var foundItem = GetMatHangById(cuaHang, id);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                    cuaHang.TatCaMatHang[index] = new MAT_HANG(id, newName, oldMatHang.HanDung, oldMatHang.CongTySanXuat, oldMatHang.NamSanXuat, oldMatHang.LoaiHang);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        public static bool UpdateMatHangHanDung(ref CUA_HANG cuaHang, string id, DateTime newDate)
        {
            bool isSuccess = false;

            var foundItem = GetMatHangById(cuaHang, id);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                    cuaHang.TatCaMatHang[index] = new MAT_HANG(id, oldMatHang.TenHang, newDate, oldMatHang.CongTySanXuat, oldMatHang.NamSanXuat, oldMatHang.LoaiHang);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
        
        public static bool UpdateMatHangCongTySx(ref CUA_HANG cuaHang, string id, string newCty)
        {
            bool isSuccess = false;

            var foundItem = GetMatHangById(cuaHang, id);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                    cuaHang.TatCaMatHang[index] = new MAT_HANG(id, oldMatHang.TenHang, oldMatHang.HanDung, newCty, oldMatHang.NamSanXuat, oldMatHang.LoaiHang);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
        
        public static bool UpdateMatHangNamSx(ref CUA_HANG cuaHang, string id, int newYear)
        {
            bool isSuccess = false;

            var foundItem = GetMatHangById(cuaHang, id);

            if (foundItem != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                    cuaHang.TatCaMatHang[index] = new MAT_HANG(id, oldMatHang.TenHang, oldMatHang.HanDung, oldMatHang.CongTySanXuat, newYear, oldMatHang.LoaiHang);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }
        
        public static bool UpdateMatHangLoaiHang(ref CUA_HANG cuaHang, string id, string maLoaiHang)
        {
            bool isSuccess = false;

            var foundMatHang = GetMatHangById(cuaHang, id);
            var foundLoaiHang = GetLoaiHangById(maLoaiHang, cuaHang);
            

            if (foundMatHang != null && foundLoaiHang != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);

                if (index != -1)
                {
                    MAT_HANG oldMatHang = cuaHang.TatCaMatHang[index];
                    cuaHang.TatCaMatHang[index] = new MAT_HANG(id, oldMatHang.TenHang, oldMatHang.HanDung, oldMatHang.CongTySanXuat, oldMatHang.NamSanXuat, maLoaiHang);
                    isSuccess = true;
                }
            }

            return isSuccess;
        }

        public static bool DeleteMatHangById(ref CUA_HANG cuaHang, string id)
        {
            bool isSuccess = false;

            var foundMatHang = GetMatHangById(cuaHang, id);
            if (foundMatHang != null)
            {
                int index = cuaHang.TatCaMatHang.FindLastIndex(c => c.Ma == id);
                cuaHang.TatCaMatHang.RemoveAt(index);
                isSuccess = true;
            }

            return isSuccess;
        }

        public static List<MAT_HANG> TimKiemMatHang(CUA_HANG cuaHang, string options, string toFindObject)
        {
            List<MAT_HANG> result = new List<MAT_HANG>();

            if (options == "id")
            {
                MAT_HANG? foundItem = GetMatHangById(cuaHang, toFindObject);

                if (foundItem != null)
                {
                    result.Add((MAT_HANG)foundItem);
                }
            }
            else if (options == "regex")
            {
                var foundItemList = cuaHang.TatCaMatHang
                    .Where(c => c.TenHang.Contains(toFindObject, StringComparison.CurrentCultureIgnoreCase)).ToList();

                foreach (var matHang in foundItemList)
                {
                    result.Add(matHang);
                }
            }

            return result;
        }

        public static void ConsoleThemMatHang(ref CUA_HANG cuaHang, MAT_HANG newItem)
        {
            bool isSuccess = ThemMatHang(ref cuaHang, newItem);

            if (isSuccess)
            {
                Console.WriteLine("Mặt hàng với ID phù hợp");
                Console.WriteLine("Mặt hàng thêm vào cơ sở dữ liệu thành công");
            }
            else
            {
                Console.WriteLine("Không thể thêm mặt hàng do ID / loại hàng không hợp lệ");
                Console.WriteLine("Mặt hàng không được thêm vào cơ sở dữ liệu");
            }
        }

        public static void ConsoleGetMatHangById(CUA_HANG cuaHang, string id)
        {
            Console.WriteLine();
            Console.WriteLine($"Tìm kiếm trong cơ sở dữ liệu mặt hàng với ID: {id}");
            var foundItem = GetMatHangById(cuaHang, id);

            if (foundItem != null)
            {
                XL_MatHang.XuatMatHang((MAT_HANG)foundItem);
            }
            else
            {
                Console.WriteLine($"Không tồn tại mặt hàng với ID: {id}");
            }
        }
        
        public static void ConsoleUpdateMatHangId(ref CUA_HANG cuaHang, string oldId, string newId)
        {
            bool updateSuccess = UpdateMatHangId(ref cuaHang, oldId, newId);
            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật ID cho mặt hàng với ID: {oldId}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID hoặc new ID không hợp lệ");
            }
        }
        
        public static void ConsoleUpdateMatHangTen(ref CUA_HANG cuaHang, string id, string newName)
        {
            bool updateSuccess = UpdateMatHangTen(ref cuaHang, id, newName);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật tên cho mặt hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }
        
        public static void ConsoleUpdateMatHangHanDung(ref CUA_HANG cuaHang, string id, DateTime newHanDung)
        {
            bool updateSuccess = UpdateMatHangHanDung(ref cuaHang, id, newHanDung);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật hạn dùng cho mặt hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }
        
        public static void ConsoleUpdateMatHangCongTySanXuat(ref CUA_HANG cuaHang, string id, string newManufacture)
        {
            bool updateSuccess = UpdateMatHangCongTySx(ref cuaHang, id, newManufacture);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật công ty sản xuất cho mặt hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }
        
        public static void ConsoleUpdateMatHangNamSanXuatt(ref CUA_HANG cuaHang, string id, int newYear)
        {
            bool updateSuccess = UpdateMatHangNamSx(ref cuaHang, id, newYear);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật năm sản xuất cho mặt hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }
        
        public static void ConsoleUpdateMatHangLoaiHang(ref CUA_HANG cuaHang, string id, string newLoaiHang)
        {
            bool updateSuccess = UpdateMatHangLoaiHang(ref cuaHang, id, newLoaiHang);

            if (updateSuccess)
            {
                Console.WriteLine($"Cập nhật loaị hàng cho mặt hàng với ID: {id}");
            }
            else
            {
                Console.WriteLine("Không thể Update vì ID không hợp lệ");
            }
        }

        public static void ConsoleDeleteMatHangById(ref CUA_HANG cuaHang, string id)
        {
            bool deleteSuccess = DeleteMatHangById(ref cuaHang, id);

            if (deleteSuccess)
            {
                Console.WriteLine($"Mặt hàng với ID: {id} đã được xóa khỏi cơ sở dữ liệu");
            }
            else
            {
                Console.WriteLine($"Mặt hàng với ID: {id} không thể xóa khỏi cơ sở dữ liệu");
            }
        }
        
        public static void ConsoleTimKiemMatHang(CUA_HANG cuaHang, string options, string toFindObject)
        {
            List<MAT_HANG> foundItems = TimKiemMatHang(cuaHang, options, toFindObject);

            if (foundItems.Any())
            {
                Console.WriteLine();
                Console.WriteLine("Kết quả tìm kiếm: ");
                XL_MatHang.XuatMatHangList(foundItems);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Không có loại hàng thỏa điều kiện tìm kiếm");
            }
        }
    }
}