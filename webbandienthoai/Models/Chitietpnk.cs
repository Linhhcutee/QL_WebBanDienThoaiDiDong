using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Chitietpnk
    {
        public int Machitietpnk { get; set; }
        public string TenSanPham { get; set; } = null!;
        public int Maphieunhap { get; set; }
        public int Soluong { get; set; }
        public string? Ghichu { get; set; }
        public int LoaiSp { get; set; }
        public double? GiaNhap { get; set; }

        public virtual Ctsanpham LoaiSp1 { get; set; } = null!;
        public virtual LoaiSp LoaiSpNavigation { get; set; } = null!;
        public virtual Phieunhapkho MaphieunhapNavigation { get; set; } = null!;
        public virtual Sanpham TenSanPhamNavigation { get; set; } = null!;
    }
}
