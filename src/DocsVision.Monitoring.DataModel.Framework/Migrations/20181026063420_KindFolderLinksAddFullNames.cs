using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsVision.Monitoring.DataModel.Framework.Migrations
{
    public partial class KindFolderLinksAddFullNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "KindFolderLinks",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FolderFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 1024,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KindFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 1024,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FolderFullName",
                schema: "dbo",
                table: "KindFolderLinks");

            migrationBuilder.DropColumn(
                name: "KindFullName",
                schema: "dbo",
                table: "KindFolderLinks");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                schema: "dbo",
                table: "KindFolderLinks",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
