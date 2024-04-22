﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheHobbyHub.PL.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    Zip = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddress_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblHobby",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHobby_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblCompany_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tblAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblCompany_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblUserHobby",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserHobby_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblUserHobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "tblHobby",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblUserHobby_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEvent_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblEvent_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tblAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEvent_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEvent_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "tblHobby",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEvent_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblFriend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFriend_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblFriend_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblFriend_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblAddress",
                columns: new[] { "Id", "City", "PostalAddress", "State", "Zip" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("06babd85-3edc-4756-a2e7-43468880da39"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"), "Anytown", "123 Main St", "CA", "12345" }
========
                    { new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), "Somewhere", "789 Oak St", "TX", "67890" }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"), "stick", "Golf", "outdoor.jpg", "outdoor" },
                    { new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"), "Gyyymm", "Gym", "image.jpg", "Indoor" },
                    { new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"), "Run", "Running", "run.jpg", "Outdoor" }
========
                    { new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), "stick", "Golf", "outdoor" },
                    { new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), "Run", "Running", "Outdoor" },
                    { new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), "Gyyymm", "Gym", "Indoor" }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" }
========
                    { new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"), new Guid("06babd85-3edc-4756-a2e7-43468880da39"), "Company C", "about company C", new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2") },
                    { new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"), new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"), "Company A", "about company A", new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee") },
                    { new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"), new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"), "Company B", "about company B", new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e") }
========
                    { new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), "Company A", "about company A", new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), "Company C", "about company C", new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), "Company B", "about company B", new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("78b00187-755c-4c99-95b1-79622f3f29d2"), new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"), new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2") },
                    { new Guid("98ce21ee-c757-4046-bc9e-250fba6ddac0"), new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"), new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e") },
                    { new Guid("f188862c-bf56-45df-9397-95d6adca6868"), new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"), new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee") }
========
                    { new Guid("31829956-c05e-43c1-9f27-1b53e03c2339"), new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("4c35e2d0-b743-422f-a0ca-8202abd9f776"), new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("e1fa0a98-7fac-4ff7-b39b-ab2527bc7862"), new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("4fa03199-9aa4-42fc-b138-513a2b5592ea"), new Guid("06babd85-3edc-4756-a2e7-43468880da39"), new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("aaf5d716-9a3c-43b4-9857-80cdf99b1b4e"), "imageC.jpg", new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2") },
                    { new Guid("d65501cc-f625-4564-ab1d-497bb109f33d"), new Guid("efe094b2-f940-4c8a-9d64-e0046883941f"), new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("79f7a87c-a41e-4c42-8479-07b0a3a31106"), "imageA.jpg", new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee") },
                    { new Guid("d818fbb8-1049-48cf-9cdf-4931bef2c908"), new Guid("748fd9e5-fbd4-43e6-bdd6-8375f8fb0d10"), new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("10cb2afe-b9e3-4bdd-a97f-b1ea20b112cc"), "imageB.jpg", new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e") }
========
                    { new Guid("13cd03e5-22c8-473c-83ae-2a0f8db5bc6b"), new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), "running.jpg", new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("1d7a3909-8041-4309-b67a-d3ea36d8cddf"), new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), "golf.jpg", new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") },
                    { new Guid("b91295f5-79cd-4fa8-b396-e3275bf46c7b"), new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), "gym.jpg", new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422232027_CreateDatabase.cs
                    { new Guid("4554c2ae-b7dc-453f-894c-409bc2d6411c"), new Guid("23fbdea2-cc45-4570-a104-0b533fe86c87"), new Guid("0e7c4c68-81a0-4de6-8d1e-d0301e1f90ee") },
                    { new Guid("80370ce0-d65d-45fd-bcb0-fcb54b68bc59"), new Guid("b5add715-f0f0-4969-b097-250fb59f01fd"), new Guid("8b6eb8ba-7cc5-4b95-bec6-0ba97c924b7e") },
                    { new Guid("b420d975-0b43-49a5-a717-34dc7c205bfe"), new Guid("1a8e61d4-f3a4-499b-a1bc-4fe9f4f7cd4d"), new Guid("806d24f9-ce8b-495e-b023-ef49dac3fdd2") }
========
                    { new Guid("0a94383b-d962-4767-867c-129f96fa70ac"), new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("2f876157-553f-4382-a417-75d67b5fe9ab"), new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") },
                    { new Guid("bc767df3-3fa6-405d-a7ec-5e0197f86107"), new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") }
>>>>>>>> TN-Working-buildable:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCompany_AddressId",
                table: "tblCompany",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCompany_UserId",
                table: "tblCompany",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_AddressId",
                table: "tblEvent",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_CompanyId",
                table: "tblEvent",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_HobbyId",
                table: "tblEvent",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_UserId",
                table: "tblEvent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFriend_CompanyId",
                table: "tblFriend",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFriend_UserId",
                table: "tblFriend",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserHobby_HobbyId",
                table: "tblUserHobby",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblUserHobby_UserId",
                table: "tblUserHobby",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.DropTable(
                name: "tblFriend");

            migrationBuilder.DropTable(
                name: "tblUserHobby");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropTable(
                name: "tblHobby");

            migrationBuilder.DropTable(
                name: "tblAddress");

            migrationBuilder.DropTable(
                name: "tblUser");
        }
    }
}
