using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Panda.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BudgetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BudgetRole = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BudgetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    YearId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AccountName = table.Column<string>(type: "TEXT", nullable: false),
                    AccountNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountCostCentre = table.Column<string>(type: "TEXT", nullable: false),
                    CostCentreName = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sage_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    YearId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    IsStandalone = table.Column<bool>(type: "INTEGER", nullable: false),
                    BudgetType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Budget_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sandbox",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BudgetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandbox", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sandbox_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Summary",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BudgetId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Summary_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    SandboxId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SummaryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReviewId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Table_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Table_Sandbox_SandboxId",
                        column: x => x.SandboxId,
                        principalTable: "Sandbox",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Table_Summary_SummaryId",
                        column: x => x.SummaryId,
                        principalTable: "Summary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TableId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Field = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Column_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Row",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TableId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Row", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Row_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cell",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    RowId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ColumnId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TableId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Quantity = table.Column<ulong>(type: "INTEGER", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cell_Column_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "Column",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cell_Row_RowId",
                        column: x => x.RowId,
                        principalTable: "Row",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cell_Table_TableId",
                        column: x => x.TableId,
                        principalTable: "Table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Budget_Name",
                table: "Budget",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Budget_YearId",
                table: "Budget",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_BudgetEmployee_BudgetId_EmployeeId",
                table: "BudgetEmployee",
                columns: new[] { "BudgetId", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_BudgetId_Name",
                table: "Category",
                columns: new[] { "BudgetId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cell_ColumnId",
                table: "Cell",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_Cell_RowId",
                table: "Cell",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Cell_TableId",
                table: "Cell",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Column_TableId",
                table: "Column",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmailAddress",
                table: "Employees",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Review_YearId",
                table: "Review",
                column: "YearId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Row_TableId",
                table: "Row",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_Sage_CategoryId",
                table: "Sage",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sandbox_BudgetId",
                table: "Sandbox",
                column: "BudgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Summary_BudgetId",
                table: "Summary",
                column: "BudgetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_ReviewId",
                table: "Table",
                column: "ReviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_SandboxId",
                table: "Table",
                column: "SandboxId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Table_SummaryId",
                table: "Table",
                column: "SummaryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetEmployee");

            migrationBuilder.DropTable(
                name: "Cell");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Sage");

            migrationBuilder.DropTable(
                name: "Column");

            migrationBuilder.DropTable(
                name: "Row");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Sandbox");

            migrationBuilder.DropTable(
                name: "Summary");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Year");
        }
    }
}
