﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using coreUserPanel.Models;

namespace coreUserPanel.Migrations
{
    [DbContext(typeof(ProjectTestDataContext))]
    [Migration("20190416045623_stripesupdates5623")]
    partial class stripesupdates5623
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("coreUserPanel.Models.Auditoriums", b =>
                {
                    b.Property<int>("AuditoriumId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuditoriumDescription");

                    b.Property<string>("AuditoriumName");

                    b.Property<int>("MultiplexId");

                    b.Property<int>("Seats");

                    b.Property<string>("Time1");

                    b.Property<string>("Time2");

                    b.Property<string>("Time3");

                    b.HasKey("AuditoriumId");

                    b.HasIndex("MultiplexId");

                    b.ToTable("Auditoriums");
                });

            modelBuilder.Entity("coreUserPanel.Models.BookingDetails", b =>
                {
                    b.Property<int>("BookingId");

                    b.Property<int>("MovieId");

                    b.Property<int>("QtySeats");

                    b.HasKey("BookingId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("coreUserPanel.Models.Bookings", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudiName");

                    b.Property<double>("BookingAmount");

                    b.Property<DateTime>("BookingDate");

                    b.Property<string>("ShowTiming");

                    b.Property<int>("UserDetailId");

                    b.HasKey("BookingId");

                    b.HasIndex("UserDetailId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("coreUserPanel.Models.Locations", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationImage");

                    b.Property<string>("LocationName");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("coreUserPanel.Models.MovieDetails", b =>
                {
                    b.Property<int>("MovieDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Casting");

                    b.Property<string>("Director");

                    b.Property<string>("MovieDuration");

                    b.Property<int>("MovieId");

                    b.Property<string>("MovieImage");

                    b.Property<string>("MovieType");

                    b.Property<string>("Producer");

                    b.HasKey("MovieDetailId");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("MovieDetails");
                });

            modelBuilder.Entity("coreUserPanel.Models.Movies", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MovieDescription");

                    b.Property<string>("MovieDuration");

                    b.Property<string>("MovieImage");

                    b.Property<string>("MovieName");

                    b.Property<double>("MoviePrice");

                    b.Property<int>("MultiplexId");

                    b.HasKey("MovieId");

                    b.HasIndex("MultiplexId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("coreUserPanel.Models.Multiplexes", b =>
                {
                    b.Property<int>("MultiplexId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LocationId");

                    b.Property<string>("MultiplexDescription");

                    b.Property<string>("MultiplexImage");

                    b.Property<string>("MultiplexName");

                    b.HasKey("MultiplexId");

                    b.HasIndex("LocationId");

                    b.ToTable("Multiplexes");
                });

            modelBuilder.Entity("coreUserPanel.Models.Payments", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnName("amount");

                    b.Property<int>("BookingId");

                    b.Property<int>("Card");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("StripePaymentId");

                    b.Property<string>("StripeSettingsId");

                    b.Property<int>("UserDetailId");

                    b.HasKey("PaymentId");

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("coreUserPanel.Models.Reviews", b =>
                {
                    b.Property<int>("UserDetailId")
                        .HasColumnName("UserDetailID");

                    b.Property<int>("MovieId");

                    b.Property<string>("Comment");

                    b.HasKey("UserDetailId", "MovieId");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.HasIndex("UserDetailId")
                        .IsUnique();

                    b.HasIndex("MovieId", "UserDetailId")
                        .IsUnique()
                        .HasName("AK_Reviews_MovieId_UserDetailID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("coreUserPanel.Models.UserDetails", b =>
                {
                    b.Property<int>("UserDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("UserDetailID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactNo");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("UserDetailId");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("coreUserPanel.Models.Auditoriums", b =>
                {
                    b.HasOne("coreUserPanel.Models.Multiplexes", "Multiplex")
                        .WithMany("Auditoriums")
                        .HasForeignKey("MultiplexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.BookingDetails", b =>
                {
                    b.HasOne("coreUserPanel.Models.Bookings", "Booking")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreUserPanel.Models.Movies", "Movie")
                        .WithMany("BookingDetails")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.Bookings", b =>
                {
                    b.HasOne("coreUserPanel.Models.UserDetails", "UserDetail")
                        .WithMany("Bookings")
                        .HasForeignKey("UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.MovieDetails", b =>
                {
                    b.HasOne("coreUserPanel.Models.Movies", "Movie")
                        .WithOne("MovieDetails")
                        .HasForeignKey("coreUserPanel.Models.MovieDetails", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.Movies", b =>
                {
                    b.HasOne("coreUserPanel.Models.Multiplexes", "Multiplex")
                        .WithMany("Movies")
                        .HasForeignKey("MultiplexId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.Multiplexes", b =>
                {
                    b.HasOne("coreUserPanel.Models.Locations", "Location")
                        .WithMany("Multiplexes")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.Payments", b =>
                {
                    b.HasOne("coreUserPanel.Models.Bookings", "Booking")
                        .WithOne("Payments")
                        .HasForeignKey("coreUserPanel.Models.Payments", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("coreUserPanel.Models.Reviews", b =>
                {
                    b.HasOne("coreUserPanel.Models.Movies", "Movie")
                        .WithOne("Reviews")
                        .HasForeignKey("coreUserPanel.Models.Reviews", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("coreUserPanel.Models.UserDetails", "UserDetail")
                        .WithOne("Reviews")
                        .HasForeignKey("coreUserPanel.Models.Reviews", "UserDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
