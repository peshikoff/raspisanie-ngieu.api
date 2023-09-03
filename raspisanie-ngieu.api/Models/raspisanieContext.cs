using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace raspisanie_ngieu.api.Models
{
    public partial class raspisanieContext : DbContext
    {
        public raspisanieContext()
        {
        }

        public raspisanieContext(DbContextOptions<raspisanieContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<ВремяПар> ВремяПарs { get; set; } = null!;
        public virtual DbSet<ДниНедели> ДниНеделиs { get; set; } = null!;
        public virtual DbSet<Изменения> Измененияs { get; set; } = null!;
        public virtual DbSet<Институты> Институтыs { get; set; } = null!;
        public virtual DbSet<Кабинеты> Кабинетыs { get; set; } = null!;
        public virtual DbSet<Кафедры> Кафедрыs { get; set; } = null!;
        public virtual DbSet<Мероприятия> Мероприятияs { get; set; } = null!;
        public virtual DbSet<Предметы> Предметыs { get; set; } = null!;
        public virtual DbSet<Преподаватели> Преподавателиs { get; set; } = null!;
        public virtual DbSet<Расписание> Расписаниеs { get; set; } = null!;
        public virtual DbSet<СписокГрупп> СписокГруппs { get; set; } = null!;
        public virtual DbSet<ТипНедели> ТипНеделиs { get; set; } = null!;
        public virtual DbSet<ТипыПар> ТипыПарs { get; set; } = null!;
        public virtual DbSet<StoredProcedureModel> StoredProcedureModels { get; set; } = null!;
        public virtual DbSet<Groups> Groups { get; set; } = null!;
        public virtual DbSet<Weeks> Weeks { get; set; } = null!;
        public virtual DbSet<Teachers> Teachers { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=raspisanie-ngieuDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.HasIndex(e => new { e.Login, e.Password }, "AK_Login_Password")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.Login).HasMaxLength(30);

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Group)
                    .HasConstraintName("FK_Users_Список_групп1");
            });

            modelBuilder.Entity<ВремяПар>(entity =>
            {
                entity.HasKey(e => e.ВремяId);

                entity.ToTable("Время_пар");

                entity.HasIndex(e => e.Guid, "AK_GUID")
                    .IsUnique();

                entity.Property(e => e.ВремяId)
                    .HasMaxLength(13)
                    .HasColumnName("Время_ID");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.НомерПары).HasColumnName("Номер_пары");
            });

            modelBuilder.Entity<ДниНедели>(entity =>
            {
                entity.HasKey(e => e.НазваниеДня)
                    .HasName("PK_Дни_недели_1");

                entity.ToTable("Дни_недели");

                entity.HasIndex(e => e.Guid, "AK_GUID3")
                    .IsUnique();

                entity.Property(e => e.НазваниеДня)
                    .HasMaxLength(15)
                    .HasColumnName("Название_дня")
                    .IsFixedLength();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.НомерДня).HasColumnName("Номер_дня");
            });

            modelBuilder.Entity<Изменения>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Изменения");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Day)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.LessonGuid).HasColumnName("Lesson_GUID");

                entity.Property(e => e.Time).HasMaxLength(13);

                entity.Property(e => e.Week).HasMaxLength(50);

                entity.Property(e => e.Кабинет).HasMaxLength(11);

                entity.HasOne(d => d.DayNavigation)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.Day)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Изменения_Дни_недели");

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Изменения_Список_групп1");

                entity.HasOne(d => d.LessonGu)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.LessonGuid)
                    .HasConstraintName("FK_Изменения_Предметы");

                entity.HasOne(d => d.TimeNavigation)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.Time)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Изменения_Время_пар");

                entity.HasOne(d => d.WeekNavigation)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.Week)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Изменения_Тип_недели");

                entity.HasOne(d => d.КабинетNavigation)
                    .WithMany(p => p.Измененияs)
                    .HasForeignKey(d => d.Кабинет)
                    .HasConstraintName("FK_Изменения_Кабинеты");
            });

            modelBuilder.Entity<Институты>(entity =>
            {
                entity.HasKey(e => e.Институт);

                entity.ToTable("Институты");

                entity.HasIndex(e => e.Guid, "AK_GUID2")
                    .IsUnique();

                entity.Property(e => e.Институт).HasMaxLength(50);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Кабинеты>(entity =>
            {
                entity.HasKey(e => e.КабинетNo);

                entity.ToTable("Кабинеты");

                entity.HasIndex(e => e.Guid, "AK_GUID7")
                    .IsUnique();

                entity.Property(e => e.КабинетNo)
                    .HasMaxLength(11)
                    .HasColumnName("Кабинет_No");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.КоличествоМест).HasColumnName("Количество_мест");
            });

            modelBuilder.Entity<Кафедры>(entity =>
            {
                entity.HasKey(e => e.Кафедра);

                entity.ToTable("Кафедры");

                entity.HasIndex(e => new { e.Guid, e.Кафедра }, "AK_GUID8")
                    .IsUnique();

                entity.Property(e => e.Кафедра).HasMaxLength(200);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Институт).HasMaxLength(50);

                entity.HasOne(d => d.ИнститутNavigation)
                    .WithMany(p => p.Кафедрыs)
                    .HasForeignKey(d => d.Институт)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Кафедры_Институты");
            });

            modelBuilder.Entity<Мероприятия>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Мероприятия");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Event).HasMaxLength(200);

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.TeacherGuid).HasColumnName("Teacher_GUID");

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Мероприятияs)
                    .HasForeignKey(d => d.Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Мероприятия_Список_групп");

                entity.HasOne(d => d.TeacherGu)
                    .WithMany(p => p.Мероприятияs)
                    .HasForeignKey(d => d.TeacherGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Мероприятия_Преподаватели");
            });

            modelBuilder.Entity<Предметы>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Предметы");

                entity.HasIndex(e => e.Guid, "AK_GUID6")
                    .IsUnique();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.Lesson).HasMaxLength(100);

                entity.Property(e => e.TeacherGuid).HasColumnName("Teacher_GUID");

                entity.Property(e => e.ТипПары)
                    .HasMaxLength(3)
                    .HasColumnName("Тип_пары")
                    .IsFixedLength();

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Предметыs)
                    .HasForeignKey(d => d.Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Предметы_Список_групп");

                entity.HasOne(d => d.TeacherGu)
                    .WithMany(p => p.Предметыs)
                    .HasForeignKey(d => d.TeacherGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Предметы_Преподаватели");

                entity.HasOne(d => d.ТипПарыNavigation)
                    .WithMany(p => p.Предметыs)
                    .HasForeignKey(d => d.ТипПары)
                    .HasConstraintName("FK_Предметы_Типы_пар");
            });

            modelBuilder.Entity<Преподаватели>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Преподаватели");

                entity.HasIndex(e => e.КурируемаяГруппа, "AK_Moderator_Group")
                    .IsUnique()
                    .HasFilter("([Курируемая_группа] IS NOT NULL)");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.Property(e => e.Patronymic).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);

                entity.Property(e => e.Институт).HasMaxLength(50);

                entity.Property(e => e.Кафедра).HasMaxLength(200);

                entity.Property(e => e.КурируемаяГруппа)
                    .HasMaxLength(15)
                    .HasColumnName("Курируемая_группа");

                entity.HasOne(d => d.ИнститутNavigation)
                    .WithMany(p => p.Преподавателиs)
                    .HasForeignKey(d => d.Институт)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Преподаватели_Институты");

                entity.HasOne(d => d.КафедраNavigation)
                    .WithMany(p => p.Преподавателиs)
                    .HasForeignKey(d => d.Кафедра)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Преподаватели_Кафедры");
            });

            modelBuilder.Entity<Расписание>(entity =>
            {
                entity.HasKey(e => e.Guid);

                entity.ToTable("Расписание");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Day)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.LessonGuid).HasColumnName("Lesson_GUID");

                entity.Property(e => e.Time).HasMaxLength(13);

                entity.Property(e => e.Week).HasMaxLength(50);

                entity.Property(e => e.Кабинет).HasMaxLength(11);

                entity.HasOne(d => d.DayNavigation)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.Day)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Расписание_Дни_недели");

                entity.HasOne(d => d.GroupNavigation)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.Group)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Расписание_Список_групп1");

                entity.HasOne(d => d.LessonGu)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.LessonGuid)
                    .HasConstraintName("FK_Расписание_Предметы");

                entity.HasOne(d => d.TimeNavigation)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.Time)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Расписание_Время_пар");

                entity.HasOne(d => d.WeekNavigation)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.Week)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Расписание_Тип_недели");

                entity.HasOne(d => d.КабинетNavigation)
                    .WithMany(p => p.Расписаниеs)
                    .HasForeignKey(d => d.Кабинет)
                    .HasConstraintName("FK_Расписание_Кабинеты");
            });

            modelBuilder.Entity<СписокГрупп>(entity =>
            {
                entity.HasKey(e => e.Group)
                    .HasName("PK_Список_групп_1");

                entity.ToTable("Список_групп");

                entity.HasIndex(e => e.Guid, "AK_GUID5")
                    .IsUnique();

                entity.Property(e => e.Group).HasMaxLength(15);

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Институт).HasMaxLength(50);

                entity.Property(e => e.КоличествоЧеловек).HasColumnName("Количество_человек");

                entity.HasOne(d => d.ИнститутNavigation)
                    .WithMany(p => p.СписокГруппs)
                    .HasForeignKey(d => d.Институт)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Список_групп_Институты");
            });

            modelBuilder.Entity<ТипНедели>(entity =>
            {
                entity.HasKey(e => e.ТипНедели1);

                entity.ToTable("Тип_недели");

                entity.HasIndex(e => e.Guid, "AK_GUID4")
                    .IsUnique();

                entity.Property(e => e.ТипНедели1)
                    .HasMaxLength(50)
                    .HasColumnName("Тип_недели");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<ТипыПар>(entity =>
            {
                entity.HasKey(e => e.ТипПарыId);

                entity.ToTable("Типы_пар");

                entity.HasIndex(e => e.Guid, "AK_GUID1")
                    .IsUnique();

                entity.Property(e => e.ТипПарыId)
                    .HasMaxLength(3)
                    .HasColumnName("Тип_пары_ID")
                    .IsFixedLength();

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");
            });
            modelBuilder.Entity<StoredProcedureModel>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<Groups>(entity =>
            {
                entity.HasNoKey();

            });
            modelBuilder.Entity<Weeks>(entity =>
            {
                entity.HasNoKey();
            });
            modelBuilder.Entity<Teachers>(enttity =>
            {
                enttity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
