namespace webbandienthoai.Models
{
    internal class SanphamViewModel
    {
        public string TenSanPham { get; set; }
        public int? SoLuong { get; set; }
        public string BoNho { get; set; }
        public double? GiaBan { get; set; }
        public double? GiaNhap { get; set; }
        public string IMEI { get; set; }
        public string Anh { get; set; }
        public int? MaThuongHieu { get; internal set; }
        public string Ten { get; internal set; }
    }
}