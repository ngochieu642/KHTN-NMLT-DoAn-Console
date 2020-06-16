using System;

namespace DoAnMonHoc
{
    public class XL_Console
    {
        public static string NhapInputString(string message)
        {
            string result = null;

            while (result == null)
            {
                Console.Write($"{message}: ");
                result = Console.ReadLine();
            }

            return result;
        }
        
        public static int NhapInputInt(string message)
        {
            int result = new int();
            bool isValidInput = false;

            while (!isValidInput)
            {
                try
                {
                    Console.Write($"{message}: ");
                    result = int.Parse(Console.ReadLine());
                    isValidInput = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Input không hợp lệ, vui lòng nhập lại");
                }
            }
            return result;
        }
        
        public static DateTime NhapNgayHetHan()
        {
            bool isValidDate = false;
            DateTime result = new DateTime();
            
            Console.WriteLine();
            Console.WriteLine("Nhập Ngày Hết Hạn");

            while (!isValidDate)
            {
                try
                {
                    int nam = XL_Console.NhapInputInt("Nhập năm");
                    int thang = XL_Console.NhapInputInt("Nhập tháng");
                    int ngay = XL_Console.NhapInputInt("Nhập ngày");

                    result = new DateTime(nam, thang, ngay);

                    isValidDate = true;
                }
                catch (Exception e)
                {
                    // Console.WriteLine("{0} Exception caught.", e);
                    Console.WriteLine("Ngày tháng vừa nhập không hợp lệ, vui lòng nhập lại");
                }
            }

            return result;
        }
    }
}