using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class versiontwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "3526ea9f-d31a-4b0e-a739-c59f41c4db79", "d596ed17-9fdb-405e-89fc-d5dc19680de5" });

            migrationBuilder.DropColumn(
                name: "LineItemId",
                table: "Project");

            migrationBuilder.CreateTable(
                name: "ProjectLineItem",
                columns: table => new
                {
                    ProjectLineItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(nullable: false),
                    LineItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLineItem", x => x.ProjectLineItemId);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "402bf845-eb9f-4681-b16b-c682a1fd599e", 0, "3ff0947c-b414-40a3-b3c5-1cdec526b191", "ApplicationUser", "thatmikeparrish@gmail.com", true, false, null, "THATMIKEPARRISH@GMAIL.COM", "MIKE PARRISH", "AQAAAAEAACcQAAAAENAJpHSfbfpOy8xRjj0T+fOXd48wJ/hrVO6/rbSSJHxiOOj8B+SdFvc0KVYM1vX3UQ==", null, false, "66c26b10-c183-4211-855c-09fac8145a22", false, "Mike Parrish", "Mike", "Parrish" });

            migrationBuilder.InsertData(
                table: "LineItem",
                columns: new[] { "LineItemId", "CompositeLabor", "Consumables", "Description", "InstallQuote", "InstallQuoteTotal", "Insurance", "LaborTotal", "ManHours", "MaterialCost", "MaterialMargin", "MaterialQuote", "SalesTax", "SubCost", "SubQuote", "Totals", "Travel", "UnburdenedRate" },
                values: new object[] { 3, null, null, "Build out a Contact page", null, null, null, null, 6, 0, null, null, null, 0, null, null, null, null });

            migrationBuilder.InsertData(
                table: "ProjectLineItem",
                columns: new[] { "ProjectLineItemId", "LineItemId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "UserId",
                value: "402bf845-eb9f-4681-b16b-c682a1fd599e");

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "UserId",
                value: "402bf845-eb9f-4681-b16b-c682a1fd599e");

            migrationBuilder.UpdateData(
                table: "TimeTracker",
                keyColumn: "TimeTrackerId",
                keyValue: 1,
                column: "UserId",
                value: "402bf845-eb9f-4681-b16b-c682a1fd599e");

            migrationBuilder.UpdateData(
                table: "TimeTracker",
                keyColumn: "TimeTrackerId",
                keyValue: 2,
                column: "UserId",
                value: "402bf845-eb9f-4681-b16b-c682a1fd599e");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLineItem");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "402bf845-eb9f-4681-b16b-c682a1fd599e", "3ff0947c-b414-40a3-b3c5-1cdec526b191" });

            migrationBuilder.DeleteData(
                table: "LineItem",
                keyColumn: "LineItemId",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "LineItemId",
                table: "Project",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "FirstName", "LastName" },
                values: new object[] { "3526ea9f-d31a-4b0e-a739-c59f41c4db79", 0, "d596ed17-9fdb-405e-89fc-d5dc19680de5", "ApplicationUser", "thatmikeparrish@gmail.com", true, false, null, "THATMIKEPARRISH@GMAIL.COM", "MIKE PARRISH", "AQAAAAEAACcQAAAAEA63qHvVnlejtwy3+zqEqS85tKFxDkuhrhJDwVEXcufFlokORDerlcZt6/Z2maweuw==", null, false, "4769bab9-7b57-47d6-b28c-cfd0c5d23c73", false, "Mike Parrish", "Mike", "Parrish" });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 1,
                columns: new[] { "LineItemId", "UserId" },
                values: new object[] { 1, "3526ea9f-d31a-4b0e-a739-c59f41c4db79" });

            migrationBuilder.UpdateData(
                table: "Project",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "LineItemId", "UserId" },
                values: new object[] { 2, "3526ea9f-d31a-4b0e-a739-c59f41c4db79" });

            migrationBuilder.UpdateData(
                table: "TimeTracker",
                keyColumn: "TimeTrackerId",
                keyValue: 1,
                column: "UserId",
                value: "3526ea9f-d31a-4b0e-a739-c59f41c4db79");

            migrationBuilder.UpdateData(
                table: "TimeTracker",
                keyColumn: "TimeTrackerId",
                keyValue: 2,
                column: "UserId",
                value: "3526ea9f-d31a-4b0e-a739-c59f41c4db79");
        }
    }
}
