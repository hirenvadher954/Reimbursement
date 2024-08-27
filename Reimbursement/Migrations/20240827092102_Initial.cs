using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Reimbursement.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentStatusDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentReference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayeeType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkerReimbursements",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WRReferenceNum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CMSReferenceNum = table.Column<long>(type: "bigint", nullable: true),
                    ClaimNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpenseTypeTXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionTXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StatusTXT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedDt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReimbursedAmt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PdfGuid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerCareNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkerReimbursements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentID = table.Column<long>(type: "bigint", nullable: true),
                    ClaimNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EntitledName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstructLineItemID = table.Column<long>(type: "bigint", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceID = table.Column<long>(type: "bigint", nullable: true),
                    WorkerCCN = table.Column<long>(type: "bigint", nullable: true),
                    WorkerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedByUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDTM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ThirdPartyPayeeID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentItems_Payments_PaymentID",
                        column: x => x.PaymentID,
                        principalTable: "Payments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "29c00633-c541-4ba8-9a77-e82283037791", null, "Manager", "MANAGER" },
                    { "ac30629b-6e27-4ea0-8ff7-44000c0e0147", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentItems_PaymentID",
                table: "PaymentItems",
                column: "PaymentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.DropTable(
                name: "PaymentItems");

            migrationBuilder.DropTable(
                name: "WorkerReimbursements");

            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
