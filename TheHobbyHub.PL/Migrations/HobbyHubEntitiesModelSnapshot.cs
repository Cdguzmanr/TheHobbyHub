﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheHobbyHub.PL.Data;

#nullable disable

namespace TheHobbyHub.PL.Migrations
{
    [DbContext(typeof(HobbyHubEntities))]
    partial class HobbyHubEntitiesModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostalAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.HasKey("Id")
                        .HasName("PK_tblAddress_Id");

                    b.ToTable("tblAddress", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"),
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("a908a318-8f5b-40a3-9660-51df362605a4"),
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"),
                            City = "Somewhere",
                            PostalAddress = "789 Oak St",
                            State = "TX",
                            Zip = "67890"
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblCompany_Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("tblCompany", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"),
                            AddressId = new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("5b586fe4-adb4-477d-a683-666836c2114b")
                        },
                        new
                        {
                            Id = new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"),
                            AddressId = new Guid("a908a318-8f5b-40a3-9660-51df362605a4"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0")
                        },
                        new
                        {
                            Id = new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"),
                            AddressId = new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b")
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblEvent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("HobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblEvent_Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("tblEvent", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b057aa4a-2ee8-4dd9-9d31-3814de062999"),
                            AddressId = new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"),
                            CompanyId = new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"),
                            Image = "imageA.jpg",
                            UserId = new Guid("5b586fe4-adb4-477d-a683-666836c2114b")
                        },
                        new
                        {
                            Id = new Guid("34f29b8d-8f64-41ae-b6af-3345b151b6e5"),
                            AddressId = new Guid("a908a318-8f5b-40a3-9660-51df362605a4"),
                            CompanyId = new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"),
                            Image = "imageB.jpg",
                            UserId = new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0")
                        },
                        new
                        {
                            Id = new Guid("0943a161-4355-4712-94af-1e33888ec7dd"),
                            AddressId = new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"),
                            CompanyId = new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"),
                            Image = "imageC.jpg",
                            UserId = new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b")
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblFriend", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblFriend_Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("UserId");

                    b.ToTable("tblFriend", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0ecf3e62-79bc-43fd-b781-d2590e4a4731"),
                            CompanyId = new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"),
                            UserId = new Guid("5b586fe4-adb4-477d-a683-666836c2114b")
                        },
                        new
                        {
                            Id = new Guid("35e161fd-036f-4749-b9a9-f5276671d441"),
                            CompanyId = new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"),
                            UserId = new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0")
                        },
                        new
                        {
                            Id = new Guid("39ce04df-3ccb-4a6b-adbc-8bb0ac7d567e"),
                            CompanyId = new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"),
                            UserId = new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b")
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblHobby", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("HobbyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblHobby_Id");

                    b.ToTable("tblHobby", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Image = "image.jpg",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Image = "outdoor.jpg",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"),
                            Description = "Run",
                            HobbyName = "Running",
                            Image = "run.jpg",
                            Type = "Outdoor"
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK_tblUser_Id");

                    b.ToTable("tblUser", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5b586fe4-adb4-477d-a683-666836c2114b"),
                            Email = "Alexr@gmail.com",
                            FirstName = "Alex",
                            Image = "image.jpg",
                            LastName = "Rosas",
                            Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=",
                            PhoneNumber = "2627459097",
                            UserName = "Arosas"
                        },
                        new
                        {
                            Id = new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0"),
                            Email = "bfoote@fvtc.edu",
                            FirstName = "Brian",
                            Image = "image.jpg",
                            LastName = "Foote",
                            Password = "pYfdnNb8sO0FgS4H0MRSwLGOIME=",
                            PhoneNumber = "3333333333",
                            UserName = "bfoote"
                        },
                        new
                        {
                            Id = new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b"),
                            Email = "sf@gmail.com",
                            FirstName = "sam",
                            Image = "sammy.jpg",
                            LastName = "fisher",
                            Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=",
                            PhoneNumber = "1111111111",
                            UserName = "sammyfish"
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblUserHobby", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HobbyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK_tblUserHobby_Id");

                    b.HasIndex("HobbyId");

                    b.HasIndex("UserId");

                    b.ToTable("tblUserHobby", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8c69b5b4-1d1b-49f1-b84a-4be0ded8be1c"),
                            HobbyId = new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"),
                            UserId = new Guid("5b586fe4-adb4-477d-a683-666836c2114b")
                        },
                        new
                        {
                            Id = new Guid("ad9755cd-b111-4b8c-b14f-4486aae01045"),
                            HobbyId = new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"),
                            UserId = new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0")
                        },
                        new
                        {
                            Id = new Guid("34aa3856-ce73-4249-b5d8-77bcf0396e70"),
                            HobbyId = new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"),
                            UserId = new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b")
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblCompany", b =>
                {
                    b.HasOne("TheHobbyHub.PL.Entities.tblAddress", "Address")
                        .WithMany("Companies")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("fk_tblCompany_AddressId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblUser", "User")
                        .WithMany("Companies")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_tblCompany_UserId");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblEvent", b =>
                {
                    b.HasOne("TheHobbyHub.PL.Entities.tblAddress", "Address")
                        .WithMany("Events")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("fk_tblEvent_AddressId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblCompany", "Company")
                        .WithMany("Events")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("fk_tblEvent_CompanyId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblHobby", "Hobby")
                        .WithMany("Events")
                        .HasForeignKey("HobbyId")
                        .IsRequired()
                        .HasConstraintName("fk_tblEvent_HobbyId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblUser", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_tblEvent_UserId");

                    b.Navigation("Address");

                    b.Navigation("Company");

                    b.Navigation("Hobby");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblFriend", b =>
                {
                    b.HasOne("TheHobbyHub.PL.Entities.tblCompany", "Company")
                        .WithMany("Friends")
                        .HasForeignKey("CompanyId")
                        .IsRequired()
                        .HasConstraintName("fk_tblFriend_CompanyId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblUser", "User")
                        .WithMany("Friends")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_tblFriend_UserId");

                    b.Navigation("Company");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblUserHobby", b =>
                {
                    b.HasOne("TheHobbyHub.PL.Entities.tblHobby", "Hobby")
                        .WithMany("UserHobbies")
                        .HasForeignKey("HobbyId")
                        .IsRequired()
                        .HasConstraintName("fk_tblUserHobby_HobbyId");

                    b.HasOne("TheHobbyHub.PL.Entities.tblUser", "User")
                        .WithMany("UserHobbies")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("fk_tblUserHobby_UserId");

                    b.Navigation("Hobby");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblAddress", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Events");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblCompany", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Friends");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblHobby", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("UserHobbies");
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblUser", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Events");

                    b.Navigation("Friends");

                    b.Navigation("UserHobbies");
                });
#pragma warning restore 612, 618
        }
    }
}
