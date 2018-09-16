﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pickles.Data;

namespace Pickles.Data.Migrations
{
    [DbContext(typeof(PickleContext))]
    [Migration("20180916193850_AddNoneTypeOption")]
    partial class AddNoneTypeOption
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Pickles.Data.Models.PickleType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PickleTypes");

                    b.HasData(
                        new { Id = 1, Name = "Dill" },
                        new { Id = 2, Name = "Sweet" },
                        new { Id = 3, Name = "Bread and Butter" },
                        new { Id = 4, Name = "Sour" },
                        new { Id = 5, Name = "Other" },
                        new { Id = 6, Name = "None" }
                    );
                });

            modelBuilder.Entity("Pickles.Data.Models.Vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PickleTypeId");

                    b.Property<int>("VoterId");

                    b.HasKey("Id");

                    b.HasIndex("PickleTypeId");

                    b.HasIndex("VoterId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("Pickles.Data.Models.Voter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("IpAddress");

                    b.Property<string>("LastName");

                    b.Property<double?>("Latitute");

                    b.Property<double?>("Longitude");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("Pickles.Data.Models.Vote", b =>
                {
                    b.HasOne("Pickles.Data.Models.PickleType", "Pickle")
                        .WithMany("Votes")
                        .HasForeignKey("PickleTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Pickles.Data.Models.Voter", "Voter")
                        .WithMany("Votes")
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}