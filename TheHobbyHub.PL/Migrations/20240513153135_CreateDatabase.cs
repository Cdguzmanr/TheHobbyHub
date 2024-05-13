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
                    { new Guid("1c75788b-bc65-479f-a6f4-16d024857ed0"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("c09c01f6-38b3-4d6b-9499-4cb64cc61891"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("cb258210-215f-45e9-b814-b7372ae0d063"), "Somewhere", "789 Oak St", "TX", "67890" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("4a6dad00-76bf-4660-ad68-6b3980fc18f0"), "Gyyymm", "Gym", "gym.jpeg", "Indoor" },
                    { new Guid("c284988a-5c23-4ab6-a49d-9d85b5f40083"), "Run", "Running", "running.jpeg", "Outdoor" },
                    { new Guid("ce194176-2170-40ed-88ca-4e9cdd45d22a"), "stick", "Golf", "golf.jpg", "outdoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("2ded031f-d9c4-4f25-a0b0-63a2be1cde41"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("b8036371-cfbe-4ba1-acd9-0c3bb1b9015e"), "bfoote@fvtc.edu", "Brian", "bfoote.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("b97cf6cf-3971-4ab1-ac82-e33ed9c85590"), "Alexr@gmail.com", "Alex", "ar.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("1931f3b7-ad62-4fb8-813f-5604a36777fc"), new Guid("1c75788b-bc65-479f-a6f4-16d024857ed0"), "Company A", "about company A", new Guid("b97cf6cf-3971-4ab1-ac82-e33ed9c85590") },
                    { new Guid("3e3884ca-e41a-4a67-b6bb-a0054f3f20d7"), new Guid("cb258210-215f-45e9-b814-b7372ae0d063"), "Company C", "about company C", new Guid("2ded031f-d9c4-4f25-a0b0-63a2be1cde41") },
                    { new Guid("af14571d-9ec5-44bb-b5cf-c7c1fdf2390c"), new Guid("c09c01f6-38b3-4d6b-9499-4cb64cc61891"), "Company B", "about company B", new Guid("b8036371-cfbe-4ba1-acd9-0c3bb1b9015e") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3d813cd8-6186-48cd-aed7-274f6ff3ef7d"), new Guid("4a6dad00-76bf-4660-ad68-6b3980fc18f0"), new Guid("b97cf6cf-3971-4ab1-ac82-e33ed9c85590") },
                    { new Guid("622899c1-05fb-4087-b809-caba9d511569"), new Guid("ce194176-2170-40ed-88ca-4e9cdd45d22a"), new Guid("b8036371-cfbe-4ba1-acd9-0c3bb1b9015e") },
                    { new Guid("a6016dfd-4606-4b21-bcdf-dc01f92a34b0"), new Guid("c284988a-5c23-4ab6-a49d-9d85b5f40083"), new Guid("2ded031f-d9c4-4f25-a0b0-63a2be1cde41") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "EventName", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("3fd06021-e8a8-4a8d-ba3f-a240882b7635"), new Guid("cb258210-215f-45e9-b814-b7372ae0d063"), new Guid("3e3884ca-e41a-4a67-b6bb-a0054f3f20d7"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Join us for an exhilarating morning of fitness and fun at our annual 5K Fun Run! Lace up your running shoes and gather your friends, family, and furry companions for a memorable event that promises laughter, camaraderie, and a healthy dose of exercise.", "5k Fun Run", new Guid("c284988a-5c23-4ab6-a49d-9d85b5f40083"), "running.jpeg", new Guid("2ded031f-d9c4-4f25-a0b0-63a2be1cde41") },
                    { new Guid("82049bd7-828b-4141-b9e7-bbf7b9f31992"), new Guid("1c75788b-bc65-479f-a6f4-16d024857ed0"), new Guid("1931f3b7-ad62-4fb8-813f-5604a36777fc"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Flex your muscles and lift your spirits at our Amateur Powerlifting Event! Calling all strength enthusiasts to showcase their prowess in squat, bench press, and deadlift. Join us for a thrilling day of competition, camaraderie, and personal bests. Whether you're a seasoned lifter or just starting out, all are welcome to test their strength and determination. Don't miss this chance to push your limits and celebrate the power within you. Register now and let's lift together!", "Amatuer Powerlifting Event", new Guid("4a6dad00-76bf-4660-ad68-6b3980fc18f0"), "gym.jpeg", new Guid("b97cf6cf-3971-4ab1-ac82-e33ed9c85590") },
                    { new Guid("e2385685-9243-4423-8baf-67f097d8030c"), new Guid("c09c01f6-38b3-4d6b-9499-4cb64cc61891"), new Guid("af14571d-9ec5-44bb-b5cf-c7c1fdf2390c"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Calling all amateur golfers! Tee up for a day of friendly competition at our Amateur Golf Tournament. Join us on the greens for a chance to showcase your skills, meet fellow enthusiasts, and enjoy a day of camaraderie. With prizes, refreshments, and beautiful fairways, it's an event you won't want to miss. Swing into action and register today!", "Amatuer Golf Tournament", new Guid("ce194176-2170-40ed-88ca-4e9cdd45d22a"), "golf.jpg", new Guid("b8036371-cfbe-4ba1-acd9-0c3bb1b9015e") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1874591d-94fe-4542-8e8b-8f82a30166a1"), new Guid("1931f3b7-ad62-4fb8-813f-5604a36777fc"), new Guid("b97cf6cf-3971-4ab1-ac82-e33ed9c85590") },
                    { new Guid("647c654b-5fd3-4012-bea0-f1aed1b4799f"), new Guid("af14571d-9ec5-44bb-b5cf-c7c1fdf2390c"), new Guid("b8036371-cfbe-4ba1-acd9-0c3bb1b9015e") },
                    { new Guid("e2d26717-6073-479c-acd9-f79b1ca8d0c2"), new Guid("3e3884ca-e41a-4a67-b6bb-a0054f3f20d7"), new Guid("2ded031f-d9c4-4f25-a0b0-63a2be1cde41") }
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
