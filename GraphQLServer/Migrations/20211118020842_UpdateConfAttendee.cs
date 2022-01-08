using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphqlDemo.Migrations
{
    public partial class UpdateConfAttendee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceAttendee",
                table: "ConferenceAttendee");

            migrationBuilder.DropIndex(
                name: "IX_ConferenceAttendee_ConferenceId",
                table: "ConferenceAttendee");

            migrationBuilder.DropColumn(
                name: "ConfrenceId",
                table: "ConferenceAttendee");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "ConferenceAttendee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceAttendee",
                table: "ConferenceAttendee",
                columns: new[] { "ConferenceId", "AttendeeID" });

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConferenceAttendee",
                table: "ConferenceAttendee");

            migrationBuilder.AlterColumn<int>(
                name: "ConferenceId",
                table: "ConferenceAttendee",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ConfrenceId",
                table: "ConferenceAttendee",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConferenceAttendee",
                table: "ConferenceAttendee",
                columns: new[] { "ConfrenceId", "AttendeeID" });

            migrationBuilder.CreateIndex(
                name: "IX_ConferenceAttendee_ConferenceId",
                table: "ConferenceAttendee",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConferenceAttendee_Conferences_ConferenceId",
                table: "ConferenceAttendee",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
