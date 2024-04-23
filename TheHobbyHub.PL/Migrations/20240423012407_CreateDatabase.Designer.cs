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
    [Migration("20240423012407_CreateDatabase")]
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
                            Id = new Guid("497fae07-6422-443e-bff6-9446cb49af40"),
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("59f466cc-a60c-4d91-a387-c67dc1427549"),
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("ca68da7f-092b-4358-94c1-9e539da72394"),
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
                            Id = new Guid("ad26d861-f9f4-4913-86fe-572456d2b537"),
                            AddressId = new Guid("497fae07-6422-443e-bff6-9446cb49af40"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("3aaedd91-3f19-4685-8bbe-8284838be079")
                        },
                        new
                        {
                            Id = new Guid("79880450-2cb3-4ed1-b20f-ddf655cc3175"),
                            AddressId = new Guid("59f466cc-a60c-4d91-a387-c67dc1427549"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("26d86571-ecb5-44ae-8e2c-51af4e57cfa3")
                        },
                        new
                        {
                            Id = new Guid("0c5229e6-4b15-44af-b5f0-8617cb37e785"),
                            AddressId = new Guid("ca68da7f-092b-4358-94c1-9e539da72394"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("4697c6b2-3e79-4f5b-9cec-90ac02ca13a0")
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
                            Id = new Guid("317a934e-0ae8-46b5-8b82-60956365ccea"),
                            AddressId = new Guid("497fae07-6422-443e-bff6-9446cb49af40"),
                            CompanyId = new Guid("ad26d861-f9f4-4913-86fe-572456d2b537"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("7765378b-5206-4e36-a92d-692c0894a2e9"),
                            Image = "gym.jpg",
                            UserId = new Guid("3aaedd91-3f19-4685-8bbe-8284838be079")
                        },
                        new
                        {
                            Id = new Guid("312cb364-f365-4524-8702-203f560d48d5"),
                            AddressId = new Guid("59f466cc-a60c-4d91-a387-c67dc1427549"),
                            CompanyId = new Guid("79880450-2cb3-4ed1-b20f-ddf655cc3175"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("6a17ba0b-ca72-4ef4-b124-f5bc2ec15da7"),
                            Image = "golf.jpg",
                            UserId = new Guid("26d86571-ecb5-44ae-8e2c-51af4e57cfa3")
                        },
                        new
                        {
                            Id = new Guid("c086141e-a9e9-40f8-9d0c-bbb2a2843df4"),
                            AddressId = new Guid("ca68da7f-092b-4358-94c1-9e539da72394"),
                            CompanyId = new Guid("0c5229e6-4b15-44af-b5f0-8617cb37e785"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("ebdaa336-adce-4475-859f-792484366f0c"),
                            Image = "running.jpg",
                            UserId = new Guid("4697c6b2-3e79-4f5b-9cec-90ac02ca13a0")
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
                            Id = new Guid("101c874c-dbc7-4380-b577-76a83ea62195"),
                            CompanyId = new Guid("ad26d861-f9f4-4913-86fe-572456d2b537"),
                            UserId = new Guid("3aaedd91-3f19-4685-8bbe-8284838be079")
                        },
                        new
                        {
                            Id = new Guid("cdf12ab2-3c51-4799-ae5f-8d497894e27c"),
                            CompanyId = new Guid("79880450-2cb3-4ed1-b20f-ddf655cc3175"),
                            UserId = new Guid("26d86571-ecb5-44ae-8e2c-51af4e57cfa3")
                        },
                        new
                        {
                            Id = new Guid("d6a02320-1331-4247-96bc-b74e623ef79e"),
                            CompanyId = new Guid("0c5229e6-4b15-44af-b5f0-8617cb37e785"),
                            UserId = new Guid("4697c6b2-3e79-4f5b-9cec-90ac02ca13a0")
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
                            Id = new Guid("7765378b-5206-4e36-a92d-692c0894a2e9"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("6a17ba0b-ca72-4ef4-b124-f5bc2ec15da7"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("ebdaa336-adce-4475-859f-792484366f0c"),
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
                            Id = new Guid("3aaedd91-3f19-4685-8bbe-8284838be079"),
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
                            Id = new Guid("26d86571-ecb5-44ae-8e2c-51af4e57cfa3"),
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
                            Id = new Guid("4697c6b2-3e79-4f5b-9cec-90ac02ca13a0"),
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
                            Id = new Guid("3caa63a5-7f6a-4070-86d7-797f87b04e23"),
                            HobbyId = new Guid("7765378b-5206-4e36-a92d-692c0894a2e9"),
                            UserId = new Guid("3aaedd91-3f19-4685-8bbe-8284838be079")
                        },
                        new
                        {
                            Id = new Guid("02ee8451-a94f-47ef-a101-9a1f094128ae"),
                            HobbyId = new Guid("6a17ba0b-ca72-4ef4-b124-f5bc2ec15da7"),
                            UserId = new Guid("26d86571-ecb5-44ae-8e2c-51af4e57cfa3")
                        },
                        new
                        {
                            Id = new Guid("f57ab1e5-ff2f-434b-8990-e7e332e55b0b"),
                            HobbyId = new Guid("ebdaa336-adce-4475-859f-792484366f0c"),
                            UserId = new Guid("4697c6b2-3e79-4f5b-9cec-90ac02ca13a0")
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