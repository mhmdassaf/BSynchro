using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro.DAL.Migrations
{
    public partial class RemoveCurrency_Col : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6229d7cf-af25-4059-be4f-349d33c64e88"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("d8b0f925-ccde-4e9d-a3b3-d418e611a5c2"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f73abd39-446b-496f-8598-4288a2aaaeff"));

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Accounts");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Currency",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("6229d7cf-af25-4059-be4f-349d33c64e88"), new DateTime(1991, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al Rafed", "Seed_Function", new DateTime(2022, 7, 23, 12, 9, 35, 790, DateTimeKind.Local).AddTicks(1885), "sara.assaf@gmail.com", "Sara", 2, "Sales Manager", "Sales Manager", "Assaf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+96170375191", "Bekaa", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("d8b0f925-ccde-4e9d-a3b3-d418e611a5c2"), new DateTime(1995, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kafrdenis", "Seed_Function", new DateTime(2022, 7, 23, 12, 9, 35, 790, DateTimeKind.Local).AddTicks(1842), "mhmd.assaf24@gmail.com", "Mohammad", 1, "Write clean testable c# code", ".Net Developer", "Assaf", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+96171355291", "Bekaa", "Main Road" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "City", "CreatedBy", "CreatedDate", "Email", "FirstName", "Gender", "JobDescription", "JobTitle", "LastName", "ModifedBy", "ModifiedDate", "Phone", "State", "Street" },
                values: new object[] { new Guid("f73abd39-446b-496f-8598-4288a2aaaeff"), new DateTime(2000, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bierut", "Seed_Function", new DateTime(2022, 7, 23, 12, 9, 35, 790, DateTimeKind.Local).AddTicks(1891), "ahmad.kadri@gmail.com", "Ahmad", 1, "Write clean testable c# code", "Fullter Developer", "AlKadri", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "+9613355792", "Bierut", "Main Road" });
        }
    }
}
