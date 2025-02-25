namespace Tech2019.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migPCaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "ActionStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actions", "ActionStatus");
        }
    }
}
