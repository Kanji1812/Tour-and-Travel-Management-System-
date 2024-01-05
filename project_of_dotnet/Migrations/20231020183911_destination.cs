using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_of_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class destination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    B_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.B_Id);
                    table.ForeignKey(
                        name: "FK_booking_user_data_Id",
                        column: x => x.Id,
                        principalTable: "user_data",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_Id",
                table: "booking",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");
        }
    }
}
