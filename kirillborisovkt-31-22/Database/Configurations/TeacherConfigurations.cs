using kirillborisovkt_31_22.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.AccessControl;

namespace kirillborisovkt_31_22.Database.Configurations
{
    public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
    {
        public void Configure(EntityTypeBuilder<AcademicDegree> builder)
        {
            // Таблица и схема
            builder.ToTable("AcademicDegrees", "university")
                .HasComment("Ученые степени преподавателей");

            // Первичный ключ
            builder.HasKey(a => a.AcademicDegreeId)
                .HasName("pk_academic_degree_id");

            // Настройка полей
            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("degree_name")
                .HasComment("Название ученой степени");

            // Связь с Teacher
            builder.HasMany(a => a.Teachers)
                .WithOne(t => t.AcademicDegree)
                .HasForeignKey(t => t.AcademicDegreeId)
                .HasConstraintName("fk_teacher_degree");
        }
    }

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments", "university")
                .HasComment("Кафедры университета");

            builder.HasKey(d => d.DepartmentId)
                .HasName("pk_department_id");

            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(300)
                .HasColumnName("department_name");

            // Связь один-к-одному с Teacher (заведующий)
            builder.HasOne(d => d.HeadTeacher)
                .WithOne()
                .HasForeignKey<Department>(d => d.HeadTeacherId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_department_head_teacher");

            // Связь один-ко-многим с Teacher
            builder.HasMany(d => d.Teachers)
                .WithOne(t => t.Department)
                .HasForeignKey(t => t.DepartmentId)
                .HasConstraintName("fk_teacher_department");
        }
    }

    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Positions", "university")
                .HasComment("Должности преподавателей");

            builder.HasKey(p => p.PositionId)
                .HasName("pk_position_id");

            builder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("position_title");

            // Связь с Teacher
            builder.HasMany(p => p.Teachers)
                .WithOne(t => t.Position)
                .HasForeignKey(t => t.PositionId)
                .HasConstraintName("fk_teacher_position");
        }
    }

    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subjects", "university")
                .HasComment("Дисциплины университета");

            builder.HasKey(s => s.SubjectId)
                .HasName("pk_subject_id");

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("subject_name");
        }
    }

    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers", "university")
                .HasComment("Преподаватели университета");

            builder.HasKey(t => t.TeacherId)
                .HasName("pk_teacher_id");

            // Имя и фамилия
            builder.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("first_name");

            builder.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");

            // Вычисляемое свойство (не сохраняется в БД)
            builder.Ignore(t => t.FullName);

            // Индекс по фамилии и имени
            builder.HasIndex(t => new { t.LastName, t.FirstName })
                .HasDatabaseName("ix_teacher_fullname");
        }
    }

    public class WorkloadConfiguration : IEntityTypeConfiguration<Workload>
    {
        public void Configure(EntityTypeBuilder<Workload> builder)
        {
            builder.ToTable("Workloads", "university")
                .HasComment("Учебная нагрузка");

            // Составной первичный ключ (TeacherId + SubjectId)
            builder.HasKey(w => new { w.TeacherId, w.SubjectId })
                .HasName("pk_workload_composite_id");

            // Альтернатива: простой первичный ключ
            // builder.HasKey(w => w.WorkloadId);

            builder.Property(w => w.Hours)
                .HasColumnName("hours")
                .HasComment("Количество часов нагрузки");

            // Связь с Teacher
            builder.HasOne(w => w.Teacher)
                .WithMany(t => t.Workloads)
                .HasForeignKey(w => w.TeacherId)
                .HasConstraintName("fk_workload_teacher");

            // Связь с Subject
            builder.HasOne(w => w.Subject)
                .WithMany(s => s.Workloads)
                .HasForeignKey(w => w.SubjectId)
                .HasConstraintName("fk_workload_subject");
        }
    }


}
