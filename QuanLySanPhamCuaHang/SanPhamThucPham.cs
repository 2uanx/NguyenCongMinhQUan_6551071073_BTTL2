using System;

namespace QuanLySanPhamCuaHang
{
    public class SanPhamThucPham : SanPham
    {
        // Field private
        private DateTime _ngayHetHan;
        private int _nhietDoBaoQuan;

        // Property tương ứng
        public DateTime NgayHetHan
        {
            get => _ngayHetHan;
            set => _ngayHetHan = value;
        }

        public int NhietDoBaoQuan
        {
            get => _nhietDoBaoQuan;
            set => _nhietDoBaoQuan = value;
        }

        // Constructor không tham số gọi base() hỗ trợ Object Initializer
        public SanPhamThucPham() : base()
        {
        }

        // Constructor đầy đủ gọi base()
        public SanPhamThucPham(string maSP, string tenSP, decimal gia, int soLuongTon, DateTime ngayHetHan, int nhietDoBaoQuan)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            NgayHetHan = ngayHetHan;
            NhietDoBaoQuan = nhietDoBaoQuan;
        }

        // Override TinhGiaBan(): nếu còn 3 ngày hết hạn thì giảm 30%
        public override decimal TinhGiaBan()
        {
            int soNgayConLai = (NgayHetHan.Date - DateTime.Today).Days;
            if (soNgayConLai <= 3)
            {
                return Gia * 0.7m; // Giảm 30%
            }
            return Gia;
        }

        // Override MoTa()
        public override string MoTa()
        {
            int soNgayConLai = (NgayHetHan.Date - DateTime.Today).Days;
            string ghiChu = soNgayConLai <= 3 
                ? $"[Cận date: còn {soNgayConLai} ngày -> Giảm 30%]" 
                : $"[Còn {soNgayConLai} ngày]";

            return $"[Sản phẩm thực phẩm ] Mã: {MaSP,-7} | Tên: {TenSP,-32} | Giá niêm yết: {Gia,12:N0} VNĐ | HSD: {NgayHetHan:dd/MM/yyyy} {ghiChu,-34} | Bảo quản: {NhietDoBaoQuan,2}°C | Tồn kho: {SoLuongTon,3}";
        }
    }
}
