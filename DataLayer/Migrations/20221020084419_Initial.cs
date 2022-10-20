using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(18,2)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    TypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Type_TypeID",
                        column: x => x.TypeID,
                        principalTable: "Type",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cart_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "RoleName" },
                values: new object[,]
                {
                    { 1, "User" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Type",
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
                columns: new[] { "ID", "Address", "FirstName", "LastName", "Mail", "Password", "Phone", "RoleId", "SoftDelete", "Username", "ZipCode" },
                values: new object[,]
                {
                    { 1, "RandomAdress1", "Bodil", "Bodilsen", "Bodil@Bodilsen.com", "Bodil123456", "88888888", 1, false, "Bodil", "1000" },
                    { 2, "RandomAdress2", "Hans", "Hansen", "Hans@Hansen.com", "Hans123456", "44444444", 2, false, "Hans", "5000" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_TypeID",
                table: "Product",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
