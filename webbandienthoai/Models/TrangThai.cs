using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class TrangThai
    {
        public TrangThai()
        {
            Ctsanphams = new HashSet<Ctsanpham>();
        }

        public bool Id { get; set; }
        public string TenTrangThai { get; set; } = null!;
        public string? Mota { get; set; }

        public virtual ICollection<Ctsanpham> Ctsanphams { get; set; }
    }
}
