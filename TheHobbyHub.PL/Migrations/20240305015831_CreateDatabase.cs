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
                    Address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
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
                columns: new[] { "Id", "Address", "City", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("a589adee-3a90-41d6-b4ac-96e5c0a7a40f"), "789 Oak St", "Somewhere", "TX", "67890" },
                    { new Guid("b683d0fd-6505-42ef-9913-5fef0ddbd7a8"), "123 Main St", "Anytown", "CA", "12345" },
                    { new Guid("e259ef18-8a98-4ce4-8a5d-3f26e381fe27"), "456 Elm St", "Othertown", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("4b6c2909-b09e-480a-96c0-128ac3c1a532"), "Gyyymm", "Gym", "image.jpg", "Indoor" },
                    { new Guid("5d2ed8f4-9406-4a11-8edd-56f48ab5dda8"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("7fe1cf20-9d9d-4356-b6c1-415eeb5961a0"), "stick", "Golf", "outdoor.jpg", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("79dbf572-83c3-4537-9b46-5504f3086320"), "ss@gmail.com", "Someone", "image.jpg", "Somebody", "B/qgP3XrZmyneblY753llJ5gtQ4=", "3333333333", "SSM" },
                    { new Guid("d5cd7228-2514-4327-89ca-01b3832d82cb"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("ddcd9bd2-4cdf-44c4-9722-e2b3b7b0b7be"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Image", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("215726ac-7186-42f2-94ab-37109dded89e"), new Guid("a589adee-3a90-41d6-b4ac-96e5c0a7a40f"), "Company C", "imageC.jpg", "urYijG3X2+D44I400gasYPqLBHw=", "companyC" },
                    { new Guid("b40e2593-d543-482f-8b2e-573a5b545095"), new Guid("e259ef18-8a98-4ce4-8a5d-3f26e381fe27"), "Company B", "imageB.jpg", "38Nd3/2M+aip9/TyIzVYXKylmQo=", "companyB" },
                    { new Guid("be41a5c0-289d-4fb4-92df-b16072b4619a"), new Guid("b683d0fd-6505-42ef-9913-5fef0ddbd7a8"), "Company A", "imageA.jpg", "/BafCUbj3r56CjioX1dcB1ynX20=", "copanyA" }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1a684d9d-2949-42cd-aad3-0dbfa118a710"), new Guid("5d2ed8f4-9406-4a11-8edd-56f48ab5dda8"), new Guid("d5cd7228-2514-4327-89ca-01b3832d82cb") },
                    { new Guid("6844fd71-c9b3-4f81-817e-a362478773a2"), new Guid("7fe1cf20-9d9d-4356-b6c1-415eeb5961a0"), new Guid("79dbf572-83c3-4537-9b46-5504f3086320") },
                    { new Guid("cfd9d7c4-e637-46b4-9a01-d75e9df2854a"), new Guid("4b6c2909-b09e-480a-96c0-128ac3c1a532"), new Guid("ddcd9bd2-4cdf-44c4-9722-e2b3b7b0b7be") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("080823d8-0491-4acc-b7b1-5b2b79e97f77"), new Guid("a589adee-3a90-41d6-b4ac-96e5c0a7a40f"), new Guid("215726ac-7186-42f2-94ab-37109dded89e"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("4861dc85-1107-45e2-a77a-b156438707ef"), "imageC.jpg", new Guid("0553b046-f861-49af-854b-49c9aab212ab") },
                    { new Guid("c191acb2-2e63-45ac-926e-d2cc005ed65f"), new Guid("b683d0fd-6505-42ef-9913-5fef0ddbd7a8"), new Guid("be41a5c0-289d-4fb4-92df-b16072b4619a"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("ce136077-ff46-40f8-a7ec-881e481580ed"), "imageA.jpg", new Guid("1dfcfb60-c1d6-4a34-80c5-f7d85b37d8fc") },
                    { new Guid("ef917c8f-bd4c-4d17-8270-c9820b593e0b"), new Guid("e259ef18-8a98-4ce4-8a5d-3f26e381fe27"), new Guid("b40e2593-d543-482f-8b2e-573a5b545095"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("9d245fe4-9dd2-49f8-bc6d-7ee863dceff4"), "imageB.jpg", new Guid("f22783b7-fe4d-4c38-8411-d7d9fd67b8f2") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8721b38a-7d3d-4352-9383-5fc4df669164"), new Guid("b40e2593-d543-482f-8b2e-573a5b545095"), new Guid("f22783b7-fe4d-4c38-8411-d7d9fd67b8f2") },
                    { new Guid("a217758a-f58f-4dc6-a997-bb8cbe626d58"), new Guid("be41a5c0-289d-4fb4-92df-b16072b4619a"), new Guid("1dfcfb60-c1d6-4a34-80c5-f7d85b37d8fc") },
                    { new Guid("ba9f3505-3614-4059-b46d-89c9a42c93fc"), new Guid("215726ac-7186-42f2-94ab-37109dded89e"), new Guid("0553b046-f861-49af-854b-49c9aab212ab") }
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
