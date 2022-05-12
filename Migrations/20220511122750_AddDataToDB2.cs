using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollection.Migrations
{
    public partial class AddDataToDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdditionalBool1",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AdditionalBool2",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AdditionalBool3",
                table: "Items",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdditionalDateTime1",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdditionalDateTime2",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdditionalDateTime3",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalInt1",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalInt2",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdditionalInt3",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalString1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalString2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalString3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalText1",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalText2",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdditionalText3",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName1",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName2",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FieldName3",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField1",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField2",
                table: "Collections",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeField3",
                table: "Collections",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalBool1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalBool2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalBool3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalDateTime1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalDateTime2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalDateTime3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalInt1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalInt2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalInt3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalString1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalString2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalString3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalText1",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalText2",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AdditionalText3",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "FieldName1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "FieldName2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "FieldName3",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField1",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField2",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "TypeField3",
                table: "Collections");
        }
    }
}
