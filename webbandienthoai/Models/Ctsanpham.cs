using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Ctsanpham
    {
        public Ctsanpham()
        {
            Chitietpnks = new HashSet<Chitietpnk>();
            Cthoadons = new HashSet<Cthoadon>();
        }

        public int Stt { get; set; }
        public string Imei { get; set; } = null!;
        public bool? TrangThai { get; set; }
        public double? GiaBan { get; set; }
        public string Ten { get; set; } = null!;
        public int Mau { get; set; }

        public virtual Mau MauNavigation { get; set; } = null!;
        public virtual Sanpham TenNavigation { get; set; } = null!;
        public virtual TrangThai? TrangThaiNavigation { get; set; }
        public virtual ICollection<Chitietpnk> Chitietpnks { get; set; }
        public virtual ICollection<Cthoadon> Cthoadons { get; set; }
    }
}
