using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class initialss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetLocation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearsProcurement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    years = table.Column<int>(nullable: false),
                    Maxfund = table.Column<int>(nullable: false),
                    Total = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearsProcurement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    NIK = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Job_Id = table.Column<int>(nullable: false),
                    Department_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_Employees_Department_Department_Id",
                        column: x => x.Department_Id,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Jobs_Job_Id",
                        column: x => x.Job_Id,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetSubmission",
                columns: table => new
                {
                    AssetCode = table.Column<string>(nullable: false),
                    AssetName = table.Column<string>(nullable: true),
                    Volume = table.Column<int>(nullable: false),
                    prize = table.Column<int>(nullable: false),
                    AssetValue = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    GoodAsset = table.Column<int>(nullable: true),
                    BrokenAsset = table.Column<int>(nullable: true),
                    Employee_Id = table.Column<string>(nullable: true),
                    AssetLocation_Id = table.Column<int>(nullable: false),
                    AssetCategory_Id = table.Column<int>(nullable: false),
                    YearsOfSubmission = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetSubmission", x => x.AssetCode);
                    table.ForeignKey(
                        name: "FK_AssetSubmission_AssetCategory_AssetCategory_Id",
                        column: x => x.AssetCategory_Id,
                        principalTable: "AssetCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetSubmission_AssetLocation_AssetLocation_Id",
                        column: x => x.AssetLocation_Id,
                        principalTable: "AssetLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssetSubmission_Employees_Employee_Id",
                        column: x => x.Employee_Id,
                        principalTable: "Employees",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssetSubmission_YearsProcurement_YearsOfSubmission",
                        column: x => x.YearsOfSubmission,
                        principalTable: "YearsProcurement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Employees_Id",
                        column: x => x.Id,
                        principalTable: "Employees",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssetHistory",
                columns: table => new
                {
                    AssetCode = table.Column<string>(nullable: false),
                    VolumeDelete = table.Column<int>(nullable: false),
                    YearsDelete = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetHistory", x => x.AssetCode);
                    table.ForeignKey(
                        name: "FK_AssetHistory_AssetSubmission_AssetCode",
                        column: x => x.AssetCode,
                        principalTable: "AssetSubmission",
                        principalColumn: "AssetCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubmission_AssetCategory_Id",
                table: "AssetSubmission",
                column: "AssetCategory_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubmission_AssetLocation_Id",
                table: "AssetSubmission",
                column: "AssetLocation_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubmission_Employee_Id",
                table: "AssetSubmission",
                column: "Employee_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssetSubmission_YearsOfSubmission",
                table: "AssetSubmission",
                column: "YearsOfSubmission");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department_Id",
                table: "Employees",
                column: "Department_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Job_Id",
                table: "Employees",
                column: "Job_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetHistory");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "AssetSubmission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "AssetCategory");

            migrationBuilder.DropTable(
                name: "AssetLocation");

            migrationBuilder.DropTable(
                name: "YearsProcurement");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
