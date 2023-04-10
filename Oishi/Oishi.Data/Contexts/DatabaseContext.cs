using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Oishi.Data.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oishi.Data.Contexts
{
    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            builder.Entity<UserAccount>().HasOne(x => x.UserInternalLogin).WithOne(x => x.UserAccount).HasForeignKey<UserInternalLogin>(x => x.UserAccountId);
        }

        public DbSet<UserAccount> UserAccounts { get;set; }
        public DbSet<ExternalProvider> ExternalProviders { get;set; }
        public DbSet<UserInternalLogin> UserInternalLogins { get;set; }
        public DbSet<UserExternalLogin> UserExternalLogins { get;set;}
    }
}
