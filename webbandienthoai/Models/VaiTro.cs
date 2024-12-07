using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class VaiTro
    {
        public VaiTro()
        {
            Taikhoans = new HashSet<Taikhoan>();
        }

        public int Id { get; set; }
        public string TenVaiTro { get; set; } = null!;
        public string Mota { get; set; } = null!;

        public virtual ICollection<Taikhoan> Taikhoans { get; set; }
    }
}
