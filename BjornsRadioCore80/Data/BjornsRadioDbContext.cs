using System;
using System.Collections.Generic;
using BjornsRadioCore80.Models;
using Microsoft.EntityFrameworkCore;

namespace BjornsRadioCore80.Data;

public partial class BjornsRadioDbContext : DbContext
{
    public BjornsRadioDbContext()
    {
    }

    public BjornsRadioDbContext(DbContextOptions<BjornsRadioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BjornsRadioDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Albums__3214EC07790AA6B9");

            entity.Property(e => e.Artist).HasMaxLength(100);
            entity.Property(e => e.Comments).HasMaxLength(150);
            entity.Property(e => e.ReleaseYear).HasMaxLength(4);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.GenreNavigation).WithMany(p => p.Albums)
                .HasForeignKey(d => d.Genre)
                .HasConstraintName("FK_Albums_Genres");

            entity.HasOne(d => d.MediaNavigation).WithMany(p => p.Albums)
                .HasForeignKey(d => d.Media)
                .HasConstraintName("FK_Albums_MediaTypes");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC0700A82894");

            entity.Property(e => e.Comments).HasMaxLength(150);
            entity.Property(e => e.GenreName).HasMaxLength(50);
        });

        modelBuilder.Entity<MediaType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MediaTyp__3214EC07A7CBE4ED");

            entity.Property(e => e.Comments).HasMaxLength(150);
            entity.Property(e => e.TypeName).HasMaxLength(50);
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Songs__3214EC07BCD86634");

            entity.Property(e => e.Comments).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(75);

            entity.HasOne(d => d.AlbumNavigation).WithMany(p => p.Songs)
                .HasForeignKey(d => d.Album)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Albums_Songs");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
