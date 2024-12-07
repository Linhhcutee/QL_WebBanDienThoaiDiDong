using System;
using System.Collections.Generic;

namespace webbandienthoai.Models
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Sanphams = new HashSet<Sanpham>();
        }

        public int Id { get; set; }
        public string? Ten { get; set; }
        public string? QuocGia { get; set; }

        public virtual ICollection<Sanpham> Sanphams { get; set; }
    }
}
