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
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
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
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
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
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
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
                    { new Guid("0486052e-6a29-42a9-b98a-ad28405903d7"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("4fc71c1a-bd5c-46cc-a879-4fedfaecadc9"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("d66a8e9c-f2e4-4cd9-850c-ba96c9b30f36"), "Othertown", "456 Elm St", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
                    { new Guid("3eaf2752-0ae4-4e8d-a7e3-a6b623a7c460"), "stick", "Golf", "outdoor" },
                    { new Guid("906f55ed-8003-43ef-af6d-c91ecff9d462"), "Run", "Running", "Outdoor" },
                    { new Guid("ae1d08c0-ad38-4c9a-a8f2-1c2b26e5de8e"), "Gyyymm", "Gym", "Indoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("8e4d07a2-9a9f-4bce-ab3c-51be8ca97feb"), "Alexr@gmail.com", "Alex", "ar.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("cdf26579-2a18-45f8-8e40-043aad8c52c5"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("fc0ba13e-91b7-431d-814d-28f10e34e3b1"), "bfoote@fvtc.edu", "Brian", "bfoote.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("3833c25e-352a-47e5-8df1-6989d4d16f50"), new Guid("4fc71c1a-bd5c-46cc-a879-4fedfaecadc9"), "Company A", "about company A", new Guid("8e4d07a2-9a9f-4bce-ab3c-51be8ca97feb") },
                    { new Guid("6744ce82-002d-4305-8f52-5e28a342d2de"), new Guid("d66a8e9c-f2e4-4cd9-850c-ba96c9b30f36"), "Company B", "about company B", new Guid("fc0ba13e-91b7-431d-814d-28f10e34e3b1") },
                    { new Guid("e60261f1-1da0-4234-b06f-3afec3070450"), new Guid("0486052e-6a29-42a9-b98a-ad28405903d7"), "Company C", "about company C", new Guid("cdf26579-2a18-45f8-8e40-043aad8c52c5") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5ecde5ec-bd9b-4966-b05f-530f16f96ac9"), new Guid("3eaf2752-0ae4-4e8d-a7e3-a6b623a7c460"), new Guid("fc0ba13e-91b7-431d-814d-28f10e34e3b1") },
                    { new Guid("65134535-e95e-4ca3-ba2a-c63ace789012"), new Guid("906f55ed-8003-43ef-af6d-c91ecff9d462"), new Guid("cdf26579-2a18-45f8-8e40-043aad8c52c5") },
                    { new Guid("ff0e36ed-7c03-40ee-b79c-dbc39c5230ee"), new Guid("ae1d08c0-ad38-4c9a-a8f2-1c2b26e5de8e"), new Guid("8e4d07a2-9a9f-4bce-ab3c-51be8ca97feb") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "EventName", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("7304c1bc-571d-4942-915b-3e2f536e5c8d"), new Guid("0486052e-6a29-42a9-b98a-ad28405903d7"), new Guid("e60261f1-1da0-4234-b06f-3afec3070450"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join us for an exhilarating morning of fitness and fun at our annual 5K Fun Run! Lace up your running shoes and gather your friends, family, and furry companions for a memorable event that promises laughter, camaraderie, and a healthy dose of exercise.", "5k Fun Run", new Guid("906f55ed-8003-43ef-af6d-c91ecff9d462"), "running.jpeg", new Guid("cdf26579-2a18-45f8-8e40-043aad8c52c5") },
                    { new Guid("bc018c0a-0aff-425a-a5a9-e7cdd36f3c0a"), new Guid("4fc71c1a-bd5c-46cc-a879-4fedfaecadc9"), new Guid("3833c25e-352a-47e5-8df1-6989d4d16f50"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flex your muscles and lift your spirits at our Amateur Powerlifting Event! Calling all strength enthusiasts to showcase their prowess in squat, bench press, and deadlift. Join us for a thrilling day of competition, camaraderie, and personal bests. Whether you're a seasoned lifter or just starting out, all are welcome to test their strength and determination. Don't miss this chance to push your limits and celebrate the power within you. Register now and let's lift together!", "Amatuer Powerlifting Event", new Guid("ae1d08c0-ad38-4c9a-a8f2-1c2b26e5de8e"), "gym.jpeg", new Guid("8e4d07a2-9a9f-4bce-ab3c-51be8ca97feb") },
                    { new Guid("c8465bc2-7634-4e2b-bf62-84956e447027"), new Guid("d66a8e9c-f2e4-4cd9-850c-ba96c9b30f36"), new Guid("6744ce82-002d-4305-8f52-5e28a342d2de"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calling all amateur golfers! Tee up for a day of friendly competition at our Amateur Golf Tournament. Join us on the greens for a chance to showcase your skills, meet fellow enthusiasts, and enjoy a day of camaraderie. With prizes, refreshments, and beautiful fairways, it's an event you won't want to miss. Swing into action and register today!", "Amatuer Golf Tournament", new Guid("3eaf2752-0ae4-4e8d-a7e3-a6b623a7c460"), "golf.jpg", new Guid("fc0ba13e-91b7-431d-814d-28f10e34e3b1") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("86190cb9-2ade-4619-9c78-cac54b56abdd"), new Guid("3833c25e-352a-47e5-8df1-6989d4d16f50"), new Guid("8e4d07a2-9a9f-4bce-ab3c-51be8ca97feb") },
                    { new Guid("9e5258f7-9441-4c5a-8542-3c6a6fb0c4fd"), new Guid("6744ce82-002d-4305-8f52-5e28a342d2de"), new Guid("fc0ba13e-91b7-431d-814d-28f10e34e3b1") },
                    { new Guid("d953422a-866e-40c8-83d9-f8cce297b642"), new Guid("e60261f1-1da0-4234-b06f-3afec3070450"), new Guid("cdf26579-2a18-45f8-8e40-043aad8c52c5") }
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
