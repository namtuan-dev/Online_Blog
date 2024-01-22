using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UnicatLearning.Models;

public partial class UnicatOnlineLearningContext : DbContext
{
    public UnicatOnlineLearningContext()
    {
    }

    public UnicatOnlineLearningContext(DbContextOptions<UnicatOnlineLearningContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<BlogComment> BlogComments { get; set; }

    public virtual DbSet<BlogFeedback> BlogFeedbacks { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseEnroll> CourseEnrolls { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonDetail> LessonDetails { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ReviewComment> ReviewComments { get; set; }

    public virtual DbSet<ReviewFeedback> ReviewFeedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
		var builder = new ConfigurationBuilder()
							  .SetBasePath(Directory.GetCurrentDirectory())
							  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
		IConfigurationRoot configuration = builder.Build();
		optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyDB"));
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK_Answer_AnswerID");

            entity.ToTable("Answer");

            entity.Property(e => e.AnswerId).HasColumnName("AnswerID");
            entity.Property(e => e.Answer1).HasColumnName("Answer");
            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Answer_QuestionID");
        });

        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK_Blog_BlogID");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Blog_UserID");
        });

        modelBuilder.Entity<BlogComment>(entity =>
        {
            entity.HasKey(e => e.BlogCommentId).HasName("PK_BlogComments_BlogCommentID");

            entity.Property(e => e.BlogCommentId).HasColumnName("BlogCommentID");
            entity.Property(e => e.BlogCommentDate).HasColumnType("datetime");
            entity.Property(e => e.BlogFeedbackId).HasColumnName("BlogFeedbackID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.BlogFeedback).WithMany(p => p.BlogComments)
                .HasForeignKey(d => d.BlogFeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogComments_BlogFeedbackID");

            entity.HasOne(d => d.User).WithMany(p => p.BlogComments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogComments_UserID");
        });

        modelBuilder.Entity<BlogFeedback>(entity =>
        {
            entity.HasKey(e => e.BlogFeedbackId).HasName("PK_BlogFeedback_BlogFeedbackID");

            entity.ToTable("BlogFeedback");

            entity.Property(e => e.BlogFeedbackId).HasColumnName("BlogFeedbackID");
            entity.Property(e => e.BlogFeedbackDate).HasColumnType("datetime");
            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Blog).WithMany(p => p.BlogFeedbacks)
                .HasForeignKey(d => d.BlogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogFeedback_BlogID");

            entity.HasOne(d => d.User).WithMany(p => p.BlogFeedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BlogFeedback_UserID");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Category_CategoryID");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK_Course_CourseID");

            entity.ToTable("Course");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Category).WithMany(p => p.Courses)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_CategoryID");

            entity.HasOne(d => d.User).WithMany(p => p.Courses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Course_UserID");
        });

        modelBuilder.Entity<CourseEnroll>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CourseEnroll");

            entity.Property(e => e.CourseEnrollId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CourseEnrollID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.EnrollDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany()
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseEnroll_CourseID");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CourseEnroll_UserID");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK_Lesson_LessonID");

            entity.ToTable("Lesson");

            entity.Property(e => e.LessonId).HasColumnName("LessonID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lesson_CourseID");
        });

        modelBuilder.Entity<LessonDetail>(entity =>
        {
            entity.HasKey(e => e.LessonDetailsId).HasName("PK_LessonDetails_LessonDetailsID");

            entity.Property(e => e.LessonDetailsId).HasColumnName("LessonDetailsID");
            entity.Property(e => e.LessonId).HasColumnName("LessonID");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonDetails)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LessonDetails_LessonID");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK_Question_QuestionID");

            entity.ToTable("Question");

            entity.Property(e => e.QuestionId).HasColumnName("QuestionID");
            entity.Property(e => e.QuizId).HasColumnName("QuizID");

            entity.HasOne(d => d.Quiz).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Question_QuizID");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK_Quiz_QuizID");

            entity.ToTable("Quiz");

            entity.Property(e => e.QuizId).HasColumnName("QuizID");
            entity.Property(e => e.LessonId).HasColumnName("LessonID");

            entity.HasOne(d => d.Lesson).WithMany(p => p.Quizzes)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Quiz_LessonID");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK_Review_ReviewID");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Course).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_CourseID");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Review_UserID");
        });

        modelBuilder.Entity<ReviewComment>(entity =>
        {
            entity.HasKey(e => e.ReviewCommentId).HasName("PK_ReviewComments_ReviewCommentID");

            entity.Property(e => e.ReviewCommentId).HasColumnName("ReviewCommentID");
            entity.Property(e => e.ReviewCommentDate).HasColumnType("datetime");
            entity.Property(e => e.ReviewFeedbackId).HasColumnName("ReviewFeedbackID");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.ReviewFeedback).WithMany(p => p.ReviewComments)
                .HasForeignKey(d => d.ReviewFeedbackId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewComments_ReviewFeedbackID");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewComments)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewComments_ReviewID");
        });

        modelBuilder.Entity<ReviewFeedback>(entity =>
        {
            entity.HasKey(e => e.ReviewFeedbackId).HasName("PK_ReviewFeedback_ReviewFeedbackID");

            entity.ToTable("ReviewFeedback");

            entity.Property(e => e.ReviewFeedbackId).HasColumnName("ReviewFeedbackID");
            entity.Property(e => e.ReviewFeedbackDate).HasColumnType("datetime");
            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

            entity.HasOne(d => d.Review).WithMany(p => p.ReviewFeedbacks)
                .HasForeignKey(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReviewFeedback_ReviewID");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User_UserID");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Dob)
                .HasColumnType("date")
                .HasColumnName("DOB");
            entity.Property(e => e.FacebookId)
                .HasMaxLength(1)
                .HasColumnName("FacebookID");
            entity.Property(e => e.GmailId)
                .HasMaxLength(1)
                .HasColumnName("GmailID");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_RoleID");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK_UserRole_RoleID");

            entity.ToTable("UserRole");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
