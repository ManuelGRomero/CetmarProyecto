namespace Sistema_Cetmar.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMigracionCambiosEnElIdentityModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alumnoes",
                c => new
                    {
                        alumnoID = c.Int(nullable: false, identity: true),
                        noExpediente = c.Int(nullable: false),
                        alumnoNumeroControl = c.Int(nullable: false),
                        nombreAlumno = c.String(nullable: false),
                        apellidoPatAlumno = c.String(nullable: false),
                        apellidoMatAlumno = c.String(nullable: false),
                        fechaNac = c.String(nullable: false),
                        telefonoAlumno = c.String(nullable: false),
                        domicilioAlumno = c.String(nullable: false),
                        grupoAlumno = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.alumnoID);
            
            CreateTable(
                "dbo.Expedientes",
                c => new
                    {
                        expedienteID = c.Int(nullable: false, identity: true),
                        alumnoID = c.Int(nullable: false),
                        especialistaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.expedienteID)
                .ForeignKey("dbo.Alumnoes", t => t.alumnoID, cascadeDelete: true)
                .ForeignKey("dbo.Especialistas", t => t.especialistaID, cascadeDelete: true)
                .Index(t => t.alumnoID)
                .Index(t => t.especialistaID);
            
            CreateTable(
                "dbo.Especialistas",
                c => new
                    {
                        especialistaID = c.Int(nullable: false, identity: true),
                        especialistaRFC = c.String(nullable: false),
                        especialistaNombre = c.String(nullable: false),
                        especialistaApellido = c.String(nullable: false),
                        especialidad = c.String(nullable: false),
                        especialistaTelefono = c.String(nullable: false),
                        especialistaDomicilio = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.especialistaID);
            
            CreateTable(
                "dbo.Registro_Historial",
                c => new
                    {
                        registroHistorialID = c.Int(nullable: false, identity: true),
                        registroHistorialnota = c.String(nullable: false),
                        registroHistorialFecha = c.DateTime(nullable: false),
                        registroHistorialCanalizacion = c.String(nullable: false),
                        expedianteID = c.Int(nullable: false),
                        expedientes_expedienteID = c.Int(),
                    })
                .PrimaryKey(t => t.registroHistorialID)
                .ForeignKey("dbo.Expedientes", t => t.expedientes_expedienteID)
                .Index(t => t.expedientes_expedienteID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Registro_Historial", "expedientes_expedienteID", "dbo.Expedientes");
            DropForeignKey("dbo.Expedientes", "especialistaID", "dbo.Especialistas");
            DropForeignKey("dbo.Expedientes", "alumnoID", "dbo.Alumnoes");
            DropIndex("dbo.Registro_Historial", new[] { "expedientes_expedienteID" });
            DropIndex("dbo.Expedientes", new[] { "especialistaID" });
            DropIndex("dbo.Expedientes", new[] { "alumnoID" });
            DropTable("dbo.Registro_Historial");
            DropTable("dbo.Especialistas");
            DropTable("dbo.Expedientes");
            DropTable("dbo.Alumnoes");
        }
    }
}
