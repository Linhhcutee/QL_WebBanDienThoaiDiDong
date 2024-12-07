namespace webbandienthoai.Models
{
    public class NhapPhieuKhoViewModel
    {
        public Phieunhapkho PhieuNhap { get; set; }
        public List<Chitietpnk> ChiTietNhap { get; set; } = new List<Chitietpnk>();
    }
}
