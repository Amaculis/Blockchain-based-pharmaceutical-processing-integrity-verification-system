using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PharmaBlockchainBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables_AddTimestampIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProtocolStep_Timestamp",
                table: "ProtocolStep",
                column: "Timestamp",
                descending: new bool[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProtocolStep_Timestamp",
                table: "ProtocolStep");
        }
    }
}
