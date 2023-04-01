using System.Reflection;
using EstateWebManager.Domain.Models;
using EstateWebManager.Domain.Models.RealEstateClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateWebManager.Domain.Models.AppointmentClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EstateWebManager.DataAccess
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<Flat> Flats => Set<Flat>();
        public DbSet<Office> Offices => Set<Office>();
        public DbSet<House> Houses => Set<House>();
        public DbSet<Land> Lands => Set<Land>();
        public DbSet<EstateAgent> EstateAgents => Set<EstateAgent>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<Image> Images => Set<Image>();

        private static StreamWriter _logger = new($@"{Directory.GetCurrentDirectory()}\Logs\log.txt");
        //{Directory.GetParent(Directory.GetCurrentDirectory())}
        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _logger.AutoFlush = true;
            optionsBuilder
                .UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=EstateManager;Trusted_Connection=True")
                .LogTo(_logger.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)//Console.Error.WriteLine  //LogLevel.Error
                .EnableSensitiveDataLogging();//true
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            //one-to-many Area-RealEstate cu FK pe AreaId
            modelBuilder.Entity<RealEstate>()
                .HasOne(realEstate => realEstate.Area)
                .WithMany(area => area.RealEstates)
                .HasForeignKey(realEstate => realEstate.AreaId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<RealEstate>()
                .HasOne(realEstate => realEstate.User)
                .WithMany(user => user.RealEstates)
                .HasForeignKey(realEstate => realEstate.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<RealEstate>()
                .HasMany(realEstate => realEstate.Images)
                .WithOne(image => image.RealEstate)
                .HasForeignKey(image => image.RealEstateId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Flat>()
                .ToTable("Flats")
                .HasBaseType<RealEstate>();

            modelBuilder.Entity<Office>()
                .ToTable("Offices")
                .HasBaseType<RealEstate>();

            modelBuilder.Entity<House>()
                .ToTable("Houses")
                .HasBaseType<RealEstate>();

            modelBuilder.Entity<Land>()
                .ToTable("Lands")
                .HasBaseType<RealEstate>();

            modelBuilder.Entity<Appointment>()
                .HasKey(appointment => new { appointment.AgentId, appointment.ClientId, appointment.RealEstateId });

            modelBuilder.Entity<Appointment>()
                .HasIndex(appointment => new { appointment.AgentId, appointment.Date }).IsUnique();

            modelBuilder.Entity<Appointment>()
                .HasIndex(appointment => new { appointment.ClientId, appointment.Date }).IsUnique();

            modelBuilder.Entity<EstateAgent>()
                .ToTable("EstateAgents")
                .HasIndex(agent => agent.Name).IsUnique();

            modelBuilder.Entity<Client>()
                .HasIndex(client => client.Name).IsUnique();
        }
    }
}
