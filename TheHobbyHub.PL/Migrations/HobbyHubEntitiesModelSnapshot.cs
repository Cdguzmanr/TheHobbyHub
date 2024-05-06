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
                            Id = new Guid("16b0149d-8dd4-429d-9160-b1c8716519c1"),
                            City = "Anytown",
                            PostalAddress = "123 Main St",
                            State = "CA",
                            Zip = "12345"
                        },
                        new
                        {
                            Id = new Guid("66cb28a1-e723-4611-9813-fc40e47948d1"),
                            City = "Othertown",
                            PostalAddress = "456 Elm St",
                            State = "NY",
                            Zip = "54321"
                        },
                        new
                        {
                            Id = new Guid("d538d0f4-ca04-41ae-b0f4-7369ff23878a"),
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
                            Id = new Guid("a3062fbb-c0df-4b62-9db0-d57f0b006c5e"),
                            AddressId = new Guid("16b0149d-8dd4-429d-9160-b1c8716519c1"),
                            CompanyName = "Company A",
                            Description = "about company A",
                            UserId = new Guid("5502c874-3582-494d-a8c5-3234d330346a")
                        },
                        new
                        {
                            Id = new Guid("8b9f9345-7164-4331-a457-a9ec6280b483"),
                            AddressId = new Guid("66cb28a1-e723-4611-9813-fc40e47948d1"),
                            CompanyName = "Company B",
                            Description = "about company B",
                            UserId = new Guid("9ad2a0ac-42fb-4286-b14d-4b6eb38483c7")
                        },
                        new
                        {
                            Id = new Guid("5768cb0c-6622-4b84-a453-85f6f16d8b68"),
                            AddressId = new Guid("d538d0f4-ca04-41ae-b0f4-7369ff23878a"),
                            CompanyName = "Company C",
                            Description = "about company C",
                            UserId = new Guid("2f30135e-c2bc-47f5-a6ee-6e3f110369cc")
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
                            Id = new Guid("93648c14-1451-45c2-b1c6-df0b0347fa7f"),
                            AddressId = new Guid("16b0149d-8dd4-429d-9160-b1c8716519c1"),
                            CompanyId = new Guid("a3062fbb-c0df-4b62-9db0-d57f0b006c5e"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event A",
                            HobbyId = new Guid("edc213c1-627f-407e-845b-177203631bb6"),
                            Image = "gym.jpeg",
                            UserId = new Guid("5502c874-3582-494d-a8c5-3234d330346a")
                        },
                        new
                        {
                            Id = new Guid("0ad424d0-ee50-4c11-acc5-0a128a0ba814"),
                            AddressId = new Guid("66cb28a1-e723-4611-9813-fc40e47948d1"),
                            CompanyId = new Guid("8b9f9345-7164-4331-a457-a9ec6280b483"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event B",
                            HobbyId = new Guid("30a559bc-d552-424d-84cc-57d51d1f1509"),
                            Image = "golf.jpg",
                            UserId = new Guid("9ad2a0ac-42fb-4286-b14d-4b6eb38483c7")
                        },
                        new
                        {
                            Id = new Guid("555869c1-f53a-4eee-aeef-3f03ae0ef0d8"),
                            AddressId = new Guid("d538d0f4-ca04-41ae-b0f4-7369ff23878a"),
                            CompanyId = new Guid("5768cb0c-6622-4b84-a453-85f6f16d8b68"),
                            Date = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Event C",
                            HobbyId = new Guid("92bcf749-d4b1-458a-ab00-7227a72808c5"),
                            Image = "running.jpeg",
                            UserId = new Guid("2f30135e-c2bc-47f5-a6ee-6e3f110369cc")
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
                            Id = new Guid("cfea316f-63b7-45be-89cb-c254b14ea41e"),
                            CompanyId = new Guid("a3062fbb-c0df-4b62-9db0-d57f0b006c5e"),
                            UserId = new Guid("5502c874-3582-494d-a8c5-3234d330346a")
                        },
                        new
                        {
                            Id = new Guid("a7b3ac4e-9dc1-4854-ab91-c4a31ac6a4ac"),
                            CompanyId = new Guid("8b9f9345-7164-4331-a457-a9ec6280b483"),
                            UserId = new Guid("9ad2a0ac-42fb-4286-b14d-4b6eb38483c7")
                        },
                        new
                        {
                            Id = new Guid("3fba98f6-e15d-4fe3-a3ab-f186cc69d108"),
                            CompanyId = new Guid("5768cb0c-6622-4b84-a453-85f6f16d8b68"),
                            UserId = new Guid("2f30135e-c2bc-47f5-a6ee-6e3f110369cc")
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
                            Id = new Guid("edc213c1-627f-407e-845b-177203631bb6"),
                            Description = "Gyyymm",
                            HobbyName = "Gym",
                            Type = "Indoor"
                        },
                        new
                        {
                            Id = new Guid("30a559bc-d552-424d-84cc-57d51d1f1509"),
                            Description = "stick",
                            HobbyName = "Golf",
                            Type = "outdoor"
                        },
                        new
                        {
                            Id = new Guid("92bcf749-d4b1-458a-ab00-7227a72808c5"),
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
                            Id = new Guid("5502c874-3582-494d-a8c5-3234d330346a"),
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
                            Id = new Guid("9ad2a0ac-42fb-4286-b14d-4b6eb38483c7"),
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
                            Id = new Guid("2f30135e-c2bc-47f5-a6ee-6e3f110369cc"),
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
                            Id = new Guid("7b39ba3e-213e-4cd6-9a8d-3b2388b1290e"),
                            HobbyId = new Guid("edc213c1-627f-407e-845b-177203631bb6"),
                            UserId = new Guid("5502c874-3582-494d-a8c5-3234d330346a")
                        },
                        new
                        {
                            Id = new Guid("f2d9b2ee-6740-419d-8e9e-2beddc2d13d4"),
                            HobbyId = new Guid("30a559bc-d552-424d-84cc-57d51d1f1509"),
                            UserId = new Guid("9ad2a0ac-42fb-4286-b14d-4b6eb38483c7")
                        },
                        new
                        {
                            Id = new Guid("440d52cd-a5bb-4c74-b3b5-3e42c27cf68f"),
                            HobbyId = new Guid("92bcf749-d4b1-458a-ab00-7227a72808c5"),
                            UserId = new Guid("2f30135e-c2bc-47f5-a6ee-6e3f110369cc")
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
