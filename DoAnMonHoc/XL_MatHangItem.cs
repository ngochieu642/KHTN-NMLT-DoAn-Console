using System;

namespace DoAnMonHoc
{
    public struct MAT_HANG
    {
        public string Ma;
        public string TenHang;
        public DateTime HanDung;
        public string CongTySanXuat;
        public int NamSanXuat;
        public string LoaiHang;
    }
    public class XL_MatHangItem
    {
        public MAT_HANG TaoMatHang()
        {
            MAT_HANG result = new MAT_HANG();
            Console.WriteLine("Nhập mặt hàng");
            
            // Nhập mã
            Console.Write("Nhập mã mặt hàng: ");
            result.Ma = Console.ReadLine();
            
            // Nhập tên mặt hàng
            Console.Write("Nhập tên mặt hàng");
            result.TenHang = Console.ReadLine();
            
            // Nhập hạn dùng
            bool isValidDate = false;

            while (!isValidDate)
            {
                try
                {
                    Console.Write("Nhập năm hết hạn");
                    int namHetHan = int.Parse(Console.ReadLine());
                    
                    Console.Write("Nhập tháng hết hạn");
                    int thangHetHan = int.Parse(Console.ReadLine());
                    
                    Console.Write("Nhập ngày hết hạn");
                    int ngayHetHan = int.Parse(Console.ReadLine());
                    
                    result.HanDung = new DateTime(namHetHan, thangHetHan, ngayHetHan);
                    
                    // Set cờ
                    isValidDate = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                }
            }
            
            // Mặt hàng
            return result;
        }
    }
}