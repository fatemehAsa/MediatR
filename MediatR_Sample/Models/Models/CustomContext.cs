using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Models.Models
{
    public partial class CustomContext : DbContext
    {
        public CustomContext()
        {
        }

        public CustomContext(DbContextOptions<CustomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BasePrice> BasePrices { get; set; }
        public virtual DbSet<Ppr> Pprs { get; set; }
        public virtual DbSet<PprLat> PprLats { get; set; }
        public virtual DbSet<PprLatSize> PprLatSizes { get; set; }
        public virtual DbSet<PprModel> PprModels { get; set; }
        public virtual DbSet<Category> tbl_Categories { get; set; }
        public virtual DbSet<Post> tbl_Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BasePrice>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.PprLatSize)
                    .WithMany(p => p.BasePrices)
                    .HasForeignKey(d => d.PprLatSizeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BasePrice_PprLatSize");
            });

            modelBuilder.Entity<Ppr>(entity =>
            {
                entity.HasComment("جنس شیت");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasComment("شناسه");

                entity.Property(e => e.CanForce).HasComment("قابلیت فوری");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.EstimateDaysForOneSideForce).HasComment("مدت زمان احتمالی برای یک روی فوری");

                entity.Property(e => e.EstimateDaysForOneSideNormal).HasComment("مدت زمان احتمالی برای یک روی معمولی");

                entity.Property(e => e.EstimateDaysForTwoSideForce).HasComment("مدت زمان احتمالی برای دو روی فوری");

                entity.Property(e => e.EstimateDaysForTwoSideNormal).HasComment("مدت زمان احتمالی برای دو روی معمولی");

                entity.Property(e => e.FilmCount).HasComment("تعداد فیلم اضافه بر زینک");

                entity.Property(e => e.GetExternalFile).HasDefaultValueSql("((0))");

                entity.Property(e => e.HaveModel).HasComment("مدل دارد");

                entity.Property(e => e.IsActive)
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال است");

                entity.Property(e => e.IsActiveLocal)
                    .HasDefaultValueSql("((1))")
                    .HasComment("نمایش در سیستم محلی");

                entity.Property(e => e.IsActiveRemote)
                    .HasDefaultValueSql("((1))")
                    .HasComment("نمایش در سیستم راه دور");

                entity.Property(e => e.Name).HasComment("نام");

                entity.Property(e => e.PaperStuffID).HasDefaultValueSql("((27))");

                entity.Property(e => e.PprDoubleType).HasComment("قابلیت دو رو");

                entity.Property(e => e.PprHasteTime).HasComment("ساعت فورس ماژور");

                entity.Property(e => e.PreviousPprID).HasComment("جنس کاغذ قبلی");

                entity.Property(e => e.Share).HasComment("شیت یک رو دو رو مشترک");

                entity.Property(e => e.Tiraj).HasComment("تیراژ");

                entity.HasOne(d => d.PreviousPpr)
                    .WithMany(p => p.InversePreviousPpr)
                    .HasForeignKey(d => d.PreviousPprID)
                    .HasConstraintName("FK_Ppr_Ppr");
            });

            modelBuilder.Entity<PprLat>(entity =>
            {
                entity.HasComment("لتهای اجناس");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasComment("شناسه");

                entity.Property(e => e.IsActive)
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال است");

                entity.Property(e => e.IsRotate)
                    .HasDefaultValueSql("((0))")
                    .HasComment("چرخیده شده");

                entity.Property(e => e.PprLatSizeID).HasComment("لت سایز اجناس");

                entity.Property(e => e.PprModelID).HasComment("مدل اجناس");

                entity.Property(e => e.X).HasComment("X");

                entity.Property(e => e.Y).HasComment("Y");

                entity.HasOne(d => d.PprLatSize)
                    .WithMany(p => p.PprLats)
                    .HasForeignKey(d => d.PprLatSizeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PprLat_PprLatSize");

                entity.HasOne(d => d.PprModel)
                    .WithMany(p => p.PprLats)
                    .HasForeignKey(d => d.PprModelID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PprLat_PprModel");
            });

            modelBuilder.Entity<PprLatSize>(entity =>
            {
                entity.HasComment("سایز لتهای اجناس");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasComment("شناسه");

                entity.Property(e => e.CuttingFreeSpaceDown).HasComment("خلاصی برش پایین");

                entity.Property(e => e.CuttingFreeSpaceLeft).HasComment("خلاصی برش چپ");

                entity.Property(e => e.CuttingFreeSpaceRight).HasComment("خلاصی برش راست");

                entity.Property(e => e.CuttingFreeSpaceTop).HasComment("خلاصی برش بالا");

                entity.Property(e => e.FakeHeight).HasComment("اختلاف سایز مجازی از ارتفاع");

                entity.Property(e => e.FakeWidth).HasComment("اختلاف سایز مجازی از پهنا");

                entity.Property(e => e.HaveHelperFile).HasComment("فایل راهنما");

                entity.Property(e => e.Height).HasComment("ارتفاع");

                entity.Property(e => e.IsActive)
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال است");

                entity.Property(e => e.IsActiveLocal).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsActiveRemote).HasDefaultValueSql("((1))");

                entity.Property(e => e.PprLatSizeName).HasComment("نام لت سایز اجناس");

                entity.Property(e => e.ShapeType).HasComment("نوع تصویر");

                entity.Property(e => e.Width).HasComment("پهنا");
            });

            modelBuilder.Entity<PprModel>(entity =>
            {
                entity.HasComment("قالب شیت");

                entity.Property(e => e.ID)
                    .ValueGeneratedNever()
                    .HasComment("شناسه");

                entity.Property(e => e.Description).HasComment("توضیحات");

                entity.Property(e => e.HLab).HasDefaultValueSql("((10))");

                entity.Property(e => e.Height).HasComment("ارتفاع");

                entity.Property(e => e.IsActive)
                    .HasDefaultValueSql("((1))")
                    .HasComment("فعال است");

                entity.Property(e => e.ModelName).HasComment("نام مدل");

                entity.Property(e => e.PaperTypeID).HasDefaultValueSql("((26))");

                entity.Property(e => e.PprID).HasComment("جنس");

                entity.Property(e => e.PprModelDoubletype).HasComment("مدل جنس کاغذ دو رو");

                entity.Property(e => e.TwoFaceGluey).HasDefaultValueSql("((0))");

                entity.Property(e => e.VLab).HasDefaultValueSql("((3))");

                entity.Property(e => e.WasteNumber).HasComment("تعداد برگ ضایعاتی");

                entity.Property(e => e.Width).HasComment("پهنا");

                entity.HasOne(d => d.Ppr)
                    .WithMany(p => p.PprModels)
                    .HasForeignKey(d => d.PprID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PprModel_Ppr");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK_BookGenre");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK_Book");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.tbl_Posts)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_BookGenre");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public object FindAsync(int id)
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
