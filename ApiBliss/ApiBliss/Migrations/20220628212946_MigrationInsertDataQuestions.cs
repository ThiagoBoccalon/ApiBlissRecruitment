using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiBliss.Migrations
{
    public partial class MigrationInsertDataQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Questions(Ask, ImageUrl, ThumbUrl, PublishedAt)" +
                "Values('Favourite programming language?'," +
                "'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)'," +
                "'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)'," +
                "now())");

            migrationBuilder.Sql("Insert Into Questions(Ask, ImageUrl, ThumbUrl, PublishedAt)" +
                "Values('Where do you prefe to live?'," +
                "'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)'," +
                "'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)'," +
                "now())");

            migrationBuilder.Sql("Insert Into Questions(Ask, ImageUrl, ThumbUrl, PublishedAt)" +
                "Values('What is the best team of football of the world?'," +
                "'https://dummyimage.com/600x400/000/fff.png&text=question+1+image+(600x400)'," +
                "'https://dummyimage.com/120x120/000/fff.png&text=question+1+image+(120x120)'," +
                "now())");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Questions");
        }
    }
}
