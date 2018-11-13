namespace vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenresFillNames : DbMigration
    {
        public override void Up()
        {
          Sql("INSERT INTO Genres (Id, Name) VALUES (1,'Action')");
          Sql("INSERT INTO Genres (Id, Name) VALUES (2,'Comedy')");
          Sql("INSERT INTO Genres (Id, Name) VALUES (3,'Drama')");
          Sql("INSERT INTO Genres (Id, Name) VALUES (4,'Sci-Fi')");
    }
        
        public override void Down()
        {
        }
    }
}
