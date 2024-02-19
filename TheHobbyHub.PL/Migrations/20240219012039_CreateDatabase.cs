using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                    City = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    State = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Zip = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblAddre__3214EC073797D4B0", x => x.Id);
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
                    table.PrimaryKey("PK__tblCompa__3214EC07F736E848", x => x.Id);
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
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblEvent__3214EC07BF9B1F91", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblFriends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblFrien__3214EC07DE9FD9A3", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblHobby",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tblHobby__3214EC0783BA9627", x => x.Id);
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
                    table.PrimaryKey("PK__tblUser__3214EC079D83832D", x => x.Id);
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
                    table.PrimaryKey("PK__tblUserH__3214EC0736B690FC", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAddress");

            migrationBuilder.DropTable(
                name: "tblCompany");

            migrationBuilder.DropTable(
                name: "tblEvent");

            migrationBuilder.DropTable(
                name: "tblFriends");

            migrationBuilder.DropTable(
                name: "tblHobby");

            migrationBuilder.DropTable(
                name: "tblUser");

            migrationBuilder.DropTable(
                name: "tblUserHobby");
        }
    }
}
