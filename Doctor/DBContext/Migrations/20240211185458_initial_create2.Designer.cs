﻿// <auto-generated />
using System;
using DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DBContext.Migrations
{
    [DbContext(typeof(DoctorDBContext))]
    [Migration("20240211185458_initial_create2")]
    partial class initial_create2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "dblink");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DBContext.Entity.PatientDetails", b =>
                {
                    b.Property<Guid>("UHID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("UHID");

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("Address");

                    b.Property<int>("Age")
                        .HasColumnType("integer")
                        .HasColumnName("Age");

                    b.Property<string>("Gender")
                        .HasColumnType("text")
                        .HasColumnName("Gender");

                    b.Property<string>("MobileNo")
                        .HasColumnType("text")
                        .HasColumnName("MobileNo");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("UHID");

                    b.ToTable("Doctor");
                });
#pragma warning restore 612, 618
        }
    }
}
