using System;

namespace QuanLySanPhamCuaHang
{
    public class SanPhamDienTu : SanPham
    {
        // Field private
        private int _baoHanhThang;
        private string _hangSanXuat = string.Empty;

        // Property tương ứng
        public int BaoHanhThang
        {
            get => _baoHanhThang;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Thời gian bảo hành không được nhỏ hơn 0.");
                }
                _baoHanhThang = value;
            }
        }

        public string HangSanXuat
        {
            get => _hangSanXuat;
            set => _hangSanXuat = value;
        }

        // Constructor không tham số gọi base() hỗ trợ Object Initializer
        public SanPhamDienTu() : base()
        {
        }

        // Constructor đầy đủ gọi base()
        public SanPhamDienTu(string maSP, string tenSP, decimal gia, int soLuongTon, int baoHanhThang, string hangSanXuat)
            : base(maSP, tenSP, gia, soLuongTon)
        {
            BaoHanhThang = baoHanhThang;
            HangSanXuat = hangSanXuat;
        }

        // Override TinhGiaBan(): tính thêm 10% phí bảo hành nếu baoHanhThang > 12
        public override decimal TinhGiaBan()
        {
            if (BaoHanhThang > 12)
            {
                return Gia * 1.1m; // Tính thêm 10% phí bảo hành
            }
            return Gia;
        }

        // Override MoTa()
        public override string MoTa()
        {
            string ghiChu = BaoHanhThang > 12 
                ? $"[Bảo hành {BaoHanhThang} tháng -> Phí BH +10%]" 
                : $"[Bảo hành {BaoHanhThang} tháng]";

            return $"[Sản phẩm điện tử  ] Mã: {MaSP,-7} | Tên: {TenSP,-32} | Giá niêm yết: {Gia,12:N0} VNĐ | Hãng SX: {HangSanXuat,-10} {ghiChu,-34} | Tồn kho: {SoLuongTon,3}";
        }
    }
}
