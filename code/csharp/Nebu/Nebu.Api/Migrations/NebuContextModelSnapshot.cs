﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nebu.Api.Ef;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Nebu.Api.Migrations
{
    [DbContext(typeof(NebuContext))]
    partial class NebuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Nebu.Api.Ef.EfBlob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("BucketId")
                        .HasColumnType("uuid");

                    b.Property<string>("Filename")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("Key")
                        .HasColumnType("uuid");

                    b.Property<long>("SizeBytes")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BucketId", "Key")
                        .IsUnique();

                    b.ToTable("Blobs");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfBucket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Uri")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Buckets");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ApiKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ApiKey")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfBlob", b =>
                {
                    b.HasOne("Nebu.Api.Ef.EfBucket", "Bucket")
                        .WithMany("Blobs")
                        .HasForeignKey("BucketId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Bucket");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfBucket", b =>
                {
                    b.HasOne("Nebu.Api.Ef.EfUser", "User")
                        .WithMany("Buckets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfBucket", b =>
                {
                    b.Navigation("Blobs");
                });

            modelBuilder.Entity("Nebu.Api.Ef.EfUser", b =>
                {
                    b.Navigation("Buckets");
                });
#pragma warning restore 612, 618
        }
    }
}
