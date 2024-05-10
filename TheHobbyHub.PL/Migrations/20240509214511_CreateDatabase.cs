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
                    { new Guid("6ec5c6f3-dba9-480e-a209-90539399bbb3"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("91fcffd9-561e-4f21-a205-b7850a7a49bc"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("9f6835a2-be48-4de0-9b01-7a91f738480b"), "Anytown", "123 Main St", "CA", "12345" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
                    { new Guid("28dced8b-9093-4a22-82e8-e1d2c0b4b578"), "Gyyymm", "Gym", "Indoor" },
                    { new Guid("3e74a3b1-c61d-464c-84c1-cdac989ec511"), "stick", "Golf", "outdoor" },
                    { new Guid("409bf79c-399b-43da-88f7-967b3ab04950"), "Run", "Running", "Outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("3ff8fd93-7833-4c60-a937-fc3ac0d8e97f"), "Alexr@gmail.com", "Alex", "ar.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("668ec8ef-6240-4482-8723-2c051d5a30e1"), "bfoote@fvtc.edu", "Brian", "bfoote.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("f4d12cb8-d8fc-43b6-838b-a06be0861d76"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("183f2e93-5db1-4fb3-aae0-2b1de63d87d8"), new Guid("6ec5c6f3-dba9-480e-a209-90539399bbb3"), "Company B", "about company B", new Guid("668ec8ef-6240-4482-8723-2c051d5a30e1") },
                    { new Guid("20948c5c-8850-44d1-9a3a-78ec5ba1b6e1"), new Guid("91fcffd9-561e-4f21-a205-b7850a7a49bc"), "Company C", "about company C", new Guid("f4d12cb8-d8fc-43b6-838b-a06be0861d76") },
                    { new Guid("25518928-5bf1-4016-a453-1c05729b98f0"), new Guid("9f6835a2-be48-4de0-9b01-7a91f738480b"), "Company A", "about company A", new Guid("3ff8fd93-7833-4c60-a937-fc3ac0d8e97f") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0aab5c2e-cfca-4400-89b2-4ed97a4e8dca"), new Guid("409bf79c-399b-43da-88f7-967b3ab04950"), new Guid("f4d12cb8-d8fc-43b6-838b-a06be0861d76") },
                    { new Guid("c66165f4-828e-41fa-974b-6ce6ca6e3d67"), new Guid("3e74a3b1-c61d-464c-84c1-cdac989ec511"), new Guid("668ec8ef-6240-4482-8723-2c051d5a30e1") },
                    { new Guid("d095a61d-6f35-4681-846c-95ef1587fffe"), new Guid("28dced8b-9093-4a22-82e8-e1d2c0b4b578"), new Guid("3ff8fd93-7833-4c60-a937-fc3ac0d8e97f") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "EventName", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("06e10c2e-6564-4c25-9cd6-c7baaeac9e91"), new Guid("91fcffd9-561e-4f21-a205-b7850a7a49bc"), new Guid("20948c5c-8850-44d1-9a3a-78ec5ba1b6e1"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join us for an exhilarating morning of fitness and fun at our annual 5K Fun Run! Lace up your running shoes and gather your friends, family, and furry companions for a memorable event that promises laughter, camaraderie, and a healthy dose of exercise.", "5k Fun Run", new Guid("409bf79c-399b-43da-88f7-967b3ab04950"), "running.jpeg", new Guid("f4d12cb8-d8fc-43b6-838b-a06be0861d76") },
                    { new Guid("901ae788-3439-4c0b-ac42-22fac9315b6e"), new Guid("9f6835a2-be48-4de0-9b01-7a91f738480b"), new Guid("25518928-5bf1-4016-a453-1c05729b98f0"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flex your muscles and lift your spirits at our Amateur Powerlifting Event! Calling all strength enthusiasts to showcase their prowess in squat, bench press, and deadlift. Join us for a thrilling day of competition, camaraderie, and personal bests. Whether you're a seasoned lifter or just starting out, all are welcome to test their strength and determination. Don't miss this chance to push your limits and celebrate the power within you. Register now and let's lift together!", "Amatuer Powerlifting Event", new Guid("28dced8b-9093-4a22-82e8-e1d2c0b4b578"), "gym.jpeg", new Guid("3ff8fd93-7833-4c60-a937-fc3ac0d8e97f") },
                    { new Guid("f66d0f74-ff50-4915-9516-49e6c35b3790"), new Guid("6ec5c6f3-dba9-480e-a209-90539399bbb3"), new Guid("183f2e93-5db1-4fb3-aae0-2b1de63d87d8"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calling all amateur golfers! Tee up for a day of friendly competition at our Amateur Golf Tournament. Join us on the greens for a chance to showcase your skills, meet fellow enthusiasts, and enjoy a day of camaraderie. With prizes, refreshments, and beautiful fairways, it's an event you won't want to miss. Swing into action and register today!", "Amatuer Golf Tournament", new Guid("3e74a3b1-c61d-464c-84c1-cdac989ec511"), "golf.jpg", new Guid("668ec8ef-6240-4482-8723-2c051d5a30e1") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("49de7e55-78c2-41dc-befa-4086027d8732"), new Guid("183f2e93-5db1-4fb3-aae0-2b1de63d87d8"), new Guid("668ec8ef-6240-4482-8723-2c051d5a30e1") },
                    { new Guid("5fc6b9b8-b395-4b0a-bb4c-1ec3ca330a0f"), new Guid("20948c5c-8850-44d1-9a3a-78ec5ba1b6e1"), new Guid("f4d12cb8-d8fc-43b6-838b-a06be0861d76") },
                    { new Guid("cd6fd333-141d-4635-8845-e1cceafe3c21"), new Guid("25518928-5bf1-4016-a453-1c05729b98f0"), new Guid("3ff8fd93-7833-4c60-a937-fc3ac0d8e97f") }
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
