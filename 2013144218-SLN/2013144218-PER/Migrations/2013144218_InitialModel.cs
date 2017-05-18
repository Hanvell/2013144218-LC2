using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2013144218_PER.Migrations
{
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispensadorEfectivo", "idRetiro", c => c.Int(nullable: false));
            AddColumn("dbo.Pantalla", "idRetiro", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "idPantalla", c => c.Int(nullable: false));
            AddColumn("dbo.Retiro", "idDispensadorEfectivo", c => c.Int(nullable: false));
            AddForeignKey("dbo.Retiro", "idRetiro", "dbo.Pantalla", "idPantalla");
            AddForeignKey("dbo.Retiro", "idRetiro", "dbo.DispensadorEfectivo", "idDispensadorefectivo");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.DispensadorEfectivo");
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.Pantalla");
            DropColumn("dbo.Retiro", "idDispensadorEfectivo");
            DropColumn("dbo.Retiro", "idPantalla");
            DropColumn("dbo.Pantalla", "idRetiro");
            DropColumn("dbo.DispensadorEfectivo", "idRetiro");
        }
    }
}

}
