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
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    tblAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    tblUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEvent_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEvent_tblAddress_tblAddressId",
                        column: x => x.tblAddressId,
                        principalTable: "tblAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tblEvent_tblUser_tblUserId",
                        column: x => x.tblUserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEvent_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
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

            migrationBuilder.CreateTable(
                name: "tblEventAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEventAddress_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblEventAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tblAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEventAddress_EventId",
                        column: x => x.EventId,
                        principalTable: "tblEvent",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblEventCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompaniesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEventCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblEventCompany_tblCompany_CompaniesId",
                        column: x => x.CompaniesId,
                        principalTable: "tblCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEventCompany_tblEvent_EventsId",
                        column: x => x.EventsId,
                        principalTable: "tblEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblEventHobby",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEventHobby_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblEventHobby_EventId",
                        column: x => x.EventId,
                        principalTable: "tblEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEventHobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "tblHobby",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblEventUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEventUser_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblEventUser_EventId",
                        column: x => x.EventId,
                        principalTable: "tblEvent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblEventUser_UserId",
                        column: x => x.UserId,
                        principalTable: "tblUser",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "tblAddress",
                columns: new[] { "Id", "Address", "City", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("73cfc8e2-2da1-4c18-b018-288fc2c97538"), "789 Oak St", "Somewhere", "TX", "67890" },
                    { new Guid("e56212a4-d1b1-4c36-a668-b9ae561cd4b7"), "123 Main St", "Anytown", "CA", "12345" },
                    { new Guid("f1823c80-54b1-4cb6-84b7-a447905e78f7"), "456 Elm St", "Othertown", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Image", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("302948ec-d423-491c-8f42-c096b21c6c02"), new Guid("00000000-0000-0000-0000-000000000000"), "Company B", "imageB.jpg", "38Nd3/2M+aip9/TyIzVYXKylmQo=", "companyB" },
                    { new Guid("55ace91d-60a9-4ff6-b359-a52d7ce0e8ac"), new Guid("00000000-0000-0000-0000-000000000000"), "Company C", "imageC.jpg", "urYijG3X2+D44I400gasYPqLBHw=", "companyC" },
                    { new Guid("fff0570d-54f6-4f12-b1f3-a4c325fd9b12"), new Guid("00000000-0000-0000-0000-000000000000"), "Company A", "imageA.jpg", "/BafCUbj3r56CjioX1dcB1ynX20=", "copanyA" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("1809d7f9-0cf9-446d-a797-5a02dafb0688"), "Gyyymm", "Gym", "image.jpg", "Indoor" },
                    { new Guid("38290c90-8d48-42c6-84fc-ca434f2c49dc"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("c28a0700-6a10-4948-aae7-0f269824d188"), "stick", "Golf", "outdoor.jpg", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("1f3d329a-aa0b-4c13-985b-9316464a7927"), "ss@gmail.com", "Someone", "image.jpg", "Somebody", "B/qgP3XrZmyneblY753llJ5gtQ4=", "3333333333", "SSM" },
                    { new Guid("72dec7c7-54ec-472c-8671-04d2fdad571a"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("a8890b05-1bd2-42ec-a38c-405b82d68263"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "CompanyId", "Date", "Description", "Image", "tblAddressId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("64d7f5f7-8f01-4415-8f1a-be85264d3af5"), new Guid("302948ec-d423-491c-8f42-c096b21c6c02"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", "imageB.jpg", null, null },
                    { new Guid("79f1a58d-10f7-4bbf-be3c-57ba93b4eae8"), new Guid("fff0570d-54f6-4f12-b1f3-a4c325fd9b12"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", "imageA.jpg", null, null },
                    { new Guid("b2a95c1f-ccef-45dc-acf7-b4dfb3054bfa"), new Guid("55ace91d-60a9-4ff6-b359-a52d7ce0e8ac"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", "imageC.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("55738053-d5c8-4f3a-b822-bbf3051fea4f"), new Guid("302948ec-d423-491c-8f42-c096b21c6c02"), new Guid("b751f7dd-99ce-4b8a-b895-e9a91a3f1317") },
                    { new Guid("c366e7c1-1a71-4036-9f4c-236c6034bd83"), new Guid("fff0570d-54f6-4f12-b1f3-a4c325fd9b12"), new Guid("5d7abddc-4d8e-4105-83ce-c83ceb0b9c2b") },
                    { new Guid("f414443f-9032-466a-a171-fbbf8e7769b1"), new Guid("55ace91d-60a9-4ff6-b359-a52d7ce0e8ac"), new Guid("c2f498f0-952a-450e-bfbc-259a244dc762") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("33cea0d4-e7f9-40b1-8966-3ffbf9f49eea"), new Guid("c28a0700-6a10-4948-aae7-0f269824d188"), new Guid("1f3d329a-aa0b-4c13-985b-9316464a7927") },
                    { new Guid("e55ca5f3-c3b7-46f4-a04f-ec73e946b873"), new Guid("1809d7f9-0cf9-446d-a797-5a02dafb0688"), new Guid("72dec7c7-54ec-472c-8671-04d2fdad571a") },
                    { new Guid("f8d271e9-bf2b-40ab-bade-470e0b50ff74"), new Guid("38290c90-8d48-42c6-84fc-ca434f2c49dc"), new Guid("a8890b05-1bd2-42ec-a38c-405b82d68263") }
                });

            migrationBuilder.InsertData(
                table: "tblEventAddress",
                columns: new[] { "Id", "AddressId", "EventId" },
                values: new object[,]
                {
                    { new Guid("49c79e15-65f2-46c1-8e9d-6c4eae70da05"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("64d7f5f7-8f01-4415-8f1a-be85264d3af5") },
                    { new Guid("9218b4a8-d0e6-489e-b8fa-a72f999588b2"), new Guid("a8890b05-1bd2-42ec-a38c-405b82d68263"), new Guid("b2a95c1f-ccef-45dc-acf7-b4dfb3054bfa") },
                    { new Guid("af0a6c79-6d47-43ed-b241-a874ab91b255"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("79f1a58d-10f7-4bbf-be3c-57ba93b4eae8") }
                });

            migrationBuilder.InsertData(
                table: "tblEventHobby",
                columns: new[] { "Id", "EventId", "HobbyId" },
                values: new object[,]
                {
                    { new Guid("91ca67cb-b913-44d2-860d-12b517d50bac"), new Guid("64d7f5f7-8f01-4415-8f1a-be85264d3af5"), new Guid("c28a0700-6a10-4948-aae7-0f269824d188") },
                    { new Guid("af42d9b7-7d90-4853-a399-9d5c498d570d"), new Guid("b2a95c1f-ccef-45dc-acf7-b4dfb3054bfa"), new Guid("38290c90-8d48-42c6-84fc-ca434f2c49dc") },
                    { new Guid("d79a8abf-540d-48e3-80d6-452cc20353ac"), new Guid("79f1a58d-10f7-4bbf-be3c-57ba93b4eae8"), new Guid("1809d7f9-0cf9-446d-a797-5a02dafb0688") }
                });

            migrationBuilder.InsertData(
                table: "tblEventUser",
                columns: new[] { "Id", "EventId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4fa0bd92-5de2-48f5-a7db-3fcdecf5bb5a"), new Guid("79f1a58d-10f7-4bbf-be3c-57ba93b4eae8"), new Guid("72dec7c7-54ec-472c-8671-04d2fdad571a") },
                    { new Guid("7ce66c43-56e0-470d-a704-25f8604d0828"), new Guid("b2a95c1f-ccef-45dc-acf7-b4dfb3054bfa"), new Guid("a8890b05-1bd2-42ec-a38c-405b82d68263") },
                    { new Guid("f6580155-0165-4fd9-944f-1185cc286921"), new Guid("64d7f5f7-8f01-4415-8f1a-be85264d3af5"), new Guid("1f3d329a-aa0b-4c13-985b-9316464a7927") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCompany_AddressId",
                table: "tblCompany",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_CompanyId",
                table: "tblEvent",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_tblAddressId",
                table: "tblEvent",
                column: "tblAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEvent_tblUserId",
                table: "tblEvent",
                column: "tblUserId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventAddress_AddressId",
                table: "tblEventAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventAddress_EventId",
                table: "tblEventAddress",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventCompany_CompaniesId",
                table: "tblEventCompany",
                column: "CompaniesId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventCompany_EventsId",
                table: "tblEventCompany",
                column: "EventsId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventHobby_EventId",
                table: "tblEventHobby",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventHobby_HobbyId",
                table: "tblEventHobby",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventUser_EventId",
                table: "tblEventUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_tblEventUser_UserId",
                table: "tblEventUser",
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
                name: "tblEventAddress");

            migrationBuilder.DropTable(
                name: "tblEventCompany");

            migrationBuilder.DropTable(
                name: "tblEventHobby");

            migrationBuilder.DropTable(
                name: "tblEventUser");

            migrationBuilder.DropTable(
                name: "tblFriend");

            migrationBuilder.DropTable(
                name: "tblUserHobby");

            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.DropTable(
                name: "tblHobby");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropTable(
                name: "tblAddress");
        }
    }
}
