﻿// <auto-generated />
using DND.BL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DND.BL.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20240109074753_InitialMigrations")]
    partial class InitialMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DND.Domain.Entities.Entity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ArmorClass")
                        .HasColumnType("integer");

                    b.Property<int>("AttackModifier")
                        .HasColumnType("integer");

                    b.Property<int>("AttackPerRound")
                        .HasColumnType("integer");

                    b.Property<int>("DamageDiceThrowsNumber")
                        .HasColumnType("integer");

                    b.Property<int>("DamageModifier")
                        .HasColumnType("integer");

                    b.Property<int>("DamageWithDice")
                        .HasColumnType("integer");

                    b.Property<int>("Health")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Entities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArmorClass = 10,
                            AttackModifier = 3,
                            AttackPerRound = 1,
                            DamageDiceThrowsNumber = 6,
                            DamageModifier = 6,
                            DamageWithDice = 6,
                            Health = 50,
                            Name = "Enchanter"
                        },
                        new
                        {
                            Id = 2,
                            ArmorClass = 12,
                            AttackModifier = 2,
                            AttackPerRound = 4,
                            DamageDiceThrowsNumber = 1,
                            DamageModifier = 2,
                            DamageWithDice = 8,
                            Health = 24,
                            Name = "Swarm of ravens"
                        },
                        new
                        {
                            Id = 3,
                            ArmorClass = 12,
                            AttackModifier = 2,
                            AttackPerRound = 1,
                            DamageDiceThrowsNumber = 8,
                            DamageModifier = 12,
                            DamageWithDice = 7,
                            Health = 60,
                            Name = "Enormous Tentacle"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}