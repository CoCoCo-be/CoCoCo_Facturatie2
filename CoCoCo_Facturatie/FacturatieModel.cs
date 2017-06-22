namespace CoCoCo_Facturatie
{
    using System;
    using System.Data.Common;
    using System.Data.Entity;
    using MySql.Data.Entity;
    using System.Linq;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class FacturatieModel : DbContext
    {
        // Your context has been configured to use a 'FacturatieModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CoCoCo_Facturatie.FacturatieModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FacturatieModel' 
        // connection string in the application configuration file.
        public FacturatieModel()
            : base("name=FacturatieModel")
        {
        }

        // Constructor to use on a DBConnection that is already opened
        public FacturatieModel(DbConnection existingConnection, bool contextOwnsConnection)
            : base (existingConnection, contextOwnsConnection)
        {
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<KostenSchema> KostenSchemas{ get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}