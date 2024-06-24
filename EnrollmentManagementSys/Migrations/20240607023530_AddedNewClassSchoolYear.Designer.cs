﻿// <auto-generated />
using System;
using EnrollmentManagementSys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EnrollmentManagementSys.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20240607023530_AddedNewClassSchoolYear")]
    partial class AddedNewClassSchoolYear
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnrollmentManagementSys.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.ClassType", b =>
                {
                    b.Property<Guid>("ClassTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClassTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClassTypeID");

                    b.ToTable("ClassTypes");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Course", b =>
                {
                    b.Property<Guid>("RecordNumberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecordNumberId");

                    b.HasIndex("StudentCourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Fee", b =>
                {
                    b.Property<Guid>("FeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FeeTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchoolYearID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TermID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("YearLevelID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeeID");

                    b.HasIndex("FeeTypeID");

                    b.HasIndex("SchoolYearID");

                    b.HasIndex("StudentCourseID");

                    b.HasIndex("TermID");

                    b.HasIndex("YearLevelID");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.FeeType", b =>
                {
                    b.Property<Guid>("FeeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FeeTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeeTypeID");

                    b.ToTable("FeeTypes");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Gender", b =>
                {
                    b.Property<Guid>("GenderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenderID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.ModeOfPayment", b =>
                {
                    b.Property<Guid>("ModeOfPaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ModeOfPaymentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModeOfPaymentID");

                    b.ToTable("ModeOfPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.ModelViews.ApplicationUserView", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationUserView");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.OfferedSubject", b =>
                {
                    b.Property<Guid>("OfferedSubjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("ClassTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOffered")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SchoolYearID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SemesterID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SubjectLevel")
                        .HasColumnType("int");

                    b.Property<float>("SubjectRate")
                        .HasColumnType("real");

                    b.HasKey("OfferedSubjectID");

                    b.HasIndex("ClassTypeID");

                    b.HasIndex("SchoolYearID");

                    b.HasIndex("SemesterID");

                    b.HasIndex("StudentCourseID");

                    b.HasIndex("SubjectId");

                    b.ToTable("OfferedSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.PaymentType", b =>
                {
                    b.Property<Guid>("PaymentTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentTypeID");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Room", b =>
                {
                    b.Property<Guid>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.SchoolYear", b =>
                {
                    b.Property<Guid>("SchoolYearID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SchoolYearName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolYearID");

                    b.ToTable("SchoolYears");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Section", b =>
                {
                    b.Property<Guid>("SectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SectionID");

                    b.HasIndex("StudentCourseID");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Semester", b =>
                {
                    b.Property<Guid>("SemesterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterID");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Student", b =>
                {
                    b.Property<Guid>("RecordID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GenderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StudentID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StudentStatusID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("YearLevelID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RecordID");

                    b.HasIndex("GenderID");

                    b.HasIndex("StudentCourseID");

                    b.HasIndex("StudentStatusID");

                    b.HasIndex("YearLevelID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentCourse", b =>
                {
                    b.Property<Guid>("StudentCourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentCourseID");

                    b.ToTable("StudentsCourses");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentPayment", b =>
                {
                    b.Property<Guid>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModeOfPaymentID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PaymentTypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RecordID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SchoolYearID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TermID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PaymentID");

                    b.HasIndex("ModeOfPaymentID");

                    b.HasIndex("PaymentTypeID");

                    b.HasIndex("RecordID");

                    b.HasIndex("SchoolYearID");

                    b.HasIndex("TermID");

                    b.ToTable("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentStatus", b =>
                {
                    b.Property<Guid>("StudentStatusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentStatusID");

                    b.ToTable("StudentStatuses");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentSubject", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentCourseID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("SubjectHours")
                        .HasColumnType("real");

                    b.Property<Guid>("TypeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("SubjectId");

                    b.HasIndex("StudentCourseID");

                    b.HasIndex("TypeID");

                    b.ToTable("StudentSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentSubjectType", b =>
                {
                    b.Property<Guid>("TypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeID");

                    b.ToTable("StudentSubjectTypes");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Term", b =>
                {
                    b.Property<Guid>("TermID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TermName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TermID");

                    b.ToTable("Terms");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.YearLevel", b =>
                {
                    b.Property<Guid>("YearLevelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("YearLevelNum")
                        .HasColumnType("int");

                    b.HasKey("YearLevelID");

                    b.ToTable("YearLevels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Course", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany("Courses")
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Fee", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.FeeType", "FeeType")
                        .WithMany("Fees")
                        .HasForeignKey("FeeTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.SchoolYear", "SchoolYear")
                        .WithMany("Fees")
                        .HasForeignKey("SchoolYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany("Fees")
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.Term", "Term")
                        .WithMany("Fees")
                        .HasForeignKey("TermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.YearLevel", "YearLevel")
                        .WithMany("Fees")
                        .HasForeignKey("YearLevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FeeType");

                    b.Navigation("SchoolYear");

                    b.Navigation("StudentCourse");

                    b.Navigation("Term");

                    b.Navigation("YearLevel");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.OfferedSubject", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.ClassType", "ClassType")
                        .WithMany("OfferedSubjects")
                        .HasForeignKey("ClassTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.SchoolYear", "SchoolYear")
                        .WithMany("OfferedSubjects")
                        .HasForeignKey("SchoolYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.Semester", "Semester")
                        .WithMany("OfferedSubjects")
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany("OfferedSubjects")
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentSubject", "StudentSubject")
                        .WithMany("OfferedSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ClassType");

                    b.Navigation("SchoolYear");

                    b.Navigation("Semester");

                    b.Navigation("StudentCourse");

                    b.Navigation("StudentSubject");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Section", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany("Sections")
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentCourse");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Student", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany("Students")
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentStatus", "StudentStatus")
                        .WithMany()
                        .HasForeignKey("StudentStatusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.YearLevel", "YearLevel")
                        .WithMany("Students")
                        .HasForeignKey("YearLevelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("StudentCourse");

                    b.Navigation("StudentStatus");

                    b.Navigation("YearLevel");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentPayment", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.ModeOfPayment", "ModeOfPayment")
                        .WithMany("StudentPayments")
                        .HasForeignKey("ModeOfPaymentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.PaymentType", "PaymentType")
                        .WithMany("StudentPayments")
                        .HasForeignKey("PaymentTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.Student", "Student")
                        .WithMany("StudentPayments")
                        .HasForeignKey("RecordID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.SchoolYear", "SchoolYear")
                        .WithMany("StudentPayments")
                        .HasForeignKey("SchoolYearID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.Term", "Term")
                        .WithMany("StudentPayments")
                        .HasForeignKey("TermID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ModeOfPayment");

                    b.Navigation("PaymentType");

                    b.Navigation("SchoolYear");

                    b.Navigation("Student");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentSubject", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.StudentCourse", "StudentCourse")
                        .WithMany()
                        .HasForeignKey("StudentCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.StudentSubjectType", "StudentSubjectType")
                        .WithMany("StudentSubjects")
                        .HasForeignKey("TypeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("StudentCourse");

                    b.Navigation("StudentSubjectType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EnrollmentManagementSys.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EnrollmentManagementSys.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.ClassType", b =>
                {
                    b.Navigation("OfferedSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.FeeType", b =>
                {
                    b.Navigation("Fees");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.ModeOfPayment", b =>
                {
                    b.Navigation("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.PaymentType", b =>
                {
                    b.Navigation("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.SchoolYear", b =>
                {
                    b.Navigation("Fees");

                    b.Navigation("OfferedSubjects");

                    b.Navigation("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Semester", b =>
                {
                    b.Navigation("OfferedSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Student", b =>
                {
                    b.Navigation("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentCourse", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Fees");

                    b.Navigation("OfferedSubjects");

                    b.Navigation("Sections");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentSubject", b =>
                {
                    b.Navigation("OfferedSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.StudentSubjectType", b =>
                {
                    b.Navigation("StudentSubjects");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.Term", b =>
                {
                    b.Navigation("Fees");

                    b.Navigation("StudentPayments");
                });

            modelBuilder.Entity("EnrollmentManagementSys.Models.YearLevel", b =>
                {
                    b.Navigation("Fees");

                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
