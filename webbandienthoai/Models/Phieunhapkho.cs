using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Phieunhapkho
    {
        public Phieunhapkho()
        {
            Chitietpnks = new HashSet<Chitietpnk>();
        }

        public int Maphieunhapkho { get; set; }
        public string TenNv { get; set; } = null!;
        public string Trangthaitt { get; set; } = null!;
        public DateTime? Thoigian { get; set; }
        public double? Tongtien { get; set; }
        public string? Mota { get; set; }

        public virtual Taikhoan TenNvNavigation { get; set; } = null!;
        public virtual ICollection<Chitietpnk> Chitietpnks { get; set; }
    }
}
