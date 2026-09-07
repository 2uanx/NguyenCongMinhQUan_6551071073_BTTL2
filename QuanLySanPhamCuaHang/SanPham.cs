namespace QuanLySanPhamCuaHang
{
    public class SanPham
    {
        // Field private
        private string _maSP = string.Empty;
        private string _tenSP = string.Empty;
        private decimal _gia;
        private int _soLuongTon;

        // Property tương ứng
        public string MaSP
        {
            get => _maSP;
            set => _maSP = value;
        }

        public string TenSP
        {
            get => _tenSP;
            set => _tenSP = value;
        }

        public decimal Gia
        {
            get => _gia;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Giá sản phẩm không được nhỏ hơn 0.");
                }
                _gia = value;
            }
        }

        public int SoLuongTon
        {
            get => _soLuongTon;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số lượng tồn không được nhỏ hơn 0.");
                }
                _soLuongTon = value;
            }
        }

        // Constructor không tham số hỗ trợ Object Initializer
        public SanPham()
        {
        }

        // Constructor đầy đủ
        public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
        {
            MaSP = maSP;
            TenSP = tenSP;
            Gia = gia;
            SoLuongTon = soLuongTon;
        }

        // Phương thức virtual tính giá bán (mặc định trả về giá niêm yết)
        public virtual decimal TinhGiaBan()
        {
            return _gia;
        }

        // Phương thức virtual mô tả thông tin sản phẩm
        public virtual string MoTa()
        {
            return $"[Sản phẩm thông thường] Mã: {MaSP,-7} | Tên: {TenSP,-32} | Giá niêm yết: {Gia,12:N0} VNĐ | Tồn kho: {SoLuongTon,3}";
        }
    }
}
