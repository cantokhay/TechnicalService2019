namespace Tech2019.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migpcproducttrace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductTraces", "ActionStatusDetail", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductTraces", "ActionStatusDetail");
        }
    }
}
