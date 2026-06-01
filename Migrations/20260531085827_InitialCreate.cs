using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HdiBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "office",
                columns: table => new
                {
                    id_office = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    address = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_office", x => x.id_office);
                });

            migrationBuilder.CreateTable(
                name: "type_user",
                columns: table => new
                {
                    id_type = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_user", x => x.id_type);
                });

            migrationBuilder.CreateTable(
                name: "policy",
                columns: table => new
                {
                    id_office = table.Column<int>(type: "integer", nullable: false),
                    policy_number = table.Column<string>(type: "text", nullable: false),
                    line_of_business = table.Column<string>(type: "text", nullable: true),
                    policy_holder = table.Column<string>(type: "text", nullable: false),
                    beneficiary = table.Column<string>(type: "text", nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    issue_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    payment_frequency = table.Column<string>(type: "text", nullable: false),
                    vehicle_info = table.Column<string>(type: "text", nullable: true),
                    is_paid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_policy", x => new { x.id_office, x.policy_number });
                    table.ForeignKey(
                        name: "FK_policy_office_id_office",
                        column: x => x.id_office,
                        principalTable: "office",
                        principalColumn: "id_office",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_type = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    tel = table.Column<string>(type: "text", nullable: true),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id_user);
                    table.ForeignKey(
                        name: "FK_user_type_user_id_type",
                        column: x => x.id_type,
                        principalTable: "type_user",
                        principalColumn: "id_type",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "report",
                columns: table => new
                {
                    id_report = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    id_office = table.Column<int>(type: "integer", nullable: false),
                    policy_number = table.Column<string>(type: "text", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    location = table.Column<string>(type: "text", nullable: false),
                    reporter_name = table.Column<string>(type: "text", nullable: false),
                    date_phone = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    license_plate = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    notes = table.Column<string>(type: "text", nullable: true),
                    id_user = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_report", x => x.id_report);
                    table.ForeignKey(
                        name: "FK_report_policy_id_office_policy_number",
                        columns: x => new { x.id_office, x.policy_number },
                        principalTable: "policy",
                        principalColumns: new[] { "id_office", "policy_number" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_report_user_id_user",
                        column: x => x.id_user,
                        principalTable: "user",
                        principalColumn: "id_user",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "office",
                columns: new[] { "id_office", "address" },
                values: new object[] { 1, "Oficina Central León" });

            migrationBuilder.InsertData(
                table: "type_user",
                columns: new[] { "id_type", "type" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Ajustador" }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "id_user", "id_type", "name", "password", "tel", "username" },
                values: new object[,]
                {
                    { 1, 1, "admin", "$2a$11$PPqo/4xrVNjlCPIH7nmATO1XEGLBk6QCP/7uecXPdFhZZ7ngXhVl.", "6632223344", "admin" },
                    { 2, 2, "Paco el Chato", "$2a$11$ZeLI77WxNZJ9OP8USJHk/.0NaPrL.acjYXL35a/fi.J/qFIHwWRmK", null, "paco" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_report_id_office_policy_number",
                table: "report",
                columns: new[] { "id_office", "policy_number" });

            migrationBuilder.CreateIndex(
                name: "IX_report_id_user",
                table: "report",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_user_id_type",
                table: "user",
                column: "id_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "report");

            migrationBuilder.DropTable(
                name: "policy");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "office");

            migrationBuilder.DropTable(
                name: "type_user");
        }
    }
}
