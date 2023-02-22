﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Niftyers;

#nullable disable

namespace LguBrgy.Migrations
{
    [DbContext(typeof(NiftyersDB))]
    [Migration("20230222183840_So Good")]
    partial class SoGood
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Niftyers.Resident", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(160)
                        .HasColumnType("varchar(160)")
                        .HasDefaultValue("");

                    b.Property<int>("Age")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("BirthDate")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasDefaultValue("");

                    b.Property<string>("CivilStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)")
                        .HasDefaultValue("");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasDefaultValue("");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasDefaultValue("");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("MidleName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("No")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)")
                        .HasDefaultValue("");

                    b.HasKey("ID")
                        .HasName("IX_ResidentID");

                    b.HasIndex("No")
                        .IsUnique();

                    b.ToTable("Residents", (string)null);
                });

            modelBuilder.Entity("Niftyers.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)")
                        .HasDefaultValue("");

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.Property<string>("Username")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("");

                    b.HasKey("Id")
                        .HasName("IX_UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
