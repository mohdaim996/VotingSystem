using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VotingSystem.Migrations
{
    public partial class votesAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Users_UserId",
                table: "VoteAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "VoteAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "OptionText",
                table: "VoteAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "VoteId",
                table: "VoteAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VotesCount",
                table: "VoteAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VoteAnswers_VoteId",
                table: "VoteAnswers",
                column: "VoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Users_UserId",
                table: "VoteAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Votes_VoteId",
                table: "VoteAnswers",
                column: "VoteId",
                principalTable: "Votes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Users_UserId",
                table: "VoteAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_VoteAnswers_Votes_VoteId",
                table: "VoteAnswers");

            migrationBuilder.DropIndex(
                name: "IX_VoteAnswers_VoteId",
                table: "VoteAnswers");

            migrationBuilder.DropColumn(
                name: "OptionText",
                table: "VoteAnswers");

            migrationBuilder.DropColumn(
                name: "VoteId",
                table: "VoteAnswers");

            migrationBuilder.DropColumn(
                name: "VotesCount",
                table: "VoteAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "VoteAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VoteAnswers_Users_UserId",
                table: "VoteAnswers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
