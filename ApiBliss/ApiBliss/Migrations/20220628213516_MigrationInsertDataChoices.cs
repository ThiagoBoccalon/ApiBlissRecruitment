using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBliss.Migrations
{
    public partial class MigrationInsertDataChoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('Python', 2048, 1)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('CSharp', 2048, 1)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('Lisbon',2048, 2)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('London', 2048, 2)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('Real Madrid FC', 2048, 3)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('Liverpool FC', 2048, 3)");

            migrationBuilder.Sql("Insert Into Choices(OptionOfChoice, Votes, QuestionId)" +
                "Values('Manchester City', 2048, 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Choices");
        }
    }
}
