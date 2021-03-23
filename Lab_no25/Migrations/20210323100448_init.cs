#region Usings

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#endregion

namespace Lab_no25.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("ToyCategories",
                                         table => new
                                                  {
                                                      Id = table.Column<int>("int", nullable :false)
                                                                .Annotation("SqlServer:Identity", "1, 1"),
                                                      WarrantyPeriod = table.Column<int>("int", nullable :false),
                                                      CareRules = table.Column<string>("nvarchar(max)", nullable :false),
                                                      Age = table.Column<int>("int", nullable :false)
                                                  },
                                         constraints :table => { table.PrimaryKey("PK_ToyCategories", x => x.Id); });

            migrationBuilder.CreateTable("Toys",
                                         table => new
                                                  {
                                                      Id = table.Column<int>("int", nullable :false)
                                                                .Annotation("SqlServer:Identity", "1, 1"),
                                                      Producer = table.Column<string>("nvarchar(max)", nullable :false),
                                                      Price = table.Column<decimal>("decimal(18,2)", nullable :false),
                                                      WarehouseCount = table.Column<int>("int", nullable :false),
                                                      Photo = table.Column<string>("nvarchar(max)", nullable :false),
                                                      CategoryId = table.Column<int>("int", nullable :false)
                                                  },
                                         constraints :table =>
                                                      {
                                                          table.PrimaryKey("PK_Toys", x => x.Id);

                                                          table.ForeignKey("FK_Toys_ToyCategories_CategoryId",
                                                                           x => x.CategoryId,
                                                                           "ToyCategories",
                                                                           "Id",
                                                                           onDelete :ReferentialAction.Cascade);
                                                      });

            migrationBuilder.CreateTable("Sales",
                                         table => new
                                                  {
                                                      Id = table.Column<int>("int", nullable :false)
                                                                .Annotation("SqlServer:Identity", "1, 1"),
                                                      ToyId = table.Column<int>("int", nullable :false),
                                                      SaleCount = table.Column<int>("int", nullable :false),
                                                      Discount = table.Column<int>("int", nullable :false),
                                                      SaleDate = table.Column<DateTime>("datetime2", nullable :false),
                                                      SaleSum = table.Column<decimal>("decimal(18,2)", nullable :false)
                                                  },
                                         constraints :table =>
                                                      {
                                                          table.PrimaryKey("PK_Sales", x => x.Id);

                                                          table.ForeignKey("FK_Sales_Toys_ToyId",
                                                                           x => x.ToyId,
                                                                           "Toys",
                                                                           "Id",
                                                                           onDelete :ReferentialAction.Cascade);
                                                      });

            migrationBuilder.CreateIndex("IX_Sales_Id",
                                         "Sales",
                                         "Id");

            migrationBuilder.CreateIndex("IX_Sales_ToyId",
                                         "Sales",
                                         "ToyId");

            migrationBuilder.CreateIndex("IX_ToyCategories_Id",
                                         "ToyCategories",
                                         "Id");

            migrationBuilder.CreateIndex("IX_Toys_CategoryId",
                                         "Toys",
                                         "CategoryId");

            migrationBuilder.CreateIndex("IX_Toys_Id",
                                         "Toys",
                                         "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Sales");

            migrationBuilder.DropTable("Toys");

            migrationBuilder.DropTable("ToyCategories");
        }
    }
}