using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TheHobbyHub.PL.Entities;

namespace TheHobbyHub.PL.Data;

public partial class HobbyHubEntities : DbContext
{
    public HobbyHubEntities()
    {
    }

    public HobbyHubEntities(DbContextOptions<HobbyHubEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAddress> tblAddresses { get; set; }

    public virtual DbSet<tblCompany> tblCompanies { get; set; }

    public virtual DbSet<tblEvent> tblEvents { get; set; }

    public virtual DbSet<tblFriend> tblFriends { get; set; }

    public virtual DbSet<tblHobby> tblHobbies { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    public virtual DbSet<tblUserHobby> tblUserHobbies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblAddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAddre__3214EC073797D4B0");

            entity.ToTable("tblAddress");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblCompany>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblCompa__3214EC07F736E848");

            entity.ToTable("tblCompany");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblEvent__3214EC07BF9B1F91");

            entity.ToTable("tblEvent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
        });

        modelBuilder.Entity<tblFriend>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblFrien__3214EC07DE9FD9A3");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblHobby>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblHobby__3214EC0783BA9627");

            entity.ToTable("tblHobby");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.HobbyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC079D83832D");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Image).IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblUserHobby>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUserH__3214EC0736B690FC");

            entity.ToTable("tblUserHobby");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
