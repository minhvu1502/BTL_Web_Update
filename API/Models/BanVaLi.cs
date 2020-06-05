namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BanVaLi : DbContext
    {
        public BanVaLi()
            : base("name=BanVaLi")
        {
        }

        public virtual DbSet<tAnhSP> tAnhSP { get; set; }
        public virtual DbSet<tChatLieu> tChatLieu { get; set; }
        public virtual DbSet<tDanhMucSP> tDanhMucSP { get; set; }
        public virtual DbSet<tHangSX> tHangSX { get; set; }
        public virtual DbSet<tKichThuoc> tKichThuoc { get; set; }
        public virtual DbSet<tLoaiDT> tLoaiDT { get; set; }
        public virtual DbSet<tLoaiSP> tLoaiSP { get; set; }
        public virtual DbSet<tQuocGia> tQuocGia { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tAnhSP>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tAnhSP>()
                .Property(e => e.TenFileAnh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tChatLieu>()
                .Property(e => e.MaChatLieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaSP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaChatLieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaKichThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaHangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaNuocSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaDacTinh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.Website)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.MaDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .Property(e => e.Anh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tDanhMucSP>()
                .HasMany(e => e.tAnhSP)
                .WithRequired(e => e.tDanhMucSP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tHangSX>()
                .Property(e => e.MaHangSX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tHangSX>()
                .Property(e => e.MaNuocThuongHieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKichThuoc>()
                .Property(e => e.MaKichThuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tKichThuoc>()
                .Property(e => e.KichThuoc)
                .IsFixedLength();

            modelBuilder.Entity<tLoaiDT>()
                .Property(e => e.MaDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tLoaiSP>()
                .Property(e => e.MaLoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tQuocGia>()
                .Property(e => e.MaNuoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tQuocGia>()
                .HasMany(e => e.tDanhMucSP)
                .WithOptional(e => e.tQuocGia)
                .HasForeignKey(e => e.MaNuocSX);

            modelBuilder.Entity<tQuocGia>()
                .HasMany(e => e.tHangSX)
                .WithOptional(e => e.tQuocGia)
                .HasForeignKey(e => e.MaNuocThuongHieu);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
