using ERPS.Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace ERPS.Infrastructure.Data.v1
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Status> Status { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<BloodType> BloodTypes { get; set; }
        public DbSet<Religion> Religions { get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<Status>().Property(e => e.ID).ValueGeneratedNever();

            modelBuilder.Entity<BloodType>().Property(e => e.ID).ValueGeneratedNever();
            //modelBuilder.Entity<BloodType>().HasOne(b => b.Status);
            //modelBuilder.Entity<BloodType>().HasOne(b => b.Status).WithMany(s => s.BloodTypes).HasForeignKey(b => b.StatusID);

            modelBuilder.Entity<Gender>().Property(e => e.ID).ValueGeneratedNever();
            //modelBuilder.Entity<Gender>().HasOne(b => b.Status);
            modelBuilder.Entity<Gender>().HasOne(b => b.Status).WithMany(s => s.Genders).HasForeignKey(b => b.StatusID);

            modelBuilder.Entity<MaritalStatus>().Property(e => e.ID).ValueGeneratedNever();
            //modelBuilder.Entity<MaritalStatus>().HasOne(b => b.Status);
            modelBuilder.Entity<MaritalStatus>().HasOne(b => b.Status).WithMany(s => s.MaritalStatus).HasForeignKey(b => b.StatusID);

            modelBuilder.Entity<Nationality>().Property(e => e.ID).ValueGeneratedNever();
            //modelBuilder.Entity<Nationality>().HasOne(b => b.Status);
            modelBuilder.Entity<Nationality>().HasOne(b => b.Status).WithMany(s => s.Nationality).HasForeignKey(b => b.StatusID);

            modelBuilder.Entity<Religion>().Property(e => e.ID).ValueGeneratedNever();
            //modelBuilder.Entity<Religion>().HasOne(b => b.Status);
            modelBuilder.Entity<Religion>().HasOne(b => b.Status).WithMany(s => s.Religions).HasForeignKey(b => b.StatusID);

            modelBuilder.Entity<Driver>().Property(d => d.ID).ValueGeneratedNever();
            modelBuilder.Entity<Driver>().HasOne(d => d.Status).WithMany(s => s.Drivers).HasForeignKey(d => d.StatusID);
            modelBuilder.Entity<Driver>().HasOne(d => d.Gender).WithMany(g => g.Drivers).HasForeignKey(d => d.GenderID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Driver>().HasOne(d => d.BloodType).WithMany(b => b.Drivers).HasForeignKey(d => d.BloodTypeID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Driver>().HasOne(d => d.Religion).WithMany(r => r.Drivers).HasForeignKey(d => d.ReligionID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Driver>().HasOne(d => d.MaritalStatus).WithMany(m => m.Drivers).HasForeignKey(d => d.MaritalStatusID).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Driver>().HasOne(d => d.Nationality).WithMany(n => n.Drivers).HasForeignKey(d => d.NationalityID).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Status>().ToTable("QMS_mstStatus");
            //modelBuilder.Entity<BloodType>().ToTable("QMS_mstBloodType");
            //modelBuilder.Entity<Gender>().ToTable("QMS_mstGender");
            //modelBuilder.Entity<MaritalStatus>().ToTable("QMS_mstMaritalStatus");
            //modelBuilder.Entity<Nationality>().ToTable("QMS_mstNationality");
            //modelBuilder.Entity<Religion>().ToTable("QMS_mstReligion");
            //modelBuilder.Entity<Driver>().ToTable("QMS_mstDriver");

            base.OnModelCreating(modelBuilder);
        }

        public IQueryable<T> SetWithIncludes<T>(params string[] includes) where T : class
        {
            IQueryable<T> queries = Set<T>();
            if (includes != null)
            {
                queries = queries.IncludeProperties(includes);
            }
            return queries;
        }

    }
}
