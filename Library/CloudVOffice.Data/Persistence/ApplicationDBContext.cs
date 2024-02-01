using CloudVOffice.Core.Domain.Company;
using CloudVOffice.Core.Domain.Comunication;
using CloudVOffice.Core.Domain.Customer;
using CloudVOffice.Core.Domain.EmailTemplates;
using CloudVOffice.Core.Domain.LocationMaster;
using CloudVOffice.Core.Domain.Logging;
using CloudVOffice.Core.Domain.Pandit;
using CloudVOffice.Core.Domain.Pemission;
using CloudVOffice.Core.Domain.SanatanMandir.PoojaCategories;
using CloudVOffice.Core.Domain.SanatanMandir.Temples;
using CloudVOffice.Core.Domain.SanatanUsers;
using CloudVOffice.Core.Domain.Users;
using CloudVOffice.Data.Seeding;
using Microsoft.EntityFrameworkCore;


namespace CloudVOffice.Data.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
         : base(options)
        {

        }
        #region Base

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<ActivityLogType> ActivityLogTypes { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<RoleAndApplicationWisePermission> RoleAndApplicationWisePermissions { get; set; }
        public virtual DbSet<UserWiseViewMapper> UserWiseViewMappers { get; set; }
        public virtual DbSet<InstalledApplication> InstalledApplications { get; set; }
        public virtual DbSet<EmailDomain> EmailDomains { get; set; }
        public virtual DbSet<EmailAccount> EmailAccounts { get; set; }
        public virtual DbSet<LetterHead> LetterHeads { get; set; }
        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

        #endregion

        #region Location Master
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<City> Cities { get; set; }

        #endregion

        #region Sanatan Mandir
        public virtual DbSet<PoojaCategory> PoojaCategories { get; set; }
        public virtual DbSet<Temple> Temples { get; set; }
        public virtual DbSet<SanatanUser> SanatanUsers { get; set; }
        public virtual DbSet<PanditRegistration> PanditRegistrations { get; set; }
        public virtual DbSet<CustomerRegistration> CustomerRegistrations { get; set; }
        public virtual DbSet<Question> Questions { get; set; }

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            #region Base

            modelBuilder.Entity<RefreshToken>()
       .Property(s => s.CreatedDate)
       .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RefreshToken>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<Role>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Role>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<User>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<Application>()
        .Property(s => s.CreatedDate)
        .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Application>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<RoleAndApplicationWisePermission>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<RoleAndApplicationWisePermission>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();




            modelBuilder.Entity<UserWiseViewMapper>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserWiseViewMapper>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<InstalledApplication>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<InstalledApplication>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailDomain>()
      .Property(s => s.CreatedDate)
      .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailDomain>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailAccount>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailAccount>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<LetterHead>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<LetterHead>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<CompanyDetails>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CompanyDetails>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();



            modelBuilder.Entity<EmailTemplate>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<EmailTemplate>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            modelBuilder.Entity<UserWiseViewMapper>()
.Property(s => s.CreatedDate)
.HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserWiseViewMapper>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            #endregion

            #region Location Master

            modelBuilder.Entity<Country>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Country>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<State>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<State>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<City>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<City>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            #endregion

            #region Sanatan Mandir

            modelBuilder.Entity<PoojaCategory>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PoojaCategory>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<Temple>()
            .Property(s => s.CreatedDate)
            .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Temple>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<SanatanUser>()
           .Property(s => s.CreatedDate)
           .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<SanatanUser>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<PanditRegistration>()
           .Property(s => s.CreatedDate)
           .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<PanditRegistration>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<CustomerRegistration>()
         .Property(s => s.CreatedDate)
         .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<CustomerRegistration>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();

            modelBuilder.Entity<Question>()
       .Property(s => s.CreatedDate)
       .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Question>()
             .Property(s => s.Deleted)
             .HasDefaultValue(false)
             .ValueGeneratedNever();


            #endregion

        }
    }
}
