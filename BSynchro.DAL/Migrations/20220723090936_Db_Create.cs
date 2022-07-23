using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSynchro.DAL.Migrations
{
    public partial class Db_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningBalance = table.Column<double>(type: "float", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Currency = table.Column<int>(type: "int", nullable: false),
                    FromCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToCustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_FromCustomerId",
                        column: x => x.FromCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Customers_ToCustomerId",
                        column: x => x.ToCustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromCustomerId",
                table: "Transactions",
                column: "FromCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToCustomerId",
                table: "Transactions",
                column: "ToCustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
