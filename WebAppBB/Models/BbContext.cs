using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppBB.Models;

public partial class BbContext : DbContext
{
    public BbContext()
    {
    }

    public BbContext(DbContextOptions<BbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Interiorcategory> Interiorcategories { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Postscategory> Postscategories { get; set; }

    public DbSet<Subcategory> Subcategories { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Categoryid).HasName("PK__categori__23CDE590D85A6FA3");

            entity.ToTable("categories");

            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Description)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        modelBuilder.Entity<Interiorcategory>(entity =>
        {
            entity.HasKey(e => e.Interiorcategoryid).HasName("PK__interior__EE8CDCAC61FD69B2");

            entity.ToTable("interiorcategories");

            entity.Property(e => e.Interiorcategoryid).HasColumnName("interiorcategoryid");
            entity.Property(e => e.Description)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__posts__DD0C739A8CE9868B");

            entity.ToTable("posts");

            entity.Property(e => e.PostId).HasColumnName("postId");
            entity.Property(e => e.Author)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.CategoryLanding).HasColumnName("category_landing");
            entity.Property(e => e.Display).HasColumnName("display");
            entity.Property(e => e.DocumentDate)
                .HasColumnType("datetime")
                .HasColumnName("document_date");
            entity.Property(e => e.Headline)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("headline");
            entity.Property(e => e.Homepage).HasColumnName("homepage");
            entity.Property(e => e.ImageAlign).HasColumnName("image_align");
            entity.Property(e => e.ImageSpan).HasColumnName("image_span");
            entity.Property(e => e.ImageWrap).HasColumnName("image_wrap");
            entity.Property(e => e.MainText)
                .HasColumnType("text")
                .HasColumnName("main_text");
            entity.Property(e => e.MetaDescription)
                .HasColumnType("text")
                .HasColumnName("meta_description");
            entity.Property(e => e.Subtitle)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("subtitle");
            entity.Property(e => e.Teaser)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("teaser");
            entity.Property(e => e.TeaserThumbnail)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("teaser_thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Url)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("url");
            entity.Property(e => e.UseOnlyHomepage).HasColumnName("use_only_homepage");
            entity.Property(e => e.WrapText).HasColumnName("wrap_text");
        });

        modelBuilder.Entity<Postscategory>(entity =>
        {
            entity.HasKey(e => e.PostcategoriesId).HasName("PK__postscat__12B46086537F75FE");

            entity.ToTable("postscategories");

            entity.Property(e => e.PostcategoriesId).HasColumnName("postcategoriesId");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Interiorcategoryid).HasColumnName("interiorcategoryid");
            entity.Property(e => e.PostId).HasColumnName("postId");
            entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");

            /*entity.HasOne(d => d.Post).WithMany(p => p.Postscategories)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK__postscate__postI__2C3393D0");*/
        });

        modelBuilder.Entity<Subcategory>(entity =>
        {
            entity.HasKey(e => e.Subcategoryid).HasName("PK__subcateg__E3EBECCDF05FEFC4");

            entity.ToTable("subcategories");

            entity.Property(e => e.Subcategoryid).HasColumnName("subcategoryid");
            entity.Property(e => e.Categoryid).HasColumnName("categoryid");
            entity.Property(e => e.Description)
                .HasMaxLength(70)
                .IsUnicode(false)
                .HasColumnName("description");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
