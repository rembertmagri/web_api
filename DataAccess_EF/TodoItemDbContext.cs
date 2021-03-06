namespace DataAccess_EF
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TodoItemDbContext : DbContext
    {
        // Your context has been configured to use a 'TodoItemModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DataAccess_EF.TodoItemModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TodoItemModel' 
        // connection string in the application configuration file.

        public TodoItemDbContext() : base("name=TodoItemModel")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<TodoItem> TodoItens { get; set; }
    }
}