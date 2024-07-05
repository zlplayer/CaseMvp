using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseMvp.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5300b8d5-086f-4d0b-b2b7-8d9ecdef5dcf");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a3cea1a-18d1-4f1f-8374-8b1661376499", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a3cea1a-18d1-4f1f-8374-8b1661376499");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "659e246f-0c4e-4d0d-ae2d-e21a15f36953", null, "admin", "admin" },
                    { "eb260fa9-8ae4-4cae-97da-cb2ab7e9170c", null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "667ec7c4-9c00-4e78-8f78-fee2ea3c3711", "AQAAAAIAAYagAAAAEPbQE4zC0PeniDDFuO7i3ReK9YHkiGbKEzMRA3eZvoP50vJ6/eVAhPnl7MM+kp+BWA==", "4d77a921-3f67-4173-bd46-5de63e026ff5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "659e246f-0c4e-4d0d-ae2d-e21a15f36953", "1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb260fa9-8ae4-4cae-97da-cb2ab7e9170c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "659e246f-0c4e-4d0d-ae2d-e21a15f36953", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "659e246f-0c4e-4d0d-ae2d-e21a15f36953");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a3cea1a-18d1-4f1f-8374-8b1661376499", null, "admin", "admin" },
                    { "5300b8d5-086f-4d0b-b2b7-8d9ecdef5dcf", null, "user", "user" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "832dc833-8a0d-4f1e-88b0-8ab6f937058e", "AQAAAAIAAYagAAAAEPz93RurQ+oDHdltBu1fIQp/sbAYJLqS5BfrUVtOUG7atzqxlis8OnhvPuZ00ALr5w==", "07e3a104-ba23-49de-af02-6678c90d1b05" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a3cea1a-18d1-4f1f-8374-8b1661376499", "1" });
        }
    }
}
