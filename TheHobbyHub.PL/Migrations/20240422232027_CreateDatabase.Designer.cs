﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheHobbyHub.PL.Data;

#nullable disable

namespace TheHobbyHub.PL.Migrations
{
    [DbContext(typeof(HobbyHubEntities))]
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
    [Migration("20240422232027_CreateDatabase")]
========
    [Migration("20240422232246_CreateDatabase")]
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"),
========
                            Id = new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"),
========
                            Id = new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("06babd85-3edc-4756-a2e7-43468880da39"),
========
                            Id = new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"),
                            AddressId = new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee")
                        },
                        new
                        {
                            Id = new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"),
                            AddressId = new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e")
                        },
                        new
                        {
                            Id = new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"),
                            AddressId = new Guid("06babd85-3edc-4756-a2e7-43468880da39"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2")
========
                            Id = new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"),
                            AddressId = new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583")
                        },
                        new
                        {
                            Id = new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"),
                            AddressId = new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b")
                        },
                        new
                        {
                            Id = new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"),
                            AddressId = new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2")
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("d65501cc-f625-4564-ab1d-497bb109f33d"),
                            AddressId = new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"),
                            CompanyId = new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"),
                            Image = "imageA.jpg",
                            UserId = new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee")
                        },
                        new
                        {
                            Id = new Guid("d818fbb8-1049-48cf-9cdf-4931bef2c908"),
                            AddressId = new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"),
                            CompanyId = new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"),
                            Image = "imageB.jpg",
                            UserId = new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e")
                        },
                        new
                        {
                            Id = new Guid("4fa03199-9aa4-42fc-b138-513a2b5592ea"),
                            AddressId = new Guid("06babd85-3edc-4756-a2e7-43468880da39"),
                            CompanyId = new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"),
                            Image = "imageC.jpg",
                            UserId = new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2")
========
                            Id = new Guid("b91295f5-79cd-4fa8-b396-e3275bf46c7b"),
                            AddressId = new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"),
                            CompanyId = new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"),
                            Image = "gym.jpg",
                            UserId = new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583")
                        },
                        new
                        {
                            Id = new Guid("1d7a3909-8041-4309-b67a-d3ea36d8cddf"),
                            AddressId = new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"),
                            CompanyId = new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"),
                            Image = "golf.jpg",
                            UserId = new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b")
                        },
                        new
                        {
                            Id = new Guid("13cd03e5-22c8-473c-83ae-2a0f8db5bc6b"),
                            AddressId = new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"),
                            CompanyId = new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"),
                            Image = "running.jpg",
                            UserId = new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2")
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("4554c2ae-b7dc-453f-894c-409bc2d6411c"),
                            CompanyId = new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"),
                            UserId = new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee")
                        },
                        new
                        {
                            Id = new Guid("80370ce0-d65d-45fd-bcb0-fcb54b68bc59"),
                            CompanyId = new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"),
                            UserId = new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e")
                        },
                        new
                        {
                            Id = new Guid("b420d975-0b43-49a5-a717-34dc7c205bfe"),
                            CompanyId = new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"),
                            UserId = new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2")
========
                            Id = new Guid("0a94383b-d962-4767-867c-129f96fa70ac"),
                            CompanyId = new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"),
                            UserId = new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583")
                        },
                        new
                        {
                            Id = new Guid("2f876157-553f-4382-a417-75d67b5fe9ab"),
                            CompanyId = new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"),
                            UserId = new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b")
                        },
                        new
                        {
                            Id = new Guid("bc767df3-3fa6-405d-a7ec-5e0197f86107"),
                            CompanyId = new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"),
                            UserId = new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2")
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"),
========
                            Id = new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Type = "Indoor"
                        },
                        new
                        {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"),
========
                            Id = new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
                            Description = "stick",
                            HobbyName = "Golf",
                            Type = "outdoor"
                        },
                        new
                        {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"),
========
                            Id = new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
                            Description = "Run",
                            HobbyName = "Running",
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee"),
========
                            Id = new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e"),
========
                            Id = new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2"),
========
                            Id = new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2"),
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.Designer.cs
                            Id = new Guid("f188862c-bf56-45df-9397-95d6adca6868"),
                            HobbyId = new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"),
                            UserId = new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee")
                        },
                        new
                        {
                            Id = new Guid("98ce21ee-c757-4046-bc9e-250fba6ddac0"),
                            HobbyId = new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"),
                            UserId = new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e")
                        },
                        new
                        {
                            Id = new Guid("78b00187-755c-4c99-95b1-79622f3f29d2"),
                            HobbyId = new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"),
                            UserId = new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2")
========
                            Id = new Guid("31829956-c05e-43c1-9f27-1b53e03c2339"),
                            HobbyId = new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"),
                            UserId = new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583")
                        },
                        new
                        {
                            Id = new Guid("e1fa0a98-7fac-4ff7-b39b-ab2527bc7862"),
                            HobbyId = new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"),
                            UserId = new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b")
                        },
                        new
                        {
                            Id = new Guid("4c35e2d0-b743-422f-a0ca-8202abd9f776"),
                            HobbyId = new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"),
                            UserId = new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2")
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.Designer.cs
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