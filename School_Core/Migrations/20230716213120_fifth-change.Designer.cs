﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School_Core;

#nullable disable

namespace School_Core.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20230716213120_fifth-change")]
    partial class fifthchange
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Teacher_id")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("Teacher_id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Entities.ClassesStudent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId", "ClassId")
                        .IsUnique();

                    b.ToTable("ClassesStudents");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Mark")
                        .HasColumnType("int");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_id")
                        .IsUnique()
                        .HasFilter("[User_id] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int?>("User_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("User_id")
                        .IsUnique()
                        .HasFilter("[User_id] IS NOT NULL");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("School_Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UserTitle_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserTitle_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("School_Core.Models.UserTitle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTitle");
                });

            modelBuilder.Entity("Entities.Class", b =>
                {
                    b.HasOne("Entities.Teacher", "Teacher")
                        .WithMany("Classes")
                        .HasForeignKey("Teacher_id");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Entities.ClassesStudent", b =>
                {
                    b.HasOne("Entities.Class", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.HasOne("School_Core.Models.User", "User")
                        .WithOne("Student")
                        .HasForeignKey("Entities.Student", "User_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Teacher", b =>
                {
                    b.HasOne("School_Core.Models.User", "User")
                        .WithOne("Teacher")
                        .HasForeignKey("Entities.Teacher", "User_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("School_Core.Models.User", b =>
                {
                    b.HasOne("School_Core.Models.UserTitle", "UserTitle")
                        .WithMany("Users")
                        .HasForeignKey("UserTitle_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTitle");
                });

            modelBuilder.Entity("Entities.Teacher", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("School_Core.Models.User", b =>
                {
                    b.Navigation("Student");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("School_Core.Models.UserTitle", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
