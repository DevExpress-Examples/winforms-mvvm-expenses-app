using System.Data.Entity;
using MVVMExpenses.DataModels;

namespace MVVMExpenses.DataBase {
    [DbConfigurationType(typeof(MVVMExpenses.Common.DataModel.EntityFramework.MyDbSQLiteConfiguration))]
    public class MyDbContext : System.Data.Entity.DbContext {
        static MyDbContext() {
            Database.SetInitializer<MyDbContext>(null);
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}