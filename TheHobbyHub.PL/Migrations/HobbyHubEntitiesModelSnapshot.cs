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

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
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
                            Id = new Guid("b3aa8d9d-89b7-4ccc-9d3a-0201c99ea064"),
                            Address = "123 Main St",
                            City = "Anytown",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("53dc6c41-c56f-469f-b836-db0be6709e4d"),
                            Address = "456 Elm St",
                            City = "Othertown",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("7349b157-5d0b-489a-be30-61693c8efd0b"),
                            Address = "789 Oak St",
                            City = "Somewhere",
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

                    b.Property<string>("Image")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
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
                        .HasName("PK_tblCompany_Id");

                    b.HasIndex("AddressId");

                    b.ToTable("tblCompany", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("0f41caa7-d856-4148-9ff1-aebe678491d8"),
                            AddressId = new Guid("b3aa8d9d-89b7-4ccc-9d3a-0201c99ea064"),
                            CompanyName = "Company A",
                            Image = "imageA.jpg",
                            Password = "/BafCUbj3r56CjioX1dcB1ynX20=",
                            UserName = "copanyA"
                        },
                        new
                        {
                            Id = new Guid("08a942e4-7b0d-4f09-9f59-06cd4f762821"),
                            AddressId = new Guid("53dc6c41-c56f-469f-b836-db0be6709e4d"),
                            CompanyName = "Company B",
                            Image = "imageB.jpg",
                            Password = "38Nd3/2M+aip9/TyIzVYXKylmQo=",
                            UserName = "companyB"
                        },
                        new
                        {
                            Id = new Guid("0113d20b-5e37-4238-bf4b-777632d331cc"),
                            AddressId = new Guid("7349b157-5d0b-489a-be30-61693c8efd0b"),
                            CompanyName = "Company C",
                            Image = "imageC.jpg",
                            Password = "urYijG3X2+D44I400gasYPqLBHw=",
                            UserName = "companyC"
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
                            Id = new Guid("0854e6e0-a6b9-4cf9-be9f-58e9b8b10098"),
                            AddressId = new Guid("b3aa8d9d-89b7-4ccc-9d3a-0201c99ea064"),
                            CompanyId = new Guid("0f41caa7-d856-4148-9ff1-aebe678491d8"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("3f49f6ee-a6e3-4c24-a3c8-fb5d5e91e890"),
                            Image = "imageA.jpg",
                            UserId = new Guid("51515d6c-b7e9-4fc1-9844-f85022cadd47")
                        },
                        new
                        {
                            Id = new Guid("f7c0bcd2-8709-4a6d-8048-83bb6020e75d"),
                            AddressId = new Guid("53dc6c41-c56f-469f-b836-db0be6709e4d"),
                            CompanyId = new Guid("08a942e4-7b0d-4f09-9f59-06cd4f762821"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("e94610f7-f602-4c3a-86a5-0ebccc538155"),
                            Image = "imageB.jpg",
                            UserId = new Guid("fd114c47-075d-4d22-b022-41e89acb9ee8")
                        },
                        new
                        {
                            Id = new Guid("02faca5f-44d6-4127-ac93-40dc7b4269c5"),
                            AddressId = new Guid("7349b157-5d0b-489a-be30-61693c8efd0b"),
                            CompanyId = new Guid("0113d20b-5e37-4238-bf4b-777632d331cc"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("c913636b-a6db-4ede-a62c-a723922dbba4"),
                            Image = "imageC.jpg",
                            UserId = new Guid("cb1f3a98-e767-4546-b499-dda7ff8235ef")
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
                            Id = new Guid("3d1ce234-32a5-440c-9e23-50029c039969"),
                            CompanyId = new Guid("0f41caa7-d856-4148-9ff1-aebe678491d8"),
                            UserId = new Guid("51515d6c-b7e9-4fc1-9844-f85022cadd47")
                        },
                        new
                        {
                            Id = new Guid("b8f0e942-3a71-4194-8087-05c28ce0c6f1"),
                            CompanyId = new Guid("08a942e4-7b0d-4f09-9f59-06cd4f762821"),
                            UserId = new Guid("fd114c47-075d-4d22-b022-41e89acb9ee8")
                        },
                        new
                        {
                            Id = new Guid("07594d7a-1c96-4af6-839e-8106032b9865"),
                            CompanyId = new Guid("0113d20b-5e37-4238-bf4b-777632d331cc"),
                            UserId = new Guid("cb1f3a98-e767-4546-b499-dda7ff8235ef")
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
                            Id = new Guid("b3aa9abc-d68e-466f-b20e-8815006b94f0"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Image = "image.jpg",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("6ef46933-4e42-4581-8e08-a532fbea2c51"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Image = "outdoor.jpg",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("159adb2e-c5ac-4b30-a49e-c9cfe5efa00b"),
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
                            Id = new Guid("df07152c-70fd-454f-8bc1-a2ea1fed6e45"),
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
                            Id = new Guid("e016e367-aa6b-4f06-b8b6-6f315ae89e21"),
                            Email = "ss@gmail.com",
                            FirstName = "Someone",
                            Image = "image.jpg",
                            LastName = "Somebody",
                            Password = "B/qgP3XrZmyneblY753llJ5gtQ4=",
                            PhoneNumber = "3333333333",
                            UserName = "SSM"
                        },
                        new
                        {
                            Id = new Guid("4f2eaeb3-5f42-4951-8b2f-c0420f3434ff"),
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
                            Id = new Guid("3d504d5e-0434-46a4-b0f9-04cbbb421fae"),
                            HobbyId = new Guid("b3aa9abc-d68e-466f-b20e-8815006b94f0"),
                            UserId = new Guid("df07152c-70fd-454f-8bc1-a2ea1fed6e45")
                        },
                        new
                        {
                            Id = new Guid("92e2b5f8-22d6-4dd0-a393-2b5d44723a26"),
                            HobbyId = new Guid("6ef46933-4e42-4581-8e08-a532fbea2c51"),
                            UserId = new Guid("e016e367-aa6b-4f06-b8b6-6f315ae89e21")
                        },
                        new
                        {
                            Id = new Guid("fb313f8e-b68e-424f-9c27-0bc3f9377add"),
                            HobbyId = new Guid("159adb2e-c5ac-4b30-a49e-c9cfe5efa00b"),
                            UserId = new Guid("4f2eaeb3-5f42-4951-8b2f-c0420f3434ff")
                        });
                });

            modelBuilder.Entity("TheHobbyHub.PL.Entities.tblCompany", b =>
                {
                    b.HasOne("TheHobbyHub.PL.Entities.tblAddress", "Address")
                        .WithMany("Companies")
                        .HasForeignKey("AddressId")
                        .IsRequired()
                        .HasConstraintName("fk_tblCompany_AddressId");

                    b.Navigation("Address");
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
                    b.Navigation("Events");

                    b.Navigation("Friends");

                    b.Navigation("UserHobbies");
                });
#pragma warning restore 612, 618
        }
    }
}