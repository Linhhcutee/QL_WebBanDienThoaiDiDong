using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            Chitietpnks = new HashSet<Chitietpnk>();
        }

        public int Id { get; set; }
        public string Tenloai { get; set; } = null!;
        public string? Mota { get; set; }

        public virtual ICollection<Chitietpnk> Chitietpnks { get; set; }
    }
}
