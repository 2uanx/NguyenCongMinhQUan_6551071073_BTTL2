using System.Text;

namespace QuanLySachCoBan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;


            Console.WriteLine("CHƯƠNG TRÌNH");

            Sach sach1 = new Sach(
                maSach: "MS001",
                tenSach: "Dế Mèn Phiêu Lưu Ký",
                tacGia: "Tô Hoài",
                namXuatBan: 1941,
                giaBan: 65000
            );

            Sach sach2 = new Sach();
            sach2.TenSach = "Cho Tôi Xin Một Vé Đi Tuổi Thơ";
            sach2.TacGia = "Nguyễn Nhật Ánh";
            sach2.NamXuatBan = 2008;

            Sach sach3 = new Sach
            {
                TenSach = "Số Đỏ",
                TacGia = "Vũ Trọng Phụng",
                NamXuatBan = 1936
            };

            //2.
            Console.WriteLine(">>>  Thông tin <<<\n");

            Console.WriteLine("--- Sách 1 ---");
            sach1.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {sach1}\n");

            Console.WriteLine("--- Sách 2 ---");
            sach2.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {sach2}\n");

            Console.WriteLine("--- Thông tin ---");
            sach3.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {sach3}\n");

            // 3. 
            Console.WriteLine(">>>  Kiểm tra <<<\n");

            int namHienTai = DateTime.Now.Year;

            // Gán NamXuatBan > HienTai
            Console.WriteLine($"Gán NamXuatBan = {namHienTai + 10} (vượt quá năm hiện tại {namHienTai}):");
            try
            {
                sach1.NamXuatBan = namHienTai + 10;
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán NamXuatBan < 1900
            Console.WriteLine("Gán NamXuatBan = 1850 (trước năm 1900):");
            try
            {
                sach2.NamXuatBan = 1850;
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán TenSach = rỗng
            Console.WriteLine("Gán TenSach = \"   \":");
            try
            {
                sach3.TenSach = "   ";
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán giá trị sau khi bắt ngoại lệ
            Console.WriteLine("Gán NamXuatBan hợp lệ (ví dụ: 2020) cho Sách 1:");
            try
            {
                sach1.NamXuatBan = 2020;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-> Năm xuất bản mới của Sách 1: {sach1.NamXuatBan}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
            Console.WriteLine("KẾT THÚC CHƯƠNG TRÌNH");
        }
    }
}
