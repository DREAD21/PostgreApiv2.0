using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PostgreApi.DAL.Entities;

public partial class PesfczomContext : DbContext
{
    public PesfczomContext()
    {
    }

    public PesfczomContext(DbContextOptions<PesfczomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Thesise> Thesises { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=hattie.db.elephantsql.com;port=5432;Username=pesfczom;Password=cW3CyCToaz-EQG1GK0l6PezvlzH9aNaR;Database=pesfczom");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("btree_gin")
            .HasPostgresExtension("btree_gist")
            .HasPostgresExtension("citext")
            .HasPostgresExtension("cube")
            .HasPostgresExtension("dblink")
            .HasPostgresExtension("dict_int")
            .HasPostgresExtension("dict_xsyn")
            .HasPostgresExtension("earthdistance")
            .HasPostgresExtension("fuzzystrmatch")
            .HasPostgresExtension("hstore")
            .HasPostgresExtension("intarray")
            .HasPostgresExtension("ltree")
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto")
            .HasPostgresExtension("pgrowlocks")
            .HasPostgresExtension("pgstattuple")
            .HasPostgresExtension("tablefunc")
            .HasPostgresExtension("unaccent")
            .HasPostgresExtension("uuid-ossp")
            .HasPostgresExtension("xml2");

        modelBuilder.Entity<Thesise>(entity =>
        {
            entity.HasKey(e => e.ThesisId).HasName("thesises_pkey");

            entity.ToTable("thesises");

            entity.HasIndex(e => e.CathedraName, "ix_thesises_cathedra_name");

            entity.HasIndex(e => e.StudentSurname, "ix_thesises_student_surname");

            entity.HasIndex(e => e.Title, "ix_thesises_title");

            entity.HasIndex(e => e.TutorSurname, "ix_thesises_tutor_surname");

            entity.HasIndex(e => e.Title, "title_gin_idx")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => e.Title, "title_gist_idx")
                .HasMethod("gist")
                .HasOperators(new[] { "gist_trgm_ops" });

            entity.HasIndex(e => e.Title, "title_idx");

            entity.Property(e => e.ThesisId).HasColumnName("thesis_id");
            entity.Property(e => e.AcademicDegree)
                .HasColumnType("character varying")
                .HasColumnName("academic_degree");
            entity.Property(e => e.AcademicTitle)
                .HasColumnType("character varying")
                .HasColumnName("academic_title");
            entity.Property(e => e.CathedraName)
                .HasColumnType("character varying")
                .HasColumnName("cathedra_name");
            entity.Property(e => e.CathedraNumber)
                .HasColumnType("character varying")
                .HasColumnName("cathedra_number");
            entity.Property(e => e.FacultyName)
                .HasColumnType("character varying")
                .HasColumnName("faculty_name");
            entity.Property(e => e.FacultyNumber)
                .HasColumnType("character varying")
                .HasColumnName("faculty_number");
            entity.Property(e => e.StudentGroup)
                .HasColumnType("character varying")
                .HasColumnName("student_group");
            entity.Property(e => e.StudentName)
                .HasColumnType("character varying")
                .HasColumnName("student_name");
            entity.Property(e => e.StudentPatronymic)
                .HasColumnType("character varying")
                .HasColumnName("student_patronymic");
            entity.Property(e => e.StudentSurname)
                .HasColumnType("character varying")
                .HasColumnName("student_surname");
            entity.Property(e => e.TCathedraName)
                .HasColumnType("character varying")
                .HasColumnName("t_cathedra_name");
            entity.Property(e => e.TCathedraNumber)
                .HasColumnType("character varying")
                .HasColumnName("t_cathedra_number");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.TutorName)
                .HasColumnType("character varying")
                .HasColumnName("tutor_name");
            entity.Property(e => e.TutorPatronymic)
                .HasColumnType("character varying")
                .HasColumnName("tutor_patronymic");
            entity.Property(e => e.TutorSurname)
                .HasColumnType("character varying")
                .HasColumnName("tutor_surname");
            entity.Property(e => e.UploadDate).HasColumnName("upload_date");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
