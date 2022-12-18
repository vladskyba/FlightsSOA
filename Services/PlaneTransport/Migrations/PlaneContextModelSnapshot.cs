﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlaneTransport.Context;

namespace PlaneTransport.Migrations
{
    [DbContext(typeof(PlaneContext))]
    partial class PlaneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PlaneTransport.Models.Plane", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("plane_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PlaneType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("plane");
                });

            modelBuilder.Entity("PlaneTransport.Models.PlaneSeat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("planeseat_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<short>("Line")
                        .HasColumnType("smallint");

                    b.Property<long>("PlaneId")
                        .HasColumnType("bigint");

                    b.Property<short>("Seat")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("PlaneId");

                    b.ToTable("plane_seat");
                });

            modelBuilder.Entity("PlaneTransport.Models.PlaneSeat", b =>
                {
                    b.HasOne("PlaneTransport.Models.Plane", "Plane")
                        .WithMany("Seats")
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plane");
                });

            modelBuilder.Entity("PlaneTransport.Models.Plane", b =>
                {
                    b.Navigation("Seats");
                });
#pragma warning restore 612, 618
        }
    }
}
