using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vacation_Manager.Shared.Models.Models;

namespace Vacation_Manager.Shared.DB.DataBase;

internal class VacationManagerContext : DbContext
{
    public DbSet<Assistent> Assistents { get; set; }
    public DbSet<VacationPeriod> VacationPeriods { get; set; }
    public DbSet<VacationCalendar> VacationCalendars { get; set; }

    private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=VacationManagerDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

    public VacationManagerContext(DbContextOptions options) : base(options)
    {
    }

    public VacationManagerContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString).UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Assistent>()
            .HasMany(a => a.VacationCalendars)
            .WithOne(vc => vc.Assistent)
            .HasForeignKey(vc => vc.AssistentId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VacationCalendar>()
            .HasMany(vc => vc.VacationList)
            .WithOne(vp => vp.VacationCalendar)
            .HasForeignKey(vp => vp.VacationCalendarId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<VacationPeriod>()
            .HasOne(vp => vp.VacationCalendar)
            .WithMany(vc => vc.VacationList)
            .HasForeignKey(vp => vp.VacationCalendarId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
