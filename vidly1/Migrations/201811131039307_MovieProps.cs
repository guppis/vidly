namespace vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovieProps : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Genre", c => c.String());
            AddColumn("dbo.Movies", "DateAdded", c => c.String());
            AddColumn("dbo.Movies", "ReleaseDate", c => c.String());
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Stock");
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "DateAdded");
            DropColumn("dbo.Movies", "Genre");
        }
    }
}
