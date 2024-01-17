using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QArte.Persistance.Migrations
{
    public partial class MyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_UserID",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserID",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Pages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserID1",
                table: "Pages",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "BanTables",
                columns: new[] { "ID", "BanID" },
                values: new object[] { -1, 0 });

            migrationBuilder.InsertData(
                table: "Fees",
                columns: new[] { "ID", "Amount", "Currency", "ExchangeRate", "InvoiceID" },
                values: new object[] { 1, 69.5m, "EUR", 4.3m, null });

            migrationBuilder.InsertData(
                table: "Galleries",
                column: "ID",
                values: new object[]
                {
                    1,
                    2
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "ID", "PaymentMethods" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "ID", "ERole" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 2 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "SettlementCycles",
                columns: new[] { "ID", "DatePeriod" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "ID", "BeneficiaryName", "IBAN", "PaymentMethodID", "StripeInfo" },
                values: new object[,]
                {
                    { 1, "Stefan Dobrev", "BG42TTBB94008757957164", 2, "albala" },
                    { 2, "Stiliqn Robinov", "BG71IORT80944884276632", 1, "stiliqnstraip" },
                    { 3, "Jivodar Konov", "BG55IORT80944219848551", 1, "Lol" }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "ID", "GalleryID", "PictureURL" },
                values: new object[,]
                {
                    { 1, 1, "/Users/Martin.Kolev/Pictures/azisazis" },
                    { 2, 1, "/Users/Martin.Kolev/Pictures/carAzis" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BanID", "BankAccountID", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "PictureUrl", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 2, -1, 0, "martin.kolev@blankfactor.com", "Martin", "Kolev", "kapachki2", "+35920768005", null, 2, "ReyRey" },
                    { 3, -1, 0, "martin.konov@blankfactor.com", "Martin", "Konov", "kapachki3", "+35922649764", null, 2, "ElbowBlock" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "ID", "BankAccountID", "InvoiceDate", "SettlementCycleID", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Local), 2, 69.69m },
                    { 2, 2, new DateTime(2025, 10, 26, 0, 0, 0, 0, DateTimeKind.Local), 1, 69.420m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "BanID", "BankAccountID", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "PictureUrl", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 4, -1, 2, "luben.kulishev@blankfactor.com", "Luben", "Kulishev", "Narko123", "+35924775508", "/Users/Martin.Kolev/Pictures/luben.png", 1, "ObichamShumaNaParite" },
                    { 5, -1, 1, "vasil.hristov@blankfactor.com", "Vasil", "Hristov", "PDA69", "+35924775232", "/Users/Martin.Kolev/Pictures/vasil.png", 1, "vasetoHulk" }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "ID", "Bio", "GalleryID", "QRLink", "UserID", "UserID1" },
                values: new object[] { 1, "Kazvam se ema, obicham da pusha", 1, "link/haha/dedaznam", 4, null });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "ID", "Bio", "GalleryID", "QRLink", "UserID", "UserID1" },
                values: new object[] { 2, "Kazvam se ReyRey, obicham da qm qbalki", 2, "link/haha/lol", 5, null });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserID",
                table: "Pages",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserID1",
                table: "Pages",
                column: "UserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_UserID",
                table: "Pages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_UserID1",
                table: "Pages",
                column: "UserID1",
                principalTable: "Users",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_UserID",
                table: "Pages");

            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Users_UserID1",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserID",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_UserID1",
                table: "Pages");

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Fees",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Galleries",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SettlementCycles",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SettlementCycles",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BanTables",
                keyColumn: "ID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserID1",
                table: "Pages");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "Pages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserID",
                table: "Pages",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_UserID",
                table: "Pages",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID");
        }
    }
}
