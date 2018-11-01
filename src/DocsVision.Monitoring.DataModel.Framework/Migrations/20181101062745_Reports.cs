using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsVision.Monitoring.DataModel.Framework.Migrations
{
    public partial class Reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KindFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "KindFolderLinks",
                nullable: true,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "FolderFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FolderName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KindName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Reports",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(unicode: false, maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("reports_pk_id", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "DocumentsWithoutShortcutsReportRows",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ReportId = table.Column<long>(nullable: false),
                    LinkId = table.Column<long>(nullable: true),
                    DocumentId = table.Column<Guid>(nullable: false),
                    DocumentName = table.Column<string>(maxLength: 480, nullable: true),
                    DocumentDescription = table.Column<string>(maxLength: 512, nullable: true),
                    DocumentKindName = table.Column<string>(maxLength: 256, nullable: true),
                    TargetFolderName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("documentswithoutshortcutsreportrows_pk_id", x => x.Id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "documentswithoutshortcutsreportrow_fk_linkid",
                        column: x => x.LinkId,
                        principalSchema: "dbo",
                        principalTable: "KindFolderLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "documentswithoutshortcutsreportrow_fk_reportid",
                        column: x => x.ReportId,
                        principalSchema: "dbo",
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "documentswithoutshortcutsreportrow_idx_linkid",
                schema: "dbo",
                table: "DocumentsWithoutShortcutsReportRows",
                column: "LinkId")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "documentswithoutshortcutsreportrow_idx_reportid",
                schema: "dbo",
                table: "DocumentsWithoutShortcutsReportRows",
                column: "ReportId")
                .Annotation("SqlServer:Clustered", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocumentsWithoutShortcutsReportRows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Reports",
                schema: "dbo");

            migrationBuilder.DropColumn(
                name: "FolderName",
                schema: "dbo",
                table: "KindFolderLinks");

            migrationBuilder.DropColumn(
                name: "KindName",
                schema: "dbo",
                table: "KindFolderLinks");

            migrationBuilder.AlterColumn<string>(
                name: "KindFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                schema: "dbo",
                table: "KindFolderLinks",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<string>(
                name: "FolderFullName",
                schema: "dbo",
                table: "KindFolderLinks",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 2048,
                oldNullable: true);
        }
    }
}
