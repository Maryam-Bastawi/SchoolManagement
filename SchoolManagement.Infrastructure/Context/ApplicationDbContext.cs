using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; } 
        public DbSet<Grades> Grades { get; set; } 
        public DbSet<Class> Classes { get; set; } 
        public DbSet<Stages> Stages { get; set; } 
        public DbSet<Vehicle> Vehicles { get; set; } 
        public DbSet<CostCenter> CostCenters { get; set; } 
        public DbSet<School> Schools { get; set; } 
        public DbSet<Section> Sections { get; set; } 
        public DbSet<TransCost> TransCosts { get; set; } 
        public DbSet<TransferType> TransferTypes { get; set; } 
        public DbSet<TransLine> TransLines { get; set; } 
        public DbSet<StudyYear> StudyYears { get; set; } 
        public DbSet<StudentStatus> StudentStatuses { get; set; } 
        public DbSet<Nation> Nations { get; set; } 
        public DbSet<Drive> Drives { get; set; } 
        public DbSet<Discount> Discounts { get; set; } 
        public DbSet<Bank> Banks { get; set; } 
        public DbSet<Area> Areas { get; set; } 
        public DbSet<Branch> Branches { get; set; } 
        public DbSet<Vat> Vats { get; set; } 
        public DbSet<Supervisor> supervisors { get; set; } 
        public DbSet<ApplicationUser> Users { get; set; } 
        public DbSet<IdentityRole> Roles { get; set; } 
    }
}
