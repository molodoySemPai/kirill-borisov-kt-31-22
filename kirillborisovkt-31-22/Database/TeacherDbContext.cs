using kirillborisovkt_31_22.Database.Configurations;
using kirillborisovkt_31_22.Models;
using Microsoft.EntityFrameworkCore;

namespace kirillborisovkt_31_22.Database
{
    public class TeacherDbContext : DbContext
    {
        //Добавляем таблицы
        DbSet<AcademicDegree> AcademicDegrees { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Position> Positions { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<Teacher> Teachers { get; set; }
        DbSet<Workload> Workloads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Добавляем конфигурации к таблицам
            modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }

        public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options) { }

    }

}
