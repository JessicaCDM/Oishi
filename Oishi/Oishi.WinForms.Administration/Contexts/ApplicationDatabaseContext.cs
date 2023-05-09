using Microsoft.EntityFrameworkCore;

namespace Oishi.WinForms.Administration.Contexts
{
    internal class ApplicationDatabaseContext : Oishi.Data.Contexts.DatabaseContext
    {
        private string _connectionString;
        public ApplicationDatabaseContext(string connectionString = "Server=sql8005.site4now.net;Database=db_a977f0_oishi;User Id=db_a977f0_oishi_admin;Password=Developer2023;MultipleActiveResultSets=true") : base()
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
