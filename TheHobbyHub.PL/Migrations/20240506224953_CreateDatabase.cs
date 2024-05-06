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
                    { new Guid("6531c1af-d51e-4491-b688-8d0b7f264ac3"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("8056bba1-4951-49a6-aa93-c947fedcf25a"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("d4c6c2a3-dc63-4b2e-83c5-d8372ff44920"), "Anytown", "123 Main St", "CA", "12345" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
                    { new Guid("02a356e8-eced-49b6-a241-7f22ad929578"), "Run", "Running", "Outdoor" },
                    { new Guid("0b9c7aab-05ad-4b08-b06d-0fa1e3c2af42"), "Gyyymm", "Gym", "Indoor" },
                    { new Guid("60a4eb15-93cf-4c14-8f95-22e38396febb"), "stick", "Golf", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("0722a920-9b8e-4ff6-95f3-a4a1102344d7"), "Alexr@gmail.com", "Alex", "ar.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("a766e3f5-c01f-4940-a759-98e469f6745a"), "bfoote@fvtc.edu", "Brian", "bfoote.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("f2125206-26f5-4e2a-9209-7673db62e0b9"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("5d580872-87dc-4d71-9ecf-c6aae8e18878"), new Guid("8056bba1-4951-49a6-aa93-c947fedcf25a"), "Company B", "about company B", new Guid("a766e3f5-c01f-4940-a759-98e469f6745a") },
                    { new Guid("64283250-f4b6-48f1-ac25-43d5750850c8"), new Guid("d4c6c2a3-dc63-4b2e-83c5-d8372ff44920"), "Company A", "about company A", new Guid("0722a920-9b8e-4ff6-95f3-a4a1102344d7") },
                    { new Guid("6f3c35c8-bca9-44ac-994d-16c546cf557c"), new Guid("6531c1af-d51e-4491-b688-8d0b7f264ac3"), "Company C", "about company C", new Guid("f2125206-26f5-4e2a-9209-7673db62e0b9") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("4b953099-d0be-4f64-9d95-467b6f15a623"), new Guid("60a4eb15-93cf-4c14-8f95-22e38396febb"), new Guid("a766e3f5-c01f-4940-a759-98e469f6745a") },
                    { new Guid("4d9a3f7f-aab3-456e-b84a-21d7b0fec4ba"), new Guid("02a356e8-eced-49b6-a241-7f22ad929578"), new Guid("f2125206-26f5-4e2a-9209-7673db62e0b9") },
                    { new Guid("9f40e806-8197-4b03-996b-8fa633720718"), new Guid("0b9c7aab-05ad-4b08-b06d-0fa1e3c2af42"), new Guid("0722a920-9b8e-4ff6-95f3-a4a1102344d7") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("2f4c3a59-be17-4902-8647-f85bd3d62dd2"), new Guid("d4c6c2a3-dc63-4b2e-83c5-d8372ff44920"), new Guid("64283250-f4b6-48f1-ac25-43d5750850c8"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("0b9c7aab-05ad-4b08-b06d-0fa1e3c2af42"), "gym.jpeg", new Guid("0722a920-9b8e-4ff6-95f3-a4a1102344d7") },
                    { new Guid("4e65ced6-0ddb-444d-883f-d9e8f4c8a3fd"), new Guid("6531c1af-d51e-4491-b688-8d0b7f264ac3"), new Guid("6f3c35c8-bca9-44ac-994d-16c546cf557c"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("02a356e8-eced-49b6-a241-7f22ad929578"), "running.jpeg", new Guid("f2125206-26f5-4e2a-9209-7673db62e0b9") },
                    { new Guid("69f5a06d-583b-4079-a97f-ccbb2e4a6755"), new Guid("8056bba1-4951-49a6-aa93-c947fedcf25a"), new Guid("5d580872-87dc-4d71-9ecf-c6aae8e18878"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("60a4eb15-93cf-4c14-8f95-22e38396febb"), "golf.jpg", new Guid("a766e3f5-c01f-4940-a759-98e469f6745a") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("5e6db9aa-5e14-4aec-ab9c-9e2910aa9731"), new Guid("64283250-f4b6-48f1-ac25-43d5750850c8"), new Guid("0722a920-9b8e-4ff6-95f3-a4a1102344d7") },
                    { new Guid("7f7f58e1-8ba3-4e75-a7f8-248bfcc43bad"), new Guid("6f3c35c8-bca9-44ac-994d-16c546cf557c"), new Guid("f2125206-26f5-4e2a-9209-7673db62e0b9") },
                    { new Guid("a9d649e4-1a5b-4595-b34b-d6f1b27262fb"), new Guid("5d580872-87dc-4d71-9ecf-c6aae8e18878"), new Guid("a766e3f5-c01f-4940-a759-98e469f6745a") }
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
