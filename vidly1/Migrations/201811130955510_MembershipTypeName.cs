namespace vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MembershipTypeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipName_Id", c => c.Byte());
            AddColumn("dbo.MembershipTypes", "MembershipName", c => c.String());
            CreateIndex("dbo.Customers", "MembershipName_Id");
            AddForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipName_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipName_Id" });
            DropColumn("dbo.MembershipTypes", "MembershipName");
            DropColumn("dbo.Customers", "MembershipName_Id");
        }
    }
}
