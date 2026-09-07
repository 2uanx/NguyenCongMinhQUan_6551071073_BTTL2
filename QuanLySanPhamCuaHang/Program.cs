using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySanPhamCuaHang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine(">>> 1. KHỞI TẠO  <<<\n");

            List<SanPham> danhSachSanPham = new List<SanPham>
            {
                new SanPham
                {
                    MaSP = "SP001",
                    TenSP = "Bình giữ nhiệt inox Lock&Lock 500ml",
                    Gia = 250_000m,
                    SoLuongTon = 30
                },
                new SanPhamThucPham
                {
                    MaSP = "TP001",
                    TenSP = "Sữa chua tiệt trùng TH True Milk",
                    Gia = 40_000m,
                    SoLuongTon = 50,
                    NgayHetHan = DateTime.Today.AddDays(2),
                    NhietDoBaoQuan = 4
                },
                new SanPhamThucPham
                {
                    MaSP = "TP002",
                    TenSP = "Gạo thơm ST25 túi 5kg",
                    Gia = 180_000m,
                    SoLuongTon = 25,
                    NgayHetHan = DateTime.Today.AddDays(180),
                    NhietDoBaoQuan = 25
                },
                new SanPhamDienTu
                {
                    MaSP = "DT001",
                    TenSP = "Điện thoại Samsung Galaxy S24 Ultra",
                    Gia = 24_000_000m,
                    SoLuongTon = 10,
                    BaoHanhThang = 24,
                    HangSanXuat = "Samsung"
                },
                new SanPhamDienTu
                {
                    MaSP = "DT002",
                    TenSP = "Tai nghe không dây Xiaomi Buds 5",
                    Gia = 800_000m,
                    SoLuongTon = 40,
                    BaoHanhThang = 12,
                    HangSanXuat = "Xiaomi"
                }
            };

            Console.WriteLine($"Đã khởi tạo thành công {danhSachSanPham.Count} sản phẩm thuộc 3 lớp khác nhau vào List<SanPham>.\n");

            Console.WriteLine(">>> 2. XUẤT THÔNG TIN VÀ GIÁ BÁN <<<");
            int stt = 1;
            foreach (SanPham sp in danhSachSanPham)
            {
                Console.WriteLine($"--- [{stt++}] Sản phẩm: {sp.TenSP} ({sp.MaSP}) ---");
                
                Console.WriteLine($"Mô tả: {sp.MoTa()}");

                decimal giaBan = sp.TinhGiaBan();
                Console.WriteLine($"Giá niêm yết: {sp.Gia,12:N0} VNĐ");
                Console.WriteLine($"Giá bán thực tế: {giaBan,10:N0} VNĐ");

                if (sp is SanPhamThucPham tp)
                {
                    int soNgayConLai = (tp.NgayHetHan.Date - DateTime.Today).Days;
                    if (soNgayConLai <= 3)
                    {
                        Console.WriteLine($"-> Ghi chú đa hình: Thực phẩm còn {soNgayConLai} ngày hết hạn (<= 3 ngày) => Đã giảm 30% ({sp.Gia:N0} -> {giaBan:N0} VNĐ)");
                    }
                    else
                    {
                        Console.WriteLine($"-> Ghi chú đa hình: Thực phẩm còn {soNgayConLai} ngày (> 3 ngày) => Giữ nguyên giá niêm yết.");
                    }
                }
                else if (sp is SanPhamDienTu dt)
                {
                    if (dt.BaoHanhThang > 12)
                    {
                        Console.WriteLine($"-> Ghi chú đa hình: Điện tử bảo hành {dt.BaoHanhThang} tháng (> 12 tháng) => Cộng thêm 10% phí bảo hành ({sp.Gia:N0} -> {giaBan:N0} VNĐ)");
                    }
                    else
                    {
                        Console.WriteLine($"-> Ghi chú đa hình: Điện tử bảo hành {dt.BaoHanhThang} tháng (<= 12 tháng) => Giữ nguyên giá niêm yết.");
                    }
                }
                else
                {
                    Console.WriteLine("-> Ghi chú đa hình: Sản phẩm cơ bản (SanPham) => Giá bán bằng đúng giá gốc.");
                }

                Console.WriteLine();
            }

            Console.WriteLine(">>> 3. TỔNG GIÁ TRỊ KHO HÀNG<<<");

            decimal tongGiaTriKhoHang = 0;

            Console.WriteLine($"{"Mã SP",-8} | {"Tên sản phẩm",-38} | {"Đơn giá (VNĐ)",15} | {"Tồn kho",8} | {"Thành tiền (VNĐ)",18}");
            Console.WriteLine(new string('-', 96));

            foreach (SanPham sp in danhSachSanPham)
            {
                decimal thanhTien = sp.Gia * sp.SoLuongTon;
                tongGiaTriKhoHang += thanhTien;

                Console.WriteLine($"{sp.MaSP,-8} | {sp.TenSP,-38} | {sp.Gia,15:N0} | {sp.SoLuongTon,8} | {thanhTien,18:N0}");
            }

            Console.WriteLine($"TỔNG CỘNG GIÁ TRỊ KHO HÀNG: {tongGiaTriKhoHang,68:N0} VNĐ\n");

            }
    }
}
