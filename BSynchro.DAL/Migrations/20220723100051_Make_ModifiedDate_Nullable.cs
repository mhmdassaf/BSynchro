using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro.DAL.Migrations
{
    public partial class Make_ModifiedDate_Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("84b1b509-cdab-4e99-80f8-a44cc339cf41"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("924e4753-e1d3-496c-b20a-795dabfe10a4"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("b1c8eec1-9358-470f-84f3-4791cb531f7f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transactions",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("776c813d-03e1-4979-b058-6ab402a58377"), new DateTime(2000, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bierut", "Seed_Function", new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7832), "ahmad.kadri@gmail.com", "Ahmad", 1, "Write clean testable c# code", "Fullter Developer", "AlKadri", null, null, "+9613355792", "Bierut", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("978cf690-019d-44ae-9c19-c6fd23e3d5cf"), new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kafrdenis", "Seed_Function", new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7774), "mhmd.assaf24@gmail.com", "Mohammad", 1, "Write clean testable c# code", ".Net Developer", "Assaf", null, null, "+96171355291", "Bekaa", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("cf517245-ea5c-4bb6-8bb4-b5a5ec411a58"), new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al Rafed", "Seed_Function", new DateTime(2022, 7, 23, 13, 0, 51, 232, DateTimeKind.Local).AddTicks(7823), "sara.assaf@gmail.com", "Sara", 2, "Sales Manager", "Sales Manager", "Assaf", null, null, "+96170375191", "Bekaa", "Main Road" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("776c813d-03e1-4979-b058-6ab402a58377"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("978cf690-019d-44ae-9c19-c6fd23e3d5cf"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("cf517245-ea5c-4bb6-8bb4-b5a5ec411a58"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("84b1b509-cdab-4e99-80f8-a44cc339cf41"), new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kafrdenis", "Seed_Function", new DateTime(2022, 7, 23, 12, 54, 59, 509, DateTimeKind.Local).AddTicks(2970), "mhmd.assaf24@gmail.com", "Mohammad", 1, "Write clean testable c# code", ".Net Developer", "Assaf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+96171355291", "Bekaa", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("924e4753-e1d3-496c-b20a-795dabfe10a4"), new DateTime(2000, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bierut", "Seed_Function", new DateTime(2022, 7, 23, 12, 54, 59, 509, DateTimeKind.Local).AddTicks(3025), "ahmad.kadri@gmail.com", "Ahmad", 1, "Write clean testable c# code", "Fullter Developer", "AlKadri", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+9613355792", "Bierut", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("b1c8eec1-9358-470f-84f3-4791cb531f7f"), new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al Rafed", "Seed_Function", new DateTime(2022, 7, 23, 12, 54, 59, 509, DateTimeKind.Local).AddTicks(3018), "sara.assaf@gmail.com", "Sara", 2, "Sales Manager", "Sales Manager", "Assaf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+96170375191", "Bekaa", "Main Road" });
        }
    }
}
