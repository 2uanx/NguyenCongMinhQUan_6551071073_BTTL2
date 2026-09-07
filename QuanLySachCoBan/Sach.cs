namespace QuanLySachCoBan
{
    public class Sach
    {
        private string _maSach = string.Empty;
        private string _tenSach = string.Empty;
        private string _tacGia = string.Empty;
        private int _namXuatBan;
        private double _giaBan;

        public string MaSach
        {
            get => _maSach;
        }

        public string TenSach
        {
            get => _tenSach;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên sách không được để trống.");
                }
                _tenSach = value.Trim();
            }
        }

        public string TacGia
        {
            get => _tacGia;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên tác giả không được để trống.");
                }
                _tacGia = value.Trim();
            }
        }

        public int NamXuatBan
        {
            get => _namXuatBan;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                {
                    throw new ArgumentOutOfRangeException(nameof(NamXuatBan), $"Năm xuất bản phải từ 1900 đến {currentYear}.");
                }
                _namXuatBan = value;
            }
        }

        public double GiaBan
        {
            get => _giaBan;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Giá bán không được nhỏ hơn 0.");
                }
                _giaBan = value;
            }
        }

        public Sach()
        {
            _maSach = "MS000";
            _tenSach = "Chưa có tên sách";
            _tacGia = "Khuyết danh";
            _namXuatBan = DateTime.Now.Year;
            _giaBan = 0;
        }

        public Sach(string maSach, string tenSach, string tacGia, int namXuatBan, double giaBan)
        {
            if (string.IsNullOrWhiteSpace(maSach))
            {
                throw new ArgumentException("Mã sách không được để trống.");
            }
            _maSach = maSach.Trim();

            TenSach = tenSach;
            TacGia = tacGia;
            NamXuatBan = namXuatBan;
            GiaBan = giaBan;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine($"| Mã sách      : {MaSach,-45} |");
            Console.WriteLine($"| Tên sách     : {TenSach,-45} |");
            Console.WriteLine($"| Tác giả      : {TacGia,-45} |");
            Console.WriteLine($"| Năm xuất bản : {NamXuatBan,-45} |");
            Console.WriteLine($"| Giá bán      : {GiaBan.ToString("#,##0 VNĐ"),-45} |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public override string ToString()
        {
            return $"[{MaSach}] \"{TenSach}\" - Tác giả: {TacGia} - Năm XB: {NamXuatBan} - Giá: {GiaBan:#,##0} VNĐ";
        }
    }
}
