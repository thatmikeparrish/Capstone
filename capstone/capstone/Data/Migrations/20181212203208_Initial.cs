using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

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
                name: "LineItem",
                columns: table => new
                {
                    LineItemId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_LineItem", x => x.LineItemId);
                });

            migrationBuilder.CreateTable(
                name: "Margin",
                columns: table => new
                {
                    MarginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnburdenedRate = table.Column<int>(nullable: true),
                    Insurance = table.Column<int>(nullable: true),
                    LaborTotal = table.Column<int>(nullable: true),
                    Travel = table.Column<int>(nullable: true),
                    Consumables = table.Column<int>(nullable: true),
                    Equipment = table.Column<int>(nullable: true),
                    CompositeLabor = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Margin", x => x.MarginId);
                });

            migrationBuilder.CreateTable(
                name: "TimeTracker",
                columns: table => new
                {
                    TimeTrackerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Hours = table.Column<int>(nullable: false),
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
                name: "Total",
                columns: table => new
                {
                    TotalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialCost = table.Column<int>(nullable: true),
                    MaterialMargin = table.Column<int>(nullable: true),
                    MaterialQuote = table.Column<int>(nullable: true),
                    SubCost = table.Column<int>(nullable: true),
                    SubQuote = table.Column<int>(nullable: true),
                    ManHours = table.Column<int>(nullable: true),
                    UnburdenedRate = table.Column<int>(nullable: true),
                    Burden = table.Column<int>(nullable: true),
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
                    MarginsId = table.Column<int>(nullable: true),
                    LineItemId = table.Column<int>(nullable: true),
                    TotalId = table.Column<int>(nullable: true),
                    WorkforceId = table.Column<int>(nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "WorkforceCalc",
                columns: table => new
                {
                    WorkforceCalcId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeePayRateId = table.Column<int>(nullable: true),
                    EmployeeTypePayRateId = table.Column<int>(nullable: true),
                    ManagmentHours = table.Column<int>(nullable: true),
                    ManagmentCost = table.Column<int>(nullable: true),
                    LaborHours = table.Column<int>(nullable: true),
                    LaborCost = table.Column<int>(nullable: true)
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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "3526ea9f-d31a-4b0e-a739-c59f41c4db79", 0, "d596ed17-9fdb-405e-89fc-d5dc19680de5", "ApplicationUser", "thatmikeparrish@gmail.com", true, false, null, "THATMIKEPARRISH@GMAIL.COM", "MIKE PARRISH", "AQAAAAEAACcQAAAAEA63qHvVnlejtwy3+zqEqS85tKFxDkuhrhJDwVEXcufFlokORDerlcZt6/Z2maweuw==", null, false, "4769bab9-7b57-47d6-b28c-cfd0c5d23c73", false, "Mike Parrish", "Mike", "Parrish" });

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
                table: "LineItem",
                columns: new[] { "LineItemId", "CompositeLabor", "Consumables", "Description", "InstallQuote", "InstallQuoteTotal", "Insurance", "LaborTotal", "ManHours", "MaterialCost", "MaterialMargin", "MaterialQuote", "SalesTax", "SubCost", "SubQuote", "Totals", "Travel", "UnburdenedRate" },
                values: new object[,]
                {
                    { 1, null, null, "Build out a home page", null, null, null, null, 2, 0, null, null, null, 0, null, null, null, null },
                    { 2, null, null, "Build out a bio page", null, null, null, null, 4, 0, null, null, null, 0, null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Margin",
                columns: new[] { "MarginId", "CompositeLabor", "Consumables", "Equipment", "Insurance", "LaborTotal", "Travel", "UnburdenedRate" },
                values: new object[,]
                {
                    { 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 2, 10, 10, 10, 10, 10, 10, 10 }
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
                    { 1, "LaVergne", 1, "My first test project!", "Test Project 1", "Random@gmail.com", "Kayla", "Carter", "6156491437", "TN", "307 Valley Forge Ct.", "37086" },
                    { 2, "Murfreesboro", 2, "My second test project!", "Test Project 2", "thatmikeparrish@gmail.com", "Mike", "Parrish", "6157886484", "TN", "2324 Chandler Pl.", "37130" }
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
                    { 1, "This went as expected.", new DateTime(2017, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "3526ea9f-d31a-4b0e-a739-c59f41c4db79" },
                    { 2, "I had an issue with Grunt.", new DateTime(2017, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "3526ea9f-d31a-4b0e-a739-c59f41c4db79" }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LineItemId", "MarginsId", "ProjectNumber", "TimeTrackerId", "TotalId", "UserId", "WorkforceId" },
                values: new object[] { 1, 1, new DateTime(2017, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, "17001", 1, 1, "3526ea9f-d31a-4b0e-a739-c59f41c4db79", 1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectId", "ClientId", "CompletionDate", "IsCompleted", "LineItemId", "MarginsId", "ProjectNumber", "TimeTrackerId", "TotalId", "UserId", "WorkforceId" },
                values: new object[] { 2, 2, null, false, 2, 2, "17002", 2, 2, "3526ea9f-d31a-4b0e-a739-c59f41c4db79", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypePayRate_EmployeeTypeId",
                table: "EmployeeTypePayRate",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserId",
                table: "Project",
                column: "UserId");

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
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Margin");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "TimeTracker");

            migrationBuilder.DropTable(
                name: "Total");

            migrationBuilder.DropTable(
                name: "WorkforceCalc");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "EmployeeTypePayRate");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3526ea9f-d31a-4b0e-a739-c59f41c4db79", "d596ed17-9fdb-405e-89fc-d5dc19680de5" });

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
