using Microsoft.Data.SqlTypes;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF10.VectorSearchSupportForSqlServer2025.Migrations
{
    /// <inheritdoc />
    public partial class FirstNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FirstNames",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Embedding = table.Column<SqlVector<float>>(type: "vector(768)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirstNames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FirstNames");
        }
    }
}
