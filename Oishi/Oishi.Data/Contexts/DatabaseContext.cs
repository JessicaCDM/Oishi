﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<EmailValidationStatus> EmailValidationStatuses { get;set; }
        public DbSet<Profile> Profiles { get;set; }
        public DbSet<Advertisement> Advertisements { get;set; }
        public DbSet<AdvertisementStatus> AdvertisementStatuses { get;set; }
        public DbSet<Image> Images { get;set; }
        public DbSet<MunicipalityOrCity> MunicipalityOrCities { get;set; }
        public DbSet<Region> Regions { get;set; }
        public DbSet<Subcategory> Subcategories { get;set; }
        public DbSet<Category> Categories { get;set; }
        public DbSet<AdvertisementHighlight> AdvertisementHighlights { get;set; }
        public DbSet<HighlightType> HighlightTypes { get;set; }
    }
}
