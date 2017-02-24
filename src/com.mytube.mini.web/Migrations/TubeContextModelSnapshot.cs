using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using com.mytube.mini.web.Models;

namespace com.mytube.mini.web.Migrations
{
    [DbContext(typeof(TubeContext))]
    partial class TubeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("com.mytube.mini.web.Models.Ratings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Comment");

                    b.Property<int>("Rating");

                    b.Property<int>("UserId");

                    b.Property<int>("VideoId");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("com.mytube.mini.web.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FullName");

                    b.Property<string>("Login");

                    b.Property<string>("Password");

                    b.Property<DateTime>("RegistrationDate");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("com.mytube.mini.web.Models.Videos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Path");

                    b.Property<string>("ScreenPath");

                    b.Property<int>("UserId");

                    b.Property<string>("VideoName");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("com.mytube.mini.web.Models.Ratings", b =>
                {
                    b.HasOne("com.mytube.mini.web.Models.Videos", "Video")
                        .WithMany("Ratings")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("com.mytube.mini.web.Models.Videos", b =>
                {
                    b.HasOne("com.mytube.mini.web.Models.Users", "User")
                        .WithMany("Videos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
