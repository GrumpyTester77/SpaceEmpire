namespace SpaceEmpire4XTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseChange1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.TechnologyViewModels", "Level_Id");
            DropColumn("dbo.TechnologyViewModels", "Cost_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TechnologyViewModels", "Cost_Id", c => c.Int(nullable: false));
            AddColumn("dbo.TechnologyViewModels", "Level_Id", c => c.Int(nullable: false));
        }
    }
}
