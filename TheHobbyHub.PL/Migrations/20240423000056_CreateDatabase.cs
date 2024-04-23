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
            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("05ccf856-3c02-44a3-9c14-dc97b845d774"));

            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("5ea8f77d-43bb-4d19-96e7-296b4f5ce0ec"));

            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("7ae2d820-71e0-4b6b-bcda-36c5d988380e"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("02845d58-549d-4753-88c8-5a9cc7b42d16"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("668ffd53-8e42-4846-8544-b1dfbf3ac271"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("a50bcbd1-a316-415a-9462-fd26f58ec074"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("2be4ac6a-e18c-4358-af45-1d2da1d96cce"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("9e00fda6-3cd1-4d54-8425-466253a26f73"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("bbd89d5d-08fa-40c8-b9d2-99080e4f2cfd"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("999bc3b2-9054-4d8a-a536-4b3be195a5e3"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("d80ee607-3400-4ee6-9624-34bbcb885899"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("e9cf2fe2-6088-4477-a811-dae4f9ea5902"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("1fae45b1-c11f-48e3-923d-3bee5cf0cc9e"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("2f265cf3-8967-43f3-a7f0-5ea44514a840"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("bb428bd3-a338-4ac8-9504-897f3a628ad5"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("58bc0021-0cae-4e4b-887c-95d7fd32c5aa"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("a2710c17-f817-4bcb-9cf1-babb6539f146"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("ba8e493c-bf79-4c00-b10a-4a7f76afe1b4"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("be960217-d969-4770-badf-664d5d78ac2f"));

            migrationBuilder.InsertData(
                table: "tblAddress",
                columns: new[] { "Id", "City", "PostalAddress", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"), "Anytown", "123 Main St", "CA", "12345" },
                    { new Guid("a908a318-8f5b-40a3-9660-51df362605a4"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"), "Somewhere", "789 Oak St", "TX", "67890" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"), "stick", "Golf", "outdoor.jpg", "outdoor" },
                    { new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"), "Gyyymm", "Gym", "image.jpg", "Indoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" },
                    { new Guid("5b586fe4-adb4-477d-a683-666836c2114b"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"), new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"), "Company A", "about company A", new Guid("5b586fe4-adb4-477d-a683-666836c2114b") },
                    { new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"), new Guid("a908a318-8f5b-40a3-9660-51df362605a4"), "Company B", "about company B", new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0") },
                    { new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"), new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"), "Company C", "about company C", new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("34aa3856-ce73-4249-b5d8-77bcf0396e70"), new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"), new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b") },
                    { new Guid("8c69b5b4-1d1b-49f1-b84a-4be0ded8be1c"), new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"), new Guid("5b586fe4-adb4-477d-a683-666836c2114b") },
                    { new Guid("ad9755cd-b111-4b8c-b14f-4486aae01045"), new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"), new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("0943a161-4355-4712-94af-1e33888ec7dd"), new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"), new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"), "imageC.jpg", new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b") },
                    { new Guid("34f29b8d-8f64-41ae-b6af-3345b151b6e5"), new Guid("a908a318-8f5b-40a3-9660-51df362605a4"), new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"), "imageB.jpg", new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0") },
                    { new Guid("b057aa4a-2ee8-4dd9-9d31-3814de062999"), new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"), new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"), "imageA.jpg", new Guid("5b586fe4-adb4-477d-a683-666836c2114b") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ecf3e62-79bc-43fd-b781-d2590e4a4731"), new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"), new Guid("5b586fe4-adb4-477d-a683-666836c2114b") },
                    { new Guid("35e161fd-036f-4749-b9a9-f5276671d441"), new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"), new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0") },
                    { new Guid("39ce04df-3ccb-4a6b-adbc-8bb0ac7d567e"), new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"), new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("0943a161-4355-4712-94af-1e33888ec7dd"));

            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("34f29b8d-8f64-41ae-b6af-3345b151b6e5"));

            migrationBuilder.DeleteData(
                table: "tblEvent",
                keyColumn: "Id",
                keyValue: new Guid("b057aa4a-2ee8-4dd9-9d31-3814de062999"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("0ecf3e62-79bc-43fd-b781-d2590e4a4731"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("35e161fd-036f-4749-b9a9-f5276671d441"));

            migrationBuilder.DeleteData(
                table: "tblFriend",
                keyColumn: "Id",
                keyValue: new Guid("39ce04df-3ccb-4a6b-adbc-8bb0ac7d567e"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("34aa3856-ce73-4249-b5d8-77bcf0396e70"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("8c69b5b4-1d1b-49f1-b84a-4be0ded8be1c"));

            migrationBuilder.DeleteData(
                table: "tblUserHobby",
                keyColumn: "Id",
                keyValue: new Guid("ad9755cd-b111-4b8c-b14f-4486aae01045"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("09163fd2-b8e4-470c-a3d2-8c07205dc8dd"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("2fd871bc-f42e-4765-a854-32966eaaef35"));

            migrationBuilder.DeleteData(
                table: "tblCompany",
                keyColumn: "Id",
                keyValue: new Guid("aba699cf-fe0f-40f1-bc7d-1f51fb0b2548"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("1d41b5f4-e204-49b1-895e-0473abedb3d3"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("836e02b9-7ee5-440b-9001-89a3dfd2e3a6"));

            migrationBuilder.DeleteData(
                table: "tblHobby",
                keyColumn: "Id",
                keyValue: new Guid("8a31e12e-4ca7-49b4-b5ab-49d4cba487e5"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("209ae054-cf48-4477-a870-83fbc2052cdd"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("a908a318-8f5b-40a3-9660-51df362605a4"));

            migrationBuilder.DeleteData(
                table: "tblAddress",
                keyColumn: "Id",
                keyValue: new Guid("c1952f4f-1e51-4a50-ab76-3233a5ed1bdf"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("32345781-3f7f-4b1c-9ccc-0450b743a97b"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("5b586fe4-adb4-477d-a683-666836c2114b"));

            migrationBuilder.DeleteData(
                table: "tblUser",
                keyColumn: "Id",
                keyValue: new Guid("c8e0c5d8-e773-4fd8-8a7a-02ff91ee4ec0"));

            migrationBuilder.InsertData(
                table: "tblAddress",
                columns: new[] { "Id", "City", "PostalAddress", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("58bc0021-0cae-4e4b-887c-95d7fd32c5aa"), "Somewhere", "789 Oak St", "TX", "67890" },
                    { new Guid("a2710c17-f817-4bcb-9cf1-babb6539f146"), "Othertown", "456 Elm St", "NY", "54321" },
                    { new Guid("ba8e493c-bf79-4c00-b10a-4a7f76afe1b4"), "Anytown", "123 Main St", "CA", "12345" }
                });

            migrationBuilder.InsertData(
                table: "tblHobby",
                columns: new[] { "Id", "Description", "HobbyName", "Image", "Type" },
                values: new object[,]
                {
                    { new Guid("1fae45b1-c11f-48e3-923d-3bee5cf0cc9e"), "Run", "Running", "run.jpg", "Outdoor" },
                    { new Guid("2f265cf3-8967-43f3-a7f0-5ea44514a840"), "stick", "Golf", "outdoor.jpg", "outdoor" },
                    { new Guid("bb428bd3-a338-4ac8-9504-897f3a628ad5"), "Gyyymm", "Gym", "image.jpg", "Indoor" }
                });

            migrationBuilder.InsertData(
                table: "tblUser",
                columns: new[] { "Id", "Email", "FirstName", "Image", "LastName", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663"), "Alexr@gmail.com", "Alex", "image.jpg", "Rosas", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "2627459097", "Arosas" },
                    { new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a"), "bfoote@fvtc.edu", "Brian", "image.jpg", "Foote", "pYfdnNb8sO0FgS4H0MRSwLGOIME=", "3333333333", "bfoote" },
                    { new Guid("be960217-d969-4770-badf-664d5d78ac2f"), "sf@gmail.com", "sam", "sammy.jpg", "fisher", "qUqP5cyxm6YcTAhz05Hph5gvu9M=", "1111111111", "sammyfish" }
                });

            migrationBuilder.InsertData(
                table: "tblCompany",
                columns: new[] { "Id", "AddressId", "CompanyName", "Description", "UserId" },
                values: new object[,]
                {
                    { new Guid("999bc3b2-9054-4d8a-a536-4b3be195a5e3"), new Guid("58bc0021-0cae-4e4b-887c-95d7fd32c5aa"), "Company C", "about company C", new Guid("be960217-d969-4770-badf-664d5d78ac2f") },
                    { new Guid("d80ee607-3400-4ee6-9624-34bbcb885899"), new Guid("a2710c17-f817-4bcb-9cf1-babb6539f146"), "Company B", "about company B", new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a") },
                    { new Guid("e9cf2fe2-6088-4477-a811-dae4f9ea5902"), new Guid("ba8e493c-bf79-4c00-b10a-4a7f76afe1b4"), "Company A", "about company A", new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663") }
                });

            migrationBuilder.InsertData(
                table: "tblUserHobby",
                columns: new[] { "Id", "HobbyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2be4ac6a-e18c-4358-af45-1d2da1d96cce"), new Guid("1fae45b1-c11f-48e3-923d-3bee5cf0cc9e"), new Guid("be960217-d969-4770-badf-664d5d78ac2f") },
                    { new Guid("9e00fda6-3cd1-4d54-8425-466253a26f73"), new Guid("bb428bd3-a338-4ac8-9504-897f3a628ad5"), new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663") },
                    { new Guid("bbd89d5d-08fa-40c8-b9d2-99080e4f2cfd"), new Guid("2f265cf3-8967-43f3-a7f0-5ea44514a840"), new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a") }
                });

            migrationBuilder.InsertData(
                table: "tblEvent",
                columns: new[] { "Id", "AddressId", "CompanyId", "Date", "Description", "HobbyId", "Image", "UserId" },
                values: new object[,]
                {
                    { new Guid("05ccf856-3c02-44a3-9c14-dc97b845d774"), new Guid("ba8e493c-bf79-4c00-b10a-4a7f76afe1b4"), new Guid("e9cf2fe2-6088-4477-a811-dae4f9ea5902"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event A", new Guid("bb428bd3-a338-4ac8-9504-897f3a628ad5"), "imageA.jpg", new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663") },
                    { new Guid("5ea8f77d-43bb-4d19-96e7-296b4f5ce0ec"), new Guid("a2710c17-f817-4bcb-9cf1-babb6539f146"), new Guid("d80ee607-3400-4ee6-9624-34bbcb885899"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event B", new Guid("2f265cf3-8967-43f3-a7f0-5ea44514a840"), "imageB.jpg", new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a") },
                    { new Guid("7ae2d820-71e0-4b6b-bcda-36c5d988380e"), new Guid("58bc0021-0cae-4e4b-887c-95d7fd32c5aa"), new Guid("999bc3b2-9054-4d8a-a536-4b3be195a5e3"), new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Event C", new Guid("1fae45b1-c11f-48e3-923d-3bee5cf0cc9e"), "imageC.jpg", new Guid("be960217-d969-4770-badf-664d5d78ac2f") }
                });

            migrationBuilder.InsertData(
                table: "tblFriend",
                columns: new[] { "Id", "CompanyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("02845d58-549d-4753-88c8-5a9cc7b42d16"), new Guid("d80ee607-3400-4ee6-9624-34bbcb885899"), new Guid("a00be4ae-585c-4560-b652-eba54d6e3e0a") },
                    { new Guid("668ffd53-8e42-4846-8544-b1dfbf3ac271"), new Guid("999bc3b2-9054-4d8a-a536-4b3be195a5e3"), new Guid("be960217-d969-4770-badf-664d5d78ac2f") },
                    { new Guid("a50bcbd1-a316-415a-9462-fd26f58ec074"), new Guid("e9cf2fe2-6088-4477-a811-dae4f9ea5902"), new Guid("76ffc371-6a3e-40b1-ae8a-8e2737f54663") }
                });
        }
    }
}
