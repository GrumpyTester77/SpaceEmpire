namespace SpaceEmpire4XTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TechnologyViewModels", "Cost_CostId", c => c.Int());
            AddColumn("dbo.TechnologyViewModels", "TechnologyLevel_LevelId", c => c.Int());
            CreateIndex("dbo.TechnologyViewModels", "Cost_CostId");
            CreateIndex("dbo.TechnologyViewModels", "TechnologyLevel_LevelId");
            AddForeignKey("dbo.TechnologyViewModels", "Cost_CostId", "dbo.CostViewModels", "CostId");
            AddForeignKey("dbo.TechnologyViewModels", "TechnologyLevel_LevelId", "dbo.TechnologyLevelViewModels", "LevelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TechnologyViewModels", "TechnologyLevel_LevelId", "dbo.TechnologyLevelViewModels");
            DropForeignKey("dbo.TechnologyViewModels", "Cost_CostId", "dbo.CostViewModels");
            DropIndex("dbo.TechnologyViewModels", new[] { "TechnologyLevel_LevelId" });
            DropIndex("dbo.TechnologyViewModels", new[] { "Cost_CostId" });
            DropColumn("dbo.TechnologyViewModels", "TechnologyLevel_LevelId");
            DropColumn("dbo.TechnologyViewModels", "Cost_CostId");
        }
    }
}
