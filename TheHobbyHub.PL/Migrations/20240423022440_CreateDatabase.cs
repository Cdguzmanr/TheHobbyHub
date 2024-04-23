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
                    { new Guid("11ebc698-16d1-4b2c-9ce4-97fbcdd2ff6a"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("d46d46f5-e179-4d0f-8cb2-48415b9d4c34"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("f835ce81-082f-4bbd-8ff6-aa78b5f63d51"), "Othertown", "456 Elm St", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
                    { new Guid("48756900-7fcf-4247-b18e-1b67c9f5aad6"), "Gyyymm", "Gym", "Indoor" },
                    { new Guid("48f5a8b2-2018-4454-bf3c-22a995b9ed42"), "Run", "Running", "Outdoor" },
                    { new Guid("bf2bbfcd-84f1-4144-8c99-c2e1315f0df8"), "stick", "Golf", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("3f5483eb-fea3-49da-91d7-320ee42def6d"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("d720eb86-fc41-48c9-ae24-98793cc71e5a"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("effcd336-50c4-4467-8d2b-a20b4387ee7c"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("285444a5-af73-4f11-9867-89fb9597cd90"), new Guid("11ebc698-16d1-4b2c-9ce4-97fbcdd2ff6a"), "Company C", "about company C", new Guid("3f5483eb-fea3-49da-91d7-320ee42def6d") },
                    { new Guid("861f08e9-cb5b-4a8f-902b-5eb1b01777f7"), new Guid("d46d46f5-e179-4d0f-8cb2-48415b9d4c34"), "Company A", "about company A", new Guid("effcd336-50c4-4467-8d2b-a20b4387ee7c") },
                    { new Guid("c01a5035-3679-41be-ab7a-234de66f7702"), new Guid("f835ce81-082f-4bbd-8ff6-aa78b5f63d51"), "Company B", "about company B", new Guid("d720eb86-fc41-48c9-ae24-98793cc71e5a") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a2d8bedc-bada-41cd-9212-014530545d6b"), new Guid("48756900-7fcf-4247-b18e-1b67c9f5aad6"), new Guid("effcd336-50c4-4467-8d2b-a20b4387ee7c") },
                    { new Guid("e06735cb-9eba-458f-9e62-2b6ec8f698c7"), new Guid("bf2bbfcd-84f1-4144-8c99-c2e1315f0df8"), new Guid("d720eb86-fc41-48c9-ae24-98793cc71e5a") },
                    { new Guid("e4ebb4d3-c743-4d86-8900-3930e1401e1f"), new Guid("48f5a8b2-2018-4454-bf3c-22a995b9ed42"), new Guid("3f5483eb-fea3-49da-91d7-320ee42def6d") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("61c8f9a5-71c9-403b-9543-9e5699fa52df"), new Guid("d46d46f5-e179-4d0f-8cb2-48415b9d4c34"), new Guid("861f08e9-cb5b-4a8f-902b-5eb1b01777f7"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("48756900-7fcf-4247-b18e-1b67c9f5aad6"), "gym.jpeg", new Guid("effcd336-50c4-4467-8d2b-a20b4387ee7c") },
                    { new Guid("99787a61-d644-4541-a061-e8720b0992ac"), new Guid("11ebc698-16d1-4b2c-9ce4-97fbcdd2ff6a"), new Guid("285444a5-af73-4f11-9867-89fb9597cd90"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("48f5a8b2-2018-4454-bf3c-22a995b9ed42"), "running.jpeg", new Guid("3f5483eb-fea3-49da-91d7-320ee42def6d") },
                    { new Guid("cb44e51f-723f-4e71-912f-b458baadfbaf"), new Guid("f835ce81-082f-4bbd-8ff6-aa78b5f63d51"), new Guid("c01a5035-3679-41be-ab7a-234de66f7702"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("bf2bbfcd-84f1-4144-8c99-c2e1315f0df8"), "golf.jpg", new Guid("d720eb86-fc41-48c9-ae24-98793cc71e5a") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0b67f43c-0080-4bc1-b602-7235c6f36bcf"), new Guid("861f08e9-cb5b-4a8f-902b-5eb1b01777f7"), new Guid("effcd336-50c4-4467-8d2b-a20b4387ee7c") },
                    { new Guid("0d124c7b-7d29-48f1-9b3f-bf913ead243f"), new Guid("285444a5-af73-4f11-9867-89fb9597cd90"), new Guid("3f5483eb-fea3-49da-91d7-320ee42def6d") },
                    { new Guid("e53f7019-4116-4645-a7ef-ec223b0ee2d2"), new Guid("c01a5035-3679-41be-ab7a-234de66f7702"), new Guid("d720eb86-fc41-48c9-ae24-98793cc71e5a") }
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
