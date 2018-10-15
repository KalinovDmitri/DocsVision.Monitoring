using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DocsVision.Monitoring.DataModel.Framework.Migrations
{
	public partial class KindFolderLinkUpdates : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AddColumn<bool>(
				name: "IsActive",
				schema: "dbo",
				table: "KindFolderLinks",
				nullable: false,
				defaultValueSql: "1");

			migrationBuilder.AddColumn<DateTime>(
				name: "CreatedAt",
				schema: "dbo",
				table: "KindFolderLinks",
				nullable: true,
				defaultValueSql: "GETDATE()");

			migrationBuilder.AddColumn<DateTime>(
				name: "UpdatedAt",
				schema: "dbo",
				table: "KindFolderLinks",
				nullable: true);
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "IsActive",
				schema: "dbo",
				table: "KindFolderLinks");

			migrationBuilder.DropColumn(
				name: "CreatedAt",
				schema: "dbo",
				table: "KindFolderLinks");

			migrationBuilder.DropColumn(
				name: "UpdatedAt",
				schema: "dbo",
				table: "KindFolderLinks");
		}
	}
}
