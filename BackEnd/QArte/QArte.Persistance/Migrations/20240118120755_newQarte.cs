using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QArte.Persistance.Migrations
{
    public partial class newQarte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentMethods = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ERole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SettlementCycles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePeriod = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementCycles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GalleryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pictures_Galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Galleries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IBAN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeneficiaryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StripeInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethodID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BankAccounts_PaymentMethods_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BankAccountID = table.Column<int>(type: "int", nullable: false),
                    SettlementCycleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_BankAccounts_BankAccountID",
                        column: x => x.BankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_SettlementCycles_SettlementCycleID",
                        column: x => x.SettlementCycleID,
                        principalTable: "SettlementCycles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isBanned = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    BankAccountID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_BankAccounts_BankAccountID",
                        column: x => x.BankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExchangeRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Fees_Invoices_InvoiceID",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRLink = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GalleryID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Pages_Galleries_GalleryID",
                        column: x => x.GalleryID,
                        principalTable: "Galleries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pages_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_PaymentMethodID",
                table: "BankAccounts",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_IBAN",
                table: "BankAccounts",
                column: "IBAN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fees_InvoiceID",
                table: "Fees",
                column: "InvoiceID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_BankAccountID",
                table: "Invoices",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SettlementCycleID",
                table: "Invoices",
                column: "SettlementCycleID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SettlementCycleID",
                table: "Invoices",
                column: "SettlementCycleID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Page_GalleryID",
                table: "Pages",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_GalleryID",
                table: "Pages",
                column: "GalleryID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_QRLink",
                table: "Pages",
                column: "QRLink",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_UserID",
                table: "Pages",
                column: "UserID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Picture_GalleryID",
                table: "Pictures",
                column: "GalleryID");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_BankAccountID",
                table: "Users",
                column: "BankAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_RoleID",
                table: "Users",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_BankAccountID",
                table: "Users",
                column: "BankAccountID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "SettlementCycles");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "PaymentMethods");
        }
    }
}
