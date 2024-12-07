using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webbandienthoai.Models
{
    public partial class QL_DienThoaiDiDongWebContext : DbContext
    {
        public QL_DienThoaiDiDongWebContext()
        {
        }

        public QL_DienThoaiDiDongWebContext(DbContextOptions<QL_DienThoaiDiDongWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chitietpnk> Chitietpnks { get; set; } = null!;
        public virtual DbSet<Cthoadon> Cthoadons { get; set; } = null!;
        public virtual DbSet<Ctsanpham> Ctsanphams { get; set; } = null!;
        public virtual DbSet<Hoadon> Hoadons { get; set; } = null!;
        public virtual DbSet<LoaiSp> LoaiSps { get; set; } = null!;
        public virtual DbSet<Mau> Maus { get; set; } = null!;
        public virtual DbSet<Phieunhapkho> Phieunhapkhos { get; set; } = null!;
        public virtual DbSet<Sanpham> Sanphams { get; set; } = null!;
        public virtual DbSet<Taikhoan> Taikhoans { get; set; } = null!;
        public virtual DbSet<Thuonghieu> Thuonghieus { get; set; } = null!;
        public virtual DbSet<TrangThai> TrangThais { get; set; } = null!;
        public virtual DbSet<VaiTro> VaiTros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QL_DienThoaiDiDongWeb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chitietpnk>(entity =>
            {
                entity.HasKey(e => e.Machitietpnk)
                    .HasName("PK__CHITIETP__5306D335B1A3051E");

                entity.ToTable("CHITIETPNK");

                entity.HasIndex(e => new { e.TenSanPham, e.Maphieunhap }, "CTTIET_PNK_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Machitietpnk).HasColumnName("MACHITIETPNK");

                entity.Property(e => e.Ghichu)
                    .HasMaxLength(255)
                    .HasColumnName("GHICHU");

                entity.Property(e => e.LoaiSp).HasColumnName("LoaiSP");

                entity.Property(e => e.Maphieunhap).HasColumnName("MAPHIEUNHAP");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.HasOne(d => d.LoaiSpNavigation)
                    .WithMany(p => p.Chitietpnks)
                    .HasForeignKey(d => d.LoaiSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHITIETPNK_LoaiSP");

                entity.HasOne(d => d.LoaiSp1)
                    .WithMany(p => p.Chitietpnks)
                    .HasForeignKey(d => d.LoaiSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPN__LoaiS__5BE2A6F2");

                entity.HasOne(d => d.MaphieunhapNavigation)
                    .WithMany(p => p.Chitietpnks)
                    .HasForeignKey(d => d.Maphieunhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPN__MAPHI__5CD6CB2B");

                entity.HasOne(d => d.TenSanPhamNavigation)
                    .WithMany(p => p.Chitietpnks)
                    .HasForeignKey(d => d.TenSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CHITIETPN__TenSa__5DCAEF64");
            });

            modelBuilder.Entity<Cthoadon>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__CTHOADON__CA1EB69059D32853");

                entity.ToTable("CTHOADON");

                entity.Property(e => e.Stt).HasColumnName("STT");

                entity.Property(e => e.Imei)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IMEI");

                entity.Property(e => e.TenSanPham).HasMaxLength(100);

                entity.HasOne(d => d.ImeiNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasPrincipalKey(p => p.Imei)
                    .HasForeignKey(d => d.Imei)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__IMEI__43D61337");

                entity.HasOne(d => d.MaHoaDonNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.MaHoaDon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__MaHoaD__41EDCAC5");

                entity.HasOne(d => d.TenSanPhamNavigation)
                    .WithMany(p => p.Cthoadons)
                    .HasForeignKey(d => d.TenSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTHOADON__TenSan__42E1EEFE");
            });

            modelBuilder.Entity<Ctsanpham>(entity =>
            {
                entity.HasKey(e => e.Stt)
                    .HasName("PK__CTSANPHA__CA1EB690270FD654");

                entity.ToTable("CTSANPHAM");

                entity.HasIndex(e => e.Imei, "UQ__CTSANPHA__8DF371FDF01F7E43")
                    .IsUnique();

                entity.Property(e => e.Stt).HasColumnName("STT");

                entity.Property(e => e.Imei)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IMEI");

                entity.Property(e => e.Mau).HasDefaultValueSql("((1))");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.TrangThai).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.MauNavigation)
                    .WithMany(p => p.Ctsanphams)
                    .HasForeignKey(d => d.Mau)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTSANPHAM_Mau");

                entity.HasOne(d => d.TenNavigation)
                    .WithMany(p => p.Ctsanphams)
                    .HasForeignKey(d => d.Ten)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CTSANPHAM__Ten__619B8048");

                entity.HasOne(d => d.TrangThaiNavigation)
                    .WithMany(p => p.Ctsanphams)
                    .HasForeignKey(d => d.TrangThai)
                    .HasConstraintName("FK_CTSANPHAM_TrangThai");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.MaHoaDon)
                    .HasName("PK__HOADON__835ED13B72C7FCC6");

                entity.ToTable("HOADON");

                entity.Property(e => e.GhiChu).HasMaxLength(255);

                entity.Property(e => e.MaTaiKhoan).HasMaxLength(30);

                entity.Property(e => e.NgayLap)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaTaiKhoanNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.MaTaiKhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MaTaiKho__628FA481");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.ToTable("LoaiSP");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mota)
                    .HasMaxLength(255)
                    .HasColumnName("mota");

                entity.Property(e => e.Tenloai)
                    .HasMaxLength(20)
                    .HasColumnName("tenloai");
            });

            modelBuilder.Entity<Mau>(entity =>
            {
                entity.ToTable("Mau");

                entity.Property(e => e.MaHex).HasMaxLength(7);

                entity.Property(e => e.MoTa).HasMaxLength(255);

                entity.Property(e => e.TenMau).HasMaxLength(30);
            });

            modelBuilder.Entity<Phieunhapkho>(entity =>
            {
                entity.HasKey(e => e.Maphieunhapkho)
                    .HasName("PK__PHIEUNHA__EC80695641103669");

                entity.ToTable("PHIEUNHAPKHO");

                entity.Property(e => e.Maphieunhapkho).HasColumnName("MAPHIEUNHAPKHO");

                entity.Property(e => e.Mota)
                    .HasMaxLength(255)
                    .HasColumnName("MOTA");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(30)
                    .HasColumnName("TenNV");

                entity.Property(e => e.Thoigian)
                    .HasColumnType("datetime")
                    .HasColumnName("THOIGIAN")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

                entity.Property(e => e.Trangthaitt)
                    .HasMaxLength(50)
                    .HasColumnName("TRANGTHAITT");

                entity.HasOne(d => d.TenNvNavigation)
                    .WithMany(p => p.Phieunhapkhos)
                    .HasForeignKey(d => d.TenNv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PHIEUNHAP__TenNV__6383C8BA");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Ten)
                    .HasName("PK__SANPHAM__C451FA82F6D8BCD0");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Ten).HasMaxLength(100);

                entity.Property(e => e.Anh).HasMaxLength(50);

                entity.Property(e => e.BoNho)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Camera)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Cpu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CPU");

                entity.Property(e => e.ManHinh)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ram)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.HasOne(d => d.MaThuongHieuNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.MaThuongHieu)
                    .HasConstraintName("FK__SANPHAM__MaThuon__6477ECF3");
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.TenTk)
                    .HasName("PK__TAIKHOAN__4CF9E776F9F3BA27");

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.TenTk)
                    .HasMaxLength(30)
                    .HasColumnName("TenTK");

                entity.Property(e => e.HoDem).HasMaxLength(50);

                entity.Property(e => e.Mk)
                    .HasMaxLength(100)
                    .HasColumnName("MK");

                entity.Property(e => e.Ten).HasMaxLength(20);

                entity.Property(e => e.TrangThai)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.VaiTro)
                    .WithMany(p => p.Taikhoans)
                    .HasForeignKey(d => d.VaiTroId)
                    .HasConstraintName("FK_Taikhoan_VaiTro");
            });

            modelBuilder.Entity<Thuonghieu>(entity =>
            {
                entity.ToTable("THUONGHIEU");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.QuocGia).HasMaxLength(30);

                entity.Property(e => e.Ten).HasMaxLength(25);
            });

            modelBuilder.Entity<TrangThai>(entity =>
            {
                entity.ToTable("TrangThai");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TenTrangThai).HasMaxLength(20);
            });

            modelBuilder.Entity<VaiTro>(entity =>
            {
                entity.ToTable("VaiTro");

                entity.Property(e => e.Mota).HasMaxLength(255);

                entity.Property(e => e.TenVaiTro).HasMaxLength(25);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
