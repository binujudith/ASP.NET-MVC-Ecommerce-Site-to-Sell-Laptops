using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbllaptops",
                columns: table => new
                {
                    serialNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbllaptops", x => x.serialNo);
                });

            migrationBuilder.InsertData(
                table: "Tbllaptops",
                columns: new[] { "serialNo", "Colour", "Image", "ModelName", "Price", "specification" },
                values: new object[,]
                {
                    { 1, "Black", "/laptop10.jpg", "HP", 45000.0, "10th Gen i3-1005G1/8GB/256GB" },
                    { 2, "Black", "/laptop11.jpg", "Dell", 36990.0, "10th gen Intel Core i3/ 8GB / 1TB" },
                    { 3, "Platinum Grey", "/laptop19.jpg", "Lenovo", 50000.0, "4GB/1TB HDD/Windows 10/MS" },
                    { 4, "Jet Black", "/laptop20.jpg", "HP", 52490.0, "i5-10210U/8GB/512GB " },
                    { 5, "Silver", "/laptop6.jpg", "HP", 45490.0, "Ryzen 5 3450U/8GB/512GB SSD" },
                    { 6, "Transparent Silver", "/laptop7.jpg", "Asus", 25269.0, "4GB RAM/1 TB HDD/Windows 10" },
                    { 7, "Pure Silver", "/laptop8.jpg", "Aser", 28670.0, "4GB Ram/1TB HDD/Window 10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbllaptops");
        }
    }
}
