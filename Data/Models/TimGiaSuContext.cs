using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Models;

public partial class TimGiaSuContext : DbContext
{
    public TimGiaSuContext()
    {
    }

    public TimGiaSuContext(DbContextOptions<TimGiaSuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<GiaSu> GiaSus { get; set; }

    public virtual DbSet<HocSinh> HocSinhs { get; set; }

    public virtual DbSet<HocSinhLopHoc> HocSinhLopHocs { get; set; }

    public virtual DbSet<LopHoc> LopHocs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Đảm bảo đọc đúng file
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build()
                .GetConnectionString("SqlConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF69011798D");

            entity.Property(e => e.NgayDanhGia).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.GiaSu).WithMany(p => p.Feedbacks)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Feedback__GiaSuI__5CD6CB2B");

            entity.HasOne(d => d.HocSinh).WithMany(p => p.Feedbacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__HocSin__5AEE82B9");

            entity.HasOne(d => d.LopHoc).WithMany(p => p.Feedbacks)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Feedback__LopHoc__5BE2A6F2");
        });

        modelBuilder.Entity<GiaSu>(entity =>
        {
            entity.HasKey(e => e.GiaSuId).HasName("PK__GiaSu__BE5E2027476869E7");
        });

        modelBuilder.Entity<HocSinh>(entity =>
        {
            entity.HasKey(e => e.HocSinhId).HasName("PK__HocSinh__CD0A97BF83DF6220");
        });

        modelBuilder.Entity<HocSinhLopHoc>(entity =>
        {
            entity.HasKey(e => e.HocSinhLopHocId).HasName("PK__HocSinhL__8AAD2035F1D1CE3F");

            entity.HasOne(d => d.HocSinh).WithMany(p => p.HocSinhLopHocs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HocSinhLo__HocSi__5535A963");

            entity.HasOne(d => d.LopHoc).WithMany(p => p.HocSinhLopHocs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HocSinhLo__LopHo__5629CD9C");
        });

        modelBuilder.Entity<LopHoc>(entity =>
        {
            entity.HasKey(e => e.LopHocId).HasName("PK__LopHoc__DBC489C0B6278608");

            entity.HasOne(d => d.GiaSu).WithMany(p => p.LopHocs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LopHoc__GiaSuID__52593CB8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
