using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Fundamentals.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "Category",
                newName: "Effort");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"), null, 20, "Pending activities" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Effort", "Name" },
                values: new object[] { new Guid("943283c8-49fa-47a5-a28b-7e80780e4d2e"), null, 50, "Personal activities" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("b0f4153b-b754-4a15-bac0-fa0f38abf17e"), new Guid("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"), new DateTime(2022, 6, 15, 16, 41, 23, 637, DateTimeKind.Local).AddTicks(1367), null, 1, "Payment of public services" });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TaskId", "CategoryId", "CreationDate", "Description", "PriorityTask", "Title" },
                values: new object[] { new Guid("e4f1353a-dca2-48cf-bb23-01ca026e6824"), new Guid("943283c8-49fa-47a5-a28b-7e80780e4d2e"), new DateTime(2022, 6, 15, 16, 41, 23, 637, DateTimeKind.Local).AddTicks(1405), null, 0, "Finish watching movie" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("b0f4153b-b754-4a15-bac0-fa0f38abf17e"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("e4f1353a-dca2-48cf-bb23-01ca026e6824"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("6e6c25c5-cb99-482d-a89b-2d5f6c7a7640"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("943283c8-49fa-47a5-a28b-7e80780e4d2e"));

            migrationBuilder.RenameColumn(
                name: "Effort",
                table: "Category",
                newName: "Weight");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Task",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
