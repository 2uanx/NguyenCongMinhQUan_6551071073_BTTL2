using System.Text;

namespace TinhLuongNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine("CHƯƠNG TRÌNH TÍNH LƯƠNG NHÂN VIÊN");
            Console.WriteLine(">>> 1. Khởi tạo <<<\n");

            Console.WriteLine("Cách 1: Constructor đầy đủ tham số");
            NhanVien nv1 = new NhanVien("NV001", "Nguyễn Văn An", 15_000_000m, 25, 1);
            Console.WriteLine("Đã tạo.\n");

            Console.WriteLine("Cách 2: Constructor chỉ nhận mã NV và họ tên");
            NhanVien nv2 = new NhanVien("NV002", "Trần Thị Bình");
            nv2.LuongCoBan = 12_000_000m;
            nv2.SoNgayLam = 26;
            nv2.SoNgayNghiPhep = 0;
            Console.WriteLine("Đã tạo.\n");

            Console.WriteLine("Cách 3: Constructor Optional Parameters với Named Arguments");
            NhanVien nv3 = new NhanVien(maNV: "NV003", hoTen: "Lê Hoàng Cường", soNgayLam: 20);
            Console.WriteLine("Đã tạo.\n");

            // 2. Thông tin
            Console.WriteLine(">>> 2. Thông tin <<<\n");

            Console.WriteLine("--- Nhân viên 1 ---");
            nv1.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {nv1}\n");

            Console.WriteLine("--- Nhân viên 2 ---");
            nv2.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {nv2}\n");

            Console.WriteLine("--- Nhân viên 3 ---");
            nv3.HienThiThongTin();
            Console.WriteLine($"Tóm tắt: {nv3}\n");

            // 3. Tính thưởng và so sánh
            Console.WriteLine(">>> 3. Tính thưởng và so sánh <<<\n");
            Console.WriteLine($"Xét nhân viên: {nv1.HoTen} (Lương cơ bản: {nv1.LuongCoBan:#,##0} VNĐ)\n");

            decimal thuong1 = nv1.TinhThuong();
            decimal thuong2 = nv1.TinhThuong(1.5m);
            decimal thuong3KhongPhucLoi = nv1.TinhThuong(1.5m, coPhucLoi: false);
            decimal thuong3CoPhucLoi = nv1.TinhThuong(1.5m, coPhucLoi: true);

            Console.WriteLine("+-------------------------------------------------------------------------+");
            Console.WriteLine("| Phương thức gọi                                      | Tiền thưởng      |");
            Console.WriteLine("+-------------------------------------------------------------------------+");
            Console.WriteLine($"| 1. TinhThuong()                                      | {thuong1.ToString("#,##0 VNĐ"),-16} |");
            Console.WriteLine($"| 2. TinhThuong(heSo: 1.5)                             | {thuong2.ToString("#,##0 VNĐ"),-16} |");
            Console.WriteLine($"| 3. TinhThuong(heSo: 1.5, coPhucLoi: false)           | {thuong3KhongPhucLoi.ToString("#,##0 VNĐ"),-16} |");
            Console.WriteLine($"| 4. TinhThuong(heSo: 1.5, coPhucLoi: true)            | {thuong3CoPhucLoi.ToString("#,##0 VNĐ"),-16} |");
            Console.WriteLine("+-------------------------------------------------------------------------+");

            Console.WriteLine();
            Console.WriteLine("So sánh kết quả:");
            Console.WriteLine($"- Không tham số: {thuong1:#,##0} VNĐ");
            Console.WriteLine($"- Có hệ số 1.5: {thuong2:#,##0} VNĐ");
            Console.WriteLine($"- Có hệ số 1.5 + phúc lợi: {thuong3CoPhucLoi:#,##0} VNĐ (chênh lệch +{(thuong3CoPhucLoi - thuong2):#,##0} VNĐ)");
            Console.WriteLine();

            // 4. Kiểm tra Validation
            Console.WriteLine(">>> 4. Kiểm tra <<<\n");

            // Gán LuongCoBan < 0
            Console.WriteLine("Gán LuongCoBan = -1,000,000:");
            try
            {
                nv1.LuongCoBan = -1_000_000m;
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán SoNgayLam ngoài khoảng 0-31
            Console.WriteLine("Gán SoNgayLam = 35 (ngoài khoảng 0 - 31):");
            try
            {
                nv2.SoNgayLam = 35;
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán HoTen = rỗng
            Console.WriteLine("Gán HoTen = \"   \":");
            try
            {
                nv3.HoTen = "   ";
                Console.WriteLine("Gán thành công (Lỗi: Vi phạm)");
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-> Bắt ngoại lệ: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine();

            // Gán giá trị hợp lệ sau khi kiểm tra
            Console.WriteLine("Gán LuongCoBan hợp lệ (ví dụ: 18,000,000 VNĐ) cho NV1:");
            try
            {
                nv1.LuongCoBan = 18_000_000m;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"-> Lương cơ bản mới của NV1: {nv1.LuongCoBan:#,##0} VNĐ");
                Console.WriteLine($"-> Lương thực nhận mới: {nv1.LuongThucNhan:#,##0} VNĐ");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }

            Console.WriteLine("\nKẾT THÚC CHƯƠNG TRÌNH");
        }
    }
}
