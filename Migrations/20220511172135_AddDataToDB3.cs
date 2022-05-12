using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCollection.Migrations
{
    public partial class AddDataToDB3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdditionalText3",
                table: "Items",
                newName: "AddText3");

            migrationBuilder.RenameColumn(
                name: "AdditionalText2",
                table: "Items",
                newName: "AddText2");

            migrationBuilder.RenameColumn(
                name: "AdditionalText1",
                table: "Items",
                newName: "AddText1");

            migrationBuilder.RenameColumn(
                name: "AdditionalString3",
                table: "Items",
                newName: "AddString3");

            migrationBuilder.RenameColumn(
                name: "AdditionalString2",
                table: "Items",
                newName: "AddString2");

            migrationBuilder.RenameColumn(
                name: "AdditionalString1",
                table: "Items",
                newName: "AddString1");

            migrationBuilder.RenameColumn(
                name: "AdditionalInt3",
                table: "Items",
                newName: "AddInt3");

            migrationBuilder.RenameColumn(
                name: "AdditionalInt2",
                table: "Items",
                newName: "AddInt2");

            migrationBuilder.RenameColumn(
                name: "AdditionalInt1",
                table: "Items",
                newName: "AddInt1");

            migrationBuilder.RenameColumn(
                name: "AdditionalDateTime3",
                table: "Items",
                newName: "AddTime3");

            migrationBuilder.RenameColumn(
                name: "AdditionalDateTime2",
                table: "Items",
                newName: "AddTime2");

            migrationBuilder.RenameColumn(
                name: "AdditionalDateTime1",
                table: "Items",
                newName: "AddTime1");

            migrationBuilder.RenameColumn(
                name: "AdditionalBool3",
                table: "Items",
                newName: "AddBool3");

            migrationBuilder.RenameColumn(
                name: "AdditionalBool2",
                table: "Items",
                newName: "AddBool2");

            migrationBuilder.RenameColumn(
                name: "AdditionalBool1",
                table: "Items",
                newName: "AddBool1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddTime3",
                table: "Items",
                newName: "AdditionalDateTime3");

            migrationBuilder.RenameColumn(
                name: "AddTime2",
                table: "Items",
                newName: "AdditionalDateTime2");

            migrationBuilder.RenameColumn(
                name: "AddTime1",
                table: "Items",
                newName: "AdditionalDateTime1");

            migrationBuilder.RenameColumn(
                name: "AddText3",
                table: "Items",
                newName: "AdditionalText3");

            migrationBuilder.RenameColumn(
                name: "AddText2",
                table: "Items",
                newName: "AdditionalText2");

            migrationBuilder.RenameColumn(
                name: "AddText1",
                table: "Items",
                newName: "AdditionalText1");

            migrationBuilder.RenameColumn(
                name: "AddString3",
                table: "Items",
                newName: "AdditionalString3");

            migrationBuilder.RenameColumn(
                name: "AddString2",
                table: "Items",
                newName: "AdditionalString2");

            migrationBuilder.RenameColumn(
                name: "AddString1",
                table: "Items",
                newName: "AdditionalString1");

            migrationBuilder.RenameColumn(
                name: "AddInt3",
                table: "Items",
                newName: "AdditionalInt3");

            migrationBuilder.RenameColumn(
                name: "AddInt2",
                table: "Items",
                newName: "AdditionalInt2");

            migrationBuilder.RenameColumn(
                name: "AddInt1",
                table: "Items",
                newName: "AdditionalInt1");

            migrationBuilder.RenameColumn(
                name: "AddBool3",
                table: "Items",
                newName: "AdditionalBool3");

            migrationBuilder.RenameColumn(
                name: "AddBool2",
                table: "Items",
                newName: "AdditionalBool2");

            migrationBuilder.RenameColumn(
                name: "AddBool1",
                table: "Items",
                newName: "AdditionalBool1");
        }
    }
}
