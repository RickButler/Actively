namespace actively.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpostalcdes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostalCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Postal = c.String(maxLength: 16),
                        City = c.String(maxLength: 128),
                        State = c.String(maxLength: 32),
                        Lat = c.Double(nullable: false),
                        Long = c.Double(nullable: false),
                        TimeZone = c.Int(nullable: false),
                        DST = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Locations", "Name", c => c.String(maxLength: 128));
            AlterColumn("dbo.Locations", "Address", c => c.String(maxLength: 128));
            AlterColumn("dbo.Locations", "City", c => c.String(maxLength: 128));
            AlterColumn("dbo.Locations", "State", c => c.String(maxLength: 32));
            AlterColumn("dbo.Locations", "Postal", c => c.String(maxLength: 16));
            AlterColumn("dbo.Locations", "Type", c => c.String(maxLength: 256));
            AlterColumn("dbo.Locations", "Keywords", c => c.String(maxLength: 512));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Keywords", c => c.String());
            AlterColumn("dbo.Locations", "Type", c => c.String());
            AlterColumn("dbo.Locations", "Postal", c => c.String());
            AlterColumn("dbo.Locations", "State", c => c.String());
            AlterColumn("dbo.Locations", "City", c => c.String());
            AlterColumn("dbo.Locations", "Address", c => c.String());
            AlterColumn("dbo.Locations", "Name", c => c.String());
            DropTable("dbo.PostalCodes");
        }
    }
}
