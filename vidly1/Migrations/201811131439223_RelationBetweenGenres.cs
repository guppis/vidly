namespace vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RelationBetweenGenres : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Movies", "GenreId");
            AddForeignKey("dbo.Movies", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "GenreId", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "GenreId" });
        }
    }
}