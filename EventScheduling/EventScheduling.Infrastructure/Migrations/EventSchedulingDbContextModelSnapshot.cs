﻿// <auto-generated />
using System;
using EventScheduling.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EventScheduling.Infrastructure.Migrations
{
    [DbContext(typeof(EventSchedulingDbContext))]
    partial class EventSchedulingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("EventScheduling.Domain.City.City", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"),
                            CountryId = new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"),
                            Name = "Medellin"
                        },
                        new
                        {
                            Id = new Guid("9b862593-628a-4bc1-8cc4-038e01f34241"),
                            CountryId = new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"),
                            Name = "Bogota"
                        },
                        new
                        {
                            Id = new Guid("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a"),
                            CountryId = new Guid("e0007308-e1e3-4892-a5a7-883c02c6de22"),
                            Name = "Lima"
                        },
                        new
                        {
                            Id = new Guid("102077ed-f0de-442c-8d97-fbb7dfd96d08"),
                            CountryId = new Guid("c39c3b71-78e9-4dcd-bbbd-35ac159f984b"),
                            Name = "Montevideo"
                        },
                        new
                        {
                            Id = new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"),
                            CountryId = new Guid("3eb63894-c376-4eea-923a-ac1f3bfc6235"),
                            Name = "Asuncion"
                        });
                });

            modelBuilder.Entity("EventScheduling.Domain.Country.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("8217f508-c17d-431e-9cf0-05ca8984971b"),
                            Name = "Colombia"
                        },
                        new
                        {
                            Id = new Guid("e0007308-e1e3-4892-a5a7-883c02c6de22"),
                            Name = "Peru"
                        },
                        new
                        {
                            Id = new Guid("c39c3b71-78e9-4dcd-bbbd-35ac159f984b"),
                            Name = "Uruguay"
                        },
                        new
                        {
                            Id = new Guid("3eb63894-c376-4eea-923a-ac1f3bfc6235"),
                            Name = "Paraguay"
                        });
                });

            modelBuilder.Entity("EventScheduling.Domain.Team.Team", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Team", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"),
                            Name = "team_one"
                        },
                        new
                        {
                            Id = new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"),
                            Name = "team_two"
                        });
                });

            modelBuilder.Entity("EventScheduling.Domain.User.User", b =>
                {
                    b.Property<string>("Email")
                        .HasMaxLength(254)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CityId")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<Guid?>("TeamId")
                        .HasColumnType("TEXT");

                    b.HasKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TeamId");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Email = "developer_one@yopmail.com",
                            CityId = new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"),
                            Mobile = "111 1111111",
                            Name = "developer_one",
                            Role = 1
                        },
                        new
                        {
                            Email = "developer_two@yopmail.com",
                            CityId = new Guid("5ebf0600-c390-4b16-945d-eb0e734cf51c"),
                            Mobile = "222 2222222",
                            Name = "developer_two",
                            Role = 1
                        },
                        new
                        {
                            Email = "developer_three@yopmail.com",
                            CityId = new Guid("9b862593-628a-4bc1-8cc4-038e01f34241"),
                            Mobile = "333 3333333",
                            Name = "developer_three",
                            Role = 1
                        },
                        new
                        {
                            Email = "developer_four@yopmail.com",
                            CityId = new Guid("386a04f3-e4c4-4922-9e79-e75ac0fa3a6a"),
                            Mobile = "444 4444444",
                            Name = "developer_four",
                            Role = 1
                        },
                        new
                        {
                            Email = "developer_five@yopmail.com",
                            CityId = new Guid("102077ed-f0de-442c-8d97-fbb7dfd96d08"),
                            Mobile = "555 5555555",
                            Name = "developer_five",
                            Role = 1
                        },
                        new
                        {
                            Email = "developer_six@yopmail.com",
                            CityId = new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"),
                            Mobile = "666 6666666",
                            Name = "developer_six",
                            Role = 1
                        },
                        new
                        {
                            Email = "qa_one@yopmail.com",
                            CityId = new Guid("0de67652-5cc0-42ca-8005-aa41b3a41802"),
                            Mobile = "777 7777777",
                            Name = "qa_one",
                            Role = 2
                        });
                });

            modelBuilder.Entity("EventScheduling.Domain.UserTeam.UserTeam", b =>
                {
                    b.Property<Guid>("TeamId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId", "Email");

                    b.ToTable("UserTeam", (string)null);

                    b.HasData(
                        new
                        {
                            TeamId = new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"),
                            Email = "developer_one@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"),
                            Email = "developer_two@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"),
                            Email = "developer_four@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("fc74ff91-3de6-4267-bce9-f390d3b0ca7c"),
                            Email = "qa_one@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"),
                            Email = "developer_three@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"),
                            Email = "developer_five@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"),
                            Email = "developer_six@yopmail.com"
                        },
                        new
                        {
                            TeamId = new Guid("7c9c3d92-40c1-4ac3-95dc-fd2916e1beda"),
                            Email = "qa_one@yopmail.com"
                        });
                });

            modelBuilder.Entity("EventScheduling.Domain.City.City", b =>
                {
                    b.HasOne("EventScheduling.Domain.Country.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventScheduling.Domain.User.User", b =>
                {
                    b.HasOne("EventScheduling.Domain.Team.Team", null)
                        .WithMany("Users")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("EventScheduling.Domain.Country.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("EventScheduling.Domain.Team.Team", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
