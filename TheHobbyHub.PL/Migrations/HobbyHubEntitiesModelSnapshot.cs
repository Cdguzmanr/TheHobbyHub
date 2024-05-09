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
                            Id = new Guid("99df141a-041a-4bef-a6db-34992cce7e11"),
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("3bb25b67-6e7f-44ee-98f9-f81d0dc17e93"),
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("9079b3f2-18d3-4371-982d-d4fa330ea4eb"),
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
                            Id = new Guid("b667a3e9-41da-4488-8d85-1bfefb269881"),
                            AddressId = new Guid("99df141a-041a-4bef-a6db-34992cce7e11"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("2afddcf9-5876-46c3-8494-bc8de3a0b3fb")
                        },
                        new
                        {
                            Id = new Guid("30e3bab0-a82c-4efe-8cee-21757c1f4ac5"),
                            AddressId = new Guid("3bb25b67-6e7f-44ee-98f9-f81d0dc17e93"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("597517ea-7a33-4127-a968-8a8ce36858db")
                        },
                        new
                        {
                            Id = new Guid("01e3e656-31c2-4940-9cd2-e8dc2548ca18"),
                            AddressId = new Guid("9079b3f2-18d3-4371-982d-d4fa330ea4eb"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("3a5446bd-4b36-48f1-9173-5b089ad825d3")
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

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                            Id = new Guid("7ac96632-f73d-48e1-a7f8-f35cb76cdc49"),
                            AddressId = new Guid("99df141a-041a-4bef-a6db-34992cce7e11"),
                            CompanyId = new Guid("b667a3e9-41da-4488-8d85-1bfefb269881"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Amatuer Powerlifting Event",
                            EventName = "Amatuer Powerlifting Event",
                            HobbyId = new Guid("c675e72f-42eb-4618-96bf-a58035ea8d52"),
                            Image = "gym.jpeg",
                            UserId = new Guid("2afddcf9-5876-46c3-8494-bc8de3a0b3fb")
                        },
                        new
                        {
                            Id = new Guid("dcf7fe99-6279-4474-906d-ae2300ca4ea2"),
                            AddressId = new Guid("3bb25b67-6e7f-44ee-98f9-f81d0dc17e93"),
                            CompanyId = new Guid("30e3bab0-a82c-4efe-8cee-21757c1f4ac5"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Amatuer Golf Tournament",
                            EventName = "Amatuer Golf Tournament",
                            HobbyId = new Guid("b7a65745-9a09-488b-b97b-2f7a579102e1"),
                            Image = "golf.jpg",
                            UserId = new Guid("597517ea-7a33-4127-a968-8a8ce36858db")
                        },
                        new
                        {
                            Id = new Guid("0280180d-2ffa-46bb-bb92-df17f84a78c9"),
                            AddressId = new Guid("9079b3f2-18d3-4371-982d-d4fa330ea4eb"),
                            CompanyId = new Guid("01e3e656-31c2-4940-9cd2-e8dc2548ca18"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "5K fun run",
                            EventName = "5k Fun Run",
                            HobbyId = new Guid("f688e97f-c866-4538-af0f-2da9a56e1ed9"),
                            Image = "running.jpeg",
                            UserId = new Guid("3a5446bd-4b36-48f1-9173-5b089ad825d3")
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
                            Id = new Guid("70392df3-c5c0-4f22-84c4-dfc0194bef21"),
                            CompanyId = new Guid("b667a3e9-41da-4488-8d85-1bfefb269881"),
                            UserId = new Guid("2afddcf9-5876-46c3-8494-bc8de3a0b3fb")
                        },
                        new
                        {
                            Id = new Guid("c81b7f20-17a3-4424-b76c-f5d21f87b803"),
                            CompanyId = new Guid("30e3bab0-a82c-4efe-8cee-21757c1f4ac5"),
                            UserId = new Guid("597517ea-7a33-4127-a968-8a8ce36858db")
                        },
                        new
                        {
                            Id = new Guid("ab097906-dd29-4aee-88a2-9e6510879b21"),
                            CompanyId = new Guid("01e3e656-31c2-4940-9cd2-e8dc2548ca18"),
                            UserId = new Guid("3a5446bd-4b36-48f1-9173-5b089ad825d3")
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
                            Id = new Guid("c675e72f-42eb-4618-96bf-a58035ea8d52"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("b7a65745-9a09-488b-b97b-2f7a579102e1"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("f688e97f-c866-4538-af0f-2da9a56e1ed9"),
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
                            Id = new Guid("2afddcf9-5876-46c3-8494-bc8de3a0b3fb"),
                            Email = "Alexr@gmail.com",
                            FirstName = "Alex",
                            Image = "ar.jpg",
                            LastName = "Rosas",
                            Password = "qUqP5cyxm6YcTAhz05Hph5gvu9M=",
                            PhoneNumber = "2627459097",
                            UserName = "Arosas"
                        },
                        new
                        {
                            Id = new Guid("597517ea-7a33-4127-a968-8a8ce36858db"),
                            Email = "bfoote@fvtc.edu",
                            FirstName = "Brian",
                            Image = "bfoote.jpg",
                            LastName = "Foote",
                            Password = "pYfdnNb8sO0FgS4H0MRSwLGOIME=",
                            PhoneNumber = "3333333333",
                            UserName = "bfoote"
                        },
                        new
                        {
                            Id = new Guid("3a5446bd-4b36-48f1-9173-5b089ad825d3"),
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
                            Id = new Guid("6498e71f-5740-427a-ba9b-8a16277f72d4"),
                            HobbyId = new Guid("c675e72f-42eb-4618-96bf-a58035ea8d52"),
                            UserId = new Guid("2afddcf9-5876-46c3-8494-bc8de3a0b3fb")
                        },
                        new
                        {
                            Id = new Guid("19e1b2b0-336c-4c25-b17c-c794c1f15aa7"),
                            HobbyId = new Guid("b7a65745-9a09-488b-b97b-2f7a579102e1"),
                            UserId = new Guid("597517ea-7a33-4127-a968-8a8ce36858db")
                        },
                        new
                        {
                            Id = new Guid("db5a03e4-ef39-4a47-98ec-484c0424664f"),
                            HobbyId = new Guid("f688e97f-c866-4538-af0f-2da9a56e1ed9"),
                            UserId = new Guid("3a5446bd-4b36-48f1-9173-5b089ad825d3")
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
