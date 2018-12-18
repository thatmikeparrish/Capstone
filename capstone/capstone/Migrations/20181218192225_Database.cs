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
                name: "Total",
                columns: table => new
                {
                    TotalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    MaterialCost = table.Column<int>(nullable: true),
                    MaterialMargin = table.Column<int>(nullable: true),
                    MaterialQuote = table.Column<int>(nullable: true),
                    SubCost = table.Column<int>(nullable: true),
                    SubQuote = table.Column<int>(nullable: true),
                    ManHours = table.Column<int>(nullable: true),
                    UnburdenedRate = table.Column<int>(nullable: true),
                    Insurance = table.Column<int>(nullable: true),
                    LaborTotal = table.Column<int>(nullable: true),
                    Travel = table.Column<int>(nullable: true),
                    Consumables = table.Column<int>(nullable: true),
                    InstallQuote = table.Column<int>(nullable: true),
                    CompositeLabor = table.Column<int>(nullable: true),
                    InstallQuoteTotal = table.Column<int>(nullable: true),
                    SalesTax = table.Column<int>(nullable: true),
                    Totals = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Total", x => x.TotalId);
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
                name: "WorkforceCalc",
                columns: table => new
                {
                    WorkforceCalcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeePayRateId = table.Column<int>(nullable: true),
                    EmployeeTypePayRateId = table.Column<int>(nullable: true),
                    ManagmentHours = table.Column<double>(nullable: true),
                    ManagmentCost = table.Column<double>(nullable: true),
                    LaborHours = table.Column<double>(nullable: true),
                    LaborCost = table.Column<double>(nullable: true)
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
                    SalesTax = table.Column<double>(nullable: true),
                    UnburdenedRate = table.Column<double>(nullable: true),
                    LaborMargin = table.Column<double>(nullable: true),
                    TotalId = table.Column<int>(nullable: true),
                    WorkforceCalcId = table.Column<int>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: true),
                    IsCompleted = table.Column<bool>(nullable: true),
                    TimeTrackerId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Project_WorkforceCalc_WorkforceCalcId",
                        column: x => x.WorkforceCalcId,
                        principalTable: "WorkforceCalc",
                        principalColumn: "WorkforceCalcId",
                        onDelete: ReferentialAction.Restrict);
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
                    ManHours = table.Column<double>(nullable: true),
                    LaborCost = table.Column<double>(nullable: true),
                    LaborQuote = table.Column<double>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "297b3f89-d7a8-4443-ae65-f86ed42c1d73", 0, "647c6068-8592-4339-871e-89a4ef2a9414", "ApplicationUser", "thatmikeparrish@gmail.com", true, false, null, "THATMIKEPARRISH@GMAIL.COM", "THATMIKEPARRISH@GMAIL.COM", "AQAAAAEAACcQAAAAEG+xozCyPgnTYB45M0qlvSLZa2Z/G0q0gj9uxuIfpe7TycgWV6ItfJJ5VEp/i/mO3A==", null, false, "1fdcb099-c078-4b58-9065-22f21b0fd14a", false, "thatmikeparrish@gmail.com", "Mike", "Parrish" });

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
                columns: new[] { "WorkforceCalcId", "EmployeePayRateId", "EmployeeTypePayRateId", "LaborCost", "LaborHours", "ManagmentCost", "ManagmentHours" },
                values: new object[,]
                {
                    { 1, 1, null, null, null, null, null },
                    { 2, 2, null, null, null, null, null }
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
                    { 1, "This went as expected.", new DateTime(2017, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.0, "297b3f89-d7a8-4443-ae65-f86ed42c1d73" },
                    { 2, "I had an issue with Grunt.", new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6.0, "297b3f89-d7a8-4443-ae65-f86ed42c1d73" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LaborMargin", "ProjectNumber", "SalesTax", "TimeTrackerId", "TotalId", "UnburdenedRate", "UserId", "WorkforceCalcId" },
                values: new object[] { 1, 1, new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 0.1, "17001", 0.0975, 1, 1, 10.0, "297b3f89-d7a8-4443-ae65-f86ed42c1d73", 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LaborMargin", "ProjectNumber", "SalesTax", "TimeTrackerId", "TotalId", "UnburdenedRate", "UserId", "WorkforceCalcId" },
                values: new object[] { 2, 2, null, true, 0.2, "17002", 0.0975, 2, 2, 20.0, "297b3f89-d7a8-4443-ae65-f86ed42c1d73", 2 });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "LineItemId", "Description", "LaborCost", "LaborQuote", "ManHours", "MaterialCost", "ProjectId", "SubCost" },
                values: new object[,]
                {
                    { 1, "Build out a 50000 page", null, null, 2.0, 50000.0, 1, 50000.0 },
                    { 3, "Build out a 5000 page", null, null, 6.0, 5000.0, 1, 5000.0 },
                    { 5, "Build out a 500 page", null, null, 6.0, 500.0, 1, 500.0 },
                    { 7, "Build out a free page", null, null, 6.0, 0.0, 1, 0.0 },
                    { 2, "Build out a 20000 page", null, null, 4.0, 20000.0, 2, 20000.0 },
                    { 4, "Build out a 1000 page", null, null, 6.0, 1000.0, 2, 1000.0 },
                    { 6, "Build out a 100 page", null, null, 6.0, 100.0, 2, 100.0 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Total");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkforceCalc");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "EmployeeTypePayRate");

            migrationBuilder.DropTable(
                name: "EmployeeType");
        }
    }
}
