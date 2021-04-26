﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(PizzaBoxContext))]
    [Migration("20210426032130_1121")]
    partial class _1121
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CrustEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SizeEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SizeEntityId1")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("CrustEntityId");

                    b.HasIndex("SizeEntityId");

                    b.HasIndex("SizeEntityId1");

                    b.ToTable("Pizzas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("APizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Stores");

                    b.HasDiscriminator<string>("Discriminator").HasValue("AStore");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Crust", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.ToTable("Crust");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Customer", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CustomerEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("PizzaEntityId")
                        .HasColumnType("bigint");

                    b.Property<long?>("StoreEntityId")
                        .HasColumnType("bigint");

                    b.HasKey("EntityId");

                    b.HasIndex("CustomerEntityId");

                    b.HasIndex("PizzaEntityId");

                    b.HasIndex("StoreEntityId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Size", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.Property<long>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("APizzaEntityId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("EntityId");

                    b.HasIndex("APizzaEntityId");

                    b.ToTable("Topping");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Mozzarella",
                            Price = 0m
                        },
                        new
                        {
                            EntityId = 2L,
                            Name = "Marinara",
                            Price = 0m
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Pepperoni",
                            Price = 0m
                        },
                        new
                        {
                            EntityId = 4L,
                            Name = "Mushrooms",
                            Price = 0m
                        },
                        new
                        {
                            EntityId = 5L,
                            Name = "Onion",
                            Price = 0m
                        },
                        new
                        {
                            EntityId = 6L,
                            Name = "Sausage",
                            Price = 0m
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizzas.CustomPizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("CustomPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizzas.MeatPizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("MeatPizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Pizzas.VeggiePizza", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.APizza");

                    b.HasDiscriminator().HasValue("VeggiePizza");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Stores.ChicagoStore", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("ChicagoStore");

                    b.HasData(
                        new
                        {
                            EntityId = 1L,
                            Name = "Greek's Pizzeria"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Stores.NewYorkStore", b =>
                {
                    b.HasBaseType("PizzaBox.Domain.Abstracts.AStore");

                    b.HasDiscriminator().HasValue("NewYorkStore");

                    b.HasData(
                        new
                        {
                            EntityId = 2L,
                            Name = "Pizza King"
                        },
                        new
                        {
                            EntityId = 3L,
                            Name = "Al's Pizza"
                        });
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustEntityId");

                    b.HasOne("PizzaBox.Domain.Models.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeEntityId");

                    b.HasOne("PizzaBox.Domain.Models.Size", null)
                        .WithMany()
                        .HasForeignKey("SizeEntityId1");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Order", b =>
                {
                    b.HasOne("PizzaBox.Domain.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerEntityId");

                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaEntityId");

                    b.HasOne("PizzaBox.Domain.Abstracts.AStore", "Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreEntityId");

                    b.Navigation("Customer");

                    b.Navigation("Pizza");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Domain.Models.Topping", b =>
                {
                    b.HasOne("PizzaBox.Domain.Abstracts.APizza", null)
                        .WithMany("Toppings")
                        .HasForeignKey("APizzaEntityId");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.APizza", b =>
                {
                    b.Navigation("Toppings");
                });

            modelBuilder.Entity("PizzaBox.Domain.Abstracts.AStore", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
