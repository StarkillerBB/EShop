using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Data_Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "ID", "TypeName" },
                values: new object[,]
                {
                    { 1, "GPU" },
                    { 2, "CPU" },
                    { 3, "Keyboard" },
                    { 4, "Mouse" },
                    { 5, "Cooling" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ID", "ImagePath", "Price", "ProductName", "TypeID" },
                values: new object[,]
                {
                    { 1, "ImagePath1", 1100.75m, "GPU1", 1 },
                    { 2, "ImagePath2", 1234.55m, "GPU2", 1 },
                    { 3, "ImagePath3", 8934.10m, "CPU1", 2 },
                    { 4, "ImagePath4", 9313m, "CPU2", 2 },
                    { 5, "ImagePath5", 110.75m, "Keyboard1", 3 },
                    { 6, "ImagePath6", 500m, "Keyboard2", 3 },
                    { 7, "ImagePath7", 50m, "Mouse1", 4 },
                    { 8, "ImagePath8", 100m, "Mouse2", 4 },
                    { 9, "ImagePath9", 200m, "Cooling1", 5 },
                    { 10, "ImagePath10", 350.50m, "Cooling2", 5 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "Address", "FirstName", "LastName", "Mail", "Password", "Phone", "RoleId", "Username", "ZipCode" },
                values: new object[,]
                {
                    { 1, "RandomAdress1", "Bodil", "Bodilsen", "Bodil@Bodilsen.com", "Bodil123456", "88888888", 1, "Bodil", "1000" },
                    { 2, "RandomAdress2", "Hans", "Hansen", "Hans@Hansen.com", "Hans123456", "44444444", 2, "Hans", "5000" }
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "ID", "Amount", "ProductId", "UserId" },
                values: new object[,]
                {
                    { 1, 2, 2, 1 },
                    { 2, 3, 2, 2 },
                    { 3, 1, 5, 1 },
                    { 4, 8, 7, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
