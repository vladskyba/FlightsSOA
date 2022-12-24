﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceRegistry.Context;

namespace ServiceRegistry.Migrations
{
    [DbContext(typeof(ServiceRegistryContext))]
    [Migration("20221224191940_Add-Migration Start")]
    partial class AddMigrationStart
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServicesRegistry.Models.ServiceSettings", b =>
                {
                    b.Property<long>("Port")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Entered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Service")
                        .HasColumnType("int");

                    b.HasKey("Port");

                    b.ToTable("ServiceSettings");
                });
#pragma warning restore 612, 618
        }
    }
}