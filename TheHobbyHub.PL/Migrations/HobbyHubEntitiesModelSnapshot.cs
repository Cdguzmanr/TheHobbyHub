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
                            Id = new Guid("fa7f6090-71a9-4628-bc17-39b5075d99bd"),
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("f24815d0-d9f9-407a-b204-c0c865172d9b"),
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("56bc2e1d-1a1b-44bf-9b95-7c86b0c21771"),
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
                            Id = new Guid("f529bc8b-4886-4ba5-9d1b-fed34685b5ee"),
                            AddressId = new Guid("fa7f6090-71a9-4628-bc17-39b5075d99bd"),
                            CompanyName = "Company A",
                            Image = "imageA.jpg",
                            Password = "/BafCUbj3r56CjioX1dcB1ynX20=",
                            UserName = "copanyA"
                        },
                        new
                        {
                            Id = new Guid("d0490734-8038-4c90-b7e8-45c9ad9552e3"),
                            AddressId = new Guid("f24815d0-d9f9-407a-b204-c0c865172d9b"),
                            CompanyName = "Company B",
                            Image = "imageB.jpg",
                            Password = "38Nd3/2M+aip9/TyIzVYXKylmQo=",
                            UserName = "companyB"
                        },
                        new
                        {
                            Id = new Guid("6a7d3a74-5698-4b62-ab7a-fca147ebb8e3"),
                            AddressId = new Guid("56bc2e1d-1a1b-44bf-9b95-7c86b0c21771"),
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
                            Id = new Guid("ffe6c4c9-abce-46bb-bb11-28d28f881ff2"),
                            AddressId = new Guid("fa7f6090-71a9-4628-bc17-39b5075d99bd"),
                            CompanyId = new Guid("f529bc8b-4886-4ba5-9d1b-fed34685b5ee"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("dfd05099-fd11-4a6a-a443-599471606bdf"),
                            Image = "imageA.jpg",
                            UserId = new Guid("7cb0fd9f-4cb8-4674-831b-9d8074ab1c7a")
                        },
                        new
                        {
                            Id = new Guid("1dac3d1e-bcab-4b93-ad43-bb41f1f0e889"),
                            AddressId = new Guid("f24815d0-d9f9-407a-b204-c0c865172d9b"),
                            CompanyId = new Guid("d0490734-8038-4c90-b7e8-45c9ad9552e3"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("fc32a9f4-0821-4d08-9977-727c400c8770"),
                            Image = "imageB.jpg",
                            UserId = new Guid("401870b2-7435-4566-af04-e7dffccbd378")
                        },
                        new
                        {
                            Id = new Guid("a6cc4f97-f0dc-4f07-a58d-3de9b59d5905"),
                            AddressId = new Guid("56bc2e1d-1a1b-44bf-9b95-7c86b0c21771"),
                            CompanyId = new Guid("6a7d3a74-5698-4b62-ab7a-fca147ebb8e3"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("c3e40fb6-48ad-427d-b891-8f8014490233"),
                            Image = "imageC.jpg",
                            UserId = new Guid("2581fe08-16c9-4e1e-87ac-d5c679268613")
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
                            Id = new Guid("36c5e98b-2fe6-4eb2-ad0d-a476345eeb98"),
                            CompanyId = new Guid("f529bc8b-4886-4ba5-9d1b-fed34685b5ee"),
                            UserId = new Guid("7cb0fd9f-4cb8-4674-831b-9d8074ab1c7a")
                        },
                        new
                        {
                            Id = new Guid("55f0ae36-427e-47c7-bc85-918fb95ee566"),
                            CompanyId = new Guid("d0490734-8038-4c90-b7e8-45c9ad9552e3"),
                            UserId = new Guid("401870b2-7435-4566-af04-e7dffccbd378")
                        },
                        new
                        {
                            Id = new Guid("54c6ef4f-1e45-4179-bbe8-38eb64d8aea7"),
                            CompanyId = new Guid("6a7d3a74-5698-4b62-ab7a-fca147ebb8e3"),
                            UserId = new Guid("2581fe08-16c9-4e1e-87ac-d5c679268613")
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
                            Id = new Guid("dfd05099-fd11-4a6a-a443-599471606bdf"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Image = "image.jpg",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("fc32a9f4-0821-4d08-9977-727c400c8770"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Image = "outdoor.jpg",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("c3e40fb6-48ad-427d-b891-8f8014490233"),
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
                            Id = new Guid("7cb0fd9f-4cb8-4674-831b-9d8074ab1c7a"),
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
                            Id = new Guid("401870b2-7435-4566-af04-e7dffccbd378"),
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
                            Id = new Guid("2581fe08-16c9-4e1e-87ac-d5c679268613"),
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
                            Id = new Guid("fbbb9af3-46b4-43ae-a8d2-189c53a228de"),
                            HobbyId = new Guid("dfd05099-fd11-4a6a-a443-599471606bdf"),
                            UserId = new Guid("7cb0fd9f-4cb8-4674-831b-9d8074ab1c7a")
                        },
                        new
                        {
                            Id = new Guid("a5878169-9df9-438b-b1a3-be3012ec5cba"),
                            HobbyId = new Guid("fc32a9f4-0821-4d08-9977-727c400c8770"),
                            UserId = new Guid("401870b2-7435-4566-af04-e7dffccbd378")
                        },
                        new
                        {
                            Id = new Guid("a87d337c-0d46-41c2-821c-e052ffd85d3e"),
                            HobbyId = new Guid("c3e40fb6-48ad-427d-b891-8f8014490233"),
                            UserId = new Guid("2581fe08-16c9-4e1e-87ac-d5c679268613")
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
