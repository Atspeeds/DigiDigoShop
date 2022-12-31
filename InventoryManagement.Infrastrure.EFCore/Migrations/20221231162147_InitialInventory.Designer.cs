﻿// <auto-generated />
using System;
using InventoryManagement.Infrastrure.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InventoryManagement.Infrastrure.EFCore.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20221231162147_InitialInventory")]
    partial class InitialInventory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("InventoryManagement.Domain.WareHouseAgg.WareHouse", b =>
                {
                    b.Property<long>("KeyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("KeyId");

                    b.ToTable("WareHouses");
                });

            modelBuilder.Entity("InventoryManagement.Domain.WareHouseAgg.WareHouse", b =>
                {
                    b.OwnsMany("InventoryManagement.Domain.WareHouseAgg.WareHouseOpration", "Oprations", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint")
                                .UseIdentityColumn();

                            b1.Property<long>("Characteristic")
                                .HasColumnType("bigint");

                            b1.Property<long>("Count")
                                .HasColumnType("bigint");

                            b1.Property<long>("CurrentCount")
                                .HasColumnType("bigint");

                            b1.Property<string>("Description")
                                .HasMaxLength(1000)
                                .HasColumnType("nvarchar(1000)");

                            b1.Property<DateTime>("OprationDate")
                                .HasColumnType("datetime2");

                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<bool>("TypeOperation")
                                .HasColumnType("bit");

                            b1.Property<long>("WareHouseID")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("WareHouseID");

                            b1.ToTable("Oprations");

                            b1.WithOwner("WareHouse")
                                .HasForeignKey("WareHouseID");

                            b1.Navigation("WareHouse");
                        });

                    b.Navigation("Oprations");
                });
#pragma warning restore 612, 618
        }
    }
}