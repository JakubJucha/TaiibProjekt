﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektTaiib.DAL.Repositories;

#nullable disable

namespace ProjektTaiib.DAL.Migrations
{
    [DbContext(typeof(ProjektTaiibDbContext))]
    [Migration("20230328195711_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EventSponsor", b =>
                {
                    b.Property<int>("EventsId_event")
                        .HasColumnType("int");

                    b.Property<int>("SponsorsId_sponsor")
                        .HasColumnType("int");

                    b.HasKey("EventsId_event", "SponsorsId_sponsor");

                    b.HasIndex("SponsorsId_sponsor");

                    b.ToTable("EventSponsor");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.DetailedInformation", b =>
                {
                    b.Property<int>("Id_information")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_information"));

                    b.Property<string>("Additional_information")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("House_number")
                        .HasColumnType("int");

                    b.Property<int?>("Local_number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Payment")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip_code")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id_information");

                    b.HasIndex("UserId");

                    b.ToTable("DetailedInformation");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.Event", b =>
                {
                    b.Property<int>("Id_event")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_event"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Event_name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_event");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.Sponsor", b =>
                {
                    b.Property<int>("Id_sponsor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_sponsor"));

                    b.Property<string>("Sponsor_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id_sponsor");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.Ticket", b =>
                {
                    b.Property<int>("Id_ticket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_ticket"));

                    b.Property<int>("Id_event")
                        .HasColumnType("int");

                    b.Property<bool?>("Premium")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId_user")
                        .HasColumnType("int");

                    b.HasKey("Id_ticket");

                    b.HasIndex("Id_event");

                    b.HasIndex("UserId_user");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.User", b =>
                {
                    b.Property<int>("Id_user")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_user"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Moderator")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id_user");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EventSponsor", b =>
                {
                    b.HasOne("ProjektTaiib.DAL.Encje.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId_event")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektTaiib.DAL.Encje.Sponsor", null)
                        .WithMany()
                        .HasForeignKey("SponsorsId_sponsor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.DetailedInformation", b =>
                {
                    b.HasOne("ProjektTaiib.DAL.Encje.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.Ticket", b =>
                {
                    b.HasOne("ProjektTaiib.DAL.Encje.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("Id_event")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjektTaiib.DAL.Encje.User", null)
                        .WithMany("Tickets")
                        .HasForeignKey("UserId_user");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("ProjektTaiib.DAL.Encje.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
