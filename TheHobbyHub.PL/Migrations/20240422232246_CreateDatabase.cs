using System;
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
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("14bb617d-da09-4a19-bce8-732737c7f47f"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("321dadb6-83df-4d1f-a3c1-6e21f649c3c2"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("a7a71bf4-abc6-4157-8214-c7f60da7efe8"), "Othertown", "456 Elm St", "NY", "54321" }
========
                    { new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), "Somewhere", "789 Oak St", "TX", "67890" }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("205e81e6-f972-4e54-92ae-2d3cec25e7d8"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("e52ca2f5-1c02-41e2-8b07-cf9d94421a6c"), "stick", "Golf", "outdoor.jpg", "outdoor" },
                    { new Guid("f9f41267-1692-4eb1-b540-0abcf4068e97"), "Gyyymm", "Gym", "image.jpg", "Indoor" }
========
                    { new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), "stick", "Golf", "outdoor" },
                    { new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), "Run", "Running", "Outdoor" },
                    { new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), "Gyyymm", "Gym", "Indoor" }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("0f2ce9ae-37c8-4a08-b799-80fdaa4340ea"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("50265275-c62f-4f76-bff7-097f91e2e357"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("62347337-4f60-4237-b7f0-b3e7f2705bad"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" }
========
                    { new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("3a2f969a-2594-4b2c-9ce9-4ecb0207538a"), new Guid("321dadb6-83df-4d1f-a3c1-6e21f649c3c2"), "Company A", "about company A", new Guid("62347337-4f60-4237-b7f0-b3e7f2705bad") },
                    { new Guid("9928ef2b-6218-40fd-86aa-7bb7ade4df93"), new Guid("14bb617d-da09-4a19-bce8-732737c7f47f"), "Company C", "about company C", new Guid("50265275-c62f-4f76-bff7-097f91e2e357") },
                    { new Guid("b465f88c-90b2-4487-be43-4522309c577d"), new Guid("a7a71bf4-abc6-4157-8214-c7f60da7efe8"), "Company B", "about company B", new Guid("0f2ce9ae-37c8-4a08-b799-80fdaa4340ea") }
========
                    { new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), "Company A", "about company A", new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), "Company C", "about company C", new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), "Company B", "about company B", new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("00284af5-033c-4b45-a963-0d1454561e5c"), new Guid("205e81e6-f972-4e54-92ae-2d3cec25e7d8"), new Guid("50265275-c62f-4f76-bff7-097f91e2e357") },
                    { new Guid("9f0387be-e811-4721-9536-be05fe373946"), new Guid("e52ca2f5-1c02-41e2-8b07-cf9d94421a6c"), new Guid("0f2ce9ae-37c8-4a08-b799-80fdaa4340ea") },
                    { new Guid("e4abd0b5-34c3-4ef8-8954-25108195bf92"), new Guid("f9f41267-1692-4eb1-b540-0abcf4068e97"), new Guid("62347337-4f60-4237-b7f0-b3e7f2705bad") }
========
                    { new Guid("31829956-c05e-43c1-9f27-1b53e03c2339"), new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("4c35e2d0-b743-422f-a0ca-8202abd9f776"), new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("e1fa0a98-7fac-4ff7-b39b-ab2527bc7862"), new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("a4fae146-df60-4620-a8a2-0b774372a9d9"), new Guid("a7a71bf4-abc6-4157-8214-c7f60da7efe8"), new Guid("b465f88c-90b2-4487-be43-4522309c577d"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("e52ca2f5-1c02-41e2-8b07-cf9d94421a6c"), "imageB.jpg", new Guid("0f2ce9ae-37c8-4a08-b799-80fdaa4340ea") },
                    { new Guid("ad09f6b0-4162-44d9-bc24-76c768f15132"), new Guid("14bb617d-da09-4a19-bce8-732737c7f47f"), new Guid("9928ef2b-6218-40fd-86aa-7bb7ade4df93"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("205e81e6-f972-4e54-92ae-2d3cec25e7d8"), "imageC.jpg", new Guid("50265275-c62f-4f76-bff7-097f91e2e357") },
                    { new Guid("cb03d266-4047-4eee-8ab5-9beb410a3fdb"), new Guid("321dadb6-83df-4d1f-a3c1-6e21f649c3c2"), new Guid("3a2f969a-2594-4b2c-9ce9-4ecb0207538a"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("f9f41267-1692-4eb1-b540-0abcf4068e97"), "imageA.jpg", new Guid("62347337-4f60-4237-b7f0-b3e7f2705bad") }
========
                    { new Guid("13cd03e5-22c8-473c-83ae-2a0f8db5bc6b"), new Guid("e1e825e4-9066-4ae9-8b05-87bcdb935442"), new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("9fabdf5a-50ac-44ca-98ab-cda066e16706"), "running.jpg", new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") },
                    { new Guid("1d7a3909-8041-4309-b67a-d3ea36d8cddf"), new Guid("887bb6ce-e468-43e5-8318-3a26aac7d9ae"), new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("39ec6c51-867a-4267-a1dd-00b8b0d13651"), "golf.jpg", new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") },
                    { new Guid("b91295f5-79cd-4fa8-b396-e3275bf46c7b"), new Guid("9c0edc25-e670-4197-a249-b2dab8cd83b9"), new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("badebd1f-3d38-4413-a952-cfc7d3a9e12b"), "gym.jpg", new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
<<<<<<<< HEAD:TheHobbyHub.PL/Migrations/20240422013839_CreateDatabase.cs
                    { new Guid("11918876-1f7e-473a-95e9-7715a4444cf5"), new Guid("b465f88c-90b2-4487-be43-4522309c577d"), new Guid("0f2ce9ae-37c8-4a08-b799-80fdaa4340ea") },
                    { new Guid("42ee7aa4-2b0c-4522-a96d-dcedb9eb5b00"), new Guid("9928ef2b-6218-40fd-86aa-7bb7ade4df93"), new Guid("50265275-c62f-4f76-bff7-097f91e2e357") },
                    { new Guid("a0abf85e-e492-45cb-bd2d-5eaa9a5e6acb"), new Guid("3a2f969a-2594-4b2c-9ce9-4ecb0207538a"), new Guid("62347337-4f60-4237-b7f0-b3e7f2705bad") }
========
                    { new Guid("0a94383b-d962-4767-867c-129f96fa70ac"), new Guid("6af33242-83fe-4afb-b9d4-f5c6ad5349c2"), new Guid("77ade5fe-f0a6-4743-a5e8-440bf6133583") },
                    { new Guid("2f876157-553f-4382-a417-75d67b5fe9ab"), new Guid("b4d9f1f9-ae2c-4d42-b0d4-7f38fb3b0405"), new Guid("c56be05d-664d-48c5-966f-2a99ca56a35b") },
                    { new Guid("bc767df3-3fa6-405d-a7ec-5e0197f86107"), new Guid("ab4f72a2-d45e-40a0-8ccf-8fa345d225d8"), new Guid("e271ca5f-cb3e-473b-9235-51ec396d76f2") }
>>>>>>>> 69cf93f71805db7154167b0098c81ce7b5eea28b:TheHobbyHub.PL/Migrations/20240422232246_CreateDatabase.cs
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
