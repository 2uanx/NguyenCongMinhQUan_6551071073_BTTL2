namespace TinhLuongNhanVien
{
    public class NhanVien
    {
        private string _maNV = string.Empty;
        private string _hoTen = string.Empty;
        private decimal _luongCoBan;
        private int _soNgayLam;
        private int _soNgayNghiPhep;

        public string MaNV
        {
            get => _maNV;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mã nhân viên không được để trống.");
                }
                _maNV = value.Trim();
            }
        }

        public string HoTen
        {
            get => _hoTen;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Họ tên không được để trống.");
                }
                _hoTen = value.Trim();
            }
        }

        public decimal LuongCoBan
        {
            get => _luongCoBan;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Lương cơ bản không được nhỏ hơn 0.");
                }
                _luongCoBan = value;
            }
        }

        public int SoNgayLam
        {
            get => _soNgayLam;
            set
            {
                if (value < 0 || value > 31)
                {
                    throw new ArgumentOutOfRangeException(nameof(SoNgayLam), "Số ngày làm phải từ 0 đến 31.");
                }
                _soNgayLam = value;
            }
        }

        public int SoNgayNghiPhep
        {
            get => _soNgayNghiPhep;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Số ngày nghỉ phép không được nhỏ hơn 0.");
                }
                _soNgayNghiPhep = value;
            }
        }

        public decimal LuongThucNhan
        {
            get
            {
                decimal khauTruBHXH = _luongCoBan * 0.08m;
                return (_luongCoBan / 26m) * _soNgayLam - khauTruBHXH;
            }
        }

        public NhanVien()
        {
            _maNV = "NV000";
            _hoTen = "Chưa có tên";
            _luongCoBan = 0m;
            _soNgayLam = 0;
            _soNgayNghiPhep = 0;
        }

        public NhanVien(string maNV, string hoTen)
        {
            MaNV = maNV;
            HoTen = hoTen;
            _luongCoBan = 0m;
            _soNgayLam = 0;
            _soNgayNghiPhep = 0;
        }

        public NhanVien(string maNV, string hoTen, decimal luongCoBan, int soNgayLam, int soNgayNghiPhep)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan;
            SoNgayLam = soNgayLam;
            SoNgayNghiPhep = soNgayNghiPhep;
        }

        public NhanVien(string maNV, string hoTen, decimal luong = 5_000_000m, int soNgayLam = 26)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luong;
            SoNgayLam = soNgayLam;
            _soNgayNghiPhep = 0;
        }

        public decimal TinhThuong()
        {
            return 0m;
        }

        public decimal TinhThuong(decimal heSo)
        {
            return LuongCoBan * heSo;
        }

        public decimal TinhThuong(decimal heSo, bool coPhucLoi)
        {
            decimal thuong = LuongCoBan * heSo;
            if (coPhucLoi)
            {
                thuong += 500_000m;
            }
            return thuong;
        }

        public void HienThiThongTin()
        {
            Console.WriteLine("+--------------------------------------------------------------+");
            Console.WriteLine($"| Mã nhân viên  : {MaNV,-44} |");
            Console.WriteLine($"| Họ và tên     : {HoTen,-44} |");
            Console.WriteLine($"| Lương cơ bản  : {LuongCoBan.ToString("#,##0 VNĐ"),-44} |");
            Console.WriteLine($"| Số ngày làm   : {SoNgayLam,-44} |");
            Console.WriteLine($"| Nghỉ phép     : {SoNgayNghiPhep,-44} |");
            Console.WriteLine($"| Thực nhận     : {LuongThucNhan.ToString("#,##0 VNĐ"),-44} |");
            Console.WriteLine("+--------------------------------------------------------------+");
        }

        public override string ToString()
        {
            return $"[{MaNV}] {HoTen} - Lương CB: {LuongCoBan:#,##0} VNĐ - Ngày làm: {SoNgayLam} - Thực nhận: {LuongThucNhan:#,##0} VNĐ";
        }
    }
}
