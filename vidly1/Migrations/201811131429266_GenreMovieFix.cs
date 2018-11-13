namespace vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreMovieFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipName_Id" });
            AddColumn("dbo.Customers", "MembershipName", c => c.String());
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Customers", "MembershipName_Id");
            DropColumn("dbo.Movies", "Genre");
            DropColumn("dbo.Movies", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Stock", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre", c => c.String(nullable: false));
            AddColumn("dbo.Customers", "MembershipName_Id", c => c.Byte());
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "DateAdded", c => c.String(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
            DropColumn("dbo.Customers", "MembershipName");
            CreateIndex("dbo.Customers", "MembershipName_Id");
            AddForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes", "Id");
        }
    }
}
