namespace _2013144218_PER.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ATM",
                c => new
                    {
                        idATM = c.Int(nullable: false),
                        idRanuraDeposito = c.Int(nullable: false),
                        idTeclado = c.Int(nullable: false),
                        idDispensadorEfectivo = c.Int(nullable: false),
                        idPantalla = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                        idBaseDatos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idATM)
                .ForeignKey("dbo.BaseDatos", t => t.idATM)
                .Index(t => t.idATM);
            
            CreateTable(
                "dbo.BaseDatos",
                c => new
                    {
                        idBaseDatos = c.Int(nullable: false, identity: true),
                        Administrador = c.String(),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idBaseDatos);
            
            CreateTable(
                "dbo.Cuenta",
                c => new
                    {
                        idCuenta = c.Int(nullable: false, identity: true),
                        NumeroCuenta = c.Int(nullable: false),
                        pin = c.Int(nullable: false),
                        saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        idBaseDatos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idCuenta)
                .ForeignKey("dbo.BaseDatos", t => t.idBaseDatos, cascadeDelete: true)
                .Index(t => t.idBaseDatos);
            
            CreateTable(
                "dbo.DispensadorEfectivo",
                c => new
                    {
                        idDispensadorefectivo = c.Int(nullable: false),
                        contador = c.Int(nullable: false),
                        idATM = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDispensadorefectivo)
                .ForeignKey("dbo.ATM", t => t.idDispensadorefectivo)
                .Index(t => t.idDispensadorefectivo);
            
            CreateTable(
                "dbo.Retiro",
                c => new
                    {
                        idRetiro = c.Int(nullable: false),
                        Monto = c.Double(nullable: false),
                        idATM = c.Int(nullable: false),
                        idTeclado = c.Int(nullable: false),
                        idPantalla = c.Int(nullable: false),
                        idDispensadorEfectivo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRetiro)
                .ForeignKey("dbo.Pantalla", t => t.idRetiro)
                .ForeignKey("dbo.Teclado", t => t.idRetiro)
                .ForeignKey("dbo.DispensadorEfectivo", t => t.idRetiro)
                .ForeignKey("dbo.ATM", t => t.idRetiro)
                .Index(t => t.idRetiro);
            
            CreateTable(
                "dbo.Pantalla",
                c => new
                    {
                        idPantalla = c.Int(nullable: false),
                        idATM = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idPantalla)
                .ForeignKey("dbo.ATM", t => t.idPantalla)
                .Index(t => t.idPantalla);
            
            CreateTable(
                "dbo.Teclado",
                c => new
                    {
                        idTeclado = c.Int(nullable: false),
                        Marca = c.String(),
                        idATM = c.Int(nullable: false),
                        idRetiro = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idTeclado)
                .ForeignKey("dbo.ATM", t => t.idTeclado)
                .Index(t => t.idTeclado);
            
            CreateTable(
                "dbo.RanuraDeposito",
                c => new
                    {
                        idRanuraDeposito = c.Int(nullable: false),
                        idATM = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idRanuraDeposito)
                .ForeignKey("dbo.ATM", t => t.idRanuraDeposito)
                .Index(t => t.idRanuraDeposito);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teclado", "idTeclado", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.ATM");
            DropForeignKey("dbo.RanuraDeposito", "idRanuraDeposito", "dbo.ATM");
            DropForeignKey("dbo.Pantalla", "idPantalla", "dbo.ATM");
            DropForeignKey("dbo.DispensadorEfectivo", "idDispensadorefectivo", "dbo.ATM");
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.DispensadorEfectivo");
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.Teclado");
            DropForeignKey("dbo.Retiro", "idRetiro", "dbo.Pantalla");
            DropForeignKey("dbo.Cuenta", "idBaseDatos", "dbo.BaseDatos");
            DropForeignKey("dbo.ATM", "idATM", "dbo.BaseDatos");
            DropIndex("dbo.RanuraDeposito", new[] { "idRanuraDeposito" });
            DropIndex("dbo.Teclado", new[] { "idTeclado" });
            DropIndex("dbo.Pantalla", new[] { "idPantalla" });
            DropIndex("dbo.Retiro", new[] { "idRetiro" });
            DropIndex("dbo.DispensadorEfectivo", new[] { "idDispensadorefectivo" });
            DropIndex("dbo.Cuenta", new[] { "idBaseDatos" });
            DropIndex("dbo.ATM", new[] { "idATM" });
            DropTable("dbo.RanuraDeposito");
            DropTable("dbo.Teclado");
            DropTable("dbo.Pantalla");
            DropTable("dbo.Retiro");
            DropTable("dbo.DispensadorEfectivo");
            DropTable("dbo.Cuenta");
            DropTable("dbo.BaseDatos");
            DropTable("dbo.ATM");
        }
    }
}
