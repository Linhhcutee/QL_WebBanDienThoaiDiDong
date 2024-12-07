using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Chitietpnks = new HashSet<Chitietpnk>();
            Cthoadons = new HashSet<Cthoadon>();
            Ctsanphams = new HashSet<Ctsanpham>();
        }

        public string Ten { get; set; } = null!;
        public string? Anh { get; set; }
        public int? Sl { get; set; }
        public string? BoNho { get; set; }
        public string? Ram { get; set; }
        public string? Cpu { get; set; }
        public string? ManHinh { get; set; }
        public string? Camera { get; set; }
        public string? Pin { get; set; }
        public string? MoTa { get; set; }
        public int? MaThuongHieu { get; set; }

        public virtual Thuonghieu? MaThuongHieuNavigation { get; set; }
        public virtual ICollection<Chitietpnk> Chitietpnks { get; set; }
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
        public virtual ICollection<Ctsanpham> Ctsanphams { get; set; }
    }
}
