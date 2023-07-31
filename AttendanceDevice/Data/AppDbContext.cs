using AttendanceDevice.Models;
using Microsoft.EntityFrameworkCore;

namespace AttendanceDevice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasKey(a => a.AttendanceId);
            modelBuilder.Entity<Person>().HasKey(a => a.PersonId);
            modelBuilder.Entity<Attendance>().HasOne(a => a.Person).WithMany(a =>a.Attendances).HasForeignKey(a => a.PersonId);
            base.OnModelCreating(modelBuilder);
        }

        //certain models name as a table
        public DbSet<Person> Person { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
    }
}
