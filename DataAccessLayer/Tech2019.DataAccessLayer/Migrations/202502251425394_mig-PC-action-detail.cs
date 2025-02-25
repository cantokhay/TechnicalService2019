namespace Tech2019.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migPCactiondetail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actions", "ActionStatusDetail", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actions", "ActionStatusDetail");
        }
    }
}
