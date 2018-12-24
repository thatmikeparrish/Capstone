using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    ClientTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.ClientTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTracker",
                columns: table => new
                {
                    TimeTrackerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<double>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTracker", x => x.TimeTrackerId);
                    table.ForeignKey(
                        name: "FK_TimeTracker_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientTypeId = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 10, nullable: false),
                    StreetAddress = table.Column<string>(maxLength: 255, nullable: false),
                    City = table.Column<string>(maxLength: 255, nullable: false),
                    State = table.Column<string>(maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    Comments = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientType",
                        principalColumn: "ClientTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypePayRate",
                columns: table => new
                {
                    EmployeeTypePayRateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeTypeId = table.Column<int>(nullable: false),
                    UnburdenedPayRate = table.Column<double>(nullable: true),
                    EmployeeQuantity = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypePayRate", x => x.EmployeeTypePayRateId);
                    table.ForeignKey(
                        name: "FK_EmployeeTypePayRate_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClientId = table.Column<int>(nullable: false),
                    ProjectNumber = table.Column<string>(maxLength: 6, nullable: false),
                    WorkDay = table.Column<int>(nullable: false),
                    SalesTax = table.Column<double>(nullable: true),
                    UnburdenedRate = table.Column<double>(nullable: true),
                    LaborMargin = table.Column<double>(nullable: true),
                    TotalId = table.Column<int>(nullable: true),
                    WorkforceCalcId = table.Column<int>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: true),
                    TimeTrackerId = table.Column<int>(nullable: true),
                    TotalMaterialCost = table.Column<double>(nullable: true),
                    TotalMaterialQuote = table.Column<double>(nullable: true),
                    TotalSubCost = table.Column<double>(nullable: true),
                    TotalSubQuote = table.Column<double>(nullable: true),
                    TotalManHours = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    LineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    MaterialCost = table.Column<double>(nullable: true),
                    SubCost = table.Column<double>(nullable: true),
                    ManHours = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineItemId);
                    table.ForeignKey(
                        name: "FK_LineItem_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkforceCalc",
                columns: table => new
                {
                    WorkforceCalcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeePayRateId = table.Column<int>(nullable: true),
                    EmployeeTypePayRateId = table.Column<int>(nullable: true),
                    WorkingDays = table.Column<double>(nullable: true),
                    ManagmentHours = table.Column<double>(nullable: true),
                    ManagmentCost = table.Column<double>(nullable: true),
                    LaborHours = table.Column<double>(nullable: true),
                    LaborCost = table.Column<double>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkforceCalc", x => x.WorkforceCalcId);
                    table.ForeignKey(
                        name: "FK_WorkforceCalc_EmployeeTypePayRate_EmployeeTypePayRateId",
                        column: x => x.EmployeeTypePayRateId,
                        principalTable: "EmployeeTypePayRate",
                        principalColumn: "EmployeeTypePayRateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkforceCalc_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "9de107e4-9a61-47d0-8804-b2aff4cc2c9a", 0, "a82612c1-d70d-424f-93d8-e04f10e0c6d1", "ApplicationUser", "thatmikeparrish@gmail.com", true, false, null, "THATMIKEPARRISH@GMAIL.COM", "THATMIKEPARRISH@GMAIL.COM", "AQAAAAEAACcQAAAAED7gQX+RClbFl6l5RA7HLS0f5YdL5opKa1mxlmiGquPR/WyhcK+7VKCKMkZ30PojdA==", null, false, "447f1cbc-5dfa-4f58-8f78-4a55020bd5df", false, "thatmikeparrish@gmail.com", "Mike", "Parrish" });

            migrationBuilder.InsertData(
                table: "ClientType",
                columns: new[] { "ClientTypeId", "Category" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Commercial" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeType",
                columns: new[] { "EmployeeTypeId", "Category" },
                values: new object[,]
                {
                    { 1, "Lead Developer" },
                    { 2, "Senior Developer" },
                    { 3, "Junior Developer" }
                });

            migrationBuilder.InsertData(
                table: "WorkforceCalc",
                columns: new[] { "WorkforceCalcId", "EmployeePayRateId", "EmployeeTypePayRateId", "LaborCost", "LaborHours", "ManagmentCost", "ManagmentHours", "ProjectId", "WorkingDays" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null, null, null },
                    { 2, 2, null, null, null, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ClientId", "City", "ClientTypeId", "Comments", "CompanyName", "Email", "FirstName", "LastName", "PhoneNumber", "State", "StreetAddress", "ZipCode" },
                values: new object[,]
                {
                    { 1, "LaVergne", 1, "My first test project!", "Test Company 1", "Random@gmail.com", "Kayla", "Carter", "6156491437", "TN", "307 Valley Forge Ct.", "37086" },
                    { 2, "Murfreesboro", 2, "My second test project!", "Test Company 2", "thatmikeparrish@gmail.com", "Mike", "Parrish", "6157886484", "TN", "2324 Chandler Pl.", "37130" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeTypePayRate",
                columns: new[] { "EmployeeTypePayRateId", "EmployeeQuantity", "EmployeeTypeId", "UnburdenedPayRate" },
                values: new object[,]
                {
                    { 1, 1, 2, 15.0 },
                    { 2, 1, 3, 12.5 }
                });

            migrationBuilder.InsertData(
                table: "TimeTracker",
                columns: new[] { "TimeTrackerId", "Comments", "Date", "Hours", "UserId" },
                values: new object[,]
                {
                    { 1, "This went as expected.", new DateTime(2017, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "9de107e4-9a61-47d0-8804-b2aff4cc2c9a" },
                    { 2, "I had an issue with Grunt.", new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0, "9de107e4-9a61-47d0-8804-b2aff4cc2c9a" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LaborMargin", "ProjectNumber", "SalesTax", "TimeTrackerId", "TotalId", "TotalManHours", "TotalMaterialCost", "TotalMaterialQuote", "TotalSubCost", "TotalSubQuote", "UnburdenedRate", "UserId", "WorkDay", "WorkforceCalcId" },
                values: new object[] { 1, 1, new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.1, "17001", 9.75, 1, null, null, null, null, null, null, 10.0, "9de107e4-9a61-47d0-8804-b2aff4cc2c9a", 8, 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LaborMargin", "ProjectNumber", "SalesTax", "TimeTrackerId", "TotalId", "TotalManHours", "TotalMaterialCost", "TotalMaterialQuote", "TotalSubCost", "TotalSubQuote", "UnburdenedRate", "UserId", "WorkDay", "WorkforceCalcId" },
                values: new object[] { 2, 2, null, false, 0.2, "17002", 9.75, 2, null, null, null, null, null, null, 20.0, "9de107e4-9a61-47d0-8804-b2aff4cc2c9a", 8, 2 });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "LineItemId", "Description", "ManHours", "MaterialCost", "ProjectId", "SubCost" },
                values: new object[,]
                {
                    { 1, "Build out a 50000 page", 2.0, 50000.0, 1, 50000.0 },
                    { 3, "Build out a 5000 page", 6.0, 5000.0, 1, 5000.0 },
                    { 5, "Build out a 500 page", 6.0, 500.0, 1, 500.0 },
                    { 7, "Build out a free page", 6.0, 0.0, 1, 0.0 },
                    { 2, "Build out a 20000 page", 4.0, 20000.0, 2, 20000.0 },
                    { 4, "Build out a 1000 page", 6.0, 1000.0, 2, 1000.0 },
                    { 6, "Build out a 100 page", 6.0, 100.0, 2, 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypePayRate_EmployeeTypeId",
                table: "EmployeeTypePayRate",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_ProjectId",
                table: "LineItem",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_WorkforceCalcId",
                table: "Project",
                column: "WorkforceCalcId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTracker_UserId",
                table: "TimeTracker",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkforceCalc_EmployeeTypePayRateId",
                table: "WorkforceCalc",
                column: "EmployeeTypePayRateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkforceCalc_ProjectId",
                table: "WorkforceCalc",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_WorkforceCalc_WorkforceCalcId",
                table: "Project",
                column: "WorkforceCalcId",
                principalTable: "WorkforceCalc",
                principalColumn: "WorkforceCalcId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AspNetUsers_UserId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Client_ClientType_ClientTypeId",
                table: "Client");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTypePayRate_EmployeeType_EmployeeTypeId",
                table: "EmployeeTypePayRate");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkforceCalc_Project_ProjectId",
                table: "WorkforceCalc");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "TimeTracker");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "WorkforceCalc");

            migrationBuilder.DropTable(
                name: "EmployeeTypePayRate");
        }
    }
}
