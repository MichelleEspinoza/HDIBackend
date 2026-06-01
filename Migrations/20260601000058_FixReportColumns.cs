using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HdiBackend.Migrations
{
    /// <inheritdoc />
    public partial class FixReportColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date_phone",
                table: "report",
                newName: "reporter_phone");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id_user",
                keyValue: 1,
                column: "password",
                value: "$2a$11$nV7h3Iu4Hc5/QAoJo/nr7O45cuGkkiuJe9iiOUJdJVeymtU8IrOa2");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id_user",
                keyValue: 2,
                column: "password",
                value: "$2a$11$LJHHuhlJzv.H.KUhhybB3OkeP6aOv6K3av3j0NpuGUsS2q54AwSre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "reporter_phone",
                table: "report",
                newName: "date_phone");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id_user",
                keyValue: 1,
                column: "password",
                value: "$2a$11$PPqo/4xrVNjlCPIH7nmATO1XEGLBk6QCP/7uecXPdFhZZ7ngXhVl.");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "id_user",
                keyValue: 2,
                column: "password",
                value: "$2a$11$ZeLI77WxNZJ9OP8USJHk/.0NaPrL.acjYXL35a/fi.J/qFIHwWRmK");
        }
    }
}
