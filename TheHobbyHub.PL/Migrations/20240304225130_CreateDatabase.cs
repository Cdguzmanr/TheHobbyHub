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
                name: "tblCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompany_Id", x => x.Id);
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
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUser_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCompanyAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCompanyAddress_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblCompanyAddress_AddressId",
                        column: x => x.AddressId,
                        principalTable: "tblAddress",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblCompanyAddress_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "tblCompany",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tblFriend",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "tblFriendUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FriendId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFriendUser_Id", x => x.Id);
                    table.ForeignKey(
                        name: "fk_tblFriendUser_FriendId",
                        column: x => x.FriendId,
                        principalTable: "tblFriend",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "fk_tblFriendUser_UserId",
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
                    { new Guid("0a7a37b3-ae3e-47c5-bf28-1a133cdb8974"), "789 Oak St", "Somewhere", "TX", "67890" },
                    { new Guid("0e4e5d5e-e422-4985-a4fb-10fbdb8398b4"), "123 Main St", "Anytown", "CA", "12345" },
                    { new Guid("c64de842-68da-4595-ba47-b8b14467bb31"), "456 Elm St", "Othertown", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "CompanyName", "Image", "Password", "UserName" },
                values: new object[,]
                {
                    { new Guid("2e8e90ff-ade4-4921-bc46-1a3bc2cc4f49"), "Company B", "imageB.jpg", "38Nd3/2M+aip9/TyIzVYXKylmQo=", "companyB" },
                    { new Guid("aeb7f848-bfdd-4070-90ca-846b249455fd"), "Company A", "imageA.jpg", "/BafCUbj3r56CjioX1dcB1ynX20=", "copanyA" },
                    { new Guid("f633150c-0062-4382-8830-3f6623240dd6"), "Company C", "imageC.jpg", "urYijG3X2+D44I400gasYPqLBHw=", "companyC" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("24eb281b-ad92-4eb5-a760-aa10a170e47e"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("7695c1ce-81c1-4076-815a-e089eb0fdccf"), "Gyyymm", "Gym", "image.jpg", "Indoor" },
                    { new Guid("f8a8905a-9610-4e55-a262-aeecd6293a0d"), "stick", "Golf", "outdoor.jpg", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("5add4b11-2ba1-404d-b758-63ef7331fb00"), "sf@gmasdfil.com", "sdf", "samddmy.jpg", "fsdfsdfisher", "mNWYTbueAuANF0c6AxbqynRxnXY=", "11211111111", "sasdfsdfmmyfish" },
                    { new Guid("7869414d-6c36-45d5-bc20-62a28a90f7f7"), "sf@gmrfffail.com", "s bvcvbam", "samrrrrmy.jpg", "fishcvbcvber", "RmQR+JhVJXAHuebYif5zjxpGa70=", "11111111111", "sasfdsdfmmyfish" },
                    { new Guid("8ef97c06-cd95-4e1f-92f3-71ef31b18131"), "sf@gdfgeeemail.com", "sdfgdfgam", "sammeeey.jpg", "fidfgdfgsher", "AKjX3OOQvQGmIexgkdxqakGshiw=", "11112111111", "sammdfgdfgyfish" },
                    { new Guid("b0981bfe-8235-4055-88cf-cacb3148a542"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("e3c5b54c-53f6-4fcd-a9c0-e52c8b98a8ef"), "ss@gmail.com", "Someone", "image.jpg", "Somebody", "B/qgP3XrZmyneblY753llJ5gtQ4=", "3333333333", "SSM" }
                });

            migrationBuilder.InsertData(
                table: "tblCompanyAddress",
                columns: new[] { "Id", "AddressId", "CompanyId" },
                values: new object[,]
                {
                    { new Guid("13aa05ca-38c0-4810-ac50-fb37e09cb358"), new Guid("0a7a37b3-ae3e-47c5-bf28-1a133cdb8974"), new Guid("f633150c-0062-4382-8830-3f6623240dd6") },
                    { new Guid("36e41895-6274-47fc-9626-7f650460e82e"), new Guid("c64de842-68da-4595-ba47-b8b14467bb31"), new Guid("2e8e90ff-ade4-4921-bc46-1a3bc2cc4f49") },
                    { new Guid("edd4f65b-f124-4e72-ad36-229ab8a20cc3"), new Guid("0e4e5d5e-e422-4985-a4fb-10fbdb8398b4"), new Guid("aeb7f848-bfdd-4070-90ca-846b249455fd") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "CompanyId", "Date", "Description", "Image", "tblAddressId", "tblUserId" },
                values: new object[,]
                {
                    { new Guid("09d7cd7d-a7f2-4640-9848-d28d363fd57f"), new Guid("f633150c-0062-4382-8830-3f6623240dd6"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", "imageC.jpg", null, null },
                    { new Guid("74554c45-2284-41da-99b2-a64ae3aeebec"), new Guid("2e8e90ff-ade4-4921-bc46-1a3bc2cc4f49"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", "imageB.jpg", null, null },
                    { new Guid("9937f374-ee10-4b22-8c0a-020481d24be9"), new Guid("aeb7f848-bfdd-4070-90ca-846b249455fd"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", "imageA.jpg", null, null }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId" },
                values: new object[,]
                {
                    { new Guid("30365c17-1743-4e50-9882-fbe3527138d6"), new Guid("aeb7f848-bfdd-4070-90ca-846b249455fd") },
                    { new Guid("a707cc25-d374-4937-ac2e-2ee73f9b6252"), new Guid("2e8e90ff-ade4-4921-bc46-1a3bc2cc4f49") },
                    { new Guid("adb1d287-e3a3-44a2-840f-c595b77a65ae"), new Guid("f633150c-0062-4382-8830-3f6623240dd6") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("360590ce-9745-45d2-a048-bced21fca0a4"), new Guid("24eb281b-ad92-4eb5-a760-aa10a170e47e"), new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af") },
                    { new Guid("5c339149-b386-4946-a993-78dde5741f9d"), new Guid("f8a8905a-9610-4e55-a262-aeecd6293a0d"), new Guid("e3c5b54c-53f6-4fcd-a9c0-e52c8b98a8ef") },
                    { new Guid("eb2a11bb-9271-4aee-bf40-16e423d53b4a"), new Guid("7695c1ce-81c1-4076-815a-e089eb0fdccf"), new Guid("b0981bfe-8235-4055-88cf-cacb3148a542") }
                });

            migrationBuilder.InsertData(
                table: "tblEventAddress",
                columns: new[] { "Id", "AddressId", "EventId" },
                values: new object[,]
                {
                    { new Guid("3e4482c3-df77-489c-bffc-802c641fa81f"), new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af"), new Guid("09d7cd7d-a7f2-4640-9848-d28d363fd57f") },
                    { new Guid("53fb1c38-e8fa-488b-ad3a-f3aa395b1692"), new Guid("c64de842-68da-4595-ba47-b8b14467bb31"), new Guid("74554c45-2284-41da-99b2-a64ae3aeebec") },
                    { new Guid("5d28dd06-463f-4473-b819-0dcd877414f8"), new Guid("0e4e5d5e-e422-4985-a4fb-10fbdb8398b4"), new Guid("9937f374-ee10-4b22-8c0a-020481d24be9") }
                });

            migrationBuilder.InsertData(
                table: "tblEventHobby",
                columns: new[] { "Id", "EventId", "HobbyId" },
                values: new object[,]
                {
                    { new Guid("02c2821e-9d25-4f49-abba-1375bd041737"), new Guid("09d7cd7d-a7f2-4640-9848-d28d363fd57f"), new Guid("24eb281b-ad92-4eb5-a760-aa10a170e47e") },
                    { new Guid("0eeeeff7-9dc4-473f-aca1-1d634ac36d76"), new Guid("9937f374-ee10-4b22-8c0a-020481d24be9"), new Guid("7695c1ce-81c1-4076-815a-e089eb0fdccf") },
                    { new Guid("895432f2-e4fd-469f-b69f-3181a7c48c15"), new Guid("74554c45-2284-41da-99b2-a64ae3aeebec"), new Guid("f8a8905a-9610-4e55-a262-aeecd6293a0d") }
                });

            migrationBuilder.InsertData(
                table: "tblEventUser",
                columns: new[] { "Id", "EventId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1ab10869-16af-458d-90bb-8cf696cfc31e"), new Guid("74554c45-2284-41da-99b2-a64ae3aeebec"), new Guid("e3c5b54c-53f6-4fcd-a9c0-e52c8b98a8ef") },
                    { new Guid("39d53abd-ab7e-4f59-a3a4-5b8784ec8a04"), new Guid("9937f374-ee10-4b22-8c0a-020481d24be9"), new Guid("b0981bfe-8235-4055-88cf-cacb3148a542") },
                    { new Guid("8654ab8e-b62a-4700-8758-0183eabb04fc"), new Guid("09d7cd7d-a7f2-4640-9848-d28d363fd57f"), new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af") }
                });

            migrationBuilder.InsertData(
                table: "tblFriendUser",
                columns: new[] { "Id", "FriendId", "UserId" },
                values: new object[,]
                {
                    { new Guid("038cee8a-89bc-429a-9d5e-b4c882582d24"), new Guid("adb1d287-e3a3-44a2-840f-c595b77a65ae"), new Guid("b0981bfe-8235-4055-88cf-cacb3148a542") },
                    { new Guid("7324c9fe-c9d8-4283-bc2e-0eece0e096fe"), new Guid("a707cc25-d374-4937-ac2e-2ee73f9b6252"), new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af") },
                    { new Guid("dd7a13ba-7cd9-4f74-9075-36e7b302c330"), new Guid("a707cc25-d374-4937-ac2e-2ee73f9b6252"), new Guid("1c48472b-0114-43cf-aef0-db951fb4f6af") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCompanyAddress_AddressId",
                table: "tblCompanyAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_tblCompanyAddress_CompanyId",
                table: "tblCompanyAddress",
                column: "CompanyId");

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
                name: "IX_tblFriendUser_FriendId",
                table: "tblFriendUser",
                column: "FriendId");

            migrationBuilder.CreateIndex(
                name: "IX_tblFriendUser_UserId",
                table: "tblFriendUser",
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
                name: "tblCompanyAddress");

            migrationBuilder.DropTable(
                name: "tblEventAddress");

            migrationBuilder.DropTable(
                name: "tblEventHobby");

            migrationBuilder.DropTable(
                name: "tblEventUser");

            migrationBuilder.DropTable(
                name: "tblFriendUser");

            migrationBuilder.DropTable(
                name: "tblUserHobby");

            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.DropTable(
                name: "tblFriend");

            migrationBuilder.DropTable(
                name: "tblHobby");

            migrationBuilder.DropTable(
                name: "tblAddress");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblCompany");
        }
    }
}
