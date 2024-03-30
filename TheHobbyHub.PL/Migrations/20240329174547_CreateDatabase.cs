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
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
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
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                    { new Guid("11855591-7d7d-4584-a01e-6bf8ae29c04c"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("65bfbb3a-4886-45cc-b2b2-c9a6b1c653a0"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("ee4f7348-25f0-437b-9593-4d7a43347574"), "Somewhere", "789 Oak St", "TX", "67890" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("1b9801b2-0a55-49c0-a58b-cecaed221c87"), "stick", "Golf", "outdoor.jpg", "outdoor" },
                    { new Guid("2ed0b4ae-fbd7-4082-9a6c-537c7b40d59e"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("b3ceae30-52f2-437c-9d23-d9294fcdb32c"), "Gyyymm", "Gym", "image.jpg", "Indoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("5a7c45e4-501f-478b-a7ef-3e75fca12323"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("b6fcceff-33be-4435-932c-eb9a45699dd7"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("e5516769-3683-4c79-ad17-7e6bc33b3d41"), "ss@gmail.com", "Someone", "image.jpg", "Somebody", "B/qgP3XrZmyneblY753llJ5gtQ4=", "3333333333", "SSM" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Image", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("6b4e8279-2dcf-4d09-8952-841b450ae36a"), new Guid("ee4f7348-25f0-437b-9593-4d7a43347574"), "Company C", "imageC.jpg", "urYijG3X2+D44I400gasYPqLBHw=", "companyC" },
                    { new Guid("7a14723e-3371-45ff-89d3-06e6cc771f1a"), new Guid("11855591-7d7d-4584-a01e-6bf8ae29c04c"), "Company A", "imageA.jpg", "/BafCUbj3r56CjioX1dcB1ynX20=", "copanyA" },
                    { new Guid("b149fe44-0c2b-4d16-92bc-067baa1261b8"), new Guid("65bfbb3a-4886-45cc-b2b2-c9a6b1c653a0"), "Company B", "imageB.jpg", "38Nd3/2M+aip9/TyIzVYXKylmQo=", "companyB" }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2d7fd79b-ac72-48e6-b41f-e155aa9d6fe6"), new Guid("1b9801b2-0a55-49c0-a58b-cecaed221c87"), new Guid("e5516769-3683-4c79-ad17-7e6bc33b3d41") },
                    { new Guid("3e2a933d-a450-4fc1-af4f-f6ac3ac00dab"), new Guid("b3ceae30-52f2-437c-9d23-d9294fcdb32c"), new Guid("b6fcceff-33be-4435-932c-eb9a45699dd7") },
                    { new Guid("613de862-8bdc-4948-817e-46e81d458686"), new Guid("2ed0b4ae-fbd7-4082-9a6c-537c7b40d59e"), new Guid("5a7c45e4-501f-478b-a7ef-3e75fca12323") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("13593c3a-45a9-4076-bcf6-c07dce3fa8e7"), new Guid("ee4f7348-25f0-437b-9593-4d7a43347574"), new Guid("6b4e8279-2dcf-4d09-8952-841b450ae36a"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("2ed0b4ae-fbd7-4082-9a6c-537c7b40d59e"), "imageC.jpg", new Guid("5a7c45e4-501f-478b-a7ef-3e75fca12323") },
                    { new Guid("7eae9c6e-2458-4477-9b6c-e68133959d11"), new Guid("65bfbb3a-4886-45cc-b2b2-c9a6b1c653a0"), new Guid("b149fe44-0c2b-4d16-92bc-067baa1261b8"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("1b9801b2-0a55-49c0-a58b-cecaed221c87"), "imageB.jpg", new Guid("e5516769-3683-4c79-ad17-7e6bc33b3d41") },
                    { new Guid("a6a8b2dd-1abf-41c6-9886-73d4f4b7fbd6"), new Guid("11855591-7d7d-4584-a01e-6bf8ae29c04c"), new Guid("7a14723e-3371-45ff-89d3-06e6cc771f1a"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("b3ceae30-52f2-437c-9d23-d9294fcdb32c"), "imageA.jpg", new Guid("b6fcceff-33be-4435-932c-eb9a45699dd7") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("028ffbc0-6f29-4279-88cf-c5f74f807b15"), new Guid("6b4e8279-2dcf-4d09-8952-841b450ae36a"), new Guid("5a7c45e4-501f-478b-a7ef-3e75fca12323") },
                    { new Guid("99811ea2-a7a2-4979-a266-4a2e4d55d45c"), new Guid("b149fe44-0c2b-4d16-92bc-067baa1261b8"), new Guid("e5516769-3683-4c79-ad17-7e6bc33b3d41") },
                    { new Guid("fde8db38-3046-41fb-8855-086b12f95778"), new Guid("7a14723e-3371-45ff-89d3-06e6cc771f1a"), new Guid("b6fcceff-33be-4435-932c-eb9a45699dd7") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCompany_AddressId",
                table: "tblCompany",
                column: "AddressId");

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
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblAddress");
        }
    }
}
