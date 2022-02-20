﻿// <auto-generated />
using System;
using System.Collections.Generic;
using ITF.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ITF.Infrastructure.Migrations
{
    [DbContext(typeof(ItfDbContext))]
    partial class ItfDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Itf")
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeveloperCategories", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperContacts", b =>
                {
                    b.Property<Guid>("DeveloperProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("LinkedInLink")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("PortfolioLink")
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .HasColumnType("text");

                    b.HasKey("DeveloperProfileId");

                    b.ToTable("DeveloperContacts", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Achievements")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<Guid>("DeveloperCategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("EnglishProficiency")
                        .HasColumnType("integer");

                    b.Property<string>("Expectations")
                        .HasColumnType("text");

                    b.Property<string>("ExperienceDescription")
                        .HasColumnType("text");

                    b.Property<int?>("ExperienceInYears")
                        .HasColumnType("integer");

                    b.Property<int?>("HourlyRate")
                        .HasColumnType("integer");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SalaryExpectation")
                        .HasColumnType("integer");

                    b.Property<List<string>>("Skills")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<int[]>("WorkOptions")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperCategoryId");

                    b.ToTable("DeveloperProfiles", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ExperienceInYears")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecruiterProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int[]>("WorkOptions")
                        .IsRequired()
                        .HasColumnType("integer[]");

                    b.HasKey("Id");

                    b.HasIndex("RecruiterProfileId");

                    b.ToTable("Positions", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.RecruiterContacts", b =>
                {
                    b.Property<Guid>("RecruiterProfileId")
                        .HasColumnType("uuid");

                    b.Property<string>("LinkedInLink")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Telegram")
                        .HasColumnType("text");

                    b.HasKey("RecruiterProfileId");

                    b.ToTable("RecruiterContacts", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.RecruiterProfile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CompanyDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompanyWebsite")
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("RecruiterProfiles", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("DeveloperProfileId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RecruiterProfileId")
                        .HasColumnType("uuid");

                    b.Property<int>("SelectedProfile")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DeveloperProfileId");

                    b.HasIndex("RecruiterProfileId");

                    b.ToTable("Users", "Itf");
                });

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperContacts", b =>
                {
                    b.HasOne("ITF.Domain.Entities.DeveloperProfile", "DeveloperProfile")
                        .WithOne("DeveloperContacts")
                        .HasForeignKey("ITF.Domain.Entities.DeveloperContacts", "DeveloperProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeveloperProfile");
                });

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperProfile", b =>
                {
                    b.HasOne("ITF.Domain.Entities.DeveloperCategory", "DeveloperCategory")
                        .WithMany()
                        .HasForeignKey("DeveloperCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeveloperCategory");
                });

            modelBuilder.Entity("ITF.Domain.Entities.Position", b =>
                {
                    b.HasOne("ITF.Domain.Entities.RecruiterProfile", "RecruiterProfile")
                        .WithMany("Positions")
                        .HasForeignKey("RecruiterProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecruiterProfile");
                });

            modelBuilder.Entity("ITF.Domain.Entities.RecruiterContacts", b =>
                {
                    b.HasOne("ITF.Domain.Entities.RecruiterProfile", "RecruiterProfile")
                        .WithOne("RecruiterContacts")
                        .HasForeignKey("ITF.Domain.Entities.RecruiterContacts", "RecruiterProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RecruiterProfile");
                });

            modelBuilder.Entity("ITF.Domain.Entities.User", b =>
                {
                    b.HasOne("ITF.Domain.Entities.DeveloperProfile", "DeveloperProfile")
                        .WithMany()
                        .HasForeignKey("DeveloperProfileId");

                    b.HasOne("ITF.Domain.Entities.RecruiterProfile", "RecruiterProfile")
                        .WithMany()
                        .HasForeignKey("RecruiterProfileId");

                    b.Navigation("DeveloperProfile");

                    b.Navigation("RecruiterProfile");
                });

            modelBuilder.Entity("ITF.Domain.Entities.DeveloperProfile", b =>
                {
                    b.Navigation("DeveloperContacts");
                });

            modelBuilder.Entity("ITF.Domain.Entities.RecruiterProfile", b =>
                {
                    b.Navigation("Positions");

                    b.Navigation("RecruiterContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
