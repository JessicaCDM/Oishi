using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Oishi.Data.Models;
using System.Reflection.Emit;

namespace Oishi.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserAccount>().HasOne(x => x.UserInternalLogin).WithOne(x => x.UserAccount).HasForeignKey<UserInternalLogin>(x => x.UserAccountId);
            builder.Entity<AdvertisementHighlight>().HasKey(x => new { x.HighLightTypeId, x.AdvertisementId });
            builder.Entity<Favorite>().HasKey(x => new { x.UserAccountId, x.AdvertisementId });
            builder.Entity<Advertisement>().HasMany(x => x.Favorites).WithOne(x => x.Advertisement).HasForeignKey(x => x.AdvertisementId);
            builder.Entity<UserAccount>().HasMany(x => x.Favorites).WithOne(x => x.UserAccount).HasForeignKey(x => x.UserAccountId);
            builder.Entity<UserAccount>().HasMany(x => x.SentMessages).WithOne(x => x.SenderUserAccount).HasForeignKey(x => x.SenderUserAccountId);
            builder.Entity<UserAccount>().HasMany(x => x.ReceivedMessages).WithOne(x => x.ReceiverUserAccount).HasForeignKey(x => x.ReceiverUserAccountId);

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                //entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(builder);
        }

        public DbSet<UserAccount> UserAccounts { get;set; }
        public DbSet<ExternalProvider> ExternalProviders { get;set; }
        public DbSet<UserInternalLogin> UserInternalLogins { get;set; }
        public DbSet<UserExternalLogin> UserExternalLogins { get;set;}
        public DbSet<Profile> Profiles { get;set; }
        public DbSet<Advertisement> Advertisements { get;set; }
        public DbSet<Image> Images { get;set; }
        public DbSet<MunicipalityOrCity> MunicipalityOrCities { get;set; }
        public DbSet<Region> Regions { get;set; }
        public DbSet<Subcategory> Subcategories { get;set; }
        public DbSet<Category> Categories { get;set; }
        public DbSet<AdvertisementHighlight> AdvertisementHighlights { get;set; }
        public DbSet<HighlightType> HighlightTypes { get;set; }
        public DbSet<Favorite> Favorites { get;set; }
        public DbSet<Message> Messages { get;set; }
    }
}
