using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Mau
    {
        public Mau()
        {
            Ctsanphams = new HashSet<Ctsanpham>();
        }

        public int Id { get; set; }
        public string TenMau { get; set; } = null!;
        public string MaHex { get; set; } = null!;
        public string? MoTa { get; set; }

        public virtual ICollection<Ctsanpham> Ctsanphams { get; set; }
    }
}
