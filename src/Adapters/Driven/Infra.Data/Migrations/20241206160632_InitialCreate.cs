using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBL_CLIENTS",
                columns: table => new
                {
                    ID_CLIENT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TX_FIRST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_LAST_NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TX_PARTICIPATION = table.Column<int>(type: "int", nullable: false),
                    TX_CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CLIENTS", x => x.ID_CLIENT);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_CLIENTS");
        }
    }
}
