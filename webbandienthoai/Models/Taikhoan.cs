using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Hoadons = new HashSet<Hoadon>();
            Phieunhapkhos = new HashSet<Phieunhapkho>();
        }

        public string TenTk { get; set; } = null!;
        public string Mk { get; set; } = null!;
        public string HoDem { get; set; } = null!;
        public string Ten { get; set; } = null!;
        public bool? TrangThai { get; set; }
        public int? VaiTroId { get; set; }

        public virtual VaiTro? VaiTro { get; set; }
        public virtual ICollection<Hoadon> Hoadons { get; set; }
        public virtual ICollection<Phieunhapkho> Phieunhapkhos { get; set; }
    }
}
