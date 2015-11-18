namespace EMMTY_GO_WEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emmtygo2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.AspNetUsers", name: "Cleinte_IdCliente", newName: "Cliente_IdCliente");
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Cleinte_IdCliente", newName: "IX_Cliente_IdCliente");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.AspNetUsers", name: "IX_Cliente_IdCliente", newName: "IX_Cleinte_IdCliente");
            RenameColumn(table: "dbo.AspNetUsers", name: "Cliente_IdCliente", newName: "Cleinte_IdCliente");
        }
    }
}
