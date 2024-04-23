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
                    { new Guid("048b243e-ed9a-42d2-bfb3-3008e0adfbeb"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("127e1705-c270-494c-8dd3-e8a565cd91fc"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("2b5ccbaa-221d-4e2a-9150-de586bcd7ba7"), "Othertown", "456 Elm St", "NY", "54321" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Type" },
                values: new object[,]
                {
                    { new Guid("0f8661aa-d55c-4f3f-8b9f-2c9748183dc7"), "stick", "Golf", "outdoor" },
                    { new Guid("2dff4b22-9ede-47fa-9d92-92803e56000b"), "Run", "Running", "Outdoor" },
                    { new Guid("bc1aa48f-f168-4d45-8b36-cc73ac21d38c"), "Gyyymm", "Gym", "Indoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("33838041-90b9-4238-8f3a-a421752378bd"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("992c6912-56bb-4601-a3c4-7f41b94db74e"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("d9d90478-015c-4eda-8a73-3dfc8e08d085"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("18fff197-d2e6-4832-96e9-faf563e93a4b"), new Guid("048b243e-ed9a-42d2-bfb3-3008e0adfbeb"), "Company C", "about company C", new Guid("33838041-90b9-4238-8f3a-a421752378bd") },
                    { new Guid("51eb12b6-f933-4d2d-98e1-398c17aed4c3"), new Guid("2b5ccbaa-221d-4e2a-9150-de586bcd7ba7"), "Company B", "about company B", new Guid("992c6912-56bb-4601-a3c4-7f41b94db74e") },
                    { new Guid("58debe0f-1609-40ca-9448-3d8d5e294dd6"), new Guid("127e1705-c270-494c-8dd3-e8a565cd91fc"), "Company A", "about company A", new Guid("d9d90478-015c-4eda-8a73-3dfc8e08d085") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1b203c2f-d14c-409b-8014-1984d69cb36c"), new Guid("bc1aa48f-f168-4d45-8b36-cc73ac21d38c"), new Guid("d9d90478-015c-4eda-8a73-3dfc8e08d085") },
                    { new Guid("3b98bb8a-c2fd-4293-aa67-30caa56686d9"), new Guid("2dff4b22-9ede-47fa-9d92-92803e56000b"), new Guid("33838041-90b9-4238-8f3a-a421752378bd") },
                    { new Guid("4fde22e0-f354-4aaf-ad31-d9158712787a"), new Guid("0f8661aa-d55c-4f3f-8b9f-2c9748183dc7"), new Guid("992c6912-56bb-4601-a3c4-7f41b94db74e") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("643f6b03-3da3-4479-bed8-fd7db664bc38"), new Guid("2b5ccbaa-221d-4e2a-9150-de586bcd7ba7"), new Guid("51eb12b6-f933-4d2d-98e1-398c17aed4c3"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("0f8661aa-d55c-4f3f-8b9f-2c9748183dc7"), "golf.jpg", new Guid("992c6912-56bb-4601-a3c4-7f41b94db74e") },
                    { new Guid("8fbd1033-2062-4cdd-affd-e3e4731518c8"), new Guid("127e1705-c270-494c-8dd3-e8a565cd91fc"), new Guid("58debe0f-1609-40ca-9448-3d8d5e294dd6"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("bc1aa48f-f168-4d45-8b36-cc73ac21d38c"), "gym.jpg", new Guid("d9d90478-015c-4eda-8a73-3dfc8e08d085") },
                    { new Guid("f0d9e34e-da6f-4c1c-95cf-b1dd7a0fb382"), new Guid("048b243e-ed9a-42d2-bfb3-3008e0adfbeb"), new Guid("18fff197-d2e6-4832-96e9-faf563e93a4b"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("2dff4b22-9ede-47fa-9d92-92803e56000b"), "running.jpg", new Guid("33838041-90b9-4238-8f3a-a421752378bd") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("52c32e5d-1d28-4af9-8338-c8e94c5f6a2f"), new Guid("18fff197-d2e6-4832-96e9-faf563e93a4b"), new Guid("33838041-90b9-4238-8f3a-a421752378bd") },
                    { new Guid("5cd461a3-ff65-464a-9285-40f2d09d0c69"), new Guid("51eb12b6-f933-4d2d-98e1-398c17aed4c3"), new Guid("992c6912-56bb-4601-a3c4-7f41b94db74e") },
                    { new Guid("f1d32c96-5629-4268-98ea-91449d3b34f0"), new Guid("58debe0f-1609-40ca-9448-3d8d5e294dd6"), new Guid("d9d90478-015c-4eda-8a73-3dfc8e08d085") }
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
