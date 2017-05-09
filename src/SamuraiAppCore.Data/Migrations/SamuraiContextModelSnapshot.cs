using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SamuraiAppCore.Data;

namespace SamuraiAppCore.Data.Migrations
{
    [DbContext(typeof(SamuraiContext))]
    partial class SamuraiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Battle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Name");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Camp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("Length");

                    b.Property<int?>("LocationId");

                    b.Property<string>("Moniker");

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Camps");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("Address3");

                    b.Property<string>("CityTown");

                    b.Property<string>("Country");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.HasKey("Id");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Quote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SamuraiId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("SamuraiId");

                    b.ToTable("Quotes");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Samurai", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BattleId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BattleId");

                    b.ToTable("Samurais");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bio");

                    b.Property<int?>("CampId");

                    b.Property<string>("CompanyName");

                    b.Property<string>("GitHubName");

                    b.Property<string>("HeadShotUrl");

                    b.Property<string>("Name");

                    b.Property<string>("PhoneNumber");

                    b.Property<byte[]>("RowVersion");

                    b.Property<string>("TwitterName");

                    b.Property<string>("WebsiteUrl");

                    b.HasKey("Id");

                    b.HasIndex("CampId");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Talk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abstract");

                    b.Property<string>("Category");

                    b.Property<string>("Level");

                    b.Property<string>("Prerequisites");

                    b.Property<string>("Room");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int?>("SpeakerId");

                    b.Property<DateTime>("StartingTime");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Talks");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Camp", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Model.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Quote", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Model.Samurai", "Samurai")
                        .WithMany("Quotes")
                        .HasForeignKey("SamuraiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Samurai", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Model.Battle")
                        .WithMany("Samurais")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Speaker", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Model.Camp", "Camp")
                        .WithMany("Speakers")
                        .HasForeignKey("CampId");
                });

            modelBuilder.Entity("SamuraiAppCore.Domain.Model.Talk", b =>
                {
                    b.HasOne("SamuraiAppCore.Domain.Model.Speaker", "Speaker")
                        .WithMany("Talks")
                        .HasForeignKey("SpeakerId");
                });
        }
    }
}
