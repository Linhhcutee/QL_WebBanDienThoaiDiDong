using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Cthoadons = new HashSet<Cthoadon>();
        }

        public int MaHoaDon { get; set; }
        public string MaTaiKhoan { get; set; } = null!;
        public DateTime? NgayLap { get; set; }
        public double TongTien { get; set; }
        public string? GhiChu { get; set; }

        public virtual Taikhoan MaTaiKhoanNavigation { get; set; } = null!;
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
