using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Cthoadon
    {
        public int Stt { get; set; }
        public int MaHoaDon { get; set; }
        public string TenSanPham { get; set; } = null!;
        public string Imei { get; set; } = null!;

        public virtual Ctsanpham ImeiNavigation { get; set; } = null!;
        public virtual Hoadon MaHoaDonNavigation { get; set; } = null!;
        public virtual Sanpham TenSanPhamNavigation { get; set; } = null!;
    }
}
